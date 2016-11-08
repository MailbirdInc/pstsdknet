namespace pstsdk.definition.disk.header
{
    /// <summary>
    /// <para>Valid "encryption" methods</para>
    /// This value indicates what method was used to "encrypt" external data
    /// (external data means the data section of external blocks) in the file.
    /// </summary>
    public enum CryptMethod
    {
        /// <summary>
        /// No "encryption" was used.
        /// </summary>
        crypt_method_none = 0,
        /// <summary>
        /// The permute method is used in this file.
        /// </summary>
        crypt_method_permute = 1,
        /// <summary>
        /// The cyclic method is used in this file.
        /// </summary>
        crypt_method_cyclic = 2
    }
}