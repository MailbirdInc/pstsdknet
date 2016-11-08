using System;
using System.Collections.Generic;

using pstsdk.definition.pst;
using pstsdk.definition.pst.folder;
using pstsdk.definition.pst.message;

using pstsdk.layer.pst;

namespace pstsdk.mcpp.sample.pstdir
{
    class Program
    {
        static int Main(string[] args)
        {
            if(args.Length != 1)
            {
                Console.WriteLine(Environment.GetCommandLineArgs()[0] + " <pst-filename>");
                return -1;
            }
            string path = args[0];

            IPst store = new Pst(path);
            DateTime lolz = DateTime.Now;
            process_folder(0, store.OpenRootFolder());
            Console.WriteLine("Total Time Elapsed: " + DateTime.Now.Subtract(lolz));

            Console.ReadKey();

            return 0;
        }

        static void process_folder(int tab_depth, IFolder f)
        {
            for(int i = 0; i < tab_depth; ++i) Console.Write('\t');
            
            Console.WriteLine(f.Name + " (" + f.MessageCount + ")");
                foreach (IMessage message in f.Messages)
            {
                process_message(tab_depth + 1, message);
                //foreach(IRecipient recipient in message.Recipients)
                //{
                //    for (int i = 0; i < tab_depth + 2; ++i) Console.Write('\t');
                //    Console.WriteLine(recipient.Name + " - " + recipient.EmailAddress);
                //}
            }

            foreach(IFolder subFolder in f.SubFolders)
                process_folder(tab_depth+1, subFolder);
        }

        static void process_message(int tab_depth, IMessage m)
        {
            for(int i = 0; i < tab_depth; ++i) Console.Write('\t');

            try
            {
                Console.WriteLine(m.Subject);
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("<no subject>");
            }
            catch (Exception)
            {
                Console.WriteLine("ERROR FETCHING SUBJECT! Press any key to continue.");
                Console.ReadKey();
            }

        }
    }
}
