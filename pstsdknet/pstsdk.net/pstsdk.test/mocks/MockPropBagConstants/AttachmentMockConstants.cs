using System;
using System.Collections.Generic;
using System.Text;
using pstsdk.definition.util.primitives;
using System.IO;

namespace pstsdk.test.mocks.MockPropBagConstants
{
    public static class AttachmentMockConstants
    {
        static AttachmentMockConstants()
        {
            ReadPropertyValues = new Dictionary<PropId, Byte[]>
                                     {
                                         {PropId.KnownValue.PidTagAttachDataObject, ByteBuffer},
                                         {PropId.KnownValue.PidTagAttachSize, BitConverter.GetBytes(ATTACHMENT_SIZE)},
                                         {
                                             PropId.KnownValue.PidTagAttachFilename,
                                             Encoding.Unicode.GetBytes(ATTACHMENT_FILE_NAME)
                                             },
                                         {
                                             PropId.KnownValue.PidTagAttachMethod,
                                             BitConverter.GetBytes(ATTACHMENT_PID_TAG_ATTACH_METHOD)
                                             },
                                         {
                                             PropId.KnownValue.PR_SUBJECT,
                                             Encoding.Unicode.GetBytes(ATTACHMENT_READ_PROP_SUBJECT)
                                             }
                                     };

            PropertySizeValues = new Dictionary<PropId, UInt32>
                                     {
                                         {PropId.KnownValue.PR_DISPLAY_NAME, ATTACHMENT_PROPERTY_SIZE},
                                         {PropId.KnownValue.PidTagAttachDataObject, ATTACHMENT_PROPERTY_SIZE}
                                     };

            PropertyExistValues = new Dictionary<PropId, bool>
                                      {
                                          {PropId.KnownValue.PR_DISPLAY_NAME, true},
                                          {PropId.KnownValue.PidTagAttachDataObject, true},
                                          {PropId.KnownValue.PidTagAttachSize, true},
                                          {PropId.KnownValue.PidTagAttachFilename, true},
                                          {PropId.KnownValue.PidTagAttachMethod, true}
                                      };

            PropertyTypeValues = new Dictionary<PropId, PropertyType>
                                     {
                                         {PropId.KnownValue.PR_DISPLAY_NAME, PropertyType.KnownValue.prop_type_wstring},
                                         {
                                             PropId.KnownValue.PidTagAttachFilename, PropertyType.KnownValue.prop_type_wstring
                                             }
                                     };

            PropertyStreamValues = new Dictionary<PropId, Stream>
                                       {
                                           {PropId.KnownValue.PR_DISPLAY_NAME, new MemoryStream(ByteBuffer)},
                                           {PropId.KnownValue.PidTagAttachDataObject, new MemoryStream(ByteBuffer)}
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
        private const int ATTACHMENT_PID_TAG_ATTACH_METHOD = 5;

        //ATTACHMENT VARIABLES
        public const int ATTACHMENT_BYTE_STREAM_LENGTH = 4;
        public const int ATTACHMENT_CONTENT_SIZE = 92;
        public const String ATTACHMENT_FILE_NAME = "DOC Word 2003 ASCII, languages, paragraphs.doc";
        public const UInt32 ATTACHMENT_NODE = 2;
        public const int ATTACHMENT_SIZE = 65338;
        public const int ATTACHMENT_OPEN_AS_MESSAGE_SIZE = 1234;
        public const UInt32 ATTACHMENT_PROPERTY_SIZE = 92;
        public const int ATTACHMENT_FIRST_ELEMENT = 0;
        public const int ATTACHMENT_INVALID_PROP_ID = 0x1111;
        public const int ATTACHMENT_OPEN_PROP_STREAM_VALID_LENGTH = 0;
        public const UInt32 ATTACHMENT_GET_PROP_TYPE_VALID_RESULT = 31;
        public const String ATTACHMENT_READ_PROP_SUBJECT = "Subject Text";
        public const int ATTACHMENT_PROPERTIES_COUNT = 2;        
    }
}
