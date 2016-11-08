using System.Runtime.InteropServices;

namespace pstsdk.definition.disk.page
{
    /// <summary>
    /// <para>BBT leaf page</para>
    /// <para>A BTree page instance. The BBT leaf page has an array of bbt_leaf_entries
    /// ordered by block id, which describe the blocks in the database.</para>
    /// <para>[MS-PST] 2.2.2.7.7.1</para>
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public class bbt_leaf_page<TPageTrailer, T> : bt_page<TPageTrailer, bbt_leaf_entry<T>>
        where TPageTrailer : page_trailer, new()
        where T : struct
    {
    }
}