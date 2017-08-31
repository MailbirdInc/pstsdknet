using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using pstsdk.definition.ltp;
using pstsdk.definition.ndb.database;
using pstsdk.definition.util.primitives;
using pstsdk.mcpp.util.prop;

namespace pstsdk.layer.util
{
    public static class PropertyUtils
    {
        /// <summary>
        /// Performs default encoding behaviour.. if the property is typed as 'prop_type_string' it's decoded with Encoding.Default, otherwise it uses Unicode (UCS16 LE)...
        /// <para>This is not always desired, but works most of the time.</para>
        /// </summary>
        /// <param name="propBag"></param>
        /// <param name="propID"></param>
        /// <returns></returns>
        public static string GetStringProperty(IPropertyObject propBag, PropId propID)
        {
            var propType = propBag.GetPropertyType(propID);
            byte[] bytes = propBag.ReadProperty(propID);

            if(propType != PropertyType.KnownValue.prop_type_wstring &&
                propType != PropertyType.KnownValue.prop_type_string)
                throw new ArgumentException("Invalid Property Type");

            return 
                propType == PropertyType.KnownValue.prop_type_string
                ? PropertyHelper.GetEncodedStringProperty(bytes, Encoding.UTF8)
                : PropertyHelper.GetUnicodeStringProperty(bytes);
        }

        /// <summary>
        /// Removes padding characters from the subject field. Not sure why the subject field has padding characters, but this removes them... ;)
        /// </summary>
        /// <param name="rawSubjectValue"></param>
        /// <returns></returns>
        public static string RemoveSubjectPaddingCharacter(string rawSubjectValue)
        {
            return
                !string.IsNullOrEmpty(rawSubjectValue) && rawSubjectValue[0] == (char)0x01
                ? rawSubjectValue.Substring(2)
                : rawSubjectValue;
        }

        /// <summary>
        /// Generates a PST-Level EntryID from a PropertyObject and PST Store.
        /// This will not create MAPI level EntryIDs as specified in [MS-OXCDATA] section 2.2
        /// </summary>
        /// <param name="node">Mode to create EntryID from</param>
        /// <param name="database">Database to create EntryID against</param>
        /// <returns></returns>
        public static EntryID GenerateEntryID(NodeID node, IDBAccessor database)
        {
            var entryId = new byte[24];

            var messageStore = database.GetPropertyObjectByNodeId((uint)NodeID.Predefined.nid_message_store);
            var storeUid = messageStore.ReadProperty(PropId.KnownValue.PR_RECORD_KEY);

            Array.Copy(storeUid, 0, entryId, 4, storeUid.Length);

            Array.Copy(BitConverter.GetBytes(node.Value), 0, entryId, (storeUid.Length + 4), 4);

            return entryId;
        }

        public static NodeID GetNodeID(EntryID entryId, IDBAccessor database)
        {
            var nodeId = new byte[4];

            var messageStore = database.GetPropertyObjectByNodeId((uint)NodeID.Predefined.nid_message_store);
            var storeUid = messageStore.ReadProperty(PropId.KnownValue.PR_RECORD_KEY);

            Array.Copy(entryId, (storeUid.Length + 4), nodeId, 0, 4);

            return BitConverter.ToUInt32(nodeId, 0);
        }

        public static byte[][] GetMultipleBinaryValues(byte[] values)
        {
            var entries = BitConverter.ToInt32(values, 0);
            var result = new byte[entries][];

            for (int i = 0; i < entries; i++)
            {
                var entryOffset = BitConverter.ToInt32(values, 4 + i*4);
                var entryLength = (i < entries - 1) ? BitConverter.ToInt32(values, 4 + (i + 1) * 4) - entryOffset : values.Length - entryOffset;

                var entry = new byte[entryLength];
                Array.Copy(values, entryOffset, entry, 0, entryLength);
                
                result[i] = entry;
            }

            return result;
        }
    }
}
