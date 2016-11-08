using pstsdk.definition.ndb.database;
using pstsdk.definition.util.btree;
using pstsdk.definition.util.primitives;

namespace pstsdk.definition.ndb.node
{
    /// <summary>
    /// <para>A block which contains information about subnodes</para>
    /// <para>
    /// Subnode blocks form a sort of "private NBT" for a node. This class is
    /// the root class of that hierarchy, with child classes for the leaf and
    /// non-leaf versions of a subnode block. 
    /// </para>
    /// <para>
    /// This hierarchy also models the btree_node structure, inheriting the
    /// actual iteration and lookup logic.
    /// </para>
    /// <para>[MS-PST] 2.2.2.8.3.3</para>
    /// </summary>
    public interface ISubNodeBlock : IBlock, IBtreeNode<NodeID, ISubNodeInfo>
    {
        int Level { get; }

    }
}