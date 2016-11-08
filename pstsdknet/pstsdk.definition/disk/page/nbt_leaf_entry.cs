using System;

using pstsdk.definition.util.primitives;

namespace pstsdk.definition.disk.page
{
    /// <summary>
    /// <para>NBT Leaf Entry</para>
    /// <para>An array of these are used on leaf NBT pages. It describes a node.</para>
    /// <para>[MS-PST] 2.2.2.7.7.4</para>
    /// </summary>
    public struct nbt_leaf_entry<T> : entry where T : struct
    {
        public const int ansi_size = 16;
        public const int unicode_size = 32;


        /// <summary>
        /// The node id
        /// </summary>
        public NidIndex<T> nid;  

        /// <summary>
        /// The block id of the data block
        /// </summary>
        public BlockIDDisk<T> data; 

        /// <summary>
        /// The block id of the subnode block
        /// </summary>
        public BlockIDDisk<T> sub;   

        /// <summary>
        /// The parent node id
        /// </summary>
        public NodeID parent_nid;

        public int Size()
        {
            return typeof(T) == typeof(UInt32) ? ansi_size : unicode_size;
        }

    }
}