using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using pstsdk.definition.pst.folder;
using System.IO;
using pstsdk.definition.util.primitives;
using pstsdk.definition.ndb.database;
using pstsdk.definition.pst.message;

namespace pstsdk.test.mocks
{
    public class MockFolder : IFolder
    {
        public int AssociatedMessageCount
        {
            get { throw new NotImplementedException(); }
        }

        public IEnumerable<IMessage> AssociatedMessages
        {
            get { throw new NotImplementedException(); }
        }

        public int MessageCount
        {
            get { throw new NotImplementedException(); }
        }

        public IEnumerable<IMessage> Messages
        {
            get { throw new NotImplementedException(); }
        }

        public IDBAccessor DatabaseContext
        {
            get { throw new NotImplementedException(); }
        }

        public EntryID EntryID
        {
            get { throw new NotImplementedException(); }
        }

        public string Name
        {
            get { throw new NotImplementedException(); }
        }

        public int SubFolderCount
        {
            get { throw new NotImplementedException(); }
        }

        public IFolder OpenSubFolder(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IFolder> SubFolders
        {
            get { throw new NotImplementedException(); }
        }

        public NodeID Node
        {
            get { throw new NotImplementedException(); }
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
