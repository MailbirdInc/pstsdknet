namespace pstsdk.definition.disk.page
{
    /// <summary>
    /// <para>The Unicode store version of the page trailer</para>
    /// <para>The last structure in every page, aligned to the page_size</para>
    /// <para>[MS-PST] 2.2.2.7.1</para>
    /// </summary>
    public class page_trailer
    {
        public page_trailer()
        {
            
        }
        /// <summary>
        /// The PageType of this page
        /// </summary>
        public byte page_type;        
        /// <summary>
        /// Same as the PageType field, for validation purposes
        /// </summary>
        public byte page_type_repeat; 
        /// <summary>
        /// Signature of this page, as calculated by the compute_signature function
        /// </summary>
        public ushort signature;

        public virtual byte[] GetBytes()
        {
            return default(byte[]);
        }

        public virtual void FromBytes(byte[] bytes)
        {
        }

        public virtual int Size()
        {
            return default(int);
        }
    }
}