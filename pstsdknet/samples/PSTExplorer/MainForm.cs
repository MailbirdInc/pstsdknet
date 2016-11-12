using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using PropertyInfoDataProvider;
using pstsdk.definition.ltp;
using pstsdk.definition.pst;
using pstsdk.definition.pst.folder;
using pstsdk.definition.pst.message;
using pstsdk.definition.util.primitives;
using pstsdk.layer.ltp.nameid;
using pstsdk.layer.pst;
using System.Reflection;

namespace PSTExplorer
{
    public partial class MainForm : Form
    {
        private IPst _pst;
        private PropertiesForm _propertiesForm;
        private Stream _htmlBodyStream;

        public MainForm()
        {
            InitializeComponent();
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
        }

        System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            if (args.Name.StartsWith("pstsdk.mcpp", StringComparison.OrdinalIgnoreCase))
            {
                string fileName = Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location),
                string.Format("pstsdk.mcpp.{0}.dll", (IntPtr.Size == 4) ? "x86" : "x64"));

                return Assembly.LoadFile(fileName);
            }
            return null;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog()
                          {
                              Filter = @"PST/OST Files|*.pst;*.ost",
                              CheckFileExists = true
                          };
            
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (_pst != null)
                    {
                        _pst.Dispose();
                        GC.Collect();
                    }

                    _pst = new Pst(ofd.FileName);
                }
                catch (Exception ex)
                {
                    var sb = new StringBuilder();

                    sb.AppendLine(ex.Message);
                    sb.AppendLine(ex.StackTrace);

                    var innerExcep = ex.InnerException;
                    while(innerExcep != null)
                    {
                        sb.AppendLine(innerExcep.Message);
                        sb.AppendLine(innerExcep.StackTrace);
                        innerExcep = innerExcep.InnerException;
                    }

                    File.WriteAllText(Guid.NewGuid() + ".txt", sb.ToString());

                    MessageBox.Show("There was an error opening the file.  It may be corrupt.");
                    return;
                }
                // clear form..
                foldersTreeView.Nodes.Clear();
                messagesListBox.Items.Clear();
                attachmentListBox.Items.Clear();
                recipientsListBox.Items.Clear();

                webBrowser1.DocumentText = string.Empty;
                messageBodyTextBox.Text = string.Empty;
                recipientCountLabel.Text = "Recipients";
                attachCountLabel.Text = "Attachments";
                messagesHeaderLabel.Text = "Messages";
                
                TreeNode rootNode = GetAllFolders(_pst.OpenRootFolder());
                foreach(TreeNode node in rootNode.Nodes)
                {
                    foldersTreeView.Nodes.Add(node);
                }
            }
        }

        private static TreeNode GetAllFolders(IFolder folder)
        {
            var parent = new TreeNode();
            
            parent.Name = folder.Node.Value.ToString();
            parent.Text = folder.Name + " (" + folder.MessageCount + ")";

            foreach (IFolder f in folder.SubFolders)
            {
                TreeNode child = GetAllFolders(f);
                parent.Nodes.Add(child);
            }
            
            return parent;
        }

        private bool _isLoading = false;
        private bool _shouldCancel = false;
        private void foldersTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if(String.IsNullOrEmpty(e.Node.Name))
                return;

            if (_isLoading)
            {
                _shouldCancel = true;
                this.foldersTreeView.SelectedNode = null;
                return;
            }

            try
            {
                _isLoading = true;
                _shouldCancel = false;

                messagesListBox.SuspendLayout();
                Cursor = Cursors.WaitCursor;
                
                var nid = new NodeID();
                nid.Value = Convert.ToUInt32(e.Node.Name);

                IFolder f = _pst.OpenFolder(nid);
                messagesListBox.Items.Clear();

                int messageCount = f.MessageCount;
                int counter = 0;
                int totalCounter = 0;
                messagesHeaderLabel.Text = "Messages (" + totalCounter  + "/" + messageCount + ")";

                if (messageCount < 1) return;
                
                foreach (IMessage message in f.Messages)
                {
                    string subject = string.Empty;

                    if (message.HasSubject)
                    {
                        try
                        {
                            subject = message.Subject;
                        }
                        catch
                        {
                        subject = "<error retrieving subject>";
                        }
                    }

                    messagesListBox.Items.Add(
                        new ListViewItem(
                            new[] { message.Node.Value.ToString(), subject, message.Size.ToString() }, string.Empty) { Tag = message.Node.Value });

                    if (_shouldCancel)
                    {
                        messagesListBox.Items.Clear();
                        break;
                    }
                    totalCounter++;
                    counter++;
                    if (counter == 50)
                    {
                        messagesListBox.ResumeLayout();
                        messagesHeaderLabel.Text = "Messages (" + totalCounter + "/" + messageCount + ")";
                        Application.DoEvents();
                        counter = 0;
                        messagesListBox.SuspendLayout();
                    }
                }
                messagesHeaderLabel.Text = "Messages (" + totalCounter + "/" + messageCount + ")";
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error completing requested action.\r\n\r\n" + ex.Message + "\r\n" + ex.StackTrace);
            }
            finally
            {
                Cursor = Cursors.Default;
                messagesListBox.ResumeLayout();
                _isLoading = false;
            }

        }

        private void messagesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (messagesListBox.SelectedIndices.Count < 1) return;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                var nodeId = new NodeID { Value = (uint)messagesListBox.SelectedItems[0].Tag };
                IMessage message = _pst.OpenMessage(nodeId);

                if (message.HasHtmlBody)
                {
                    var htmlBody = message.HtmlBody;

                    webBrowser1.Visible = true;
                    messageBodyTextBox.Visible = false;

                    // reset webBrowser control... 
                    // (hackhackhack -- this is a silly workaround for framework bug) -th
                    if (webBrowser1.Document != null)
                        webBrowser1.Document.OpenNew(true);
                    else
                        webBrowser1.Navigate("about:blank");

                    _htmlBodyStream = message.HtmlBodyStream; //new MemoryStream(htmlBody);
                    //webBrowser1.DocumentStream = _htmlBodyStream;


                    webBrowser1.DocumentText = message.HtmlBodyString;

                }
                else if (message.HasBody)
                {
                    messageBodyTextBox.Visible = true;
                    webBrowser1.Visible = false;
                    messageBodyTextBox.Text = message.Body;
                }
                else
                {
                    messageBodyTextBox.Visible = true;
                    webBrowser1.Visible = false;
                    messageBodyTextBox.Text = "";
                }

                var uid = message.Uid;

                attachCountLabel.Text = "Attachments (" + message.AttachmentCount + ")";
                recipientCountLabel.Text = "Recipients (" + message.RecipientCount + ")";
                
                messageBodyLabel.Text = "Message Body (" + 
                    (message.HasHtmlBody 
                    ? "text/html, " + message.HtmlBodySize
                    : message.HasBody 
                        ? "text/plain, " + message.BodySize.ToString() 
                        : "n/a") + " bytes)";

                
                recipientsListBox.Items.Clear();
                if (message.RecipientCount > 0)
                {
                    foreach (IRecipient recipient in message.Recipients)
                    {
                    recipientsListBox.Items.Add(
                        (recipient.HasAccountName ? recipient.AccountName : recipient.Name) + 
                        (recipient.HasEmailAddress ? " <" + recipient.EmailAddress + ">" :""));
                        Application.DoEvents();
                    }
                }

                attachmentListBox.Items.Clear();
                if (message.AttachmentCount > 0)
                {
                    foreach (IAttachment attachment in message.Attachments)
                    {
                        string filename;
                        try
                        {
                            filename = attachment.Filename;
                        }
                        catch
                        {
                            filename = "<error retrieving attachment name>";
                        }
                        attachmentListBox.Items.Add(filename);
                        Application.DoEvents();
                    }
                }
                        }
            catch(Exception ex)
            {
                MessageBox.Show("Error completing requested action.\r\n\r\n" + ex.Message + "\r\n" + ex.StackTrace);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            if(attachmentListBox.SelectedItem == null)
            {
                MessageBox.Show("No item selected!");
                return;
            }

            var nodeId = new NodeID { Value = (uint)messagesListBox.SelectedItems[0].Tag };
            var attachmentName = attachmentListBox.SelectedItem as String ?? string.Empty;

            char[] invalidChars = System.IO.Path.GetInvalidFileNameChars();
            string invalidString = Regex.Escape(new string(invalidChars));
            var validAttachmentName = Regex.Replace(attachmentName, "[" + invalidString + "]", "");

            if (null != attachmentName)
            {
                string fileFilter = Path.GetExtension(attachmentName);

                var sfd = new SaveFileDialog();
                sfd.Filter = "*" + fileFilter + "|*" + fileFilter;
                sfd.FileName = validAttachmentName;

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    
                    IMessage message = _pst.OpenMessage(nodeId);

                    foreach (IAttachment attachment in message.Attachments)
                    {
                        if (attachment.Filename == attachmentName)
                        {
                            try
                            {
                                if (attachment.IsMessage)
                                {
                                    var writer = new MimeMessageWriter();
                                    var embeddedMessage = attachment.OpenAsMessage();
                                    using (var fs = sfd.OpenFile()) writer.Write(embeddedMessage, fs);
                                }
                                else
                                {
                                    using (var bw = new BinaryWriter(sfd.OpenFile()))
                                    {
                                        bw.Write(attachment.Bytes);
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error completing requested action.\r\n\r\n" + ex.Message + "\r\n" + ex.StackTrace);
                            }

                            break;
                        }
                    }
                }
            }
            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _propertiesForm = new PropertiesForm();
        }

        private void messageBodyTextBox_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }

        private void contextMenu_Opening(object sender, CancelEventArgs e)
        {

        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (messagesListBox.SelectedIndices.Count < 1) return;
            
            var nodeId = new NodeID { Value = (uint)messagesListBox.SelectedItems[0].Tag };

            var emailSubject = messagesListBox.SelectedItems[0].SubItems[1].Text;

            char[] invalidChars = System.IO.Path.GetInvalidFileNameChars();
            string invalidString = Regex.Escape(new string(invalidChars));
            var validOutputFilename = Regex.Replace(emailSubject, "[" + invalidString + "]", "");
            validOutputFilename =
                string.IsNullOrEmpty(validOutputFilename) ?
                "Untitled Message.eml" : validOutputFilename + ".eml";

            string fileFilter = Path.GetExtension(validOutputFilename);

            var sfd = new SaveFileDialog();
            sfd.Filter = "*" + fileFilter + "|*" + fileFilter;
            sfd.FileName = validOutputFilename;

            if (sfd.ShowDialog() == DialogResult.OK)
            {

                try
                {

                    IMessage message = _pst.OpenMessage(nodeId);

                    var writer = new MimeMessageWriter();
                    using (var fs = sfd.OpenFile()) writer.Write(message, fs);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error completing requested action.\r\n\r\n" + ex.Message + "\r\n" + ex.StackTrace);
                }
            }
        }

        private void emailItemContextMenu_Opening(object sender, CancelEventArgs e)
        {
            if(emailItemContextMenu.SourceControl == messagesListBox)
            {
                saveAsToolStripMenuItem.Visible = true;
            }
            else
            {
                saveAsToolStripMenuItem.Visible = false;
            }
        }

        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (contextMenu.SourceControl == foldersTreeView)
            {
                try
                {
                    TreeNode tn = foldersTreeView.SelectedNode;

                    if (null == tn || String.IsNullOrEmpty(tn.Name))
                        return;

                    var nid = new NodeID();
                    nid.Value = Convert.ToUInt32(tn.Name);

                    IFolder f = _pst.OpenFolder(nid);
                    _propertiesForm.PopulatePropertyList(f, MessageClass.Common);

                    _propertiesForm.Show();
                    _propertiesForm.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Operation failed with exception: " + ex.Message);
                }
            }
            else if (emailItemContextMenu.SourceControl == attachmentListBox)
            {
                try
                {
                    var node = new NodeID {Value = (uint) messagesListBox.SelectedItems[0].Tag};
                    var attachmentName = attachmentListBox.SelectedItem as String ?? string.Empty;

                    IMessage msg = _pst.OpenMessage(node);
                    foreach (IAttachment attachment in msg.Attachments)
                    {
                        if (attachment.Filename == attachmentName)
                        {
                            _propertiesForm.PopulatePropertyList(attachment, MessageClass.Common);
                            _propertiesForm.Show();
                            _propertiesForm.Focus();
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Operation failed with exception: " + ex.Message);
                }
            }
            else if (emailItemContextMenu.SourceControl == messagesListBox)
            {
                if (messagesListBox.SelectedIndices.Count < 1) return;

                try
                {
                    var nodeId = new NodeID {Value = (uint) messagesListBox.SelectedItems[0].Tag};
                    IMessage message = _pst.OpenMessage(nodeId);

                    _propertiesForm.PopulatePropertyList(message, MessageClass.Email);
                    _propertiesForm.Show();
                    _propertiesForm.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Operation failed with exception: " + ex.Message);
                }
            }
            else if (contextMenu.SourceControl == recipientsListBox)
            {
                if (recipientsListBox.SelectedIndices.Count < 1) return;

                var nodeID = new NodeID {Value = (uint) messagesListBox.SelectedItems[0].Tag};
                var recipientName = recipientsListBox.SelectedItem as String ?? String.Empty;

                IMessage message = _pst.OpenMessage(nodeID);
                foreach (IRecipient recipient in message.Recipients)
                {
                    //if (recipient.Name == recipientName)
                    //{
                        _propertiesForm.PopulatePropertyList(recipient, MessageClass.Contact);
                        _propertiesForm.Show();
                        _propertiesForm.Focus();
                        break;
                    //}
                }
            }
        }

        private void OpenProperties(NodeID rootNode)
        {
            try
            {
                var obj = _pst.DatabaseAccessor.GetPropertyObjectByNodeId(rootNode);
                _propertiesForm.PopulatePropertyList(obj, MessageClass.Common);
                _propertiesForm.Show();
                _propertiesForm.Focus();
            }
            catch (Exception)
            {
                //SUPPRESS
            }
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (_htmlBodyStream != null && _htmlBodyStream.CanRead)
                _htmlBodyStream.Close();
        }

        private void messageStoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenProperties(0x21);
        }

        private void rootMailboxFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var propObject = new NameIdMap(_pst.DatabaseAccessor);
            var namedPropertiesForm = new NamedPropertiesForm(propObject);
            namedPropertiesForm.ShowDialog(this);
        }

        private void rootFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenProperties(0x122);
        }
    }
}
