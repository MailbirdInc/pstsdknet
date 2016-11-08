using System;
using System.Collections.Generic;
using System.Text;
using pstsdk.definition.util.primitives;
using System.IO;

namespace pstsdk.test.mocks.MockPropBagConstants
{
    public static class SearchFolderMockConstants
    {
        static SearchFolderMockConstants()
        {
            ReadPropertyValues = new Dictionary<PropId, Byte[]>
                                     {
                                         {PropId.KnownValue.PR_SUBJECT, Encoding.Unicode.GetBytes(MESSAGE_SUBJECT)},
                                         {
                                             PropId.KnownValue.PR_DISPLAY_NAME,
                                             Encoding.Unicode.GetBytes(FOLDER_VALID_SUBFOLDER)
                                             },
                                         {
                                             PropId.KnownValue.PidTagContentCount,
                                             BitConverter.GetBytes(FOLDER_VALID_MESSAGE_COUNT)
                                             }
                                     };

            PropertySizeValues = new Dictionary<PropId, UInt32>
                                     {{PropId.KnownValue.PR_DISPLAY_NAME, SEARCH_FOLDER_PROPERTY_SIZE}};

            PropertyExistValues = new Dictionary<PropId, bool>
                                      {
                                          {PropId.KnownValue.PR_DISPLAY_NAME, true},
                                          {PropId.KnownValue.PidTagContentCount, true}
                                      };


            PropertyTypeValues = new Dictionary<PropId, PropertyType>
                                     {
                                         {PropId.KnownValue.PR_SUBJECT, PropertyType.KnownValue.prop_type_wstring},
                                         {PropId.KnownValue.PR_DISPLAY_NAME, PropertyType.KnownValue.prop_type_wstring},
                                         {PropId.KnownValue.PR_EMAIL_ADDRESS, PropertyType.KnownValue.prop_type_wstring}
                                     };

            PropertyStreamValues = new Dictionary<PropId, Stream>
                                       {{PropId.KnownValue.PR_SUBJECT, new MemoryStream(ByteBuffer)}};
        }

        //Prop Bag Dictionaries
        public static Dictionary<PropId, Byte[]> ReadPropertyValues;
        public static Dictionary<PropId, UInt32> PropertySizeValues;
        public static Dictionary<PropId, bool> PropertyExistValues;
        public static Dictionary<PropId, PropertyType> PropertyTypeValues;
        public static Dictionary<PropId, Stream> PropertyStreamValues; 

        //Prop Bag Values
        private static readonly Byte[] ByteBuffer = BitConverter.GetBytes((UInt32)NodeID.Predefined.nid_message_store);

        //SEARCH FOLDER VARIABLES
        private const String MESSAGE_SUBJECT = "RE: Please reply to this message";
        private const String FOLDER_VALID_SUBFOLDER = "Inbox";
        private const int FOLDER_VALID_MESSAGE_COUNT = 2;

        public const UInt32 SEARCH_FOLDER_PROPERTY_SIZE = 92;
        public const int SEARCH_FOLDER_DB_CONTEXT_NODE_VALUE = 290;
        public const int SEARCH_FOLDER_FIRST_ELEMENT = 0;
        public const int SEARCH_FOLDER_SECOND_ELEMENT = 1;
        public const int SEARCH_FOLDER_PROPERTY_PROP_ID_VALUE = 55;
        public const int SEARCH_FOLDER_PROPERTY_PROP_TYPE_VALUE = 31;
        public const String SEARCH_FOLDER_NAME = "Inbox";
        public const int SEARCH_FOLDER_INVALID_PROP_ID = 0x2389;
        public const int SEARCH_FOLDER_PROPERTY_STREAM_LENGTH = 0;
        public const int SEARCH_FOLDER_READ_PROPERTY_RESULT = 82;
    }
}
