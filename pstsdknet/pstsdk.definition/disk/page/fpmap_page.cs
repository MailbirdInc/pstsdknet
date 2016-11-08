namespace pstsdk.definition.disk.page
{
    /// <summary>
    /// <para>A deprecated allocation system optimized for AMap page searching</para>
    /// <para>
    /// A Free Page Map page has one bit per PMap page, indicating if that PMap page has any
    /// slots available. A bit being set indicates there is no space available in that PMap page.
    /// No longer used as of Outlook 2007, but still created for backwards compatibility.
    ///</para>
    ///<para>
    /// The lack of fpmap pages was the reason for the 2GB limit of ANSI pst files (rather than
    /// a more intuitive 4GB limit) - the fpmap region in the header only had enough slots to
    /// "map" 2GB of space.
    /// </para>
    /// <para> [MS-PST] 2.2.2.7.6.1</para>
    /// </summary>
    public class fpmap_page<T> : page<T> where T : page_trailer, new()
    {
    }
}