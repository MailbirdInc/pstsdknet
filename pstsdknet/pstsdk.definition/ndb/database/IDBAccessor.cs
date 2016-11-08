using System;
using System.Collections.Generic;
using System.Text;
using pstsdk.definition.ltp;
using pstsdk.definition.ltp.nameid;
using pstsdk.definition.util.primitives;

namespace pstsdk.definition.ndb.database
{
    public interface IDBAccessor : IDisposable
    {
        IPropertyObject GetPropertyObjectByNodeId(UInt32 nodeID);
        IPropertyObject GetSubObjectByNodeId(IPropertyObject parentObject, UInt32 nodeID);

        IEnumerable<NodeID> GetNodeIDsByNodeTypeId(NidType nidType);

        IEnumerable<IPropertyObject> GetSubObjectsByNodeId(IPropertyObject parent, UInt32 childNode);
        int GetSubObjectCountByNodeId(IPropertyObject parent, UInt32 childNode);

        IEnumerable<IPropertyObject> GetSubObjectsByNidType(IPropertyObject parent, NidType nidType);
		int GetSubObjectCountByNidType(IPropertyObject parent, NidType nidType);

        IEnumerable<NodeInfo> Nodes { get; }
        IEnumerable<BlockInfo> Blocks { get; }
    }
}
