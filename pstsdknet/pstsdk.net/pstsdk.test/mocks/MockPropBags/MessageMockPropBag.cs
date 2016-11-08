using System;
using System.Collections.Generic;
using pstsdk.definition.ltp;
using pstsdk.definition.util.primitives;
using System.IO;
using pstsdk.definition.exception;
using pstsdk.test.mocks.MockPropBagConstants;

namespace pstsdk.test.mocks.MockPropBags
{
    public class MessageMockPropBag : IPropertyObject
    {        
        public NodeID Node
        {
            get { return NodeID.make_nid(NidType.nid_type_message, 0); }
        }

        public IEnumerable<PropId> Properties
        {
            get 
            { 
                return new List<PropId>() 
                {
                    PropId.KnownValue.PR_SUBJECT,
                    PropId.KnownValue.PR_DISPLAY_NAME
                }; 
            }
        }

        public PropertyType GetPropertyType(PropId id)
        {
            if (!MessageMockConstants.PropertyTypeValues.ContainsKey(id))
                throw new PstSdkException();

            return MessageMockConstants.PropertyTypeValues[id];
        }

        public bool PropertyExists(PropId id)
        {
            return MessageMockConstants.PropertyExistValues.ContainsKey(id);
        }

        public uint PropertySize(PropId id)
        {
            if (!MessageMockConstants.PropertySizeValues.ContainsKey(id))
                throw new PstSdkException(String.Format("PropId: {0}", id));

            return MessageMockConstants.PropertySizeValues[id];
        }

        public byte[] ReadProperty(PropId id)
        {
            if (!MessageMockConstants.ReadPropertyValues.ContainsKey(id))                            
                throw new PstSdkException(String.Format("PropId: {0}", id));

            return MessageMockConstants.ReadPropertyValues[id];
        }        

        public Stream OpenPropertyStream(PropId id)
        {
            if (!MessageMockConstants.PropertyStreamValues.ContainsKey(id))                            
                throw new PstSdkException();

            return MessageMockConstants.PropertyStreamValues[id];
        }

        public void Dispose()
        {
            return;
        }
    }
}
