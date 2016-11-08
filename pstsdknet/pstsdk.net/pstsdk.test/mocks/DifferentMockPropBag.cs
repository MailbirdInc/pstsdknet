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

namespace pstsdk.test.mocks
{
    public class DifferentMockPropBag : IPropertyObject
    {
        public NodeID Node
        {
            get { return NodeID.make_nid(NidType.nid_type_message, 0); }
        }

        public IEnumerable<PropId> Properties
        {
            get { throw new NotImplementedException(); }
        }

        public PropertyType GetPropertyType(PropId id)
        {
            return PropertyType.KnownValue.prop_type_wstring;
        }

        public bool PropertyExists(PropId id)
        {
            return true;
        }

        public uint PropertySize(PropId id)
        {
            return 1234;
        }

        public byte[] ReadProperty(PropId id)
        {
            String propertyStringValue = "Body Text";

            if (id == PropId.KnownValue.PR_SUBJECT)
                propertyStringValue = "RE: Please reply to this message";

            return Encoding.Unicode.GetBytes(propertyStringValue);
        }

        public Stream OpenPropertyStream(PropId id)
        {
            return System.IO.Stream.Null;
        }

        public void Dispose()
        {
            return;
        }
    }
}
