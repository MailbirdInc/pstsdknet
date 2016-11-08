using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using pstsdk.definition.exception;
using pstsdk.definition.ltp;
using pstsdk.definition.ltp.nameid;
using pstsdk.definition.ndb.database;
using pstsdk.definition.pst;
using pstsdk.definition.pst.folder;
using pstsdk.definition.pst.message;
using pstsdk.definition.util.primitives;
using pstsdk.layer.ltp.nameid;
using pstsdk.layer.util;
using pstsdk.mcpp.ndb.database;
using pstsdk.mcpp.util.prop;

namespace pstsdk.layer.pst
{
    public class Pst : IPst
    {
        private IDBAccessor _dbContext;

        private IPropertyObject _propBag;

        public Pst(string path)
        {
            _dbContext = new DBContext(path);
            _propBag = _dbContext.GetPropertyObjectByNodeId((uint)NodeID.Predefined.nid_message_store);
        }

        #region IPst Members

        public IDBAccessor DatabaseAccessor
        {
            get
            {
                return _dbContext;
            }
        }

        public IEnumerable<IFolder> Folders
        {
            get
            {
                foreach (var node in _dbContext.GetNodeIDsByNodeTypeId(NidType.nid_type_folder))
                    yield return new Folder(_dbContext, node);

            }
        }

        public IEnumerable<IMessage> Messages
        {
            get
            {
                foreach (var node in _dbContext.GetNodeIDsByNodeTypeId(NidType.nid_type_message))
                    yield return new Message(_dbContext, node);
            }
        }

        public string Name
        {
            get
            {
                return PropertyUtils.GetStringProperty(_propBag, PropId.KnownValue.PR_DISPLAY_NAME);
            }
        }

        public INameIDMap NameIDMap
        {
            get
            {
                return new NameIdMap(_dbContext);
            }
        }

        public IFolder OpenFolder(string name)
        {
            foreach (var folder in Folders)
                if (folder.Name == name)
                    return folder;

            throw new NoViableAlternativeException("Could not find folder named '" + name + "' and there is no viable fallback behaviour.");
        }

        public IFolder OpenFolder(NodeID nodeID)
        {
            return new Folder(_dbContext, nodeID);
        }

        public IMessage OpenMessage(NodeID nodeID)
        {
            return new Message(_dbContext, nodeID);
        }

        public IFolder OpenRootFolder()
        {
            return new Folder(_dbContext, (uint)NodeID.Predefined.nid_root_folder);
        }

        public ISearchFolder OpenSearchFolder(NodeID nodeID)
        {
            return new SearchFolder(_dbContext, nodeID);
        }

        public NodeID GetTopIPMFolderId()
        {
            return GetNodeID(PropId.KnownValue.PidTagIpmSubTreeEntryId);
        }

        public NodeID GetTrashFolderId()
        {
            return GetNodeID(PropId.KnownValue.PidTagIpmWastebasketEntryId);
        }

        public NodeID GetSentFolderId()
        {
            return GetNodeID(PropId.KnownValue.PidTagIpmSentMailEntryId);
        }

        public NodeID GetOutboxFolderId()
        {
            return GetNodeID(PropId.KnownValue.PidTagIpmOutboxEntryId);  
        }

        public NodeID GetNodeID(PropId propId)
        {
            if(_propBag.PropertyExists(propId))
                return GetNodeID(_propBag.ReadProperty(propId));  
            else
                return 0;
        }

        public NodeID GetNodeID(EntryID entry)
        {
            return PropertyUtils.GetNodeID(entry, _dbContext);  
        }

        #endregion

        #region IDisposable members

        public void Dispose()
        {
            _propBag.Dispose();
            _dbContext.Dispose();
        }

        #endregion

        #region IPropertyObject members

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
    }
}