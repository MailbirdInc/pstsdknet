using System;

namespace pstsdk.definition.ltp.nameid
{
    public interface INamedProperty
    {
        Guid Guid { get; }
        bool IsString { get; }
        uint ID { get; }
        string Name { get; }
    }
}