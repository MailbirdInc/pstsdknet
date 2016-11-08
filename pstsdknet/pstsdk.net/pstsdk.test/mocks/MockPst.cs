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
    public class MockPst : IPst
    {
        public string Name
        {
            get { return "Mock Pst"; }
        }

        public IEnumerable<IFolder> Folders
        {
            get 
            {
                var folders = new List<IFolder>
                                  {
                                      new Folder(new FolderMockDBContext(), new FolderMockPropBag()),
                                      new Folder(new DifferentMockDBContext(), new DifferentMockPropBag())
                                  };

                return folders;
            }
        }

        public IFolder OpenRootFolder()
        {
            return new Folder(new FolderMockDBContext(), new FolderMockPropBag());            
        }

        public IFolder OpenFolder(string name)
        {
            return new Folder(new FolderMockDBContext(), new FolderMockPropBag()); 
        }

        public IFolder OpenFolder(NodeID nodeID)
        {
            return new Folder(new FolderMockDBContext(), new FolderMockPropBag()); 
        }

        public ISearchFolder OpenSearchFolder(NodeID nodeID)
        {
            return new SearchFolder(new SearchFolderMockDBContext(), nodeID); 
        }

        public INameIDMap NameIDMap
        {
            get 
            {
                return new NameIdMap(new NameIdMapMockDBContext());
            }
        }

        public IEnumerable<IMessage> Messages
        {
            get 
            {
                var messages = new List<IMessage>
                                   {
                                       new Message(new MessageMockDBContext(), new MessageMockPropBag()),
                                       new Message(new DifferentMockDBContext(), new DifferentMockPropBag())
                                   };

                return messages;
            }
        }

        public IMessage OpenMessage(NodeID nodeID)
        {
            return new Message(new MessageMockDBContext(), nodeID);
        }

        public IDBAccessor DatabaseAccessor
        {
            get { return new MockDBContext(); }
        }

        public NodeID Node
        {
            get { return 1234; }
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
            return 1234;
        }

        public byte[] ReadProperty(PropId id)
        {
            byte[] byteArray = { 1, 2, 3, 4 };
            return byteArray;
        }

        public Stream OpenPropertyStream(PropId id)
        {
            var mockPropBag = new MockPropBag();
            return mockPropBag.OpenPropertyStream(id);
        }

        public void Dispose()
        {
            return;
        }

    }
}
