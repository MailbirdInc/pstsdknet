using System;
using pstsdk.definition.ltp.nameid;
using pstsdk.definition.util.primitives;

namespace pstsdk.test.mocks
{
    public class MockNamedProperty : INamedProperty
    {
        public Guid Guid
        {
            get { return Guid.NewGuid(); }
        }

        public bool IsString
        {
            get { return true; }
        }

        public uint ID
        {
            get { return (UInt32)PropId.KnownValue.PR_ENTRYID; }
        }

        public string Name
        {
            get { return "Named Property Name"; }
        }
    }
}
