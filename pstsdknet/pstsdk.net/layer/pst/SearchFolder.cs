using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using pstsdk.definition.ltp;
using pstsdk.definition.ltp.table;
using pstsdk.definition.ndb.database;
using pstsdk.definition.pst.folder;
using pstsdk.definition.pst.message;
using pstsdk.definition.util.primitives;
using pstsdk.layer.util;
using pstsdk.mcpp.ndb.database;

namespace pstsdk.layer.pst
{
    public class SearchFolder : ISearchFolder
    {
        public SearchFolder(IDBAccessor context, NodeID nodeID)
        {
            _dbContext = context;
            _propBag = _dbContext.GetPropertyObjectByNodeId(nodeID);
        }

        private IDBAccessor _dbContext;
        private IPropertyObject _propBag;

        #region IPropertyObject Members

        public NodeID Node
        {
            get
            {
                return _propBag.Node;
            }
        }

        public IEnumerable<PropId> Properties
        {
            get
            {
                return _propBag.Properties;
            }
        }

        public PropertyType GetPropertyType(PropId id)
        {
            return _propBag.GetPropertyType(id);
        }

        public bool PropertyExists(PropId id)
        {
            return _propBag.PropertyExists(id);
        }

        public uint PropertySize(PropId id)
        {
            return _propBag.PropertySize(id);
        }

        public byte[] ReadProperty(PropId id)
        {
            return _propBag.ReadProperty(id);
        }

        public Stream OpenPropertyStream(PropId id)
        {
            return _propBag.OpenPropertyStream(id);
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            _propBag.Dispose();
        }

        #endregion

        public string Name
        {
            get
            {
                return _propBag.PropertyExists(PropId.KnownValue.PR_DISPLAY_NAME) 
                    ? PropertyUtils.GetStringProperty(_propBag, PropId.KnownValue.PR_DISPLAY_NAME) 
                    : string.Empty;
            }
        }

        public IDBAccessor DatabaseContext
        {
            get { return _dbContext; }
        }

        public int MessageCount
        {
            get
            {
                return _propBag.PropertyExists(PropId.KnownValue.PidTagContentCount)
                           ? BitConverter.ToInt32(_propBag.ReadProperty(PropId.KnownValue.PidTagContentCount), 0)
                           : 0;
            }
        }

        public IEnumerable<IMessage> Messages
        {
            get
            {
                if (MessageCount <= 0)
                    return Enumerable.Empty<IMessage>();

                return _dbContext.GetSubObjectsByNidType(_propBag, NidType.nid_type_contents_table)
                    .Where(a => NodeID.get_nid_type(a.Node) == NidType.nid_type_message)
                    .Select<IPropertyObject, IMessage>(m => new Message(_dbContext, m));
            }
        }
    }
}