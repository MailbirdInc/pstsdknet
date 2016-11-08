using System;
using System.Collections.Generic;
using pstsdk.definition.ltp;
using pstsdk.definition.util.primitives;
using System.IO;
using pstsdk.definition.exception;
using pstsdk.test.mocks.MockPropBagConstants;

namespace pstsdk.test.mocks.MockPropBags
{
    public class RecipientMockPropBag : IPropertyObject
    {        
        public NodeID Node
        {
            get { return NodeID.make_nid(NidType.nid_type_recipient_table, 0); }
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
            if (!RecipientMockConstants.PropertyTypeValues.ContainsKey(id))
                throw new PstSdkException();

            return RecipientMockConstants.PropertyTypeValues[id];
        }

        public bool PropertyExists(PropId id)
        {
            return RecipientMockConstants.PropertyExistValues.ContainsKey(id);
        }

        public uint PropertySize(PropId id)
        {
            if (!RecipientMockConstants.PropertySizeValues.ContainsKey(id))
                throw new PstSdkException(String.Format("PropId: {0}", id));

            return RecipientMockConstants.PropertySizeValues[id];
        }

        public byte[] ReadProperty(PropId id)
        {
            if (!RecipientMockConstants.ReadPropertyValues.ContainsKey(id))                            
                throw new PstSdkException(String.Format("PropId: {0}", id));

            return RecipientMockConstants.ReadPropertyValues[id];
        }        

        public Stream OpenPropertyStream(PropId id)
        {
            if (!RecipientMockConstants.PropertyStreamValues.ContainsKey(id))                            
                throw new PstSdkException();

            return RecipientMockConstants.PropertyStreamValues[id];
        }

        public void Dispose()
        {
            return;
        }
    }
}
