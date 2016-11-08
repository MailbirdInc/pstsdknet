using System;
using System.Collections.Generic;
using pstsdk.definition.ltp;
using pstsdk.definition.util.primitives;
using System.IO;
using pstsdk.definition.exception;
using pstsdk.test.mocks.MockPropBagConstants;

namespace pstsdk.test.mocks.MockPropBags
{
    public class SearchFolderMockPropBag : IPropertyObject
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
            if (!SearchFolderMockConstants.PropertyTypeValues.ContainsKey(id))
                throw new PstSdkException();

            return SearchFolderMockConstants.PropertyTypeValues[id];
        }

        public bool PropertyExists(PropId id)
        {
            if (SearchFolderMockConstants.PropertyExistValues.ContainsKey(id))
                return true;
            
            return false;
        }

        public uint PropertySize(PropId id)
        {
            if (!SearchFolderMockConstants.PropertySizeValues.ContainsKey(id))
                throw new PstSdkException(String.Format("PropId: {0}", id));

            return SearchFolderMockConstants.PropertySizeValues[id];
        }

        public byte[] ReadProperty(PropId id)
        {
            if (!SearchFolderMockConstants.ReadPropertyValues.ContainsKey(id))                            
                throw new PstSdkException(String.Format("PropId: {0}", id));

            return SearchFolderMockConstants.ReadPropertyValues[id];
        }        

        public Stream OpenPropertyStream(PropId id)
        {
            if (!SearchFolderMockConstants.PropertyStreamValues.ContainsKey(id))                            
                throw new PstSdkException();

            return SearchFolderMockConstants.PropertyStreamValues[id];
        }

        public void Dispose()
        {
            return;
        }
    }
}
