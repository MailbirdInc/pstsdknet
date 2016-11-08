using System;

using pstsdk.definition.util.primitives;

namespace pstsdk.definition.ndb.database
{
    /// <summary>
    /// <para>
    ///  An in memory, database format agnostic version of bbt_leaf_entry. 
    ///  </para>
    ///  <para>
    ///  It doesn't contain a ref count because that value is of no interest to the in memory objects.
    ///  </para>
    /// </summary>
    public interface IBlockInfo
    {
        BlockID ID { get; }
        UInt64 Address { get; }
        ushort Size { get; }
        ushort RefCount { get; }
    }
}