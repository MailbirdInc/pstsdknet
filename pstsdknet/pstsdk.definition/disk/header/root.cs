using pstsdk.definition.disk.block;
using pstsdk.definition.util.primitives;

namespace pstsdk.definition.disk.header
{
    /// <summary>
    /// <para>The root of the database</para>
    /// <para>
    /// The root structures describes where the root pages of the NBT and BBT are
    /// located, the EOF location, how much space is free, the allocation state 
    /// flag, and more.
    /// </para>
    /// <para>[MS-PST] 2.2.2.5</para>
    /// </summary>
    /// <typeparam name="T">UInt64 for a unicode store, UInt32 for an ANSI store</typeparam>
    public struct root<T> where T : struct
    {
        /// <summary>
        /// The number of "orphans" in the BBT
        /// </summary>
        public System.UInt32 cOrphans;             

        /// <summary>
        /// EOF of the file, according the header
        /// </summary>
        public Location<T> ibFileEof;         
        /// <summary>
        /// The location of the last valid AMap page
        /// </summary>
        public Location<T> ibAMapLast;        
        /// <summary>
        /// Amount of space free in all AMap pages
        /// </summary>
        public Count<T> cbAMapFree;           
        /// <summary>
        /// Amount of space free in all PMap pages
        /// </summary>
        public Count<T> cbPMapFree;           
        /// <summary>
        /// The location of the root of the NBT
        /// </summary>
        public block_reference<T> brefNBT; 
        /// <summary>
        /// The location of the root of the BBT
        /// </summary>
        public block_reference<T> brefBBT; 
        /// <summary>
        /// Indicates if the AMap pages are valid or not
        /// </summary>
        public byte fAMapValid;            
        /// <summary>
        /// Indicates which AddRef vector is used
        /// </summary>
        public byte bARVec;                
        /// <summary>
        /// Number of elements in the AddRef vector
        /// </summary>
        public ushort cARVec;
    };
}