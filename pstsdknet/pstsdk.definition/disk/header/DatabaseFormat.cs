namespace pstsdk.definition.disk.header
{
    /// <summary>
    /// Valid database format values (ANSI vs. Unicode), [MS-PST] 2.2.2.6
    /// </summary>
    public enum DatabaseFormat
    {
        /// <summary>
        /// Initial ANSI file version number
        /// </summary>
        database_format_ansi_min = 14,
        /// <summary>
        /// Current ANSI file version number
        /// </summary>
        database_format_ansi = 15,
        /// <summary>
        /// Initial unicode version number
        /// </summary>
        database_format_unicode_min = 20,
        /// <summary>
        /// Current unicode version number
        /// </summary>
        database_format_unicode = 23
    }
}