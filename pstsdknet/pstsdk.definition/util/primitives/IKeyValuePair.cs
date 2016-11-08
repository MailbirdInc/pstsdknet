namespace pstsdk.definition.util.primitives
{
    public interface IKeyValuePair<TKey, TValue>
    {
        TKey Key { get; set; }
        TValue Value { get; set; }
    }
}