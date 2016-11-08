using System;
using System.Runtime.InteropServices;

namespace pstsdk.definition.disk.page
{
    /// <summary>
    /// <para>A metapage holding information about AMap pages</para>
    /// <para>The Density List page contains a list of AMap pages in the file, in ascending
    /// order of density. That is to say, the "emptiest" page is at the top. This is the
    /// data backing the new allocation scheme which replaced the old pmap/fmap/fpmap
    /// scheme, starting in Outlook 2007 SP2.</para>
    /// <para>[MS-PST] 2.2.2.7.4.2</para>
    /// </summary>
    public class dlist_page<T> where T : page_trailer, new()
    {
        public static int extra_space = page<T>.page_data_size - 8;
            
        /// <summary>
        /// Maximum number of entries in the dlist page
        /// </summary>
        public static int max_entries = extra_space / sizeof(UInt32);

        public dlist_page()
        {
            this.entries = new UInt32[max_entries];
            this._ignore = new byte[extra_space];
            this.trailer = new T();
        }
        /// <summary>
        /// Flags indicating the state of the dlist page
        /// </summary>
        public byte flags;                       

        /// <summary>
        /// Number of entries in the entries array
        /// </summary>
        public byte num_entries;                 
        
        // union 1

        /// <summary>
        /// The current AMap page used for allocations
        /// </summary>
        public UInt32 current_page { get; private set; }

        /// <summary>
        /// The current backfill marker, when backfilling
        /// </summary>
        public UInt32 backfill_location { get; private set; }
        
        // union 2 

        /// <summary>
        /// Each entry has bits for the amap page (ordinal) and free space (slots)
        /// </summary>
        public UInt32[] entries { get; private set; }
        public byte[] _ignore { get; private set; }

        /// <summary>
        /// The page trailer for this page
        /// </summary>
        public T trailer;

        public byte[] GetBytes()
        {
            byte[] bytes = new byte[Disk.page_size];
            int currentOffset = 0;
            bytes[currentOffset] = this.flags;
            bytes[currentOffset++] = this.num_entries;
            var nextSetOfBytes =
                //current_page != default(UInt32)
                //? 
                BitConverter.GetBytes(this.current_page);
            //: BitConverter.GetBytes(backfill_location);

            bytes[currentOffset++] = nextSetOfBytes[0];
            bytes[currentOffset++] = nextSetOfBytes[1];
            bytes[currentOffset++] = nextSetOfBytes[2];
            bytes[currentOffset++] = nextSetOfBytes[3];

            for (int i = 0; i < extra_space; i++)
            {
                bytes[currentOffset++] = this._ignore[i];
            }

            var trailerBytes = this.trailer.GetBytes();
            for (int i = 0; i < trailerBytes.Length; i++)
            {
                bytes[currentOffset++] = trailerBytes[i];
            }

            return bytes;
        }
        public void FromBytes(byte[] bytes)
        {
            int currentOffset = 0;
            this.flags = bytes[currentOffset];
            this.num_entries = bytes[currentOffset++];

            this.current_page = BitConverter.ToUInt32(bytes, currentOffset++);
            this.backfill_location = this.current_page;

            for (int i = 0; i < extra_space; i++)
            {
                this._ignore[i] = bytes[currentOffset++];
            }
            for (int i = 0; i < max_entries; i++)
            {
                this.entries[i] = BitConverter.ToUInt32(this._ignore, i * 4);
            }
            byte[] trailerBytes = new byte[this.trailer.Size()];
            Array.Copy(bytes, currentOffset++, trailerBytes, 0, trailerBytes.Length);

            this.trailer.FromBytes(trailerBytes);
        }        
    }
}