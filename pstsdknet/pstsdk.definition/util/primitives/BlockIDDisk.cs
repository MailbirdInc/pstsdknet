namespace pstsdk.definition.util.primitives
{
    public struct BlockIDDisk<T> where T : struct
    {
        public T Value { get; set; }

        public static implicit operator BlockIDDisk<T>(T value)
        {
            return new BlockIDDisk<T> { Value = value };
        }
        public static implicit operator T(BlockIDDisk<T> value)
        {
            return value.Value;
        }
    }
}