using System;
using System.Collections.Generic;
using pstsdk.definition.ndb.database;
using pstsdk.definition.ltp;
using pstsdk.definition.util.primitives;
using pstsdk.test.mocks.MockPropBags;

namespace pstsdk.test.mocks.MockDBContexts
{
    public class AttachmentMockDBContext : IDBAccessor
    {
        public IPropertyObject GetPropertyObjectByNodeId(uint nodeID)
        {
            return new AttachmentMockPropBag();
        }

        public IPropertyObject GetSubObjectByNodeId(IPropertyObject parentObject, uint nodeID)
        {
            if (nodeID == 33)
                return new MessageMockPropBag();

            return new AttachmentMockPropBag();
        }

        public IEnumerable<NodeID> GetNodeIDsByNodeTypeId(NidType nidType)
        {
            var nodeIdList = new List<NodeID>();
            return nodeIdList;
        }

        public IEnumerable<IPropertyObject> GetSubObjectsByNodeId(IPropertyObject parent, uint childNode)
        {
            var propertyObjectList = new List<IPropertyObject>();
            return propertyObjectList;
        }

        public int GetSubObjectCountByNodeId(IPropertyObject parent, uint childNode)
        {            
            return 1;
        }

        public IEnumerable<IPropertyObject> GetSubObjectsByNidType(IPropertyObject parent, NidType nidType)
        {
                var propertyObjectList = new List<IPropertyObject>();

                return propertyObjectList;
        }

        public int GetSubObjectCountByNidType(IPropertyObject parent, NidType nidType)
        {
            return 2;
        }

        public IEnumerable<NodeInfo> Nodes
        {
            get 
            {
                var nodes = new List<NodeInfo>();
                nodes.Add(new NodeInfo() { NodeId = new NodeID() { Value = (UInt32)NodeID.Predefined.nid_root_folder } });

                return nodes; 
            }
        }

        public IEnumerable<BlockInfo> Blocks
        {
            get { return new List<BlockInfo>(); }
        }

        public void Dispose()
        {
            return;
        }
    }
}
