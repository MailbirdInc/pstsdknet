namespace PSTExplorer
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.propertiesToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.messageStoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rootMailboxFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rootFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.messagesHeaderLabel = new System.Windows.Forms.Label();
            this.messageBodyLabel = new System.Windows.Forms.Label();
            this.attachmentListBox = new System.Windows.Forms.ListBox();
            this.emailItemContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.propertiesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportButton = new System.Windows.Forms.Button();
            this.messageBodyTextBox = new System.Windows.Forms.RichTextBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.recipientsListBox = new System.Windows.Forms.ListBox();
            this.recipientCountLabel = new System.Windows.Forms.Label();
            this.attachCountLabel = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.foldersTreeView = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.messagesListBox = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.mainMenu.SuspendLayout();
            this.emailItemContextMenu.SuspendLayout();
            this.contextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Dock = System.Windows.Forms.DockStyle.None;
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.propertiesToolStripMenuItem2});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(961, 24);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(100, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // propertiesToolStripMenuItem2
            // 
            this.propertiesToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.messageStoreToolStripMenuItem,
            this.rootMailboxFolderToolStripMenuItem,
            this.rootFolderToolStripMenuItem});
            this.propertiesToolStripMenuItem2.Name = "propertiesToolStripMenuItem2";
            this.propertiesToolStripMenuItem2.Size = new System.Drawing.Size(91, 20);
            this.propertiesToolStripMenuItem2.Text = "&Pst Properties";
            // 
            // messageStoreToolStripMenuItem
            // 
            this.messageStoreToolStripMenuItem.Name = "messageStoreToolStripMenuItem";
            this.messageStoreToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.messageStoreToolStripMenuItem.Text = "Message Store";
            this.messageStoreToolStripMenuItem.Click += new System.EventHandler(this.messageStoreToolStripMenuItem_Click);
            // 
            // rootMailboxFolderToolStripMenuItem
            // 
            this.rootMailboxFolderToolStripMenuItem.Name = "rootMailboxFolderToolStripMenuItem";
            this.rootMailboxFolderToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.rootMailboxFolderToolStripMenuItem.Text = "Name-to-Id Map";
            this.rootMailboxFolderToolStripMenuItem.Click += new System.EventHandler(this.rootMailboxFolderToolStripMenuItem_Click);
            // 
            // rootFolderToolStripMenuItem
            // 
            this.rootFolderToolStripMenuItem.Name = "rootFolderToolStripMenuItem";
            this.rootFolderToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.rootFolderToolStripMenuItem.Text = "Root Folder";
            this.rootFolderToolStripMenuItem.Click += new System.EventHandler(this.rootFolderToolStripMenuItem_Click);
            // 
            // messagesHeaderLabel
            // 
            this.messagesHeaderLabel.AutoSize = true;
            this.messagesHeaderLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.messagesHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messagesHeaderLabel.Location = new System.Drawing.Point(5, 5);
            this.messagesHeaderLabel.Name = "messagesHeaderLabel";
            this.messagesHeaderLabel.Padding = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.messagesHeaderLabel.Size = new System.Drawing.Size(68, 23);
            this.messagesHeaderLabel.TabIndex = 7;
            this.messagesHeaderLabel.Text = "Messages";
            // 
            // messageBodyLabel
            // 
            this.messageBodyLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.messageBodyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageBodyLabel.Location = new System.Drawing.Point(5, 5);
            this.messageBodyLabel.Name = "messageBodyLabel";
            this.messageBodyLabel.Padding = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.messageBodyLabel.Size = new System.Drawing.Size(624, 23);
            this.messageBodyLabel.TabIndex = 7;
            this.messageBodyLabel.Text = "Message Body";
            // 
            // attachmentListBox
            // 
            this.attachmentListBox.ContextMenuStrip = this.emailItemContextMenu;
            this.attachmentListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.attachmentListBox.FormattingEnabled = true;
            this.attachmentListBox.IntegralHeight = false;
            this.attachmentListBox.Location = new System.Drawing.Point(5, 28);
            this.attachmentListBox.Name = "attachmentListBox";
            this.attachmentListBox.Size = new System.Drawing.Size(215, 67);
            this.attachmentListBox.TabIndex = 9;
            // 
            // emailItemContextMenu
            // 
            this.emailItemContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveAsToolStripMenuItem,
            this.propertiesToolStripMenuItem1});
            this.emailItemContextMenu.Name = "emailItemContextMenu";
            this.emailItemContextMenu.Size = new System.Drawing.Size(128, 48);
            this.emailItemContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.emailItemContextMenu_Opening);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // propertiesToolStripMenuItem1
            // 
            this.propertiesToolStripMenuItem1.Name = "propertiesToolStripMenuItem1";
            this.propertiesToolStripMenuItem1.Size = new System.Drawing.Size(127, 22);
            this.propertiesToolStripMenuItem1.Text = "Properties";
            this.propertiesToolStripMenuItem1.Click += new System.EventHandler(this.propertiesToolStripMenuItem_Click);
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.propertiesToolStripMenuItem});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(128, 26);
            this.contextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenu_Opening);
            // 
            // propertiesToolStripMenuItem
            // 
            this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
            this.propertiesToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.propertiesToolStripMenuItem.Text = "Properties";
            this.propertiesToolStripMenuItem.Click += new System.EventHandler(this.propertiesToolStripMenuItem_Click);
            // 
            // exportButton
            // 
            this.exportButton.AutoSize = true;
            this.exportButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.exportButton.Location = new System.Drawing.Point(220, 28);
            this.exportButton.Name = "exportButton";
            this.exportButton.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.exportButton.Size = new System.Drawing.Size(60, 67);
            this.exportButton.TabIndex = 10;
            this.exportButton.Text = "Save";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // messageBodyTextBox
            // 
            this.messageBodyTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.messageBodyTextBox.ContextMenuStrip = this.contextMenu;
            this.messageBodyTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.messageBodyTextBox.Location = new System.Drawing.Point(5, 128);
            this.messageBodyTextBox.Name = "messageBodyTextBox";
            this.messageBodyTextBox.Size = new System.Drawing.Size(624, 266);
            this.messageBodyTextBox.TabIndex = 11;
            this.messageBodyTextBox.Text = "";
            this.messageBodyTextBox.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.messageBodyTextBox_LinkClicked);
            // 
            // webBrowser1
            // 
            this.webBrowser1.AllowWebBrowserDrop = false;
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.IsWebBrowserContextMenuEnabled = false;
            this.webBrowser1.Location = new System.Drawing.Point(5, 128);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.Size = new System.Drawing.Size(624, 266);
            this.webBrowser1.TabIndex = 12;
            this.webBrowser1.Visible = false;
            this.webBrowser1.WebBrowserShortcutsEnabled = false;
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitContainer3.Location = new System.Drawing.Point(5, 28);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.recipientsListBox);
            this.splitContainer3.Panel1.Controls.Add(this.recipientCountLabel);
            this.splitContainer3.Panel1.Padding = new System.Windows.Forms.Padding(0, 5, 5, 5);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.attachmentListBox);
            this.splitContainer3.Panel2.Controls.Add(this.exportButton);
            this.splitContainer3.Panel2.Controls.Add(this.attachCountLabel);
            this.splitContainer3.Panel2.Padding = new System.Windows.Forms.Padding(5, 5, 0, 5);
            this.splitContainer3.Size = new System.Drawing.Size(624, 100);
            this.splitContainer3.SplitterDistance = 340;
            this.splitContainer3.TabIndex = 20;
            // 
            // recipientsListBox
            // 
            this.recipientsListBox.ContextMenuStrip = this.contextMenu;
            this.recipientsListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.recipientsListBox.FormattingEnabled = true;
            this.recipientsListBox.IntegralHeight = false;
            this.recipientsListBox.Location = new System.Drawing.Point(0, 28);
            this.recipientsListBox.Name = "recipientsListBox";
            this.recipientsListBox.Size = new System.Drawing.Size(335, 67);
            this.recipientsListBox.TabIndex = 1;
            // 
            // recipientCountLabel
            // 
            this.recipientCountLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.recipientCountLabel.Location = new System.Drawing.Point(0, 5);
            this.recipientCountLabel.Name = "recipientCountLabel";
            this.recipientCountLabel.Size = new System.Drawing.Size(335, 23);
            this.recipientCountLabel.TabIndex = 19;
            this.recipientCountLabel.Text = "Recipients";
            // 
            // attachCountLabel
            // 
            this.attachCountLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.attachCountLabel.Location = new System.Drawing.Point(5, 5);
            this.attachCountLabel.Name = "attachCountLabel";
            this.attachCountLabel.Size = new System.Drawing.Size(275, 23);
            this.attachCountLabel.TabIndex = 11;
            this.attachCountLabel.Text = "Attachments";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(5, 5);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.splitContainer1.Panel1.Controls.Add(this.foldersTreeView);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(5);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(951, 574);
            this.splitContainer1.SplitterDistance = 312;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 14;
            // 
            // foldersTreeView
            // 
            this.foldersTreeView.ContextMenuStrip = this.contextMenu;
            this.foldersTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.foldersTreeView.Location = new System.Drawing.Point(5, 28);
            this.foldersTreeView.Name = "foldersTreeView";
            this.foldersTreeView.Size = new System.Drawing.Size(302, 541);
            this.foldersTreeView.TabIndex = 7;
            this.foldersTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.foldersTreeView_AfterSelect);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 5);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.label1.Size = new System.Drawing.Size(53, 23);
            this.label1.TabIndex = 6;
            this.label1.Text = "Folders";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.splitContainer2.Panel1.Controls.Add(this.messagesListBox);
            this.splitContainer2.Panel1.Controls.Add(this.messagesHeaderLabel);
            this.splitContainer2.Panel1.Padding = new System.Windows.Forms.Padding(5);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.splitContainer2.Panel2.Controls.Add(this.messageBodyTextBox);
            this.splitContainer2.Panel2.Controls.Add(this.webBrowser1);
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Panel2.Controls.Add(this.messageBodyLabel);
            this.splitContainer2.Panel2.Margin = new System.Windows.Forms.Padding(5);
            this.splitContainer2.Panel2.Padding = new System.Windows.Forms.Padding(5);
            this.splitContainer2.Size = new System.Drawing.Size(634, 574);
            this.splitContainer2.SplitterDistance = 171;
            this.splitContainer2.TabIndex = 0;
            // 
            // messagesListBox
            // 
            this.messagesListBox.AllowColumnReorder = true;
            this.messagesListBox.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader1,
            this.columnHeader2});
            this.messagesListBox.ContextMenuStrip = this.emailItemContextMenu;
            this.messagesListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.messagesListBox.FullRowSelect = true;
            this.messagesListBox.HideSelection = false;
            this.messagesListBox.Location = new System.Drawing.Point(5, 28);
            this.messagesListBox.MultiSelect = false;
            this.messagesListBox.Name = "messagesListBox";
            this.messagesListBox.Size = new System.Drawing.Size(624, 138);
            this.messagesListBox.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.messagesListBox.TabIndex = 8;
            this.messagesListBox.UseCompatibleStateImageBehavior = false;
            this.messagesListBox.View = System.Windows.Forms.View.Details;
            this.messagesListBox.SelectedIndexChanged += new System.EventHandler(this.messagesListBox_SelectedIndexChanged);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Node ID";
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Subject";
            this.columnHeader1.Width = 500;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Size";
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.splitContainer1);
            this.toolStripContainer1.ContentPanel.Padding = new System.Windows.Forms.Padding(5);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(961, 584);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(961, 608);
            this.toolStripContainer1.TabIndex = 8;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.mainMenu);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(961, 608);
            this.Controls.Add(this.toolStripContainer1);
            this.MainMenuStrip = this.mainMenu;
            this.Name = "MainForm";
            this.Text = "PST Explorer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.emailItemContextMenu.ResumeLayout(false);
            this.contextMenu.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label messageBodyLabel;
        private System.Windows.Forms.ListBox attachmentListBox;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.RichTextBox messageBodyTextBox;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView foldersTreeView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label messagesHeaderLabel;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.Label attachCountLabel;
        private System.Windows.Forms.Label recipientCountLabel;
        private System.Windows.Forms.ListBox recipientsListBox;
        private System.Windows.Forms.ListView messagesListBox;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip emailItemContextMenu;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem messageStoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rootMailboxFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rootFolderToolStripMenuItem;
    }
}

