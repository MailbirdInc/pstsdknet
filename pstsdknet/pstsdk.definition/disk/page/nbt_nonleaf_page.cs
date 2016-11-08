namespace pstsdk.definition.disk.page
{
    /// <summary>
    /// <para>NBT non-leaf page</para>
    /// <para>A BTree page instance.</para>
    /// <para>[MS-PST] 2.2.2.7.7.1</para>
    /// </summary>
    public class nbt_nonleaf_page<TPageTrailer, T> : bt_page<TPageTrailer, bt_entry<T>> 
        where TPageTrailer: page_trailer, new() 
        where T : struct
    {
    }
}