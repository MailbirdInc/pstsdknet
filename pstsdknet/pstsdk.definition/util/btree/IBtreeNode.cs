using System;
using System.Collections.Generic;

namespace pstsdk.definition.util.btree
{
    /// <summary>
    /// <para>A BTree Node</para>
    /// <para>The fundamental type in the BTree system is the btree_node. It provides
    /// the generic interface which is refined by the other classes.
    /// </para>
    /// </summary>
    /// <typeparam name="TKey">The key type. Must be LessThan comparable.</typeparam>
    /// <typeparam name="TValue">The value type</typeparam>
    public interface IBtreeNode<TKey, TValue> where TKey: IComparable<TKey>
    {
        /// <summary>
        /// <para>Looks up the associated value for a given key</para>
        /// <para>This will defer to child btree_nodes as appropriate</para>
        /// </summary>
        /// <param name="key">The key to lookup</param>
        /// <returns>The associated value</returns>
        TValue Lookup(TKey key);

        /// <summary>
        /// <para>Returns the key at the specified position</para>
        /// <para>This is specific to this btree_node, not the entire tree</para>
        /// </summary>
        /// <param name="pos">The position to retrieve the key for</param>
        /// <returns>The key at the requested position</returns>
        TKey GetKey(uint pos);

        /// <summary>
        /// <para>Returns the number of entries in this btree_node</para>
        /// <para>This is specific to this btree_node, not the entire tree</para>
        /// </summary>
        uint NumValues { get; }


        /// <summary>
        /// <para>
        /// Returns a enumeration of the values.
        /// </para>
        /// </summary>
        IEnumerable<TValue> Values { get; }

        /// <summary>
        /// <para>
        /// Performs a binary search over the keys of this btree_node
        /// </para>
        /// </summary>
        /// <param name="key">The key to lookup</param>
        /// <returns>The position of the key, or of the entry which would contain it</returns>
        int BinarySearch(TKey key);
    }
}