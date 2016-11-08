using System;
using System.Collections.Generic;
using System.Text;
using pstsdk.definition.util.primitives;
using System.IO;

namespace pstsdk.test.mocks.MockPropBagConstants
{
    public static class MessageMockConstants
    {
        static MessageMockConstants()
        {
            ReadPropertyValues = new Dictionary<PropId, Byte[]>
                                     {
                                         {PropId.KnownValue.PR_SUBJECT, Encoding.Unicode.GetBytes(MESSAGE_SUBJECT)},
                                         {PropId.KnownValue.PR_MESSAGE_SIZE, BitConverter.GetBytes(MESSAGE_SIZE)},
                                         {PropId.KnownValue.PidTagBody, Encoding.Unicode.GetBytes(MESSAGE_BODY_TEXT)},
                                         {
                                             PropId.KnownValue.PR_RECORD_KEY, BitConverter.GetBytes(RECORD_KEY_PROPERTY_VALUE)
                                             }
                                     };

            PropertySizeValues = new Dictionary<PropId, UInt32>
                                     {
                                         {PropId.KnownValue.PR_SUBJECT, MESSAGE_SUBJECT_SIZE},
                                         {PropId.KnownValue.PidTagBody, PID_TAG_BODY_PROPERTY_SIZE}
                                     };

            PropertyExistValues = new Dictionary<PropId, bool>
                                      {{PropId.KnownValue.PidTagBody, true}, {PropId.KnownValue.PR_SUBJECT, true}};

            PropertyTypeValues = new Dictionary<PropId, PropertyType>
                                     {
                                         {PropId.KnownValue.PidTagBody, PropertyType.KnownValue.prop_type_wstring},
                                         {PropId.KnownValue.PR_SUBJECT, PropertyType.KnownValue.prop_type_wstring}
                                     };

            PropertyStreamValues = new Dictionary<PropId, Stream>
                                       {
                                           {PropId.KnownValue.PidTagBody, Stream.Null},
                                           {PropId.KnownValue.PR_SUBJECT, new MemoryStream(ByteBuffer)}
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
        private static UInt32 PID_TAG_BODY_PROPERTY_SIZE = 1234;
        private static int RECORD_KEY_PROPERTY_VALUE = 0x0FF9;

        //MESSAGE VARIABLES
        public const String MESSAGE_SUBJECT = "RE: Please reply to this message";
        public const String MESSAGE_BODY_TEXT = "Body Text";
        public const int MESSAGE_ATTACHMENT_COUNT = 1;
        public const int MESSAGE_SIZE = 1234;
        public const UInt32 MESSAGE_SUBJECT_SIZE = 68;
        public const int MESSAGE_INVALID_PROPERTY = 0x2837;        
    }
}
