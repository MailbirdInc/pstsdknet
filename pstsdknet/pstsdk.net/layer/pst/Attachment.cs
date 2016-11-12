using System;
using System.Collections.Generic;
using System.IO;
using pstsdk.definition.ltp;
using pstsdk.definition.ndb.database;
using pstsdk.definition.pst.message;
using pstsdk.definition.util.primitives;
using pstsdk.layer.util;
using pstsdk.mcpp.util.prop;

namespace pstsdk.layer.pst
{
    public class Attachment : IAttachment
    {
        public Attachment(IDBAccessor context, NodeID nodeID, IPropertyObject parent)
        {
            _dbContext = context;
            _propBag = _dbContext.GetSubObjectByNodeId(parent, nodeID);
        }
        public Attachment(IDBAccessor context, IPropertyObject propBag, IPropertyObject parent)
        {
            _dbContext = context;
            _propBag = _dbContext.GetSubObjectByNodeId(parent, propBag.Node);
        }

        private IDBAccessor _dbContext;
        private IPropertyObject _propBag;

        #region IAttachment Members

        public int ContentSize
        {
            get
            {
                return
                    _propBag.PropertyExists(PropId.KnownValue.PidTagAttachDataObject)
                    ? (int)_propBag.PropertySize(PropId.KnownValue.PidTagAttachDataObject)
                    : 0;
            }

        }

        public byte[] Bytes
        {
            get
            {
                return
                    _propBag.PropertyExists(PropId.KnownValue.PidTagAttachDataObject)
                    ? _propBag.ReadProperty(PropId.KnownValue.PidTagAttachDataObject) 
                    : default(byte[]);
            }
        }

        public string Filename
        {
            get 
            {
                if (_propBag.PropertyExists(PropId.KnownValue.PidTagAttachLongFilename))
                    return PropertyUtils.GetStringProperty(_propBag, PropId.KnownValue.PidTagAttachLongFilename);

                if (_propBag.PropertyExists(PropId.KnownValue.PidTagAttachFilename))
                    return PropertyUtils.GetStringProperty(_propBag, PropId.KnownValue.PidTagAttachFilename);

                return string.Empty;
            }
        }

        private const int ATTACH_EMBEDDED_MSG = 5;
        public bool IsMessage
        {
            get 
            {
                if (!_propBag.PropertyExists(PropId.KnownValue.PidTagAttachMethod)) return false;

                return PropertyHelper.GetInt32Property(_propBag.ReadProperty(PropId.KnownValue.PidTagAttachMethod)) == ATTACH_EMBEDDED_MSG;
            }
        }

        public IMessage OpenAsMessage()
        {
            if (!IsMessage) return default(IMessage);
            
            var nodeID = BitConverter.ToUInt32(Bytes, 0);
            
            var messagePropbag = _dbContext.GetSubObjectByNodeId(_propBag, nodeID);

            return new Message(_dbContext, messagePropbag);
        }

        public Stream ByteStream
        {
            get { return _propBag.OpenPropertyStream(PropId.KnownValue.PidTagAttachDataObject); }
        }

        public int Size
        {
            get 
            {
                return
                    _propBag.PropertyExists(PropId.KnownValue.PidTagAttachSize)
                    ? PropertyHelper.GetInt32Property(_propBag.ReadProperty(PropId.KnownValue.PidTagAttachSize))
                    : 0;
            }
        }

        public string MimeTag
        {
            get
            {
                if (_propBag.PropertyExists(PropId.KnownValue.PidTagAttachMimeTag))
                    return PropertyUtils.GetStringProperty(_propBag, PropId.KnownValue.PidTagAttachMimeTag);

                return string.Empty;
            }
        }

        public string ContentId
        {
            get
            {
                if (_propBag.PropertyExists(PropId.KnownValue.PidTagAttachContentId))
                    return PropertyUtils.GetStringProperty(_propBag, PropId.KnownValue.PidTagAttachContentId);

                return string.Empty;
            }
        }

        public string MimeLocation
        {
            get
            {
                if (_propBag.PropertyExists(PropId.KnownValue.PidTagAttachContentLocation))
                    return PropertyUtils.GetStringProperty(_propBag, PropId.KnownValue.PidTagAttachContentLocation);

                return string.Empty;
            }
        }

        public int MimeSequence
        {
            get
            {
                return
                    _propBag.PropertyExists(PropId.KnownValue.PidTagAttachMimeSequence)
                    ? PropertyHelper.GetInt32Property(_propBag.ReadProperty(PropId.KnownValue.PidTagAttachMimeSequence))
                    : 0;
            }
        }

        public int RenderingPosition
        {
            get
            {
                return
                    _propBag.PropertyExists(PropId.KnownValue.PidTagRenderingPosition)
                    ? PropertyHelper.GetInt32Property(_propBag.ReadProperty(PropId.KnownValue.PidTagRenderingPosition))
                    : 0;
            }
        }

        public AttachmentMethod AttachmentMethod
        {
            get
            {
                return
                    _propBag.PropertyExists(PropId.KnownValue.PidTagAttachMethod)
                    ? (AttachmentMethod) PropertyHelper.GetInt32Property(_propBag.ReadProperty(PropId.KnownValue.PidTagAttachMethod))
                    : AttachmentMethod.NoAttachment;
            }
        }

        public AttachmentFlag AttachmentFlag
        {
            get
            {
                return
                    _propBag.PropertyExists(PropId.KnownValue.PidTagAttachFlags)
                    ? (AttachmentFlag)PropertyHelper.GetInt32Property(_propBag.ReadProperty(PropId.KnownValue.PidTagAttachFlags))
                    : AttachmentFlag.AttMhtmlRef;
            }
        }

        #endregion

        #region IEquatable<IAttachment> Members

        public bool Equals(IAttachment other)
        {
            return Node.Value.Equals(other.Node.Value);
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
    }
}