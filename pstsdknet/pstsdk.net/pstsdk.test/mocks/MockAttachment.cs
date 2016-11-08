using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using pstsdk.definition.pst.message;
using System.IO;
using pstsdk.definition.util.primitives;

namespace pstsdk.test.mocks
{
    public class MockAttachment : IAttachment
    {
        public int ContentSize
        {
            get { throw new NotImplementedException(); }
        }

        public byte[] Bytes
        {
            get { throw new NotImplementedException(); }
        }

        public string Filename
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsMessage
        {
            get { throw new NotImplementedException(); }
        }

        public IMessage OpenAsMessage()
        {
            throw new NotImplementedException();
        }

        public Stream ByteStream
        {
            get { throw new NotImplementedException(); }
        }

        public int Size
        {
            get { throw new NotImplementedException(); }
        }

        public bool Equals(IAttachment other)
        {
            throw new NotImplementedException();
        }

        public NodeID Node
        {
            get { return (UInt32)NodeID.Predefined.nid_attachment_table; }
        }

        public IEnumerable<PropId> Properties
        {
            get { throw new NotImplementedException(); }
        }

        public PropertyType GetPropertyType(PropId id)
        {
            throw new NotImplementedException();
        }

        public bool PropertyExists(PropId id)
        {
            throw new NotImplementedException();
        }

        public uint PropertySize(PropId id)
        {
            throw new NotImplementedException();
        }

        public byte[] ReadProperty(PropId id)
        {
            throw new NotImplementedException();
        }

        public Stream OpenPropertyStream(PropId id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}
