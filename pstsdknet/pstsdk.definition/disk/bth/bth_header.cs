
using pstsdk.definition.util.primitives;

namespace pstsdk.definition.disk.bth
{
    /// <summary>
    /// <para>Describes the BTH, including the size of the keys/values and the heap_id of the root allocation.</para>
    /// <para>[MS-PST] 2.3.2.1</para>
    /// </summary>
    public struct bth_header
    {
        /// <summary>
        /// Always \ref heap_sig_bth
        /// </summary>
        public byte bth_signature; 
        /// <summary>
        /// Key size in bytes
        /// </summary>
        public byte key_size;      
        /// <summary>
        /// Entry size in bytes
        /// </summary>
        public byte entry_size;    
        /// <summary>
        /// Number of levels
        /// </summary>
        public byte num_levels;   
        /// <summary>
        /// Root of the actual tree structure
        /// </summary>
        public HeapID root;       
    }
}
