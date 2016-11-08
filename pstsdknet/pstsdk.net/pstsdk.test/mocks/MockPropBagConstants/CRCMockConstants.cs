using System;

namespace pstsdk.test.mocks.MockPropBagConstants
{
    public static class CRCMockConstants
    {
        //CRC VARIABLES
        public const UInt32 EXPECTED_CRC = 2094778303;
        public const UInt32 EXCESSIVE_CRC_LENGTH = 5;
        public const UInt32 INSUFFICIENT_CRC_LENGTH = 2;
        public const UInt32 EXPECTED_INSUFFICIENT_LENGTH_CRC = 1861902987;
        public static byte[] BYTES = { 1, 2 };
        public const UInt32 COMPUTE_CRC_ZERO_LENGTH = 0;
        public const UInt32 COMPUTE_CRC_NULL_BYTES_LENGTH = 1;
        public const UInt32 COMPUTE_CRC_NULL_BYTES_ZERO_LENGTH = 0;
    }
}
