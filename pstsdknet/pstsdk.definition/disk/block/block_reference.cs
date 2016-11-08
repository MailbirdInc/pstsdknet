using pstsdk.definition.util.primitives;

namespace pstsdk.definition.disk.block
{
    /// <summary>
    /// The combination of the id and physical location of a block or page 
    /// </summary>
    public struct block_reference<T> where T : struct
    {
        /// <summary>
        /// The id of the referenced object
        /// </summary>
        public BlockID bid; 

        /// <summary>
        /// The location on Disk (index byte) of the referenced object
        /// </summary>
        public Location<T> ib;  
    }
}