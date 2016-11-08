using System;
using System.Text;

using pstsdk.definition.ndb.database;

namespace pstsdk.definition.util.btree
{
    /// <summary>
    /// <para>
    /// Represents a non-leaf node in a BTree structure
    /// </para>
    /// Classes which model a non-leaf of a BTree structure inherit from this.
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public interface IBtreeNodeNonLeaf<TKey, TValue> : IBtreeNode<TKey, TValue> where TKey : IComparable<TKey>
    {
    }
}
