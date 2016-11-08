using System;
using System.Collections.Generic;
using System.Text;
using pstsdk.definition.util.primitives;
using System.IO;

namespace pstsdk.test.mocks.MockPropBagConstants
{
    public static class MockConstants
    {
        static MockConstants()
        {
            ReadPropertyValues = new Dictionary<PropId, Byte[]>
                                     {
                                         {PropId.KnownValue.PR_SUBJECT, Encoding.Unicode.GetBytes(MESSAGE_SUBJECT)},
                                         {
                                             PropId.KnownValue.PR_RECORD_KEY, BitConverter.GetBytes(RECORD_KEY_PROPERTY_VALUE)
                                             }
                                     };

            PropertySizeValues = new Dictionary<PropId, UInt32>();

            PropertyExistValues = new Dictionary<PropId, bool>
                                      {
                                          {PropId.KnownValue.PidTagBody, true},
                                          {PropId.KnownValue.PR_SUBJECT, true},
                                          {PropId.KnownValue.PR_DISPLAY_NAME, true},
                                          {PropId.KnownValue.PidTagContentCount, true},
                                          {PropId.KnownValue.PidTagAddressType, true},
                                          {PropId.KnownValue.PR_EMAIL_ADDRESS, true},
                                          {PropId.KnownValue.PR_ACCOUNT, true},
                                          {PropId.KnownValue.PidTagRecipientDisplayName, true},
                                          {PropId.KnownValue.PidTagAttachDataObject, true},
                                          {PropId.KnownValue.PidTagAttachSize, true},
                                          {PropId.KnownValue.PidTagAttachFilename, true},
                                          {PropId.KnownValue.PidTagAssociatedContentCount, true}
                                      };


            PropertyTypeValues = new Dictionary<PropId, PropertyType>
                                     {
                                         {PropId.KnownValue.PidTagBody, PropertyType.KnownValue.prop_type_wstring},
                                         {PropId.KnownValue.PR_SUBJECT, PropertyType.KnownValue.prop_type_wstring},
                                         {PropId.KnownValue.PR_DISPLAY_NAME, PropertyType.KnownValue.prop_type_wstring},
                                         {PropId.KnownValue.PR_ACCOUNT, PropertyType.KnownValue.prop_type_wstring},
                                         {PropId.KnownValue.PidTagAddressType, PropertyType.KnownValue.prop_type_wstring},
                                         {PropId.KnownValue.PR_EMAIL_ADDRESS, PropertyType.KnownValue.prop_type_wstring},
                                         {
                                             PropId.KnownValue.PidTagRecipientDisplayName,
                                             PropertyType.KnownValue.prop_type_wstring
                                             },
                                         {
                                             PropId.KnownValue.PidTagAttachFilename, PropertyType.KnownValue.prop_type_wstring
                                             }
                                     };

            PropertyStreamValues = new Dictionary<PropId, Stream>
                                       {
                                           {PropId.KnownValue.PidTagBody, Stream.Null},
                                           {PropId.KnownValue.PR_DISPLAY_NAME, new MemoryStream(ByteBuffer)},
                                           {PropId.KnownValue.PidTagAttachDataObject, new MemoryStream(ByteBuffer)},
                                           {PropId.KnownValue.PR_SUBJECT, new MemoryStream(ByteBuffer)},
                                           {PropId.KnownValue.PidTagNameidStreamString, new MemoryStream(ByteBuffer)},
                                           {STRING_STREAM_READER_BUCKET_PROPERTY, new MemoryStream(ByteBuffer)}
                                       };
        }

        //Prop Bag Dictionaries
        public static Dictionary<PropId, Byte[]> ReadPropertyValues;
        public static Dictionary<PropId, UInt32> PropertySizeValues;
        public static Dictionary<PropId, bool> PropertyExistValues;
        public static Dictionary<PropId, PropertyType> PropertyTypeValues;
        public static Dictionary<PropId, Stream> PropertyStreamValues; 

        //Prop Bag Values
        private static readonly Byte[] ByteBuffer = BitConverter.GetBytes((UInt32)NodeID.Predefined.nid_message_store);
        private static int RECORD_KEY_PROPERTY_VALUE = 0x0FF9;  
        
        //MESSAGE VARIABLES
        public const String MESSAGE_SUBJECT = "RE: Please reply to this message";

        //STRING STREAM READER VARIABLES
        public const int STRING_STREAM_READER_BUCKET_PROPERTY = 0x1009;
    }
}
