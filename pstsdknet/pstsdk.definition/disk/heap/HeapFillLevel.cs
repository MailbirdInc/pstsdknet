namespace pstsdk.definition.disk.heap
{
    /// <summary>
    /// <para>  Fill level descriptions </para>
    /// <para>[MS-PST] 2.3.1.2</para>
    /// </summary>
    public enum HeapFillLevel
    {
        /// <summary>
        /// >= 3584 bytes free
        /// </summary>
        heap_fill_empty,     
        /// <summary>
        /// 2560 - 3583 bytes free
        /// </summary>
        heap_fill_1,
        /// <summary>
        /// 2048 - 2559 bytes free
        /// </summary>
        heap_fill_2,        
        /// <summary>
        /// 1792 - 2047 bytes free
        /// </summary>
        heap_fill_3,        
        /// <summary>
        /// 1536 - 1791 bytes free
        /// </summary>
        heap_fill_4,        
        /// <summary>
        /// 1280 - 1535 bytes free
        /// </summary>
        heap_fill_5,        
        /// <summary>
        /// 1024 - 1279 bytes free
        /// </summary>
        heap_fill_6,        
        /// <summary>
        /// 768 - 1023 bytes free
        /// </summary>
        heap_fill_7,        
        /// <summary>
        /// 512 - 767 bytes free
        /// </summary>
        heap_fill_8,        
        /// <summary>
        /// 256 - 511 bytes free
        /// </summary>
        heap_fill_9,        
        /// <summary>
        /// 128 - 255 bytes free
        /// </summary>
        heap_fill_10,       
        /// <summary>
        /// 64 - 127 bytes free
        /// </summary>
        heap_fill_11,       
        /// <summary>
        /// 32 - 63 bytes free
        /// </summary>
        heap_fill_12,       
        /// <summary>
        /// 16 - 31 bytes free
        /// </summary>
        heap_fill_13,       
        /// <summary>
        /// 8 - 15 bytes free
        /// </summary>
        heap_fill_14,       
        /// <summary>
        /// < 8 bytes free
        /// </summary>
        heap_fill_full      
    }
}