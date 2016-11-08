using pstsdk.definition.ndb.database;
using pstsdk.definition.util.btree;
using pstsdk.definition.util.primitives;

namespace pstsdk.definition.ndb.node
{
    /// <summary>
    /// <para>
    /// Contains the actual subnode information
    /// </para>
    /// <para>
    /// Typically a node will point directly to one of these. Because they are
    /// blocks, and thus up to 8k in size, they can hold information for about
    /// ~300 subnodes in a unicode store, and up to ~600 in an ANSI store.
    /// </para>
    /// <para>[MS-PST] 2.2.2.8.3.3.1</para>
    /// </summary>
    public interface ISubNodeLeafBlock : ISubNodeBlock, IBtreeNodeLeaf<NodeID, ISubNodeInfo>
    {

    }
}