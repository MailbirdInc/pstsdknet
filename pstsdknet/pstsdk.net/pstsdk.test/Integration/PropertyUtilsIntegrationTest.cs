using System;
using pstsdk.layer.pst;
using pstsdk.layer.util;
using pstsdk.definition.util.primitives;
using MbUnit.Framework;
using pstsdk.test.mocks.MockPropBagConstants;
using pstsdk.test.mocks.MockPropBags;

namespace pstsdk.test.Integration
{
    public class PropertyUtilsIntegrationTest
    {
        [Test]
        public void GenerateEntryID_EntryID_Not_Null()
        {
            using (var mockPst = IntegrationUtil.GetMockPst())
            {
                EntryID entryId = PropertyUtils.GenerateEntryID(PropertyUtilsMockConstants.PROPERTY_UTILS_VALID_NODE, mockPst.DatabaseAccessor);
                Assert.IsNotNull(entryId);
            }
        }

        [Test]
        public void GenerateEntryID_EntryID_Not_Empty()
        {
            using (var mockPst = IntegrationUtil.GetMockPst())
            {
                EntryID entryId = PropertyUtils.GenerateEntryID(PropertyUtilsMockConstants.PROPERTY_UTILS_VALID_NODE, mockPst.DatabaseAccessor);
                Assert.AreNotEqual(entryId, EntryID.Empty);
            }
        }

        [Test]
        public void GenerateEntryID_EntryID_Value_Not_Null()
        {
            using (var mockPst = IntegrationUtil.GetMockPst())
            {
                EntryID entryId = PropertyUtils.GenerateEntryID(PropertyUtilsMockConstants.PROPERTY_UTILS_VALID_NODE, mockPst.DatabaseAccessor);
                Assert.IsNotNull(entryId.Value);
            }
        }

        [Test]
        public void GenerateEntryID_Invalid_NodeID_Not_Null()
        {
            using (var mockPst = IntegrationUtil.GetMockPst())
            {
                EntryID entryId = PropertyUtils.GenerateEntryID(PropertyUtilsMockConstants.PROPERTY_UTILS_INVALID_NODE, mockPst.DatabaseAccessor);
                Assert.IsNotNull(entryId);
            }
        }

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void GenerateEntryID_Null_DatabaseAccessor()
        {
            EntryID entryId = PropertyUtils.GenerateEntryID(PropertyUtilsMockConstants.PROPERTY_UTILS_VALID_NODE, null);
        }

        [Test]
        public void RemoveSubjectPaddingCharacter_Valid_Subject()
        {
            using (var mockPst = IntegrationUtil.GetMockPst())
            {
                Message testMessage = (Message)mockPst.OpenMessage(PropertyUtilsMockConstants.PROPERTY_UTILS_VALID_NODE);
                Assert.AreEqual(PropertyUtils.RemoveSubjectPaddingCharacter(testMessage.Subject),
                    testMessage.Subject);
                testMessage.Dispose();
                testMessage = null;
            }
        }

        [Test]
        public void RemoveSubjectPaddingCharacter_Empty_Subject()
        {
            Assert.AreEqual(PropertyUtils.RemoveSubjectPaddingCharacter(String.Empty),
                String.Empty);
        }

        [Test]
        public void RemoveSubjectPaddingCharacter_Null_Subject()
        {
            Assert.AreEqual(PropertyUtils.RemoveSubjectPaddingCharacter(null), null);
        }

        [Test]
        public void GetStringProperty_Valid_PropBag_And_PropId()
        {
            String test = PropertyUtils.GetStringProperty(new MockPropBag(), PropId.KnownValue.PR_SUBJECT);
            Assert.AreEqual("RE: Please reply to this message", test);
        }
    }
}
