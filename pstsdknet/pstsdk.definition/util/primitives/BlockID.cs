using System;

namespace pstsdk.definition.util.primitives
{
    public struct BlockID
    {
        public UInt64 Value { get; set; }

        public static implicit operator BlockID(UInt64 value)
        {
            return new BlockID { Value = value };
        }
        public static implicit operator UInt64(BlockID value)
        {
            return value.Value;
        }
        public static implicit operator BlockID(UInt32 value)
        {
            return new BlockID { Value = value };
        }
        public static implicit operator UInt32(BlockID value)
        {
            return (UInt32)value.Value;
        }

        /// <summary>
        /// <para>The internal bit indicates a block is an extended_block or a subnode_block</para>
        /// <para>[MS-PST] 2.2.2.2/i</para>
        /// </summary>
        public const UInt16 block_id_internal_bit = 0x2;

        /// <summary>
        /// <para>The block id counter in the header is incremented by this amount for each block</para>
        /// <para>2.2.2.6/bidNextB</para>
        /// </summary>
        public const UInt16 block_id_increment = 0x4;

        /// <summary>
        /// <para>Determines if a block is external or not</para>
        /// </summary>
        /// <param name="bid"></param>
        /// <returns></returns>
        public static bool bid_is_external(UInt64 bid)
        {
            return (bid & block_id_internal_bit) == 0;
        }

        public static bool bid_is_external(UInt32 bid)
        {
            return (bid & block_id_internal_bit) == 0;
        }

        /// <summary>
        /// <para>Determines if a block is internal or not</para>
        /// </summary>
        /// <param name="bid"></param>
        /// <returns></returns>
        public static bool bid_is_internal(UInt64 bid) { return !bid_is_external(bid); }
        public static bool bid_is_internal(UInt32 bid) { return !bid_is_external(bid); }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}