using System;
using System.Collections.Generic;
using pstsdk.definition.ltp;
using pstsdk.definition.util.primitives;
using System.IO;
using pstsdk.definition.exception;
using pstsdk.test.mocks.MockPropBagConstants;

namespace pstsdk.test.mocks.MockPropBags
{
    public class NameIdMapMockPropBag : IPropertyObject
    {        
        public NodeID Node
        {
            get { return NodeID.make_nid(NidType.nid_type_storage, 0); }
        }

        public IEnumerable<PropId> Properties
        {
            get 
            { 
                return new List<PropId>() 
                {
                    PropId.KnownValue.PidTagNameidStreamEntry,
                    PropId.KnownValue.PidTagNameidBucketCount,
                    PropId.KnownValue.PidTagNameidStreamGuid,
                    PropId.KnownValue.PidTagNameidStreamString
                }; 
            }
        }

        public PropertyType GetPropertyType(PropId id)
        {
            if (!NameIdMapMockConstants.PropertyTypeValues.ContainsKey(id))
                throw new PstSdkException();

            return NameIdMapMockConstants.PropertyTypeValues[id];
        }

        public bool PropertyExists(PropId id)
        {
            return NameIdMapMockConstants.PropertyExistValues.ContainsKey(id);
        }

        public uint PropertySize(PropId id)
        {
            if (!NameIdMapMockConstants.PropertySizeValues.ContainsKey(id))
                throw new PstSdkException(String.Format("PropId: {0}", id));

            return NameIdMapMockConstants.PropertySizeValues[id];
        }

        public byte[] ReadProperty(PropId id)
        {
            if (!NameIdMapMockConstants.ReadPropertyValues.ContainsKey(id))                            
                throw new PstSdkException(String.Format("PropId: {0}", id));

            return NameIdMapMockConstants.ReadPropertyValues[id];
        }        

        public Stream OpenPropertyStream(PropId id)
        {
            if (!NameIdMapMockConstants.PropertyStreamValues.ContainsKey(id))                            
                throw new PstSdkException();

            return NameIdMapMockConstants.PropertyStreamValues[id].Invoke();
        }

        public void Dispose()
        {
            return;
        }
    }
}
