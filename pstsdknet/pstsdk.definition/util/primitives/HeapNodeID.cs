using System;

namespace pstsdk.definition.util.primitives
{
    public struct HeapNodeID 
    {
        public UInt32 Value { get; set; }

        public static implicit operator HeapNodeID(UInt32 value)
        {
            return new HeapNodeID { Value = value };
        }

        public static implicit operator UInt32(HeapNodeID value)
        {
            return value.Value;
        }

        // no struct inheritance... -th

        public static implicit operator HeapNodeID(NodeID value)
        {
            return new HeapNodeID { Value = value };
        }

        public static implicit operator NodeID(HeapNodeID value)
        {
            return value.Value;
        }

        /// <summary>
        /// Inspects a heapnode_id (also known as a HNID) to determine if
        /// it is a heap_id (HID), [MS-PST] 2.3.3.2
        /// </summary>
        /// <param name="id">The heapnode_id</param>
        /// <returns>true if this is a heap_id</returns>
        public static bool is_heap_id(HeapNodeID id)
        {
            return (NodeID.get_nid_type(id) == NidType.nid_type_none);
        }

        /// <summary>
        ///  Inspects a heapnode_id (also known as a HNID) to determine if
        ///  it is a node_id (NID), [MS-PST] 2.3.3.2
        /// </summary>
        /// <param name="id">The heapnode_id</param>
        /// <returns>true if this is a node_id of a subnode</returns>
        public static bool is_subnode_id(HeapNodeID id)
        { 
            return (NodeID.get_nid_type(id) != NidType.nid_type_none); 
        }
    }
}