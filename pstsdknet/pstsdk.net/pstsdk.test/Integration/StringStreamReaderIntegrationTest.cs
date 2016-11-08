using System;
using MbUnit.Framework;
using pstsdk.test.mocks.MockPropBagConstants;


namespace pstsdk.test.Integration
{
    public class StringStreamReaderIntegrationTest
    {

        [Test]
        public void StringStreamReader_ReadString_Valid()
        {
            using (var strStreamReader = IntegrationUtil.GetStringStreamReader())
            {
                String test = strStreamReader.ReadString(StreamReaderMockConstants.STRING_STREAM_READER_STRING_ONE_OFFSET);

                Assert.IsFalse(String.IsNullOrEmpty(test));
                Assert.AreEqual(StreamReaderMockConstants.STRING_STREAM_READER_STRING_ONE, test);

                test = strStreamReader.ReadString(StreamReaderMockConstants.STRING_STREAM_READER_STRING_TWO_OFFSET);
                Assert.IsFalse(String.IsNullOrEmpty(test));
                Assert.AreEqual(StreamReaderMockConstants.STRING_STREAM_READER_STRING_TWO, test);
            }
        }

        [Test]
        public void StringStreamReader_ReadString_Invalid()
        {
            using (var strStreamReader = IntegrationUtil.GetStringStreamReader())
            {
                String test = strStreamReader.ReadString(StreamReaderMockConstants.STRING_STREAM_READER_INVALID_OFFSET);
                Assert.IsTrue(String.IsNullOrEmpty(test));
            }
        }        

       
    }
}
