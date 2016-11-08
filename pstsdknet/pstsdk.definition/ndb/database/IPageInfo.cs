using System;

using pstsdk.definition.util.primitives;

namespace pstsdk.definition.ndb.database
{
    /// <summary>
    /// An in memory, database format agnostic version of block_reference used specifically for the page class hierarchy
    /// </summary>
    public interface IPageInfo
    {
        PageID ID { get; }
        UInt64 Address { get; }
    }
}