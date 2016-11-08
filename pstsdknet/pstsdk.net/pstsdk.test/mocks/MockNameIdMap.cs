using System;
using System.Collections.Generic;
using pstsdk.definition.ltp.nameid;
using pstsdk.definition.util.primitives;
using pstsdk.definition.ltp;
using pstsdk.test.mocks.MockPropBags;

namespace pstsdk.test.mocks
{
    public class MockNameIdMap : INameIDMap
    {
        public bool NameExists(Guid guid, string name)
        {
            throw new NotImplementedException();
        }

        public bool IdExists(Guid guid, int id)
        {
            throw new NotImplementedException();
        }

        public bool NamedPropertyExists(INamedProperty namedProp)
        {
            throw new NotImplementedException();
        }

        public bool PropertyExists(PropId id)
        {
            throw new NotImplementedException();
        }

        public int PropertyCount
        {
            get { throw new NotImplementedException(); }
        }

        public int BucketCount
        {
            get { throw new NotImplementedException(); }
        }

        public IEnumerable<PropId> Properties
        {
            get { throw new NotImplementedException(); }
        }

        public IEnumerable<INamedProperty> NamedProperties
        {
            get { throw new NotImplementedException(); }
        }

        public IPropertyObject PropertyBag
        {
            get { return new MockPropBag(); }
        }

        public PropId Lookup(Guid guid, string name)
        {
            throw new NotImplementedException();
        }

        public PropId Lookup(Guid guid, int id)
        {
            throw new NotImplementedException();
        }

        public PropId Lookup(INamedProperty namedProp)
        {
            throw new NotImplementedException();
        }

        public INamedProperty Lookup(PropId id)
        {
            throw new NotImplementedException();
        }
    }
}
