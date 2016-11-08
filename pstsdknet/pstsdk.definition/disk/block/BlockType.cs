namespace pstsdk.definition.disk.block
{
    /// <summary>
    /// <para>The different block types.</para>
    /// <para>[MS-PST] 2.2.2.8.3</para>
    /// </summary>
    public enum BlockType
    {
        /// <summary>
        /// An external data block
        /// </summary>
        block_type_external = 0x00,
        /// <summary>
        /// An extended block type
        /// </summary>
        block_type_extended = 0x01,
        /// <summary>
        /// A subnode block type
        /// </summary>
        block_type_sub = 0x02
    }
}