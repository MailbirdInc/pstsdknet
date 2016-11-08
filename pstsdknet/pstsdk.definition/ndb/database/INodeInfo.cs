using pstsdk.definition.util.primitives;

namespace pstsdk.definition.ndb.database
{
    /// <summary>
    /// An in memory, database format agnostic version of nbt_leaf_entry.
    /// </summary>
    public interface INodeInfo
    {
        NodeID ID { get; }
        BlockID DataBid { get; }
        BlockID SubBid { get; }
        NodeID  ParentID { get; }
    }
}