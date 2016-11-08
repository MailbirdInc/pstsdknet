using System;
using System.Collections.Generic;
using pstsdk.definition.util.primitives;
using System.IO;

namespace pstsdk.test.mocks.MockPropBagConstants
{
    public static class NameIdMapMockConstants
    {
        static NameIdMapMockConstants()
        {
            ReadPropertyValues = new Dictionary<PropId, Byte[]>
                                     {{PropId.KnownValue.PidTagNameidBucketCount, BitConverter.GetBytes(0xFB)}};

            PropertySizeValues = new Dictionary<PropId, UInt32>();

            PropertyExistValues = new Dictionary<PropId, bool>
                                      {
                                          {NAMED_IDMAP_VALID_PROP_ID, true},
                                          {NAMED_IDMAP_VALID_PROP_ID_BUCKET_PROP_ID, true}
                                      };

            PropertyTypeValues = new Dictionary<PropId, PropertyType>();

            PropertyStreamValues = new Dictionary<PropId, Func<Stream>>
                                       {
                                           {
                                               PropId.KnownValue.PidTagNameidStreamEntry,
                                               () => new MemoryStream(NameIdConstants.EntryStreamBytes)
                                               },
                                           {
                                               PropId.KnownValue.PidTagNameidStreamGuid,
                                               () => new MemoryStream(NameIdConstants.GuidStreamBytes)
                                               },
                                           {
                                               PropId.KnownValue.PidTagNameidStreamString,
                                               () => new MemoryStream(NameIdConstants.StringStreamBytes)
                                               },
                                           {
                                               NameIdMapMockConstants.NAMED_IDMAP_VALID_PROP_ID_BUCKET_PROP_ID,
                                               () => new MemoryStream(NameIdConstants.EntryStreamBytes)
                                               }
                                       };
        }

        //Prop Bag Dictionaries
        public static Dictionary<PropId, Byte[]> ReadPropertyValues;
        public static Dictionary<PropId, UInt32> PropertySizeValues;
        public static Dictionary<PropId, bool> PropertyExistValues;
        public static Dictionary<PropId, PropertyType> PropertyTypeValues;
        public static Dictionary<PropId, Func<Stream>> PropertyStreamValues; 

        //NameIdMap VARIABLES
        public const String NAMED_IDMAP_VALID_GUID = "c314e04cbb0a4d4ab8830b77e792723a";
        public const int NAMED_IDMAP_VALID_PROP_ID = 0x8003;
        public const int NAMED_IDMAP_VALID_PROP_ID_BUCKET_PROP_ID = 0x108f;
        public const int NAMED_IDMAP_INVALID_PROP_ID = 0x9999;
        public const int NAMED_IDMAP_BUCKET_COUNT = 0xFB;
        public const int NAMED_IDMAP_PROPERTY_COUNT = 6;
        public const int NAMED_IDMAP_INVALID_PROPID = 0x1111;
        public const String NAMED_IDMAP_VALID_GUID2 = "0002032900000000c000000000000046";
        public const UInt32 NAMED_IDMAP_VALID_NAMED_PROPERTY = 5762;
        public const UInt32 NAMED_IDMAP_VALID_PROPERTY = 32768;
        public const String NAMED_IDMAP_VALID_NAME = "http://schemas.microsoft.com/outlook/spoofingstamp";

        public const int LOOK_UP_VALID_TEST_PROP_ID = 0x8205;
        public const int NAMED_PROPERTY_EXISTS_VALID_PROP_ID = 0x8000;
        public const int NAME_ID_MAP_FIRST_ELEMENT = 0;
    }
}
