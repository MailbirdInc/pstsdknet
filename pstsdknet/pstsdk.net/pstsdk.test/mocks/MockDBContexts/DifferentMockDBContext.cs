using System;
using System.Collections.Generic;
using pstsdk.definition.ndb.database;
using pstsdk.definition.ltp;
using pstsdk.definition.util.primitives;
using pstsdk.layer.pst;
using pstsdk.test.mocks.MockPropBags;

namespace pstsdk.test.mocks.MockDBContexts
{
    public class DifferentMockDBContext : IDBAccessor
    {
        public IPropertyObject GetPropertyObjectByNodeId(uint nodeID)
        {
            return new DifferentMockPropBag();
        }

        public IPropertyObject GetSubObjectByNodeId(IPropertyObject parentObject, uint nodeID)
        {
            return new DifferentMockPropBag();
        }

        public IEnumerable<NodeID> GetNodeIDsByNodeTypeId(NidType nidType)
        {
            var nodeIdList = new List<NodeID>();
            return nodeIdList;
        }

        public IEnumerable<IPropertyObject> GetSubObjectsByNodeId(IPropertyObject parent, uint childNode)
        {
            var properetyObjectList = new List<IPropertyObject>();
            return properetyObjectList;
        }

        public int GetSubObjectCountByNodeId(IPropertyObject parent, uint childNode)
        {
            return 1;
        }

        public IEnumerable<IPropertyObject> GetSubObjectsByNidType(IPropertyObject parent, NidType nidType)
        {
            var propertyObjectList = new List<IPropertyObject>();

            if (nidType == NidType.nid_type_hierarchy_table)
            {
                propertyObjectList.Add(new Folder(this, 1111));
                propertyObjectList.Add(new Folder(this, 2222));
            }

            return propertyObjectList;
        }

        public int GetSubObjectCountByNidType(IPropertyObject parent, NidType nidType)
        {
            return 0;
        }

        public IEnumerable<NodeInfo> Nodes
        {
            get { throw new NotImplementedException(); }
        }

        public IEnumerable<BlockInfo> Blocks
        {
            get { throw new NotImplementedException(); }
        }

        public void Dispose()
        {
            return;
        }
    }
}
