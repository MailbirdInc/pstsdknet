using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using pstsdk.definition.ltp;
using pstsdk.definition.util.primitives;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using pstsdk.layer.ltp.nameid;
using pstsdk.test.Integration;
using pstsdk.definition.exception;

namespace pstsdk.test.mocks
{
    public class AnotherMockPropBag : IPropertyObject
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
            if (!IntegrationTestConstants.PropertyTypeValues.ContainsKey(id))
                throw new PstSdkException();

            return IntegrationTestConstants.PropertyTypeValues[id];
        }

        public bool PropertyExists(PropId id)
        {
            if (IntegrationTestConstants.PropertyExistValues.ContainsKey(id))
                return true;
            
            return false;
        }

        public uint PropertySize(PropId id)
        {
            if (!IntegrationTestConstants.PropertySizeValues.ContainsKey(id))
                throw new PstSdkException(String.Format("PropId: {0}", id));

            return IntegrationTestConstants.PropertySizeValues[id];
        }

        public byte[] ReadProperty(PropId id)
        {
            if (!IntegrationTestConstants.ReadPropertyValues.ContainsKey(id))                            
                throw new PstSdkException(String.Format("PropId: {0}", id));

            return IntegrationTestConstants.ReadPropertyValues[id];
        }        

        public Stream OpenPropertyStream(PropId id)
        {
            if (!IntegrationTestConstants.PropertyStreamValues.ContainsKey(id))                            
                throw new PstSdkException();

            return IntegrationTestConstants.PropertyStreamValues[id];
        }

        public void Dispose()
        {
            return;
        }
    }
}
