using System;
using System.Collections.Generic;
using System.Text;
using pstsdk.definition.util.primitives;

namespace pstsdk.definition.ltp.nameid
{
    public interface INameIDMap
    {
        bool NameExists(Guid guid, string name);
        bool IdExists(Guid guid, int id);
        bool NamedPropertyExists(INamedProperty namedProp);
        bool PropertyExists(PropId id);
        int PropertyCount { get; }

        int BucketCount { get; }

        IEnumerable<PropId> Properties { get; }
        IEnumerable<INamedProperty> NamedProperties { get; }

        IPropertyObject PropertyBag { get; }

        PropId Lookup(Guid guid, string name);
        PropId Lookup(Guid guid, int id);
        PropId Lookup(INamedProperty namedProp);
        INamedProperty Lookup(PropId id);
    }
}
