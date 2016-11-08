using System;

using pstsdk.definition.util.primitives;

namespace pstsdk.definition.disk.header
{
    /// <summary>
    /// <para>The ANSI header structure</para>
    /// <para>See the documentation for Unicode header. Note that some fields
    /// in the ANSI header are in a different order (most notably \a bidNextB).
    /// </para>
    /// <para>[MS-PST] 2.2.2.6</para>
    /// </summary>
    public class ansi_header : header<UInt32>
    {
        public const int size_of = 512;

        /// <summary>
        /// Unused
        /// </summary>
        public BlockID bidNextB;

        /// <summary>
        /// The page id counter
        /// </summary>
        public BlockID bidNextP;

        /// <summary>
        /// 
        /// </summary>
        public UInt32 dwUnique;

        /// <summary>
        /// Array of node_id counters, one per node type
        /// </summary>
        public NodeID[] rgnid = new NodeID[(uint)NidType.nid_type_max];

        /// <summary>
        /// The root info for this database
        /// </summary>
        public root<UInt32> root_info;

        /// <summary>
        /// deprecated The header's FMap entries
        /// </summary>
        public byte[] rgbFM = new byte[Disk.header_fmap_entries];

        /// <summary>
        /// deprecated The header's FPMap entries
        /// </summary>
        public byte[] rgbFP = new byte[Disk.header_fpmap_size];

        /// <summary>
        /// deprecated Sentinel byte indicating the end of the headers FPMap
        /// </summary>
        public byte bSentinel;

        /// <summary>
        /// The CryptMethod used in this file
        /// </summary>
        public byte bCryptMethod;

        /// <summary>
        /// Unused
        /// </summary>
        public byte[] rgbReserved = new byte[2];

        /// <summary>
        /// The block id counter
        /// </summary>
        public UInt64 ullReserved;

        public UInt32 dwReserved;

        public byte[] rgbVersionEncoded = new byte[3];

        /// <summary>
        /// Implementation specific
        /// </summary>
        public byte bLockSemaphore;

        /// <summary>
        /// Implementation specific
        /// </summary>
        public byte[] rgbLock = new byte[Disk.header_lock_entries];

        public const int offset_of_bLockSemaphore = size_of - Disk.header_lock_entries - 1;

        // TODO: implement From/Get Bytes
    }
}