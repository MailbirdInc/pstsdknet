namespace pstsdk.definition.util.primitives
{
    public struct BTKey<T> where T : struct
    {
        public T Value { get; set; }

        public static implicit operator BTKey<T>(T value)
        {
            return new BTKey<T> { Value = value };
        }
        public static implicit operator T(BTKey<T> value)
        {
            return value.Value;
        }
    }
}