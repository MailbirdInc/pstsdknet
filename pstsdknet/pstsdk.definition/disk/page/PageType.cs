namespace pstsdk.definition.disk.page
{
    /// <summary>
    /// <para>Valid page types</para>
    /// <para>Used in the PageType and page_type_repeat fields of the page trailer.</para>
    /// <para>[MS-PST] 2.2.2.7.1/ptype</para>
    /// </summary>
    public enum PageType
    {
        /// <summary>
        /// A BBT (Blocks BTree) page
        /// </summary>
        page_type_bbt = 0x80,
        /// <summary>
        /// A NBT (Nodes BTree) page
        /// </summary>
        page_type_nbt = 0x81,
        /// <summary>
        /// deprecated: A FMap (Free Map) page
        /// </summary>
        page_type_fmap = 0x82,
        /// <summary>
        /// deprecated: A PMap (Page Map) page
        /// </summary>
        page_type_pmap = 0x83,
        /// <summary>
        /// An AMap (Allocation Map) page
        /// </summary>
        page_type_amap = 0x84,
        /// <summary>
        /// deprecated: A FPMap (Free Page Map) page. Unicode stores only.
        /// </summary>
        page_type_fpmap = 0x85,
        /// <summary>
        /// A DList (Density List) page
        /// </summary>
        page_type_dlist = 0x86
    }
}