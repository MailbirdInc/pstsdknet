using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using pstsdk.definition.ltp;
using pstsdk.definition.ndb.database;
using pstsdk.definition.pst.folder;
using pstsdk.definition.pst.message;
using pstsdk.definition.util.primitives;
using pstsdk.layer.util;

using pstsdk.mcpp.util.prop;

namespace pstsdk.layer.pst
{
    public class Folder : IFolder
    {
        public Folder(IDBAccessor context, NodeID nodeID)
        {
            _dbContext = context;
            _propBag = _dbContext.GetPropertyObjectByNodeId(nodeID);
        }
        public Folder(IDBAccessor context, IPropertyObject propBag)
        {
            _dbContext = context;
            _propBag = propBag;
        }

        private IDBAccessor _dbContext;
        private IPropertyObject _propBag;

        #region IFolder Members

        public int AssociatedMessageCount
        {
            get
            { 
                return _propBag.PropertyExists(PropId.KnownValue.PidTagAssociatedContentCount)
                           ? PropertyHelper.GetInt32Property(
                                 _propBag.ReadProperty(PropId.KnownValue.PidTagAssociatedContentCount))
                           : 0;
            }
        }

        public IEnumerable<IMessage> AssociatedMessages
        {
            get
            {
                if (AssociatedMessageCount <= 0) return default(IEnumerable<IMessage>);
                
                return 
                    _dbContext
                        .GetSubObjectsByNidType(_propBag, NidType.nid_type_associated_contents_table)
                        .Where( a=> NodeID.get_nid_type(a.Node) == NidType.nid_type_associated_message)
                        .Select<IPropertyObject, IMessage>(a => new Message(_dbContext, a));
            }
        }

        public int MessageCount
        {
            get
            {
                return 
                    _propBag.PropertyExists(PropId.KnownValue.PidTagContentCount) 
                    ? PropertyHelper.GetInt32Property(_propBag.ReadProperty(PropId.KnownValue.PidTagContentCount)) 
                    : 0;
            }
        }

        public string ContainerClass
        {
            get
            {
                return
                    _propBag.PropertyExists(PropId.KnownValue.PidTagContainerClass)
                    ? PropertyUtils.GetStringProperty(_propBag, PropId.KnownValue.PidTagContainerClass) 
                    : string.Empty;
            }
        }

        public IEnumerable<IMessage> Messages
        {
            get {
                if (MessageCount <= 0)
                    return Enumerable.Empty<IMessage>();
                
                return 
                    _dbContext
                        .GetSubObjectsByNidType(_propBag, NidType.nid_type_contents_table)
                        .Where( a=> NodeID.get_nid_type(a.Node) == NidType.nid_type_message)
                        .Select<IPropertyObject, IMessage>(a=> new Message(_dbContext, a));
            }
        }

        public IDBAccessor DatabaseContext
        {
            get { return _dbContext;  }
        }

        public EntryID EntryID
        {
            get { return PropertyUtils.GenerateEntryID(Node, _dbContext); }
        }

        public string Name
        {
            get
            {
                return 
                    _propBag.PropertyExists(PropId.KnownValue.PR_DISPLAY_NAME) 
                    ? PropertyUtils.GetStringProperty(_propBag, PropId.KnownValue.PR_DISPLAY_NAME) 
                    : string.Empty;
            }
        }

        public int SubFolderCount
        {
            get
            {
                try
                {
                    return _dbContext
                        .GetSubObjectCountByNidType(_propBag, NidType.nid_type_hierarchy_table);
                }
                catch
                {
                    return 0;
                }
            }
        }

        public IFolder OpenSubFolder(string name)
        {
            if (SubFolderCount <= 0) return default(IFolder);

            return SubFolders.FirstOrDefault(folder => folder.Name.CompareTo(name) == 0);
        }

        public IEnumerable<IFolder> SubFolders
        {
            get 
            {
                if (SubFolderCount <= 0)
                    return Enumerable.Empty<IFolder>();
               
                return 
                    _dbContext
                        .GetSubObjectsByNidType(_propBag, NidType.nid_type_hierarchy_table)
                        .Where(a=>NodeID.get_nid_type(a.Node) == NidType.nid_type_folder)
                        .Select<IPropertyObject, IFolder>(a=>new Folder(_dbContext, a));
            }
        }

        public EntryID GetDraftsFolderEntryId()
        {
            return
                _propBag.PropertyExists(PropId.KnownValue.PR_IPM_DRAFTS_ENTRYID)
                ? new EntryID() { Value = _propBag.ReadProperty(PropId.KnownValue.PR_IPM_DRAFTS_ENTRYID) }
                : EntryID.Empty;
        }

        public EntryID[] GetAdditionalEntryIds()
        {
            List<EntryID> result = new List<definition.util.primitives.EntryID>();

            if (_propBag.PropertyExists(PropId.KnownValue.PR_ADDITIONAL_REN_ENTRYIDS))
            {
                var entries = PropertyUtils.GetMultipleBinaryValues(_propBag.ReadProperty(PropId.KnownValue.PR_ADDITIONAL_REN_ENTRYIDS));
                foreach (var entry in entries)
                    result.Add(entry);
            }

            return result.ToArray();
        }

        #endregion

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

        #region Overrides

        public override string ToString()
        {
            return "Node" + Node.Value + ", Name: " + Name;
        }

        #endregion
    }
}