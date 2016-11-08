using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using pstsdk.definition.ltp;
using pstsdk.definition.util.primitives;

namespace pstsdk.test.mocks
{
    public class MockPropBag : IPropertyObject
    {
        public Func<NodeID> OnGetNode { private get; set; }
        public Func<IEnumerable<PropId>> OnGetProperties { private get; set; }
        public Func<PropertyType> OnGetPropertyType { private get; set; }
        public Func<PropId, bool> OnPropertyExists { private get; set; }
        public Func<uint> OnPropertySize { private get; set; }
        public Func<byte[]> OnReadProperty { private get; set; }
        public Func<System.IO.Stream> OnOpenPropertyStream { private get; set; }

        public MockPropBag()
        {
            OnGetProperties = () => Enumerable.Empty<PropId>();
        }

        #region IPropertyObject Members

        public NodeID Node
        {
            get { return OnGetNode(); }
        }

        public IEnumerable<PropId> Properties
        {
            get { return OnGetProperties(); }
        }

        public PropertyType GetPropertyType(PropId id)
        {
            return OnGetPropertyType();
        }

        public bool PropertyExists(PropId id)
        {
            return OnPropertyExists(id);
        }

        public uint PropertySize(PropId id)
        {
            return OnPropertySize();
        }

        public byte[] ReadProperty(PropId id)
        {
            return OnReadProperty();
        }

        public System.IO.Stream OpenPropertyStream(PropId id)
        {
            return OnOpenPropertyStream();
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
           //do nothing
        }

        #endregion
    }
}
