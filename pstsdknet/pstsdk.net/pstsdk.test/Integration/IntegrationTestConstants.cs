using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using pstsdk.definition.util.primitives;
using System.IO;

namespace pstsdk.test.Integration
{
    public static class IntegrationTestConstants
    {
        static IntegrationTestConstants()
        {
            ReadPropertyValues = new Dictionary<PropId, Byte[]>();
            ReadPropertyValues.Add(PropId.KnownValue.PR_SUBJECT, Encoding.Unicode.GetBytes(MESSAGE_SUBJECT));
            ReadPropertyValues.Add(PropId.KnownValue.PR_MESSAGE_SIZE, BitConverter.GetBytes(MESSAGE_SIZE));
            ReadPropertyValues.Add(PropId.KnownValue.PidTagBody, Encoding.Unicode.GetBytes(MESSAGE_BODY_TEXT));
            ReadPropertyValues.Add(PropId.KnownValue.PR_RECORD_KEY, BitConverter.GetBytes(RECORD_KEY_PROPERTY_VALUE));
            ReadPropertyValues.Add(PropId.KnownValue.PR_DISPLAY_NAME, Encoding.Unicode.GetBytes(FOLDER_VALID_SUBFOLDER));
            ReadPropertyValues.Add(PropId.KnownValue.PidTagContentCount, BitConverter.GetBytes(FOLDER_VALID_MESSAGE_COUNT));
            ReadPropertyValues.Add(PropId.KnownValue.PR_ACCOUNT, Encoding.Unicode.GetBytes(RECIPIENT_ACCOUNT_NAME));
            ReadPropertyValues.Add(PropId.KnownValue.PidTagAddressType, Encoding.Unicode.GetBytes(RECIPIENT_ADDRESS_TYPE));
            ReadPropertyValues.Add(PropId.KnownValue.PR_EMAIL_ADDRESS, Encoding.Unicode.GetBytes(RECIPIENT_EMAIL_ADDRESS));
            ReadPropertyValues.Add(PropId.KnownValue.PidTagRecipientDisplayName, Encoding.Unicode.GetBytes(RECIPIENT_DISPLAY_NAME));
            ReadPropertyValues.Add(PropId.KnownValue.PidTagAttachDataObject, byteBuffer);
            ReadPropertyValues.Add(PropId.KnownValue.PidTagAttachSize, BitConverter.GetBytes(ATTACHMENT_SIZE));
            ReadPropertyValues.Add(PropId.KnownValue.PidTagAttachFilename, Encoding.Unicode.GetBytes(ATTACHMENT_FILE_NAME));
            ReadPropertyValues.Add(PropId.KnownValue.PidTagAssociatedContentCount, BitConverter.GetBytes(FOLDER_ASSOCIATED_MESSAGE_COUNT));

            PropertySizeValues = new Dictionary<PropId, UInt32>();
            PropertySizeValues.Add(PropId.KnownValue.PR_SUBJECT, MESSAGE_SUBJECT_SIZE);
            PropertySizeValues.Add(PropId.KnownValue.PidTagBody, PID_TAG_BODY_PROPERTY_SIZE);
            PropertySizeValues.Add(RECIPIENT_VALID_PROP_ID, RECIPIENT_PROPERTY_SIZE);
            PropertySizeValues.Add(PropId.KnownValue.PR_DISPLAY_NAME, ATTACHMENT_PROPERTY_SIZE); 
            PropertySizeValues.Add(PropId.KnownValue.PidTagAttachDataObject, ATTACHMENT_PROPERTY_SIZE);

            PropertyExistValues = new Dictionary<PropId, bool>();
            PropertyExistValues.Add(PropId.KnownValue.PidTagBody, true);
            PropertyExistValues.Add(PropId.KnownValue.PR_SUBJECT, true);
            PropertyExistValues.Add(PropId.KnownValue.PR_DISPLAY_NAME, true);
            PropertyExistValues.Add(PropId.KnownValue.PidTagContentCount, true);
            PropertyExistValues.Add(PropId.KnownValue.PidTagAddressType, true);
            PropertyExistValues.Add(PropId.KnownValue.PR_EMAIL_ADDRESS, true);
            PropertyExistValues.Add(PropId.KnownValue.PR_ACCOUNT, true);
            PropertyExistValues.Add(PropId.KnownValue.PidTagRecipientDisplayName, true);
            PropertyExistValues.Add(PropId.KnownValue.PidTagAttachDataObject, true);
            PropertyExistValues.Add(PropId.KnownValue.PidTagAttachSize, true);
            PropertyExistValues.Add(PropId.KnownValue.PidTagAttachFilename, true);
            PropertyExistValues.Add(PropId.KnownValue.PidTagAssociatedContentCount, true);
            
            PropertyTypeValues = new Dictionary<PropId, PropertyType>();
            PropertyTypeValues.Add(PropId.KnownValue.PidTagBody, PropertyType.KnownValue.prop_type_wstring);
            PropertyTypeValues.Add(PropId.KnownValue.PR_SUBJECT, PropertyType.KnownValue.prop_type_wstring);
            PropertyTypeValues.Add(PropId.KnownValue.PR_DISPLAY_NAME, PropertyType.KnownValue.prop_type_wstring);
            PropertyTypeValues.Add(PropId.KnownValue.PR_ACCOUNT, PropertyType.KnownValue.prop_type_wstring);
            PropertyTypeValues.Add(PropId.KnownValue.PidTagAddressType, PropertyType.KnownValue.prop_type_wstring);
            PropertyTypeValues.Add(PropId.KnownValue.PR_EMAIL_ADDRESS, PropertyType.KnownValue.prop_type_wstring);
            PropertyTypeValues.Add(PropId.KnownValue.PidTagRecipientDisplayName, PropertyType.KnownValue.prop_type_wstring);
            PropertyTypeValues.Add(PropId.KnownValue.PidTagAttachFilename, PropertyType.KnownValue.prop_type_wstring);


            PropertyStreamValues = new Dictionary<PropId, Stream>();
            PropertyStreamValues.Add(PropId.KnownValue.PidTagBody, Stream.Null);
            PropertyStreamValues.Add(RECIPIENT_VALID_PROP_ID, Stream.Null);
            PropertyStreamValues.Add(PropId.KnownValue.PR_DISPLAY_NAME, new MemoryStream(byteBuffer));
            PropertyStreamValues.Add(PropId.KnownValue.PidTagAttachDataObject, new MemoryStream(byteBuffer));
            PropertyStreamValues.Add(PropId.KnownValue.PR_SUBJECT, new MemoryStream(byteBuffer));
        }

        //Prop Bag Dictionaries
        public static Dictionary<PropId, Byte[]> ReadPropertyValues;
        public static Dictionary<PropId, UInt32> PropertySizeValues;
        public static Dictionary<PropId, bool> PropertyExistValues;
        public static Dictionary<PropId, PropertyType> PropertyTypeValues;
        public static Dictionary<PropId, Stream> PropertyStreamValues; 

        //Prop Bag Values
        private static Byte[] byteBuffer = { 1, 2, 3, 4 };
        private static UInt32 PID_TAG_BODY_PROPERTY_SIZE = 1234;
        private static int RECORD_KEY_PROPERTY_VALUE = 0x0FF9;

        //ATTACHMENT VARIABLES
        public const int ATTACHMENT_BYTE_STREAM_LENGTH = 4;
        public const int ATTACHMENT_CONTENT_SIZE = 92;
        public const String ATTACHMENT_FILE_NAME = "DOC Word 2003 ASCII, languages, paragraphs.doc";
        public const UInt32 ATTACHMENT_NODE = 2;
        public const int ATTACHMENT_SIZE = 65338;
        public const int ATTACHMENT_OPEN_AS_MESSAGE_SIZE = 7816;
        public const UInt32 ATTACHMENT_PROPERTY_SIZE = 92;

        //CRC VARIABLES
        public const UInt32 EXPECTED_CRC = 3858796389;
        public const UInt32 EXCESSIVE_CRC_LENGTH = 5;
        public const UInt32 INSUFFICIENT_CRC_LENGTH = 2;
        public const UInt32 EXPECTED_INSUFFICIENT_LENGTH_CRC = 1322268772;
        
        //MESSAGE VARIABLES
        public const String MESSAGE_SUBJECT = "RE: Please reply to this message";
        public const String MESSAGE_BODY_TEXT = "Body Text";
        public const int MESSAGE_ATTACHMENT_COUNT = 1;
        public const int MESSAGE_SIZE = 1234;
        public const UInt32 MESSAGE_SUBJECT_SIZE = 68;
        public const int MESSAGE_INVALID_PROPERTY = 0x0004; 
        
        //ENTRY STREAM READER VARIABLES
        public const ushort ENTRY_PROP_ID_VALUE = 4000;
        public const UInt32 ENTRY_INVALID_GUID_INDEX = 0; 
        
        //FOLDER VARIABLES
        public const int FOLDER_VALID_PROPERTY_TYPE = 31;
        public const int FOLDER_INVALID_PROP_ID = 4;
        public const String FOLDER_VALID_SUBFOLDER = "Inbox";
        public const String FOLDER_INVALID_SUBFOLDER = "Incorrect";
        public const UInt32 FOLDER_VALID_PROPERTY_SIZE = 4;
        public const int FOLDER_VALID_READ_PROPERTY = 82;
        public const int FOLDER_VALID_MESSAGE_COUNT = 2;
        public const int FOLDER_ASSOCIATED_MESSAGE_COUNT = 0;
        public const UInt32 FOLDER_VALID_NODE_ID = (UInt32)NodeID.Predefined.nid_root_folder;
        public const Byte FOLDER_VALID_BYTE = 113;
        public const UInt32 FOLDER_VALID_NODE = 2;
        public const int FOLDER_VALID_PROPERTY = 13826;
        public const UInt32 FOLDER_VALID_NODE2 = 4;
        public const UInt32 FOLDER_MESSAGE_NODE_VALUE = (UInt32)NidType.nid_type_message;

        //GUID STREAM READER VARIABLES
        public const UInt32 GUID_VALID_INDEX = 1;
        public const String GUID_VALID_GUID = "00020328-0000-0000-c000-000000000046";
        public const int GUID_INVALID_INDEX = 4000;

        //NAMED ID MAP VARIABLES
        public const String NAMED_IDMAP_VALID_GUID = "0006200200000000c000000000000046";
        public const int NAMED_IDMAP_VALID_PROP_ID = 0x8205;
        public const int NAMED_IDMAP_BUCKET_COUNT = 251;
        public const int NAMED_IDMAP_PROPERTY_COUNT = 155;
        public const int NAMED_IDMAP_INVALID_PROPID = 0x1111;
        public const String NAMED_IDMAP_VALID_GUID2 = "0002032900000000c000000000000046";
        public const UInt32 NAMED_IDMAP_VALID_NAMED_PROPERTY = 33285;
        public const UInt32 NAMED_IDMAP_VALID_PROPERTY = 32768;
        public const String NAMED_IDMAP_VALID_NAME = "http://schemas.microsoft.com/outlook/spoofingstamp";

        //NAMED PROPERTY VARIABLES
        public const String NAMED_PROPERTY_VALID_GUID = "0002038600000000c000000000000046";
        public const String NAMED_PROPERTY_VALID_NAME = "content-class";
        public const UInt32 NAMED_PROPERTY_VALID_ID = 0;

        //PROPERTY UTILS VARIABLES
        public const int PROPERTY_UTILS_VALID_NODE = 2097252;
        public const int PROPERTY_UTILS_INVALID_NODE = 111111;

        //PST VARIABLES
        public const String PST_NAME = "Personal Folders";
        public const int PST_MESSAGE_COUNT = 28;
        public const int PST_PROPERTIES_COUNT = 13;
        public const int PST_INVALID_PROP_ID = 1234;
        public const int PST_FOLDERS_COUNT = 6;

        //RECIPIENT VARIABLES
        public const String RECIPIENT_ACCOUNT_NAME = "Account Name";
        public const String RECIPIENT_EMAIL_ADDRESS = "aaron.shaver@discover-e-legal.com";
        public const String RECIPIENT_ADDRESS_TYPE = "EX";
        public const String RECIPIENT_NAME = "Aaron Shaver";
        public const UInt32 RECIPIENT_VALID_NODE = (UInt32)NidType.nid_type_folder;
        public const int RECIPIENT_VALID_PROP_ID = 0x5FF6;
        public const int RECIPIENT_INVALID_PROP_ID = 0x51F6;
        public const String RECIPIENT_DISPLAY_NAME = "Aaron Shaver";
        public const UInt32 RECIPIENT_PROPERTY_SIZE = 4;

        //STRING STREAM READER VARIABLES
        public const int STRING_STREAM_READER_BUCKET_PROPERTY = 0x1009;

        //SEARCH FOLDER VARIABLES

    }
}
