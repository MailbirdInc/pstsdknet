using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using pstsdk.definition.ltp;
using pstsdk.definition.pst;
using pstsdk.definition.util.primitives;
using pstsdk.layer.ltp.nameid;
using pstsdk.layer.pst;

namespace pstsdk.mcpp.sample.nameprop
{
    class Program
    {
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

            IPst pst = new Pst(pstFile);
            var nameIdMap = pst.NameIDMap;
            var nameIdMapObject = nameIdMap.PropertyBag;

            Console.WriteLine("Bucket Count: {0}", nameIdMap.BucketCount);
            Console.WriteLine(Environment.NewLine);

            //Dump out all the Guids
            using (var guids =
                    new GuidStreamReader(nameIdMapObject.OpenPropertyStream(PropId.KnownValue.PidTagNameidStreamGuid)))
            {
                Console.WriteLine("GUID Stream: (* indicates predefined guid)");
                Console.WriteLine("\t [000] {0}*", Guid.Empty);
                Console.WriteLine("\t [001] {0}*", GuidStreamReader.MapiGuid);
                Console.WriteLine("\t [002] {0}*", GuidStreamReader.PublicStringsGuid);

                for (int i = 3; i < nameIdMap.PropertyCount; i++)
                {
                    Console.WriteLine("\t [{0:D3}] {1}", i, guids.ReadGuid(i));
                }
            }

            Console.WriteLine(Environment.NewLine);

            //Dump out the Entry Stream);
            using(var entries = 
                new EntryStreamReader(nameIdMapObject.OpenPropertyStream(PropId.KnownValue.PidTagNameidStreamEntry)))
            {
                Console.WriteLine("Entry Stream: ");
                for(int i = 0; i < nameIdMap.PropertyCount; i++)
                {
                    Console.WriteLine("\t [{0:D3}] {1}", i, entries.ReadEntry(i));
                    
                }
            }

            Console.WriteLine(Environment.NewLine);

            using(var strings = new BinaryReader(nameIdMapObject.OpenPropertyStream(PropId.KnownValue.PidTagNameidStreamString)))
            {
                Console.WriteLine("String Stream: ");
                var streamLength = strings.BaseStream.Length;

                while (strings.BaseStream.Position < streamLength)
                {
                    var stringLength = strings.ReadInt32();
                    var stringBytes = strings.ReadBytes(stringLength);

                    Console.WriteLine(Encoding.Unicode.GetString(stringBytes));

                    //seek to nearest 4-byte boundary
                    var offset = stringLength % 4;

                    if (offset != 0)
                        strings.BaseStream.Seek((4 - offset), SeekOrigin.Current);
                }
            }

            Console.WriteLine("Hash Buckets:");
            for (int i = 0; i < nameIdMap.BucketCount; i++)
            {
                var bucketProperty = i + 0x1000;

                if (nameIdMapObject.PropertyExists((PropId)bucketProperty))
                {
                    var bytes = nameIdMapObject.ReadProperty((PropId)bucketProperty);
                    var nameIdbytes = new byte[8];

                    for (int x = 0; x < bytes.Length; x += 8)
                    {
                        Array.Copy(bytes, x, nameIdbytes, 0, 8);

                        var nameId = new NameId(nameIdbytes);
                        Console.WriteLine("[{0:D3}] Hash: 0x{1:X8}, Guid Index: {2}, \r\n\tProperty Index: 0x{3:X4}, Is String? {4}",
                                          i, nameId.Id, nameId.GuidIndex, (nameId.PropertyIndex + 0x8000), nameId.IsString);
                        Console.WriteLine();
                    }
                }
            }


            foreach(var np in nameIdMap.NamedProperties)
            {
                Console.WriteLine();
                Console.WriteLine(np.ToString());
                Console.WriteLine();
            }

            Console.ReadKey(true);

            return 0;
        }

        static void printUsage(string program)
        {
            Console.WriteLine("Usage");
            Console.WriteLine("\t" + program + " [PST file]");
        }
    }
}
