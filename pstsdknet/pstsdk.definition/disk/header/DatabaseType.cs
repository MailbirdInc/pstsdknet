namespace pstsdk.definition.disk.header
{
    /// <summary>
    /// Valid database types (OST vs. PST), [MS-PST] 2.2.2.6
    /// </summary>
    public enum DatabaseType
    {
        /// <summary>
        /// A OST file
        /// </summary>
        database_ost = 12,
        /// <summary>
        /// A PST file
        /// </summary>
        database_pst = 19
    }
}