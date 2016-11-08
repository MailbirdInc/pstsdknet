using System.Linq;
using pstsdk.definition.util.primitives;
using MbUnit.Framework;
using pstsdk.test.mocks.MockPropBagConstants;

namespace pstsdk.test.Integration
{
    public class EntryStreamReaderIntegrationTest
    {
        [Test]
        public void EntryStreamReader_PropertyCount_Valid()
        {
            using (var entryStreamReader = IntegrationUtil.GetEntryStreamReader())
            {
                Assert.AreEqual(entryStreamReader.PropertyIds.Count(), entryStreamReader.PropertyCount);
            }
        }

        [Test]
        public void EntryStreamReader_PropertyIds_Valid()
        {
            using (var entryStreamReader = IntegrationUtil.GetEntryStreamReader())
            {
                Assert.IsTrue(entryStreamReader.PropertyIds.Count() > StreamReaderMockConstants.ENTRY_PROPERTY_IDS_VALID_COUNT);
            }
        }



        [Test]
        public void EntryStreamReader_ReadEntry_Valid()
        {
            using (var entryStreamReader = IntegrationUtil.GetEntryStreamReader())
            {
                PropId testPropId = entryStreamReader.PropertyIds.ElementAt(StreamReaderMockConstants.SECOND_ELEMENT);
                NameId testNameId = entryStreamReader.ReadEntry(testPropId);
                Assert.AreEqual(StreamReaderMockConstants.ENTRY_READ_ENTRY_VALID_GUID_INDEX, testNameId.GuidIndex);
            }
        }

        [Test]
        public void EntryStreamReader_ReadEntry_Invalid()
        {
            using (var entryStreamReader = IntegrationUtil.GetEntryStreamReader())
            {
                PropId testPropId = new PropId { Value = StreamReaderMockConstants.ENTRY_PROP_ID_VALUE };
                NameId testNameId = entryStreamReader.ReadEntry(testPropId);
                Assert.AreEqual(StreamReaderMockConstants.ENTRY_INVALID_GUID_INDEX, testNameId.GuidIndex);
            }
        }

    }
}
