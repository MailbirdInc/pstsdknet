using pstsdk.definition.util.primitives;

namespace pstsdk.definition.ndb.database
{
    /// <summary>
    /// An in memory, database format agnostic version of sub_leaf_entry.
    /// </summary>
    public interface ISubNodeInfo
    {
        NodeID ID { get; }
        BlockID DataBid { get; }
        BlockID SubBid { get; }
    }
}