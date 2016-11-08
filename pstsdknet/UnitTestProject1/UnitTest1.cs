using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using pstsdk.layer.pst;
using pstsdk.definition.pst;
using pstsdk.definition.util.primitives;
using System.Collections.Generic;
using pstsdk.definition.pst.folder;
using System.Linq;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetTopIMFFolder()
        {
            using (IPst pstFile = new Pst(@"Resources\small_test.pst"))
            {

                var topId = pstFile.GetTopIPMFolderId();
                Assert.AreNotEqual(0, topId);

                var topFolder = pstFile.OpenFolder(topId);

                Assert.IsNotNull(topFolder);

            }
        }

        [TestMethod]
        public void GetAdditionalEntries()
        {
            using (IPst pstFile = new Pst(@"C:\\Users\\Antonio\\Documents\\Outlook Files\\antonioperezcontreras@outlook.com.pst"))
            {
                var addEntries = pstFile.OpenRootFolder().GetAdditionalEntryIds();

            }
        }

        private IEnumerable<IFolder> GetFolders(IFolder parent)
        {
            List<IFolder> folders = new List<IFolder>();

            folders.Add(parent);

            foreach (var folder in parent.SubFolders)
                folders.AddRange(GetFolders(folder));

            return folders;
        }
    }
}
