namespace pstsdk.definition.util.primitives
{
    public struct Count<T> where T : struct
    {
        public T Value { get; set; }

        public static implicit operator Count<T>(T value)
        {
            return new Count<T> { Value = value };
        }
        public static implicit operator T(Count<T> value)
        {
            return value.Value;
        }
    }
}