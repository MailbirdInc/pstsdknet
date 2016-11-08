using System.Linq;
using System.IO;
using pstsdk.layer.pst;
using pstsdk.definition.util.primitives;
using MbUnit.Framework;
using pstsdk.test.mocks.MockPropBagConstants;

namespace pstsdk.test.Integration
{
    public class FolderIntegrationTest
    {
        [Test]
        public void Folder_GetPropertyType_Valid()
        {
            using (var folder = IntegrationUtil.GetFolder())
            {
                PropId pid = folder.Properties.ElementAt(FolderMockConstants.FOLDER_FIRST_ELEMENT);
                Assert.AreEqual(FolderMockConstants.FOLDER_VALID_PROPERTY_TYPE, folder.GetPropertyType(pid));
            }
        }

        [Test]
        [ExpectedException(typeof(pstsdk.definition.exception.PstSdkException))]
        public void Folder_GetPropertyType_Invalid()
        {
            using (var folder = IntegrationUtil.GetFolder())
            {
                folder.GetPropertyType(FolderMockConstants.FOLDER_INVALID_PROP_ID);
            }
        }

        [Test]
        public void Folder_OpenPropertyStream_Valid()
        {
            using (var folder = IntegrationUtil.GetFolder())
            {
                Stream s = folder.OpenPropertyStream(folder.Properties.ElementAt(FolderMockConstants.FOLDER_FIRST_ELEMENT));
                Assert.IsTrue(FolderMockConstants.FOLDER_OPEN_PROPERTY_STREAM_VALID_LENGTH < s.Length);
            }
        }

        [Test]
        [ExpectedException(typeof(pstsdk.definition.exception.PstSdkException))]
        public void Folder_OpenPropertyStream_Invalid()
        {
            using (var folder = IntegrationUtil.GetFolder())
            {
                folder.OpenPropertyStream(FolderMockConstants.FOLDER_INVALID_PROP_ID);
            }
        }

        [Test]
        public void Folder_OpenSubFolder_Valid()
        {
            using (var folder = IntegrationUtil.GetFolder())
            {
                Folder testFolder = (Folder)folder.OpenSubFolder(FolderMockConstants.FOLDER_VALID_SUBFOLDER);
                Assert.IsNotNull(testFolder);
                Assert.AreEqual(FolderMockConstants.FOLDER_VALID_SUBFOLDER, testFolder.Name);
            }
        }

        [Test]
        public void Folder_OpenSubFolder_Invalid()
        {
            using (var folder = IntegrationUtil.GetDifferentFolder())
            {
                Folder testFolder = (Folder)folder.OpenSubFolder(FolderMockConstants.FOLDER_INVALID_SUBFOLDER);
                Assert.AreEqual(null, testFolder);
            }
        }

        [Test]
        public void Folder_OpenSubFolder_Null()
        {
            using (var folder = IntegrationUtil.GetDifferentFolder())
            {
                Folder f = (Folder)folder.OpenSubFolder(null);
                Assert.AreEqual(null, f);
            }
        }

        [Test]
        public void Folder_PropertyExists_Valid()
        {
            using (var folder = IntegrationUtil.GetFolder())
            {
                PropId p = folder.Properties.ElementAt(FolderMockConstants.FOLDER_FIRST_ELEMENT);
                Assert.IsTrue(folder.PropertyExists(p));
            }
        }

        [Test]
        public void Folder_PropertyExists_Invalid()
        {
            using (var folder = IntegrationUtil.GetFolder())
            {
                Assert.IsFalse(folder.PropertyExists(FolderMockConstants.FOLDER_INVALID_PROP_ID));
            }
        }


        [Test]
        public void Folder_PropertySize_Valid()
        {
            using (var folder = IntegrationUtil.GetFolder())
            {
                PropId p = folder.Properties.ElementAt(FolderMockConstants.FOLDER_FIRST_ELEMENT);
                Assert.AreEqual(FolderMockConstants.FOLDER_MESSAGE_SUBJECT_SIZE, folder.PropertySize(p));
            }
        }

        [Test]
        [ExpectedException(typeof(pstsdk.definition.exception.PstSdkException))]
        public void Folder_PropertySize_Invalid()
        {
            using (var folder = IntegrationUtil.GetFolder())
            {
                folder.PropertySize(FolderMockConstants.FOLDER_INVALID_PROP_ID);
            }
        }


        [Test]
        public void Folder_ReadProperty_Valid()
        {
            using (var folder = IntegrationUtil.GetFolder())
            {
                PropId p = folder.Properties.ElementAt(FolderMockConstants.FOLDER_FIRST_ELEMENT);
                Assert.AreEqual(FolderMockConstants.FOLDER_VALID_READ_PROPERTY, 
                    folder.ReadProperty(p).ElementAt(FolderMockConstants.FOLDER_FIRST_ELEMENT));
            }
        }

        [Test]
        [ExpectedException(typeof(pstsdk.definition.exception.PstSdkException))]
        public void Folder_ReadProperty_Invalid()
        {
            using (var folder = IntegrationUtil.GetFolder())
            {
                folder.ReadProperty(FolderMockConstants.FOLDER_INVALID_PROP_ID);
            }
        }



        [Test]
        public void Folder_AssociatedMessageCount_Valid()
        {
            using (var folder = IntegrationUtil.GetFolder())
            {
                Assert.AreEqual(FolderMockConstants.FOLDER_ASSOCIATED_MESSAGE_COUNT, folder.AssociatedMessageCount);
            }
        }

        [Test]
        public void Folder_AssociatedMessages_Valid()
        {
            using (var folder = IntegrationUtil.GetFolder())
            {
                Assert.IsNull(folder.AssociatedMessages);
            }
        }

        [Test]
        public void Folder_DatabaseContext_Valid()
        {
            using (var folder = IntegrationUtil.GetFolder())
            {
                Assert.AreEqual(new NodeID { Value = FolderMockConstants.FOLDER_VALID_NODE_ID },
                    folder.DatabaseContext.Nodes.ElementAt(FolderMockConstants.FOLDER_FIRST_ELEMENT).NodeId);
            }
        }

        //TODO: Fix this test    
        //[Test]
        //public void Folder_EntryID_Valid()
        //{
        //    using (var folder = IntegrationUtil.GetFolder())
        //    {
        //        Assert.AreEqual(FolderMockConstants.FOLDER_VALID_BYTE, folder.EntryID.Value.ElementAt(FolderMockConstants.FOLDER_FIRST_ELEMENT));
        //    }
        //}


        [Test]
        public void Folder_MessageCount_Valid()
        {
            using (var folder = IntegrationUtil.GetFolder())
            {
                Assert.AreEqual(folder.Messages.Count(), folder.MessageCount);
            }
        }

        [Test]
        public void Folder_Messages_Valid()
        {
            using (var folder = IntegrationUtil.GetFolder())
            {
                Message m = (Message)folder.Messages.ElementAt(FolderMockConstants.FOLDER_FIRST_ELEMENT);
                Assert.AreEqual(FolderMockConstants.FOLDER_MESSAGE_NODE_VALUE, m.Node.Value);
            }
        }

        [Test]
        public void Folder_Name_Valid()
        {
            using (var folder = IntegrationUtil.GetFolder())
            {
                Assert.AreEqual(FolderMockConstants.FOLDER_VALID_SUBFOLDER, folder.Name);
            }
        }

        [Test]
        public void Folder_Node_Valid()
        {
            using (var folder = IntegrationUtil.GetFolder())
            {
                Assert.AreEqual(FolderMockConstants.FOLDER_VALID_NODE_ID, folder.Node.Value);
            }
        }

        [Test]
        public void Folder_Properties_Valid()
        {
            using (var folder = IntegrationUtil.GetFolder())
            {
                PropId p = folder.Properties.ElementAt(FolderMockConstants.FOLDER_FIRST_ELEMENT);
                Assert.AreEqual((int)PropId.KnownValue.PR_SUBJECT, p.Value);
            }
        }
        [Test]
        public void Folder_SubFolderCount_Valid()
        {
            using (var folder = IntegrationUtil.GetDifferentFolder())
            {
                Assert.AreEqual(folder.SubFolders.Count(), folder.SubFolderCount);
            }

        }

        [Test]
        public void Folder_SubFolders_Valid()
        {
            using (var folder = IntegrationUtil.GetFolder())
            {
                Folder testFolder = IntegrationUtil.GetDifferentFolder();
                Assert.AreEqual(FolderMockConstants.FOLDER_DIFFERENT_VALID_NODE_ID, testFolder.Node.Value);
                Assert.AreEqual(FolderMockConstants.FOLDER_VALID_NODE_ID, folder.Node.Value);
            }
        }

    }
}
