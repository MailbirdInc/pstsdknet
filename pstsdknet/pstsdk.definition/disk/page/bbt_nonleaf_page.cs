namespace pstsdk.definition.disk.page
{
    /// <summary>
    /// <para>BBT non-leaf page</para>
    /// <para>A BTree page instance. Note that this structure is identical to a non-leaf NBT page.</para>
    /// <para>[MS-PST] 2.2.2.7.7.1</para>
    /// </summary>
    public class bbt_nonleaf_page<TPageTrailer, T> : bt_page<TPageTrailer, bt_entry<T>>
        where TPageTrailer : page_trailer, new()
        where T : struct
    {
    }
}