namespace pstsdk.definition.util.primitives
{
    public struct NidIndex<T> where T : struct
    {
        public T Value { get; set; }

        public static implicit operator NidIndex<T>(T value)
        {
            return new NidIndex<T> { Value = value };
        }
        public static implicit operator T(NidIndex<T> value)
        {
            return value.Value;
        }
    }
}