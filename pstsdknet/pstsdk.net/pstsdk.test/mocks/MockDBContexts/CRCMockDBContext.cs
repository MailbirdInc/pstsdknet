using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using pstsdk.definition.ndb.database;
using pstsdk.definition.ltp;
using pstsdk.definition.util.primitives;
using pstsdk.layer.util;
using pstsdk.layer.pst;

namespace pstsdk.test.mocks
{
    public class CRCMockDBContext : IDBAccessor
    {
        public CRCMockDBContext()
        {
            
        }

        public IPropertyObject GetPropertyObjectByNodeId(uint nodeID)
        {
            return new CRCMockPropBag();
        }

        public IPropertyObject GetSubObjectByNodeId(IPropertyObject parentObject, uint nodeID)
        {
            return new CRCMockPropBag();
        }

        public IEnumerable<NodeID> GetNodeIDsByNodeTypeId(NidType nidType)
        {
            List<NodeID> nodeIdList = new List<NodeID>();
            return nodeIdList;
        }

        public IEnumerable<IPropertyObject> GetSubObjectsByNodeId(IPropertyObject parent, uint childNode)
        {
            List<IPropertyObject> propertyObjectList = new List<IPropertyObject>();
            return propertyObjectList;
        }

        public int GetSubObjectCountByNodeId(IPropertyObject parent, uint childNode)
        {            
            return 1;
        }

        public IEnumerable<IPropertyObject> GetSubObjectsByNidType(IPropertyObject parent, NidType nidType)
        {
                List<IPropertyObject> propertyObjectList = new List<IPropertyObject>();

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
                List<NodeInfo> nodes = new List<NodeInfo>();
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
