using System;

namespace pstsdk.test.mocks.MockPropBagConstants
{
    public class StreamReaderMockConstants
    {
        public const int FIRST_ELEMENT = 0;
        public const int SECOND_ELEMENT = 1;

        //ENTRY STREAM READER VARIABLES
        public const ushort ENTRY_PROP_ID_VALUE = 4000;
        public const UInt32 ENTRY_INVALID_GUID_INDEX = 0;
        public const int ENTRY_PROPERTY_IDS_VALID_COUNT = 0;
        public const UInt32 ENTRY_READ_ENTRY_VALID_GUID_INDEX = 0;

        //GUID STREAM READER VARIABLES        
        public const UInt32 GUID_VALID_INDEX = 1;
        public const String GUID_VALID_GUID = "00020328-0000-0000-c000-000000000046";
        public const int GUID_INVALID_INDEX = 4000;

        //STRING STREAM READER VARIABLES
        public static String STRING_STREAM_READER_STRING_ONE = "hello";
        public static UInt32 STRING_STREAM_READER_STRING_ONE_OFFSET = 0x00;
        public static String STRING_STREAM_READER_STRING_TWO = "bcbcbc";
        public static UInt32 STRING_STREAM_READER_STRING_TWO_OFFSET = 0x18;
        public static UInt32 STRING_STREAM_READER_INVALID_OFFSET = 0x30;
    }
}
