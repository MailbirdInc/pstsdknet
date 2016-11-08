namespace pstsdk.definition.ndb.node
{
    /// <summary>
    /// <para>A data block which refers to other data blocks, in order to extend
    /// the physical size limit (8k) to a larger logical size.
    /// </para>
    /// <para>
    /// An extended_block is essentially a list of block_ids of other 
    /// data_block, which themselves may be an extended_block or an 
    /// external_block. Ultimately they form a "data tree", the leafs of which
    /// form the "logical" contents of the block.
    /// </para>
    /// <para>[MS-PST] 2.2.2.8.3.2</para>
    /// </summary>
    public interface IExtendedBlock : IDataBlock
    {
        ExtendedBlockLevel Level { get; } 
    }
}