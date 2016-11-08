using System;
using System.Linq;
using pstsdk.definition.exception;
using MbUnit.Framework;
using pstsdk.test.mocks.MockPropBagConstants;

namespace pstsdk.test.Integration
{
    public class PstIntegrationTest
    {       
        [Test]
        public void Pst_Name_Not_Null()
        {
            using (var pst = IntegrationUtil.GetPst())
            {
                Assert.IsTrue(!String.IsNullOrEmpty(pst.Name), PstMockConstants.PST_NAME_NOT_NULL_FAIL);
            }
        }

        [Test]
        public void Pst_Name_Compare()
        {
            using (var pst = IntegrationUtil.GetPst())
            {
                Assert.AreEqual(pst.Name, PstMockConstants.PST_NAME);
            }
        }

        [Test]
        public void Messages_Enumerator_Valid()
        {
            using (var pst = IntegrationUtil.GetPst())
            {
                Assert.IsNotNull(pst.Messages);
                Assert.AreEqual(PstMockConstants.PST_MESSAGE_COUNT, pst.Messages.Count());

                foreach (var message in pst.Messages)
                {
                    Assert.IsNotNull(message, PstMockConstants.PST_MESSAGES_ENUMERATOR_VALID_FAIL);
                }
            }
        }

        [Test]
        public void DatabaseAccessor_Not_Null()
        {
            using (var pst = IntegrationUtil.GetPst())
            {
                Assert.IsNotNull(pst.DatabaseAccessor);
            }
        }


        [Test]
        public void Folders_Enumerator_Valid()
        {
            using (var pst = IntegrationUtil.GetPst())
            {
                Assert.IsNotNull(pst.Folders);
                Assert.AreEqual(PstMockConstants.PST_FOLDERS_COUNT, pst.Folders.Count());

                foreach (var folder in pst.Folders)
                {
                    Assert.IsNotNull(folder, PstMockConstants.PST_FOLDERS_ENUMERATOR_VALID_FAIL);
                }
            }
        }


        [Test]
        public void NameIdMap_Not_Null()
        {
            using (var pst = IntegrationUtil.GetPst())
            {
                Assert.IsNotNull(pst.NameIDMap, pst.NameIDMap.ToString());
            }
        }


        [Test]
        public void Node_Not_Null()
        {
            using (var pst = IntegrationUtil.GetPst())
            {
                Assert.IsNotNull(pst.Node);
            }
        }


        [Test]
        public void Properties_Enumerator_Valid()
        {
            using (var pst = IntegrationUtil.GetPst())
            {
                Assert.IsNotNull(pst.Properties);
                Assert.AreEqual(PstMockConstants.PST_PROPERTIES_COUNT, pst.Properties.Count());

                foreach (var property in pst.Properties)
                {
                    Assert.IsNotNull(property, PstMockConstants.PST_PROPERTIES_ENUMERATOR_VALID_FAIL);
                }
            }
        }
        
        [Test]
        [ExpectedException(typeof(PstSdkException))]
        public void GetPropertyType_Invalid_PropId()
        {
            using (var pst = IntegrationUtil.GetPst())
            {
                var prop = pst.GetPropertyType(PstMockConstants.PST_INVALID_PROP_ID);
            }
        }
    }
}
