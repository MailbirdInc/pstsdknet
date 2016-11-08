using System.Collections.Generic;
using System.Text;

using pstsdk.definition.ndb.database;
using pstsdk.definition.util.btree;
using pstsdk.definition.util.primitives;

namespace pstsdk.definition.ndb.node
{
    /// <summary>
    /// <para>
    /// An in memory representation of the "node" concept in a PST data file
    /// </para>
    /// <para>
    /// A node is the primary abstraction exposed by the ndb to the
    /// upper layers. It's purpose is to abstract away the details of working with
    /// immutable blocks and subnode blocks. It can therefor be thought of simply
    /// as a mutable stream of bytes and a collection of sub nodes, themselves
    /// a mutable stream of bytes potentially with another collection of subnodes,
    /// etc.
    /// </para>
    /// <para>
    /// When using the node class, think of it as creating an in memory 
    /// "instance" of the node on the disk. You can have several in memory
    /// instances of the same node on disk. You can even have an alias_tag 
    /// "alias" of another in memory instance, as is sometimes required when 
    /// creating higher level abstractions. 
    /// </para>
    /// <para>
    /// There isn't much interesting to do with a node, you can query its size,
    /// read from a specific location, get it's id and parent id, iterate over
    /// subnodes, etc. Most of the interesting things are done by higher level
    /// abstractions which are built on top of and know specifically how to 
    /// interpret the bytes in a node - such as the heap, table, and 
    /// property_bag.
    /// </para>
    /// <para>[MS-PST] 2.2.1.1</para> 
    /// </summary>
    public interface INode
    {
        NodeID ID { get; }
        BlockID DataID { get; }
        BlockID SubID { get; }
        NodeID ParentID { get; }
        IDataBlock DataBlock { get; }
        ISubNodeBlock SubNodeBlock { get; }
        IDatabaseContext Database { get; }
        int Read(byte[] buffer, int offset);
        T Read<T>(int offset);
        int Read(byte[] buffer, int pageNum, int offset);
        T Read<T>(int pageNum, int offset);

        int Write(byte[] buffer, int offset);
        void Write<T>(T obj, int offset);
        int Write(byte[] buffer, int pageNum, int offset);
        void Write<T>(T obj, int pageNum, int offset);
        int Resize(int size);

        INodeStreamDevice OpenAsStream();

        int Size { get; }
        int GetPageSize(int pageNum);
        uint PageCount { get; }
        IEnumerable<IBtreeNode<NodeID, ISubNodeInfo>> SubNodes { get; }

    }
}
