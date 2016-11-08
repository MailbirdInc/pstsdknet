using pstsdk.definition.ndb.database;
using pstsdk.definition.util.btree;
using pstsdk.definition.util.primitives;

namespace pstsdk.definition.ndb.node
{
    /// <summary>
    /// <para> Contains references to subnode_leaf_blocks.</para>
    /// <para>
    /// Because of the width of a subnode_leaf_block and the relative scarcity of
    /// subnodes, it's actually pretty uncommon to encounter a subnode non-leaf
    /// block in practice. But it does occur, typically on large tables.
    /// </para>
    /// <para>[MS-PST] 2.2.2.8.3.3.2</para>
    /// </summary>
    public interface ISubNodeNonLeafBlock : ISubNodeBlock, IBtreeNodeNonLeaf<NodeID, ISubNodeInfo>
    {
        ISubNodeBlock GetChild(int pos);
    }
}