using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using pstsdk.definition.ltp;
using pstsdk.definition.ndb.database;
using pstsdk.definition.util.primitives;

namespace pstsdk.test.mocks
{
    public class MockDbContext : IDBAccessor
    {
        public Func<IPropertyObject> OnGetPropertyObjectByNodeId { private get; set; }
        public Func<IPropertyObject> OnGetSubObjectbyNodeId { private get; set; }
        public Func<IEnumerable<NodeID>> OnGetNodeIDsByNodeTypeId { private get; set; }
        public Func<IEnumerable<IPropertyObject>> OnGetSubObjectsByNodeId { private get; set; }
        public Func<int> OnGetSubObjectCountByNodeId { private get; set; }
        public Func<IEnumerable<IPropertyObject>> OnGetSubObjectsByNidType { private get; set; }
        public Func<int> OnGetSubObjectCountByNidType { private get; set; }

        public MockDbContext()
        {
            OnGetNodeIDsByNodeTypeId = () => Enumerable.Empty<NodeID>();
            OnGetSubObjectsByNidType = () => Enumerable.Empty<IPropertyObject>();
            OnGetSubObjectsByNodeId = () => Enumerable.Empty<IPropertyObject>();
        }

        #region IDBAccessor Members

        public IPropertyObject GetPropertyObjectByNodeId(uint nodeID)
        {
            return OnGetPropertyObjectByNodeId();
        }

        public IPropertyObject GetSubObjectByNodeId(IPropertyObject parentObject, uint nodeID)
        {
            return OnGetSubObjectbyNodeId();
        }

        public IEnumerable<NodeID> GetNodeIDsByNodeTypeId(NidType nidType)
        {
            return OnGetNodeIDsByNodeTypeId();
        }

        public IEnumerable<IPropertyObject> GetSubObjectsByNodeId(IPropertyObject parent, uint childNode)
        {
            return OnGetSubObjectsByNodeId();
        }

        public int GetSubObjectCountByNodeId(IPropertyObject parent, uint childNode)
        {
            return OnGetSubObjectCountByNodeId();
        }

        public IEnumerable<IPropertyObject> GetSubObjectsByNidType(IPropertyObject parent, NidType nidType)
        {
            return OnGetSubObjectsByNidType();
        }

        public int GetSubObjectCountByNidType(IPropertyObject parent, NidType nidType)
        {
            return OnGetSubObjectCountByNidType();
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            //bunch of nothing
        }

        #endregion

        #region IDBAccessor Members


        public IEnumerable<NodeInfo> Nodes
        {
            get { throw new NotImplementedException(); }
        }

        public IEnumerable<BlockInfo> Blocks
        {
            get { throw new NotImplementedException(); }
        }

        #endregion
    }
}
