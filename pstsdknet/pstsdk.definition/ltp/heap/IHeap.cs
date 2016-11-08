using System;
using pstsdk.definition.ndb.node;
using pstsdk.definition.util.primitives;

namespace pstsdk.definition.ltp.heap
{
    public interface IHeap
    {
        uint Size(HeapID id);
        HeapID RootID { get; }
        byte ClientSignature { get; }
        uint Read(byte[] buffer, HeapID id, UInt32 offset);
        byte[] Read(HeapID id);
        IHidStreamDevice OpenStream(HeapID id);

        INode Node { get; }
    
        IBTHNode<TKey, TValue> OpenBth<TKey, TValue>(HeapID root);
    }
}