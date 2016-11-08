using System;
using System.Collections.Generic;
using System.Text;

namespace pstsdk.definition.util.primitives
{
    public struct NodeID : IComparable<NodeID>, IComparable<NodeID.Predefined>
    {
        /// <summary>
        /// The portion of a node_id reserved for the type
        /// [MS-PST] 2.2.2.1/nidType
        /// </summary>
        public const UInt32 nid_type_mask = (UInt32)0x1FL;

        public UInt32 Value { get; set; }

        public static implicit operator NodeID(UInt32 value)
        {
            return new NodeID { Value = value };
        }

        public static implicit operator UInt32(NodeID value)
        {
            return value.Value;
        }

        public static implicit operator NodeID(Predefined value)
        {
            return value;
        }

        public static implicit operator Predefined(NodeID value)
        {
            return value;
        }

        /// <summary>
        /// Construct a node_id (NID) from a node type and index
        /// [MS-PST] 2.2.2.1
        /// </summary>
        public static NodeID make_nid(NidType nid_type, NodeID nid_index)
        {
            return ((UInt32)nid_type & nid_type_mask) | ((nid_index) << 5);
        }

        /// <summary>
        ///  Construct a folders node_id for an OST file
        /// </summary>
        /// <param name="nid_index"></param>
        /// <returns></returns>
        public static NodeID make_prv_pub_nid(NodeID nid_index)
        {
            return (make_nid(NidType.nid_type_folder, ((UInt32)Predefined.nid_index_prv_pub_base) + (nid_index)));
        }

        /// <summary>
        /// Get a node type from a node id, [MS-PST] 2.2.2.1/nidType
        /// </summary>
        /// <param name="id">The node id</param>
        /// <returns>The node type</returns>
        public static NidType get_nid_type(NodeID id)
        {
            return (NidType)(id & nid_type_mask);
        }

        /// <summary>
        /// Get a node index from a node id, [MS-PST] 2.2.2.1/nidIndex
        /// </summary>
        /// <param name="id">The node id</param>
        /// <returns>The node index</returns>
        public static NodeID get_nid_index(NodeID id)
        {
            return id >> 5;
        }

        public static NodeID make_nid(Predefined predefined)
        {
            return (UInt16)predefined;
        }

        public int CompareTo(NodeID other)
        {
            return Value.CompareTo(other.Value);
        }
        
        public int CompareTo(Predefined other)
        {
            return Value.CompareTo(other);
        }
        /// <summary>
        /// <para>The predefined nodes in a PST/OST file</para>
        /// <para>[MS-PST] 2.4.1</para>
        /// </summary>
        public enum Predefined : uint
        {
            nid_message_store = (NidType.nid_type_internal & NodeID.nid_type_mask) | (0x1 << 5),   //!< The property bag for this file
            nid_name_id_map = (NidType.nid_type_internal & NodeID.nid_type_mask) | (0x3 << 5),     //!< Contains the named prop mappings
            nid_normal_folder_template = (NidType.nid_type_folder & NodeID.nid_type_mask) | (0x6 << 5),
            nid_search_folder_template = (NidType.nid_type_folder & NodeID.nid_type_mask) | (0x7 << 5),
            nid_root_folder = (NidType.nid_type_folder & NodeID.nid_type_mask) | (0x9 << 5),       //!< Root folder of the store
            nid_search_management_queue = (NidType.nid_type_internal & NodeID.nid_type_mask) | (0xF << 5),
            nid_search_activity_list = (NidType.nid_type_internal & NodeID.nid_type_mask) | (0x10 << 5),
            nid_search_domain_alternative = (NidType.nid_type_internal & NodeID.nid_type_mask) | (0x12 << 5),
            nid_search_domain_object = (NidType.nid_type_internal & NodeID.nid_type_mask) | (0x13 << 5),
            nid_search_gatherer_queue = (NidType.nid_type_internal & NodeID.nid_type_mask) | (0x14 << 5),
            nid_search_gatherer_descriptor = (NidType.nid_type_internal & NodeID.nid_type_mask) | (0x15 << 5),
            nid_table_rebuild_queue = (NidType.nid_type_internal & NodeID.nid_type_mask) | (0x17 << 5),
            nid_junk_mail_pihsl = (NidType.nid_type_internal & NodeID.nid_type_mask) | (0x18 << 5),
            nid_search_gatherer_folder_queue = (NidType.nid_type_internal & NodeID.nid_type_mask) | (0x19 << 5),
            nid_tc_sub_props = (NidType.nid_type_internal & NodeID.nid_type_mask) | (0x27 << 5),
            nid_index_template = 0x30,
            nid_hierarchy_table_template = (NidType.nid_type_hierarchy_table & NodeID.nid_type_mask) | (nid_index_template << 5),
            nid_contents_table_template = (NidType.nid_type_contents_table & NodeID.nid_type_mask) | (nid_index_template << 5),
            nid_associated_contents_table_template = (NidType.nid_type_associated_contents_table & NodeID.nid_type_mask) | (nid_index_template << 5),
            nid_search_contents_table_template = (NidType.nid_type_search_contents_table & NodeID.nid_type_mask) | (nid_index_template << 5),
            nid_smp_template = (NidType.nid_type_contents_smp & NodeID.nid_type_mask) | (nid_index_template << 5),
            nid_tombstone_table_template = (NidType.nid_type_tombstone_table & NodeID.nid_type_mask) | (nid_index_template << 5),
            nid_lrep_dups_table_template = (NidType.nid_type_lrep_dups_table & NodeID.nid_type_mask) | (nid_index_template << 5),
            nid_receive_folders = (NidType.nid_type_receive_folder_table & NodeID.nid_type_mask) | (0x31 << 5),
            nid_outgoing_queue = (NidType.nid_type_outgoing_queue_table & NodeID.nid_type_mask) | (0x32 << 5),
            nid_attachment_table = (NidType.nid_type_attachment_table & NodeID.nid_type_mask) | (0x33 << 5),
            nid_recipient_table = (NidType.nid_type_recipient_table & NodeID.nid_type_mask) | (0x34 << 5),
            nid_change_history_table = (NidType.nid_type_change_history_table & NodeID.nid_type_mask) | (0x35 << 5),
            nid_tombstone_table = (NidType.nid_type_tombstone_table & NodeID.nid_type_mask) | (0x36 << 5),
            nid_tombstone_date_table = (NidType.nid_type_tombstone_date_table & NodeID.nid_type_mask) | (0x37 << 5),
            nid_all_message_search_folder = (NidType.nid_type_search_folder & NodeID.nid_type_mask) | (0x39 << 5), //!< \deprecated The GUST
            nid_all_message_search_contents = (NidType.nid_type_search_contents_table & NodeID.nid_type_mask) | (0x39 << 5),
            nid_lrep_gmp = (NidType.nid_type_internal & NodeID.nid_type_mask) | (0x40 << 5),
            nid_lrep_folders_smp = (NidType.nid_type_internal & NodeID.nid_type_mask) | (0x41 << 5),
            nid_lrep_folders_table = (NidType.nid_type_internal & NodeID.nid_type_mask) | (0x42 << 5),
            nid_folder_path_tombstone_table = (NidType.nid_type_internal & NodeID.nid_type_mask) | (0x43 << 5),
            nid_hst_hmp = (NidType.nid_type_internal & NodeID.nid_type_mask) | (0x60 << 5),
            nid_index_prv_pub_base = 0x100,
            nid_pub_root_folder = (NidType.nid_type_folder & NodeID.nid_type_mask) | ((0x100 + 0) << 5),
            nid_prv_root_folder = (NidType.nid_type_folder & NodeID.nid_type_mask) | ((0x100 + 5) << 5),
            nid_criterr_notification = (NidType.nid_type_internal & NodeID.nid_type_mask) | (0x3FD << 5),
            nid_object_notification = (NidType.nid_type_internal & NodeID.nid_type_mask) | (0x3FE << 5),
            nid_newemail_notification = (NidType.nid_type_internal & NodeID.nid_type_mask) | (0x3FF << 5),
            nid_extended_notification = (NidType.nid_type_internal & NodeID.nid_type_mask) | (0x400 << 5),
            nid_indexing_notification = (NidType.nid_type_internal & NodeID.nid_type_mask) | (0x401 << 5)
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
