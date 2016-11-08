namespace pstsdk.definition.ndb.node
{
    /// <summary>
    /// <para>
    /// Contains actual data
    /// </para>
    /// <para>
    /// An external_block contains the actual data contents used by the higher
    /// layers. This data is also "encrypted", although the encryption/decryption
    /// process occurs immediately before/after going to disk, not here. 
    /// </para>
    /// <para>[MS-PST] 2.2.2.8.3.1</para>
    /// </summary>
    public interface IExternalBlock : IDataBlock
    {
    }
}