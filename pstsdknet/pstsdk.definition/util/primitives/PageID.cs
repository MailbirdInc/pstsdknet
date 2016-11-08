using System;

namespace pstsdk.definition.util.primitives
{
    public struct PageID
    {
        public UInt64 Value { get; set; }

        public static implicit operator PageID(UInt64 value)
        {
            return new PageID { Value = value };
        }
        public static implicit operator UInt64(PageID value)
        {
            return value.Value;
        }
        public static implicit operator PageID(UInt32 value)
        {
            return new PageID { Value = value };
        }
        public static implicit operator UInt32(PageID value)
        {
            return (UInt32)value.Value;
        }
    }
}