// A sample application to extract all image attachments, i.e. attachments
// with any of the extensions gif, jpg or png.
// All image attachments are saved in the current working directory, with care
// taken not to overwrite any existing files.

using System;
using System.IO;
using System.Text;

using pstsdk.definition.pst;
using pstsdk.definition.pst.message;

using pstsdk.layer.pst;

namespace pstsdk.mcpp.sample.pstattachment
{
    class Program
    {
        const string gifExtn = "gif";
        const string jpgExtn = "jpg";
        const string pngExtn = "png";

        static int Main(string[] args)
        {
            if (args.Length != 1)
            {
                printUsage(Environment.GetCommandLineArgs()[0]);
                return -1;
            }

            string pstFile = args[0];

            // Check if the file exists

            if (!File.Exists(pstFile))
            {
                Console.WriteLine(
                    "The specified PST file argument is incorrect. " +
                    "Either it is not a file or the file does not exist");
                return -1;
            }

            IPst myFile = new Pst(pstFile);
            traverseAllMessages(myFile);

            return 0;
        }

        static void printUsage(string program)
        {
            Console.WriteLine("Usage");
            Console.WriteLine("\t" + program + " [PST file]");
        }

        static void traverseAllMessages(IPst pstFile)
        {
            // Iterate through all the folders in the given PST object.
            foreach (var currentFolder in pstFile.Folders)
            {
                // Process all messages in the current folder.
                if (currentFolder.MessageCount > 0)
                {
                    foreach (var message in currentFolder.Messages)
                    {
                        processMessage(message);
                    }
                }
            }
        }

        static void processMessage(IMessage msg)
        {
            // Ensure that there is atleast one attachment to the current message
            if (msg.AttachmentCount > 0)
            {
                foreach (var attachment in msg.Attachments)
                {
                    processAttachment(attachment);
                }
            }
        }

        static void processAttachment(IAttachment attch)
        {
            // Parse out the extension from the file name
            string attachmentFilename = string.Empty;
            try
            {
                attachmentFilename = attch.Filename;
            }
            catch
            {
                attachmentFilename = "Unknown Attachment.bin";
                Console.WriteLine("Error fetching attachment name!");
            }
            string extn = Path.GetExtension(attachmentFilename).Replace(".","");

            // Only consider files with an extension
            if (!String.IsNullOrEmpty(extn))
            {
                // Shortcut:
                // Since we know that we are looking for 3 character extensions, reject
                // on basis of extension length before doing string comparision.
                // Might not hold true in the future and may need to be removed.
                if (extn.Length != 3) return;

                // Convert to lower case for comparision purposes
                string lowerExtn = extn.ToLower();

                // Only process certain, recognised image extensions
                if ((lowerExtn == gifExtn) || (lowerExtn == jpgExtn) || (lowerExtn == pngExtn))
                {
                    saveAttachment(attch);
                }
            }
        }

        static void saveAttachment(IAttachment attch)
        {
            string filenameFull = string.Empty;
            try
            {
                filenameFull = attch.Filename;
            }
            catch
            {
                filenameFull = "Unknown Attachment.bin";
            }

            string filenameBase = Path.GetFileNameWithoutExtension(filenameFull);
            string filenameExtn = Path.GetExtension(filenameFull);

            bool done = false;
            int i = 1;

            StringBuilder sb = new StringBuilder();
            sb.Append(filenameFull);
            do
            {
                // Check if the file already exists
                if (File.Exists(sb.ToString()))
                {
                    // File with the name of current attachment already exits.
                    // Do not overwrite the existing file, instead use a different name
                    // for this file.
                    sb.Length = 0;

                    sb.Append(filenameBase);
                    sb.Append("(" + i++ + ")");
                    sb.Append(filenameExtn);
                }
                else
                {
                    done = true;
                }
            } while (!done);

            Console.WriteLine("Saving image attachment to '" + sb + "'");
            using (FileStream imgFile = new FileStream(sb.ToString(), FileMode.Create, FileAccess.Write, FileShare.Read))
            {
                byte[] attachmentContent = attch.Bytes;

                imgFile.Write(attachmentContent, 0, attachmentContent.Length);
            }
        }
    }
}
