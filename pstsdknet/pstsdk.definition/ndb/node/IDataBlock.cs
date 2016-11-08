namespace pstsdk.definition.ndb.node
{
    public interface IDataBlock : IBlock
    {
        int Read(byte[] buffer, int offset);
        T Read<T>(int offset);
        int ReadRaw(byte[] buffer, int size, int offset);
        int WriteRaw(byte[] buffer, int size, int offset, out IDataBlock result);
        int PageCount { get; }
        IExternalBlock GetPage(uint pageNum);
        int Resize(int size, out IDataBlock result);
    }
}