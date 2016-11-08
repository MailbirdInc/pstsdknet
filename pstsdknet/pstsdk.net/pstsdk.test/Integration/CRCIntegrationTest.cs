using System;
using System.Text;
using pstsdk.layer.util;
using MbUnit.Framework;
using pstsdk.test.mocks.MockPropBagConstants;

namespace pstsdk.test.Integration
{
    public class CRCIntegrationTest
    {
        [Test]
        public void CRC_ComputeCRC_Valid()
        {
            var namedProp = IntegrationUtil.GetMockNamedProperty();

            var bytes = Encoding.Unicode.GetBytes(namedProp.Name);
            uint test = CRC.ComputeCRC(bytes, (uint)bytes.Length);

            Assert.AreEqual(CRCMockConstants.EXPECTED_CRC, test);
        }

        [Test]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void CRC_ComputeCRC_Excessive_Length()
        {
            uint test = CRC.ComputeCRC(CRCMockConstants.BYTES, CRCMockConstants.EXCESSIVE_CRC_LENGTH);
        }

        [Test]
        public void CRC_ComputeCRC_Insufficient_Length()
        {
            var namedProp = IntegrationUtil.GetMockNamedProperty();

            var bytes = Encoding.Unicode.GetBytes(namedProp.Name);
            uint test = CRC.ComputeCRC(bytes, CRCMockConstants.INSUFFICIENT_CRC_LENGTH);

            Assert.AreEqual(CRCMockConstants.EXPECTED_INSUFFICIENT_LENGTH_CRC, test);            
        }

        [Test]
        public void CRC_ComputeCRC_Zero_Length()
        {
            uint test = CRC.ComputeCRC(CRCMockConstants.BYTES, CRCMockConstants.COMPUTE_CRC_ZERO_LENGTH);
            Assert.AreEqual(CRCMockConstants.COMPUTE_CRC_ZERO_LENGTH, test);
        }

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void CRC_ComputeCRC_Null_Bytes()
        {
            uint test = CRC.ComputeCRC(null, CRCMockConstants.COMPUTE_CRC_NULL_BYTES_LENGTH);
        }

        [Test]
        public void CRC_ComputeCRC_Null_Bytes_Zero_Length()
        {
            uint test = CRC.ComputeCRC(null, CRCMockConstants.COMPUTE_CRC_NULL_BYTES_ZERO_LENGTH);
            Assert.AreEqual(CRCMockConstants.COMPUTE_CRC_NULL_BYTES_ZERO_LENGTH, test);
        }

    }
}
