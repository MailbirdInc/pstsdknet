using pstsdk.definition.util.primitives;

namespace pstsdk.definition.disk.bth
{
    /// <summary>
    /// <para>Entries which make up a "non-leaf" BTH allocation</para>
    /// <para>
    /// Clients must keep track of the current level as they are doing a BTH
    /// lookup. Non-leaf entries, similar to how the BT pages and sub_blocks
    /// work, contain the key and id of a lower level page.
    /// </para>
    /// <para>[MS-PST] 2.3.2.2</para>
    /// </summary>
    /// <typeparam name="TKey">The key type</typeparam>
    public struct bth_nonleaf_entry<TKey> : bth_entry
    {
        /// <summary>
        /// Key of the lower level page
        /// </summary>
        public TKey key;    

        /// <summary>
        /// Heap id of the lower level page
        /// </summary>
        public HeapID page; 
    }
}