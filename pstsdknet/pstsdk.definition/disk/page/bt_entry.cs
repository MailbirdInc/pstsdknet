using System;

using pstsdk.definition.disk.block;
using pstsdk.definition.util.primitives;

namespace pstsdk.definition.disk.page
{
    /// <summary>
    /// <para>BTree Entry</para>
    /// <para>An array of these are used on non-leaf BT Pages</para>
    /// <para>[MS-PST] 2.2.2.7.7.2</para>
    /// </summary>
    public struct bt_entry<T> : entry where T : struct 
    {
        public const int ansi_size = 12;
        public const int unicode_size = 24;

        /// <summary>
        /// The key of the page in ref
        /// </summary>
        public BTKey<T> key;               

        /// <summary>
        /// A reference to a lower level page
        /// </summary>
        public block_reference<T> @ref;

        public int Size()
        {
            return typeof(T) == typeof(UInt32) ? ansi_size : unicode_size;
        }
    }
}