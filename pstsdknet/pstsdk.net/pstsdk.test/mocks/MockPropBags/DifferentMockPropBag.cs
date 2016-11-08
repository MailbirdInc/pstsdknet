using System;
using System.Collections.Generic;
using System.Text;
using pstsdk.definition.ltp;
using pstsdk.definition.util.primitives;
using System.IO;

namespace pstsdk.test.mocks.MockPropBags
{
    public class DifferentMockPropBag : IPropertyObject
    {
        public NodeID Node
        {
            get { return NodeID.make_nid(NidType.nid_type_none, 0); }
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
            return Stream.Null;
        }

        public void Dispose()
        {
            return;
        }
    }
}
