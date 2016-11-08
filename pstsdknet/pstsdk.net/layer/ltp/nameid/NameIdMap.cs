using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using pstsdk.definition.exception;
using pstsdk.definition.ltp;
using pstsdk.definition.ltp.nameid;
using pstsdk.definition.ndb.database;
using pstsdk.definition.util.primitives;
using pstsdk.layer.util;

namespace pstsdk.layer.ltp.nameid
{
    public class NameIdMap : INameIDMap
    {
        private IDBAccessor _database;
        private IPropertyObject _propBag;

        public int BucketCount { get; private set; }

        public IEnumerable<INamedProperty> NamedProperties
        {
            get
            {
                var propList = new List<INamedProperty>();
                foreach (var prop in Properties)
                {
                    propList.Add(Lookup(prop));
                }

                return propList;
            }
        }

        #region INameIDMap Members

        public IPropertyObject PropertyBag
        {
            get { return _propBag; }
        }

        public IEnumerable<PropId> Properties
        {
            get
            {
                using (var entryStream = new EntryStreamReader(_propBag.OpenPropertyStream(PropId.KnownValue.PidTagNameidStreamEntry)))
                    return entryStream.PropertyIds;
            }
        }

        public int PropertyCount
        {
            get
            {
                using (var entryStream = new EntryStreamReader(_propBag.OpenPropertyStream(PropId.KnownValue.PidTagNameidStreamEntry)))
                    return entryStream.PropertyCount;
            }
        }

        public NameIdMap(IDBAccessor database)
        {
            _database = database;
            _propBag = database.GetPropertyObjectByNodeId((uint)NodeID.Predefined.nid_name_id_map);

            BucketCount = BitConverter.ToInt32(_propBag.ReadProperty(PropId.KnownValue.PidTagNameidBucketCount), 0);
        }

        public bool NameExists(Guid guid, string name)
        {
            return NamedPropertyExists(new NamedProperty(guid, name));
        }

        public bool IdExists(Guid guid, int id)
        {
            return NamedPropertyExists(new NamedProperty(guid, (uint)id));
        }

        public bool NamedPropertyExists(INamedProperty namedProperty)
        {
            try
            {
                Lookup(namedProperty);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool PropertyExists(PropId id)
        {
            if(id >= 0x8000)
                return (id - 0x8000) < PropertyCount;

            return true;
        }

        public PropId Lookup(Guid guid, string name)
        {
            return Lookup(new NamedProperty(guid, name));
        }

        public PropId Lookup(Guid guid, int id)
        {
            return Lookup(new NamedProperty(guid, (uint) id));
        }

        public PropId Lookup(INamedProperty namedProperty)
        {
            ushort guidIndex;

            try
            {
                guidIndex = GetGuidIndex(namedProperty.Guid);
            }
            catch (PstSdkException ex)
            {
                throw new PstSdkException("Unable to lookup Guid, was not found in guid stream", ex);
            }

            //If this is a MAPI Guid, handle accordingly
            if(guidIndex == 1)
            {
                if(namedProperty.IsString || namedProperty.ID >= 0x8000)
                    throw new PstSdkException("Could not lookup named property.  Invalid NamedProperty");

                return guidIndex;
            }

            uint hashValue = ComputeHashValue(guidIndex, namedProperty);
            uint hashBase = ComputeHashBase(namedProperty);

            if (!_propBag.PropertyExists(GetBucketProperty(hashValue)))
                throw new PstSdkException("Could not find property in Hash Bucket");

            using(var stream = _propBag.OpenPropertyStream(GetBucketProperty(hashValue)))
            {
                var bytes = new byte[NameId.NameIdSize];
                while(stream.Read(bytes, 0, NameId.NameIdSize) != 0)
                {
                    NameId nameId = bytes;
                    if( (nameId.Id == hashBase) && 
                        (nameId.IsString == namedProperty.IsString) &&
                        (nameId.GuidIndex == guidIndex))
                    {
                        if(nameId.IsString)
                        {
                            if(string.Compare(BuildNamedProperty((PropId)nameId.PropertyIndex).Name, namedProperty.Name) != 0)
                                continue;
                        }

                        return (PropId) (nameId.PropertyIndex + 0x8000) ;
                    }
                }
            }

            throw new PstSdkException("Could not find Property in NamedPropertyMap!");
        }

        public INamedProperty Lookup(PropId id)
        {
            if (id < 0x8000)
                return new NamedProperty(GuidStreamReader.MapiGuid, id);

            var index = id - 0x8000;

            if (index > PropertyCount)
                throw new PstSdkException("Property Not Found!");

            return BuildNamedProperty((PropId)index);
        }

        #endregion

        #region Helper Functions

        private NamedProperty BuildNamedProperty(PropId id)
        {
            using(var entryStream = new EntryStreamReader(_propBag.OpenPropertyStream(PropId.KnownValue.PidTagNameidStreamEntry)))
                return BuildNamedProperty(entryStream.ReadEntry(id));
        }

        private NamedProperty BuildNamedProperty(NameId id)
        {
            if (id.IsString)
                return new NamedProperty(ReadGuid(id), ReadString(id));

            return new NamedProperty(ReadGuid(id), id.Id);
        }

        private Guid ReadGuid(NameId id)
        {
            using(var guidStream = new GuidStreamReader(_propBag.OpenPropertyStream(PropId.KnownValue.PidTagNameidStreamGuid)))
                return guidStream.ReadGuid((int)id.GuidIndex);
        }

        private string ReadString(NameId id)
        {
            using(var stringStream = new StringStreamReader(_propBag.OpenPropertyStream(PropId.KnownValue.PidTagNameidStreamString)))
                return stringStream.ReadString(id.Id);
        }

        private ushort GetGuidIndex(Guid guid)
        {
            using(var guidStream = new GuidStreamReader(_propBag.OpenPropertyStream(PropId.KnownValue.PidTagNameidStreamGuid)))
                return guidStream.GetGuidIndex(guid);
        }

        private PropId GetBucketProperty(uint hashValue)
        {
            return (PropId) ((hashValue%BucketCount) + 0x1000);
        }

        private static uint ComputeHashBase(INamedProperty n)
        {
            if (n.IsString)
            {
                var bytes = Encoding.Unicode.GetBytes(n.Name);
                return CRC.ComputeCRC(bytes, (uint)bytes.Length);
            }

            return n.ID;
        }

        private static uint ComputeHashValue(ushort guidIndex, INamedProperty n)
        {
            return (uint)(n.IsString ? ((guidIndex << 1) | 1) : (guidIndex << 1)) ^ ComputeHashBase(n);
        }

        #endregion
    }
}
