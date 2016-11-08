using System;

namespace pstsdk.definition.util.btree
{
    /// <summary>
    /// <para>Represents a leaf node in a BTree structure</para> 
    /// <para>
    /// Classes which model a leaf of a BTree structure inherit from this.
    /// </para>
    /// <para>
    /// </summary>
    /// <typeparam name="TKey">The key type. Must be LessThan comparable.</typeparam>
    /// <typeparam name="TValue">The value type</typeparam>
    public interface IBtreeNodeLeaf<TKey, TValue> : IBtreeNode<TKey, TValue> where TKey : IComparable<TKey>
    {
        TValue GetValue(uint pos);
    }
}