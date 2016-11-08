using System;
using System.Collections.Generic;
using System.Text;

using pstsdk.definition.ltp.nameid;
using pstsdk.definition.ltp.propbag;

using pstsdk.definition.ndb.database;
using pstsdk.definition.ltp;
using pstsdk.definition.pst.folder;
using pstsdk.definition.pst.message;
using pstsdk.definition.util.primitives;

namespace pstsdk.definition.pst
{
    public interface IPst : IPropertyObject
    {
        string Name { get; }

        NodeID GetNodeID(EntryID entry);

        IEnumerable<IFolder> Folders { get; }
        IFolder OpenRootFolder();
        IFolder OpenFolder(string name);
        IFolder OpenFolder(NodeID nodeID);
        ISearchFolder OpenSearchFolder(NodeID nodeID);
        NodeID GetTopIPMFolderId();
        NodeID GetTrashFolderId();
        NodeID GetSentFolderId();
        NodeID GetOutboxFolderId();

        INameIDMap NameIDMap { get; }

        IEnumerable<IMessage> Messages { get; }
        IMessage OpenMessage(NodeID nodeID);

        IDBAccessor DatabaseAccessor { get; }
    }
}
