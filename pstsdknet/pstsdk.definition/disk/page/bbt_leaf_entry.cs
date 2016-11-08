using System;

using pstsdk.definition.disk.block;

namespace pstsdk.definition.disk.page
{
    /// <summary>
    /// <para>BBT Leaf Entry</para>
    /// <para>An array of these are used on leaf BBT pages. It describes a block.</para>
    /// <para>[MS-PST] 2.2.2.7.7.3</para>
    /// </summary>
    public struct bbt_leaf_entry<T> : entry where T : struct
    {
        public const int ansi_size = 12;
        public const int unicode_size = 24;

        /// <summary>
        /// A reference to this block on Disk
        /// </summary>
        public block_reference<T> @ref;

        /// <summary>
        /// The unaligned size of this block
        /// </summary>
        public ushort size;            

        /// <summary>
        /// The reference count of this block
        /// </summary>
        public ushort ref_count;

        public int Size()
        {
            return typeof(T) == typeof(UInt32) ? ansi_size : unicode_size;
        }
    }
}