using pstsdk.definition.pst.folder;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using pstsdk.definition.pst.message;
using System.Collections.Generic;
using pstsdk.definition.ndb.database;
using pstsdk.definition.util.primitives;

namespace pstsdk.test
{
    public class IFolderTest
    {
        public static void SubFoldersTest(IFolder target)
        {
            IEnumerable<IFolder> actual;
            actual = target.SubFolders;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        public static void SubFolderCountTest(IFolder target, int expected)
        {
            Assert.AreEqual(expected, target.SubFolderCount);
        }

        public static void NameTest(IFolder target, string expected)
        {
            Assert.IsTrue(target.Name.CompareTo(expected) == 0);
        }

        public static void MessagesTest(IFolder target)
        {
            IEnumerable<IMessage> actual;
            actual = target.Messages;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        public static void MessageCountTest(IFolder target, int expected)
        {
            Assert.AreEqual(expected, target.MessageCount);
        }

        public static void EntryIDTest(IFolder target, EntryID expected)
        {
            Assert.AreEqual(expected, target.EntryID);
        }

        public static void DatabaseContextTest(IFolder target)
        {
            IDBAccessor actual;
            actual = target.DatabaseContext;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        public static void AssociatedMessagesTest(IFolder target)
        {
            IEnumerable<IMessage> actual;
            actual = target.AssociatedMessages;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        public static void AssociatedMessageCountTest(IFolder target, int expected)
        {
            Assert.AreEqual(expected, target.AssociatedMessageCount);
        }

        public static void OpenSubFolderTest(IFolder target, string subFolderName)
        {
            Assert.IsNotNull(target.OpenSubFolder(subFolderName));
        }

        public static void OpenSubFolderTestExpectsNull(IFolder target, string subFolderName)
        {
            Assert.IsNull(target.OpenSubFolder(subFolderName));
        }
    }
}
