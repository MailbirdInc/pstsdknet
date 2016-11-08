namespace pstsdk.definition.util.primitives
{
    public struct EntryID 
    {
        public static EntryID Empty = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

        public byte[] Value { get; set; }

        public static implicit operator EntryID(byte[] value)
        {
            return new EntryID { Value = value };
        }

        public static implicit operator byte[](EntryID value)
        {
            return value.Value;
        }
    }
}