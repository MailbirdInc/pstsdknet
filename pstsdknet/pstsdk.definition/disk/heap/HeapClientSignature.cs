using System;
using System.Collections.Generic;
using System.Text;

namespace pstsdk.definition.disk.heap
{
    /// <summary>
    /// <para>Different heap client signature types</para>
    /// <para>[MS-PST] 2.3.1.2 <bold>ClientSig</bold></para>
    /// </summary>
    public enum HeapClientSignature : byte
    {
        /// <summary>
        /// Internal
        /// </summary>
        heap_sig_gmp = 0x6C,  
        /// <summary>
        /// Table context
        /// </summary>
        heap_sig_tc = 0x7C,   
        /// <summary>
        /// Internal
        /// </summary>
        heap_sig_smp = 0x8C,  
        /// <summary>
        /// Internal
        /// </summary>
        heap_sig_hmp = 0x9C,  
        /// <summary>
        /// deprecated Internal
        /// </summary>
        heap_sig_ch = 0xA5,
        /// <summary>
        /// deprecated Internal
        /// </summary>
        heap_sig_chtc = 0xAC, 
        /// <summary>
        /// BTree on Heap
        /// </summary>
        heap_sig_bth = 0xB5,  
        /// <summary>
        /// Property Context
        /// </summary>
        heap_sig_pc = 0xBC  
    }
}
