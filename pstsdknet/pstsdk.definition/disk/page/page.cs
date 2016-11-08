using pstsdk.definition.disk.header;

namespace pstsdk.definition.disk.page
{
    /// <summary>
    /// Page structure, [MS-PST] 2.2.2.7
    /// </summary>
    public class page<T> where T : page_trailer, new()
    {
        public page()
        {
            
        }
        public const int size_of = Disk.page_size;

        //!< Amount of usable space in a page
        public static readonly int page_data_size = 
            Disk.page_size - 
            (typeof(T) == typeof(ansi_header) ?
                                                  ansi_page_trailer.size_of : unicode_page_trailer.size_of);

        /// <summary>
        /// space used for actual data
        /// </summary>
        public byte[] data = new byte[page_data_size]; 

        /// <summary>
        /// The page trailer for this page
        /// </summary>
        public T trailer;
    }
}