namespace pstsdk.definition.disk.bth
{
    /// <summary>
    /// <para>Entries which make up a "leaf" BTH allocation</para>
    /// <para>Simply an ordered array of key/values.</para>
    /// <para>[MS-PST] 2.3.2.3</para>
    /// </summary>
    /// <typeparam name="TKey">The key type</typeparam>
    /// <typeparam name="TValue">The value type</typeparam>
    public struct bth_leaf_entry<TKey, TValue> : bth_entry
    {
        /// <summary>
        /// Key of the lower level page
        /// </summary>
        public TKey key;

        /// <summary>
        /// Heap id of the lower level page
        /// </summary>
        public TValue page;
    }
}