namespace pstsdk.definition.ndb.node
{
    /// <summary>
    /// <para>Defines a stream device for a node.</para> 
    /// <para>The boost iostream library requires that one defines a device, which
    /// implements a few key operations. This is the device for streaming out
    /// of a node.
    /// </para>
    /// </summary>
    public interface INodeStreamDevice 
    {
        int Read(byte[] buffer, int n);
        int Write(byte[] buffer, int n);
        int Seek(int offset, System.IO.SeekOrigin way);
    }
}