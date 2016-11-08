using System;
using System.Linq;
using System.IO;
using pstsdk.layer.pst;
using pstsdk.definition.util.primitives;
using MbUnit.Framework;
using pstsdk.test.mocks.MockPropBagConstants;

namespace pstsdk.test.Integration
{    
    public class SearchFolderIntegrationTest
    {
        [Test]
        public void SearchFolder_DatabaseContext_Valid()
        {
            using (var searchFolder = IntegrationUtil.GetSearchFolder())
            {
                Assert.AreEqual(new NodeID { Value = SearchFolderMockConstants.SEARCH_FOLDER_DB_CONTEXT_NODE_VALUE }, 
                    searchFolder.DatabaseContext.Nodes.ElementAt(SearchFolderMockConstants.SEARCH_FOLDER_FIRST_ELEMENT).NodeId);
            }
        }

        [Test]
        public void SearchFolder_MessageCount_Valid()
        {
            using (var searchFolder = IntegrationUtil.GetSearchFolder())
            {
                Assert.AreEqual(searchFolder.Messages.Count(), searchFolder.MessageCount);
            }
        }

        [Test]
        public void SearchFolder_Messages_Valid()
        {
            using (var searchFolder = IntegrationUtil.GetSearchFolder())
            {
                Message testMessage = (Message)searchFolder.Messages.ElementAt(SearchFolderMockConstants.SEARCH_FOLDER_FIRST_ELEMENT);
                Assert.AreEqual((UInt32)NidType.nid_type_message, testMessage.Node.Value);
            }
        }

        [Test]
        public void SearchFolder_Name_Valid()
        {
            using (var searchFolder = IntegrationUtil.GetSearchFolder())
            {
                Assert.AreEqual(SearchFolderMockConstants.SEARCH_FOLDER_NAME, searchFolder.Name);
            }
        }

        [Test]
        public void SearchFolder_Node_Valid()
        {
            using (var searchFolder = IntegrationUtil.GetSearchFolder())
            {
                Assert.AreEqual((UInt32)NidType.nid_type_folder, searchFolder.Node.Value);
            }
        }

        [Test]
        public void SearchFolder_Properties_Valid()
        {
            using (var searchFolder = IntegrationUtil.GetSearchFolder())
            {
                PropId testPropId = searchFolder.Properties.ElementAt(SearchFolderMockConstants.SEARCH_FOLDER_FIRST_ELEMENT);
                Assert.AreEqual(SearchFolderMockConstants.SEARCH_FOLDER_PROPERTY_PROP_ID_VALUE, testPropId.Value);
            }
        }


        [Test]
        public void SearchFolder_GetPropertyType_Valid()
        {
            using (var searchFolder = IntegrationUtil.GetSearchFolder())
            {
                PropId testPropId = searchFolder.Properties.ElementAt(SearchFolderMockConstants.SEARCH_FOLDER_FIRST_ELEMENT);
                Assert.AreEqual(SearchFolderMockConstants.SEARCH_FOLDER_PROPERTY_PROP_TYPE_VALUE, searchFolder.GetPropertyType(testPropId));
            }
        }

        [Test]
        [ExpectedException(typeof(pstsdk.definition.exception.PstSdkException))]
        public void SearchFolder_GetPropertyType_Invalid()
        {
            using (var searchFolder = IntegrationUtil.GetSearchFolder())
            {
                searchFolder.GetPropertyType(SearchFolderMockConstants.SEARCH_FOLDER_INVALID_PROP_ID);
            }
        }

        [Test]
        public void SearchFolder_OpenPropertyStream_Valid()
        {
            using (var searchFolder = IntegrationUtil.GetSearchFolder())
            {
                Stream testStream = searchFolder.OpenPropertyStream(
                    searchFolder.Properties.ElementAt(SearchFolderMockConstants.SEARCH_FOLDER_FIRST_ELEMENT));
                Assert.IsTrue(SearchFolderMockConstants.SEARCH_FOLDER_PROPERTY_STREAM_LENGTH < testStream.Length);
            }
        }

        [Test]
        [ExpectedException(typeof(pstsdk.definition.exception.PstSdkException))]
        public void SearchFolder_OpenPropertyStream_Invalid()
        {
            using (var searchFolder = IntegrationUtil.GetSearchFolder())
            {
                searchFolder.OpenPropertyStream(SearchFolderMockConstants.SEARCH_FOLDER_INVALID_PROP_ID);
            }
        }

        [Test]
        public void SearchFolder_PropertyExists_Valid()
        {
            using (var searchFolder = IntegrationUtil.GetSearchFolder())
            {
                PropId testPropId = searchFolder.Properties.ElementAt(SearchFolderMockConstants.SEARCH_FOLDER_SECOND_ELEMENT);
                Assert.IsTrue(searchFolder.PropertyExists(testPropId));
            }
        }

        [Test]
        public void SearchFolder_PropertyExists_Invalid()
        {
            using (var searchFolder = IntegrationUtil.GetSearchFolder())
            {
                Assert.IsFalse(searchFolder.PropertyExists(SearchFolderMockConstants.SEARCH_FOLDER_INVALID_PROP_ID));
            }
        }

        [Test]
        public void SearchFolder_PropertySize_Valid()
        {
            using (var searchFolder = IntegrationUtil.GetSearchFolder())
            {
                PropId testPropId = searchFolder.Properties.ElementAt(SearchFolderMockConstants.SEARCH_FOLDER_SECOND_ELEMENT);
                Assert.AreEqual(SearchFolderMockConstants.SEARCH_FOLDER_PROPERTY_SIZE, searchFolder.PropertySize(testPropId));
            }
        }

        [Test]
        [ExpectedException(typeof(pstsdk.definition.exception.PstSdkException))]
        public void SearchFolder_PropertySize_Invalid()
        {
            using (var searchFolder = IntegrationUtil.GetSearchFolder())
            {
                searchFolder.PropertySize(SearchFolderMockConstants.SEARCH_FOLDER_INVALID_PROP_ID);
            }
        }

        [Test]
        public void SearchFolder_ReadProperty_Valid()
        {
            using (var searchFolder = IntegrationUtil.GetSearchFolder())
            {
                PropId testPropId = searchFolder.Properties.ElementAt(SearchFolderMockConstants.SEARCH_FOLDER_FIRST_ELEMENT);
                Assert.AreEqual(SearchFolderMockConstants.SEARCH_FOLDER_READ_PROPERTY_RESULT, 
                    searchFolder.ReadProperty(testPropId).ElementAt(SearchFolderMockConstants.SEARCH_FOLDER_FIRST_ELEMENT));
            }
        }

        [Test]
        [ExpectedException(typeof(pstsdk.definition.exception.PstSdkException))]
        public void SearchFolder_ReadProperty_Invalid()
        {
            using (var searchFolder = IntegrationUtil.GetSearchFolder())
            {
                searchFolder.ReadProperty(SearchFolderMockConstants.SEARCH_FOLDER_INVALID_PROP_ID);
            }
        }

    }
}
