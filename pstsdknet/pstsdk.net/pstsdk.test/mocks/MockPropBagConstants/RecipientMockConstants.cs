using System;
using System.Collections.Generic;
using System.Text;
using pstsdk.definition.util.primitives;
using System.IO;

namespace pstsdk.test.mocks.MockPropBagConstants
{
    public static class RecipientMockConstants
    {
        static RecipientMockConstants()
        {
            ReadPropertyValues = new Dictionary<PropId, Byte[]>
                                     {
                                         {PropId.KnownValue.PR_ACCOUNT, Encoding.Unicode.GetBytes(RECIPIENT_ACCOUNT_NAME)},
                                         {
                                             PropId.KnownValue.PidTagAddressType,
                                             Encoding.Unicode.GetBytes(RECIPIENT_ADDRESS_TYPE)
                                             },
                                         {
                                             PropId.KnownValue.PR_EMAIL_ADDRESS,
                                             Encoding.Unicode.GetBytes(RECIPIENT_EMAIL_ADDRESS)
                                             },
                                         {
                                             PropId.KnownValue.PidTagRecipientDisplayName,
                                             Encoding.Unicode.GetBytes(RECIPIENT_DISPLAY_NAME)
                                             }
                                     };

            PropertySizeValues = new Dictionary<PropId, UInt32>
                                     {{PropId.KnownValue.PidTagRecipientDisplayName, RECIPIENT_PROPERTY_SIZE}};

            PropertyExistValues = new Dictionary<PropId, bool>
                                      {
                                          {PropId.KnownValue.PidTagAddressType, true},
                                          {PropId.KnownValue.PR_EMAIL_ADDRESS, true},
                                          {PropId.KnownValue.PR_ACCOUNT, true},
                                          {PropId.KnownValue.PidTagRecipientDisplayName, true}
                                      };

            PropertyTypeValues = new Dictionary<PropId, PropertyType>
                                     {
                                         {PropId.KnownValue.PR_ACCOUNT, PropertyType.KnownValue.prop_type_wstring},
                                         {PropId.KnownValue.PidTagAddressType, PropertyType.KnownValue.prop_type_wstring},
                                         {PropId.KnownValue.PR_EMAIL_ADDRESS, PropertyType.KnownValue.prop_type_wstring},
                                         {
                                             PropId.KnownValue.PidTagRecipientDisplayName,
                                             PropertyType.KnownValue.prop_type_wstring
                                             }
                                     };

            PropertyStreamValues = new Dictionary<PropId, Stream>
                                       {{PropId.KnownValue.PidTagRecipientDisplayName, new MemoryStream(ByteBuffer)}};
        }

        //Prop Bag Dictionaries
        public static Dictionary<PropId, Byte[]> ReadPropertyValues;
        public static Dictionary<PropId, UInt32> PropertySizeValues;
        public static Dictionary<PropId, bool> PropertyExistValues;
        public static Dictionary<PropId, PropertyType> PropertyTypeValues;
        public static Dictionary<PropId, Stream> PropertyStreamValues; 

        //Prop Bag Values
        private static readonly Byte[] ByteBuffer = BitConverter.GetBytes((UInt32)NodeID.Predefined.nid_message_store);

        //RECIPIENT VARIABLES
        public const String RECIPIENT_ACCOUNT_NAME = "Account Name";
        public const String RECIPIENT_EMAIL_ADDRESS = "aaron.shaver@discover-e-legal.com";
        public const String RECIPIENT_ADDRESS_TYPE = "EX";
        public const String RECIPIENT_NAME = "Aaron Shaver";
        public const String RECIPIENT_DISPLAY_NAME = "Aaron Shaver";
        public const int RECIPIENT_INVALID_PROP_ID = 0x51F6;
        public const int RECIPIENT_VALID_PROP_ID = 0x5FF6;
        public const UInt32 RECIPIENT_PROPERTY_SIZE = 4;
        public const UInt32 RECIPIENT_VALID_NODE = (UInt32)NidType.nid_type_recipient_table;
        public const int RECIPIENT_OPEN_PROPERTY_STREAM_LENGTH = 0;


    }
}
