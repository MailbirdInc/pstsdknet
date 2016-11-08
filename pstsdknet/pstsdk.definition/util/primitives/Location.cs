namespace pstsdk.definition.util.primitives
{
    public struct Location<T> where T : struct
    {
        public T Value { get; set; }

        public static implicit operator Location<T>(T value)
        {
            return new Location<T> { Value = value };
        }
        public static implicit operator T(Location<T> value)
        {
            return value.Value;
        }
    }
}