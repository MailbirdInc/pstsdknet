using pstsdk.definition.ndb.database;

namespace pstsdk.definition.disk.page
{
    /// <summary>
    /// <para>The fundamental page structure which forms the basis of the two BTrees</para>
    /// <para>
    /// Generally speaking, the generic form of a BTree page contains a fixed
    /// array of entries, followed by metadata about those entries and the
    /// page. The entry type (and entry size, and thus the max number of
    /// entries) varies between NBT and BBT pages.
    /// </para>
    /// <para>[MS-PST] 2.2.2.7.7.1</para>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TEntry"></typeparam>
    public class bt_page<T, TEntry> : IBTPage<T, TEntry>
        where T : page_trailer, new()
        where TEntry : struct, entry
    {

        public static int extra_space =
            page<T>.page_data_size - (new T().Size() * sizeof(byte));

        /// <summary>
        /// Maximum number of entries on a page
        /// </summary>
        public static int max_entries = 
            extra_space /  default(TEntry).Size(); 

        public bt_page()
        {
            this.entries = new TEntry[max_entries];
            this._ignore = new byte[extra_space];
            this.trailer = new T();
        }

        public TEntry[] entries { get; private set; }
        public byte[] _ignore { get; private set; }

        /// <summary>
        /// Number of entries on this page
        /// </summary>
        public byte num_entries;          
        /// <summary>
        /// Maximum number of entries on this page
        /// </summary>
        public byte num_entries_max;      
        /// <summary>
        /// The size of each entry
        /// </summary>
        public byte entry_size;           
        
        /// <summary>
        /// The level of this page. A level of zero indicates a leaf.
        /// </summary>
        public byte level;                

        /// <summary>
        /// The page trailer
        /// </summary>
        public T trailer { get; private set; }   

        // TODO: implement GetBytes and FromBytes as others of this ilk do.. -th
    }
}