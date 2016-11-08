using System;

namespace pstsdk.definition.util.primitives
{
    public struct HeapID
    {
        public UInt32 Value { get; set; }

        public static implicit operator HeapID(UInt32 value)
        {
            return new HeapID { Value = value };
        }

        public static implicit operator UInt32(HeapID value)
        {
            return value.Value;
        }


        /// <summary>
        /// Get the heap page from the heap id, [MS-PST] 2.3.1.1/hidBlockIndex
        /// </summary>
        /// <param name="id">The heap id</param>
        /// <returns>The heap page</returns>
        public static HeapID get_heap_page(HeapID id)
        {
            return (id >> 16);
        }

        /// <summary>
        /// Get the index from the heap id, [MS-PST] 2.3.1.1/hidIndex
        /// </summary>
        /// <param name="id">The heap id</param>
        /// <returns>The index</returns>
        public static HeapID get_heap_index(HeapID id)
        {
            return (((id >> 5) - 1) & 0x7FF);
        }
    }
}