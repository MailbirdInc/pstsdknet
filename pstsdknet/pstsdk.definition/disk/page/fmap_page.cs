namespace pstsdk.definition.disk.page
{
    /// <summary>
    /// <para>A deprecated allocation system optimized for AMap page searching</para>
    /// <para>
    /// A Free Map (or fmap) page has one byte per AMap page, indicating how many consecutive
    /// slots are available for allocation on that amap page. No longer used as of Outlook 2007
    /// SP2, but as with PMap pages are still created for backwards compatibility.
    /// </para>
    /// <para> [MS-PST] 2.2.2.7.5.1</para>
    /// </summary>

    public class fmap_page<T> : page<T> where T : page_trailer, new()
    {
    }
}