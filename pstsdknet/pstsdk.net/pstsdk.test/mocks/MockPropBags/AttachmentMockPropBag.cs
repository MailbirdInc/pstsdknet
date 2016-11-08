using System;
using System.Collections.Generic;
using pstsdk.definition.ltp;
using pstsdk.definition.util.primitives;
using System.IO;
using pstsdk.definition.exception;
using pstsdk.test.mocks.MockPropBagConstants;

namespace pstsdk.test.mocks.MockPropBags
{
    public class AttachmentMockPropBag : IPropertyObject
    {        
        public NodeID Node
        {
            get { return NodeID.make_nid(NidType.nid_type_folder, 0); }
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
            if (!AttachmentMockConstants.PropertyTypeValues.ContainsKey(id))
                throw new PstSdkException();

            return AttachmentMockConstants.PropertyTypeValues[id];
        }

        public bool PropertyExists(PropId id)
        {
            return AttachmentMockConstants.PropertyExistValues.ContainsKey(id);
        }

        public uint PropertySize(PropId id)
        {
            if (!AttachmentMockConstants.PropertySizeValues.ContainsKey(id))
                throw new PstSdkException(String.Format("PropId: {0}", id));

            return AttachmentMockConstants.PropertySizeValues[id];
        }

        public byte[] ReadProperty(PropId id)
        {
            if (!AttachmentMockConstants.ReadPropertyValues.ContainsKey(id))                            
                throw new PstSdkException(String.Format("PropId: {0}", id));

            return AttachmentMockConstants.ReadPropertyValues[id];
        }        

        public Stream OpenPropertyStream(PropId id)
        {
            if (!AttachmentMockConstants.PropertyStreamValues.ContainsKey(id))                            
                throw new PstSdkException();

            return AttachmentMockConstants.PropertyStreamValues[id];
        }

        public void Dispose()
        {
            return;
        }
    }
}
