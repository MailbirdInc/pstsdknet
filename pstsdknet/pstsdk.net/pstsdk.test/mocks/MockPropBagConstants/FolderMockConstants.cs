using System;
using System.Collections.Generic;
using System.Text;
using pstsdk.definition.util.primitives;
using System.IO;

namespace pstsdk.test.mocks.MockPropBagConstants
{
    public static class FolderMockConstants
    {
        static FolderMockConstants()
        {
            ReadPropertyValues = new Dictionary<PropId, Byte[]>
                                     {
                                         {PropId.KnownValue.PR_SUBJECT, Encoding.Unicode.GetBytes(FOLDER_MESSAGE_SUBJECT)},
                                         {
                                             PropId.KnownValue.PR_DISPLAY_NAME,
                                             Encoding.Unicode.GetBytes(FOLDER_VALID_SUBFOLDER)
                                             },
                                         {
                                             PropId.KnownValue.PidTagContentCount,
                                             BitConverter.GetBytes(FOLDER_VALID_MESSAGE_COUNT)
                                             },
                                         {
                                             PropId.KnownValue.PidTagAssociatedContentCount,
                                             BitConverter.GetBytes(FOLDER_ASSOCIATED_MESSAGE_COUNT)
                                             }
                                     };

            PropertySizeValues = new Dictionary<PropId, UInt32>
                                     {{PropId.KnownValue.PR_SUBJECT, FOLDER_MESSAGE_SUBJECT_SIZE}};

            PropertyExistValues = new Dictionary<PropId, bool>
                                      {
                                          {PropId.KnownValue.PR_SUBJECT, true},
                                          {PropId.KnownValue.PR_DISPLAY_NAME, true},
                                          {PropId.KnownValue.PidTagContentCount, true}
                                      };

            PropertyTypeValues = new Dictionary<PropId, PropertyType>
                                     {
                                         {PropId.KnownValue.PR_SUBJECT, PropertyType.KnownValue.prop_type_wstring},
                                         {PropId.KnownValue.PR_DISPLAY_NAME, PropertyType.KnownValue.prop_type_wstring}
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
        
        //FOLDER VARIABLES
        public const int FOLDER_FIRST_ELEMENT = 0;
        public const int FOLDER_VALID_PROPERTY_TYPE = 31;
        public const int FOLDER_INVALID_PROP_ID = 0x2389;
        public const String FOLDER_VALID_SUBFOLDER = "Inbox";
        public const String FOLDER_INVALID_SUBFOLDER = "Incorrect";
        public const UInt32 FOLDER_VALID_PROPERTY_SIZE = 4;
        public const int FOLDER_VALID_READ_PROPERTY = 82;
        public const int FOLDER_VALID_MESSAGE_COUNT = 2;
        public const int FOLDER_ASSOCIATED_MESSAGE_COUNT = 0;
        public const UInt32 FOLDER_VALID_NODE_ID = (UInt32)NidType.nid_type_folder;
        public const UInt32 FOLDER_DIFFERENT_VALID_NODE_ID = (UInt32)NidType.nid_type_none;
        public const Byte FOLDER_VALID_BYTE = 113;
        public const int FOLDER_VALID_PROPERTY = 13826;
        public const UInt32 FOLDER_MESSAGE_NODE_VALUE = (UInt32)NidType.nid_type_message;
        public const UInt32 FOLDER_MESSAGE_SUBJECT_SIZE = 68;
        public const String FOLDER_MESSAGE_SUBJECT = "RE: Please reply to this message";
        public const int FOLDER_OPEN_PROPERTY_STREAM_VALID_LENGTH = 0;
    }
}
