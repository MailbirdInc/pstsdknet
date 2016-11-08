using System;
using System.Linq;
using pstsdk.layer.pst;
using System.IO;
using pstsdk.layer.ltp.nameid;
using pstsdk.definition.util.primitives;
using pstsdk.definition.pst.message;
using pstsdk.test.mocks;
using pstsdk.definition.pst;
using pstsdk.definition.ltp.nameid;
using pstsdk.test.mocks.MockPropBagConstants;

namespace pstsdk.test.Integration
{
    public static class IntegrationUtil
    {
        public static Pst GetPst()
        {
            FileInfo pstFileInfo = new FileInfo(Path.Combine(Path.GetTempPath(),
                Guid.NewGuid() + "small_test.pst"));

            SetupTestFile(pstFileInfo, Properties.Resources.small_test);

            //MD5CryptoServiceProvider cryptoProvider = new MD5CryptoServiceProvider();
            //var pstHashBytes = cryptoProvider.ComputeHash(new FileStream(pstFileInfo.FullName, FileMode.Open));
            //StringBuilder s = new StringBuilder();

            //foreach (byte b in pstHashBytes)
            //    s.Append(b.ToString("x2").ToLower());            

            //String pstMd5String = s.ToString();
            //Console.Write(pstMd5String);

            return new Pst(pstFileInfo.FullName);
        }

        public static IPst GetMockPst()
        {
            return new MockPst();
        }

        public static IPst GetDifferentMockPst()
        {
            return new DifferentMockPst();
        }

        public static void SetupTestFile(FileInfo testFile, byte[] contents)
        {
            if (testFile.Exists)
                testFile.Delete();

            using (var fs = testFile.OpenWrite())
                fs.Write(contents, 0, contents.Length);
        }

        public static GuidStreamReader GetGuidStreamReader()
        {
            return new GuidStreamReader(new MemoryStream(NameIdConstants.GuidStreamBytes));
        }

        public static Message GetMessage()
        {
            var pst = GetMockPst();
            return (Message)pst.OpenMessage(2097476);
        }

        public static Message GetDifferentMessage()
        {
            var pst = GetDifferentMockPst();
            return (Message)pst.OpenMessage(2097380);
        }

        public static IMessage GetMockMessage()
        {
            return new MockMessage();
        }

        public static Attachment GetAttachment()
        {
            var mockMessage = GetMockMessage();
            return (Attachment)mockMessage.Attachments.ElementAt(0);
        }

        public static Attachment GetDifferentAttachment()
        {
            var mockMessage = GetMockMessage();
            return (Attachment)mockMessage.Attachments.ElementAt(1);
        }

        public static NameIdMap GetNameIdMap()
        {
            var mockPst = GetMockPst();
            return (NameIdMap)mockPst.NameIDMap;
        }

        public static INameIDMap GetMockNameIdMap()
        {
            return new MockNameIdMap();
        }

        public static NamedProperty GetNamedProperty()
        {
            return new NamedProperty(new Guid("1d942145-c3ca-4c71-ab3e-e2f31e5f02e4"), "Named Property");
        }

        public static INamedProperty GetMockNamedProperty()
        {
            return new MockNamedProperty();
        }

        public static EntryStreamReader GetEntryStreamReader()
        {
            return new EntryStreamReader(new MemoryStream(NameIdConstants.EntryStreamBytes));
        }

        public static Folder GetFolder()
        {
            var pst = GetMockPst();
            return (Folder)pst.Folders.ElementAt(0);
        }

        public static Folder GetDifferentFolder()
        {
            var pst = GetMockPst();
            return (Folder)pst.Folders.ElementAt(1);
        }

        public static Folder GetFolderAtElement(int elementNumber)
        {
            var pst = GetMockPst();
            return (Folder)pst.Folders.ElementAt(elementNumber);
        }

        public static SearchFolder GetSearchFolder()
        {
            var pst = GetMockPst();
            return (SearchFolder)pst.OpenSearchFolder(new NodeID());
        }

        public static Recipient GetRecipient()
        {
            var message = GetMockMessage();
            return (Recipient)message.Recipients.ElementAt(0);
        }

        public static Recipient GetDifferentRecipient()
        {
            var message = GetMockMessage();
            return (Recipient)message.Recipients.ElementAt(1);
        }

        public static StringStreamReader GetStringStreamReader()
        {
            return new StringStreamReader(new MemoryStream(NameIdConstants.StringStreamBytes));
        }
    }
}