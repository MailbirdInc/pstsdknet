using System.Collections.Generic;
using pstsdk.definition.pst;
using pstsdk.definition.util.primitives;
using pstsdk.definition.ltp.nameid;
using pstsdk.definition.pst.folder;
using pstsdk.definition.pst.message;
using pstsdk.definition.ndb.database;
using System.IO;
using pstsdk.layer.pst;
using pstsdk.layer.ltp.nameid;
using pstsdk.test.mocks.MockDBContexts;
using pstsdk.test.mocks.MockPropBags;

namespace pstsdk.test.mocks
{
    public class DifferentMockPst : IPst
    {
        public string Name
        {
            get { return "Mock Pst"; }
        }

        public IEnumerable<IFolder> Folders
        {
            get
            {
                var folders = new List<IFolder> {new Folder(new DifferentMockDBContext(), new DifferentMockPropBag())};
                return folders;
            }
        }

        public IFolder OpenRootFolder()
        {
            return new Folder(new DifferentMockDBContext(), new DifferentMockPropBag());
        }

        public IFolder OpenFolder(string name)
        {
            return new Folder(new DifferentMockDBContext(), new DifferentMockPropBag());
        }

        public IFolder OpenFolder(NodeID nodeID)
        {
            return new Folder(new DifferentMockDBContext(), nodeID);
        }

        public ISearchFolder OpenSearchFolder(NodeID nodeID)
        {
            return new SearchFolder(new DifferentMockDBContext(), nodeID);
        }

        public INameIDMap NameIDMap
        {
            get
            {
                return new NameIdMap(new DifferentMockDBContext());
            }
        }

        public IEnumerable<IMessage> Messages
        {
            get
            {
                IEnumerable<IMessage> messages = new List<IMessage>();
                return messages;
            }
        }

        public IMessage OpenMessage(NodeID nodeID)
        {
            return new Message(new DifferentMockDBContext(), nodeID);
        }

        public IDBAccessor DatabaseAccessor
        {
            get { return new DifferentMockDBContext(); }           
        }

        public NodeID Node
        {
            get { return NodeID.Predefined.nid_message_store; }
        }

        public IEnumerable<PropId> Properties
        {
            get
            {
                IEnumerable<PropId> props = new List<PropId>();
                return props;
            }
        }

        public PropertyType GetPropertyType(PropId id)
        {
            return new PropertyType();
        }

        public bool PropertyExists(PropId id)
        {
            return true;
        }

        public uint PropertySize(PropId id)
        {
            var mockPropBag = new DifferentMockPropBag();
            return mockPropBag.GetPropertyType(id);
        }

        public byte[] ReadProperty(PropId id)
        {
            byte[] byteArray = { 5, 6, 7, 8 };
            return byteArray;
        }

        public Stream OpenPropertyStream(PropId id)
        {
            var mockPropBag = new DifferentMockPropBag();
            return mockPropBag.OpenPropertyStream(id);
        }

        public void Dispose()
        {
            return;
        }

    }
}
