using System;
using System.Linq;
using MbUnit.Framework;
using pstsdk.test.mocks.MockPropBagConstants;

namespace pstsdk.test.Integration
{
    public class GuidStreamReaderIntegrationTest
    {
        [Test]
        public void GuidStreamReader_GetGuidIndex_Valid()
        {
            using (var guidStreamReader = IntegrationUtil.GetGuidStreamReader())
            {
                var index = guidStreamReader.GetGuidIndex(guidStreamReader.ReadGuid((int)StreamReaderMockConstants.GUID_VALID_INDEX));
                Assert.AreEqual(StreamReaderMockConstants.GUID_VALID_INDEX, index);
            }
        }

        //TODO: Fix this test 
        //[Test]
        //[ExpectedException(typeof(pstsdk.definition.exception.PstSdkException))]
        //public void GuidStreamReader_GetGuidIndex_Invalid()
        //{
        //    using (var pst = IntegrationUtil.GetMockPst())
        //    {
        //        using (var guidStreamReader = IntegrationUtil.GetGuidStreamReader())
        //        {
        //            var index = guidStreamReader.GetGuidIndex(pst.NameIDMap.NamedProperties.ElementAt(StreamReaderMockConstants.FIRST_ELEMENT).Guid);
        //        }
        //    }
        //}

        [Test]
        public void GuidStreamReader_ReadGuid_Valid()
        {
            using (var guidStreamReader = IntegrationUtil.GetGuidStreamReader())
            {
                Guid testGuidOne = guidStreamReader.ReadGuid(StreamReaderMockConstants.SECOND_ELEMENT);

                Guid guid = new Guid(StreamReaderMockConstants.GUID_VALID_GUID);

                Assert.AreEqual(guid, testGuidOne);
            }
        }

        [Test]
        public void GuidStreamReader_ReadGuid_Invalid()
        {
            using (var guidStreamReader = IntegrationUtil.GetGuidStreamReader())
            {
                Assert.AreEqual(new Guid(), guidStreamReader.ReadGuid(StreamReaderMockConstants.GUID_INVALID_INDEX));
            }
        }

    }
}
