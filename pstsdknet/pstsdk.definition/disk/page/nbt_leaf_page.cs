using System.Runtime.InteropServices;

namespace pstsdk.definition.disk.page
{
    /// <summary>
    /// <para>NBT leaf page</para>
    /// <para>A BTree page instance. The NBT leaf page has an array of nbt_leaf_entries
    /// ordered by node id, which describe the nodes of the database.</para>
    /// <para>[MS-PST] 2.2.2.7.7.1</para>
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public class nbt_leaf_page<TPageTrailer, T> : bt_page<TPageTrailer, nbt_leaf_entry<T>>
        where TPageTrailer : page_trailer, new()
        where T : struct
    {
    }
}