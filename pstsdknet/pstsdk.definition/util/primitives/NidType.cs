using System;

namespace pstsdk.definition.util.primitives
{
    /// <summary>
    /// <para>Different node types found in a PST file</para>
    /// <para>[MS-PST] 2.2.2.1</para>
    /// </summary>
    public enum NidType : uint
    {
        nid_type_none = 0x00,
        nid_type_internal = 0x01,
        nid_type_folder = 0x02,
        nid_type_search_folder = 0x03,
        nid_type_message = 0x04,
        nid_type_attachment = 0x05,
        nid_type_search_update_queue = 0x06,
        nid_type_search_criteria_object = 0x07,
        nid_type_associated_message = 0x08,
        nid_type_storage = 0x09,
        nid_type_contents_table_index = 0x0A,
        nid_type_receive_folder_table = 0x0B,
        nid_type_outgoing_queue_table = 0x0C,
        nid_type_hierarchy_table = 0x0D,
        nid_type_contents_table = 0x0E,
        nid_type_associated_contents_table = 0x0F,
        nid_type_search_contents_table = 0x10,
        nid_type_attachment_table = 0x11,
        nid_type_recipient_table = 0x12,
        nid_type_search_table_index = 0x13,
        nid_type_contents_smp = 0x14,
        nid_type_associated_contents_smp = 0x15,
        nid_type_change_history_table = 0x16,
        nid_type_tombstone_table = 0x17,
        nid_type_tombstone_date_table = 0x18,
        nid_type_lrep_dups_table = 0x19,
        nid_type_folder_path_tombstone_table = 0x1A,
        nid_type_ltp = 0x1F,
        nid_type_max = 0x20
    }
}