namespace pstsdk.definition.disk.page
{
    /// <summary>
    /// <para>The authoritative source of free space in the file</para>
    /// <para>
    /// Each bit in an AMap page refers to bytes_per_slot bytes of the file.
    /// If that bit is set, that indicates those bytes in the file are occupied.
    /// If the bit is not set, that indicates those bytes in the file are available
    /// for allocation. Note that each AMap page "maps" itself. Since an AMap page
    /// (like all pages) is page_size bytes (512), this means the first 8 bytes
    /// of an AMap page are by definition always 0xFF.</para>
    /// <para> [MS-PST] 2.2.2.7.2.1</para>
    /// </summary>
    public class amap_page<T> : page<T> where T : page_trailer, new()
    {
    }
}