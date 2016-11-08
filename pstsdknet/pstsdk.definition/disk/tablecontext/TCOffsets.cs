using System;
using System.Collections.Generic;
using System.Text;

namespace pstsdk.definition.disk.tablecontext
{
    /// <summary>
    /// <para>Indices into the size offsets array</para>
    /// <para>[MS-PST] 2.3.4.1</para>
    /// </summary>
    public enum TCOffsets
    {
        /// <summary>
        /// Offset of the end of the four and eight byte columns
        /// </summary>
        tc_offsets_four,    
        /// <summary>
        /// Offset of the end of the two byte columns
        /// </summary>
        tc_offsets_two,     
        /// <summary>
        /// Offset of the end of the one byte columns
        /// </summary>
        tc_offsets_one,     
        /// <summary>
        /// Offset of the end of the existance bitmap
        /// </summary>
        tc_offsets_bitmap,  
        /// <summary>
        /// Number of entries in the offset array
        /// </summary>
        tc_offsets_max      
    };
}
