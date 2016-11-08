namespace pstsdk.definition.disk.page
{
    /// <summary>
    /// <para>An old allocation system optimized for pages</para>
    /// <para>
    /// Similar to an amap_page, except each bit refers to page_size bytes
    /// rather than bytes_per_slot bytes. This allocation scheme is no longer used
    /// as of Outlook 2007 SP2, however these pages are still created in the file
    /// for backwards compatability purposes.</para>
    /// <para> [MS-PST] 2.2.2.7.3.1</para>
    /// </summary>
    public class pmap_page<T> : page<T> where T : page_trailer, new()
    {
    }
}