using System;

using pstsdk.definition.util.primitives;

namespace pstsdk.definition.ndb.node
{
    /// <summary>
    /// <para>
    /// The base class of the block class hierarchy
    /// </para>
    /// <para>
    /// A block is an atomic unit of storage in a PST file. This class, and other
    /// classes in this hierarchy, are in memory representations of those blocks
    /// on disk. They are immutable, and are shared freely between different node
    /// instances as needed (via shared pointers). A block also knows how to read
    /// any blocks it may refer to (in the case of extended_block or a 
    /// subnode_block). 
    /// </para> 
    /// <para>
    /// All blocks in the block hierarchy are also in the category of what is known
    /// as <i>dependant objects</i>. This means is they only keep a weak 
    /// reference to the database context to which they're a member. Contrast this
    /// to an independant object such as the node, which keeps a strong ref
    /// or a full shared_ptr to the related context. This implies that someone
    /// must externally make sure the database context outlives it's blocks -
    /// this is usually done by the database context itself or the node which
    /// holds these blocks.
    /// </para> 
    /// <para>[MS-PST] 2.2.2.8</para>
    /// </summary>
    public interface IBlock
    {
        bool IsInternal { get; }
        int DiskSize { get; set; }
        BlockID ID { get; }
        UInt64 Address { get; set; }

        void Touch();
    }
}