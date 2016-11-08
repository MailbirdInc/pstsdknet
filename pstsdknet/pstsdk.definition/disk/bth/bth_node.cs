namespace pstsdk.definition.disk.bth
{
    /// <summary>
    /// <para>A BTH node is simply an array of entries, where the entry is either
    /// a bth_nonleaf_entry or a bth_leaf_entry. Clients must keep
    /// track of the current level as they are recursing down a BTH, starting
    /// with the value stored in the bth_header.
    /// </para>
    /// <para>The number of entries is determined simply by the size of the heap
    /// allocation divided by the size of the EntryType.</para>
    /// <para> [MS-PST] 2.3.2</para>
    /// </summary>
    /// <typeparam name="TEntry">The entry type in this BTH. In practice eitehr a bth_leaf_entry or bth_nonleaf_entry.</typeparam>
    public struct bth_node<TEntry> where TEntry : bth_entry
    {
        /// <summary>
        /// Array of entries
        /// </summary>
        public TEntry[] entries;
    }
}