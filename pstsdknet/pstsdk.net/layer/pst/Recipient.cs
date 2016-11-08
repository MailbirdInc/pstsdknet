using System;
using System.Collections.Generic;
using System.IO;
using pstsdk.definition.ltp;
using pstsdk.definition.ndb.database;
using pstsdk.definition.pst.message;
using pstsdk.definition.util.primitives;

using pstsdk.layer.util;

namespace pstsdk.layer.pst
{
    public class Recipient : IRecipient
    {
        public Recipient(IDBAccessor context, NodeID nodeID)
        {
            _dbContext = context;
            _propBag = _dbContext.GetPropertyObjectByNodeId(nodeID);
        }
        public Recipient(IDBAccessor context, IPropertyObject propBag)
        {
            _dbContext = context;
            _propBag = propBag;
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

        public bool Equals(IRecipient other)
        {
            return Node.Value.Equals(other.Node.Value);
        }

        public string AccountName
        {
            get
            {
                if (HasAccountName)
                    return PropertyUtils.GetStringProperty(_propBag, PropId.KnownValue.PR_ACCOUNT);

                return string.Empty;
            }
        }

        public string AddressType
        {
            get
            {
                if (_propBag.PropertyExists(PropId.KnownValue.PidTagAddressType))
                    return PropertyUtils.GetStringProperty(_propBag, PropId.KnownValue.PidTagAddressType);

                return string.Empty;
            }
        }

        public string EmailAddress
        {
            get
            {
                if (_propBag.PropertyExists(PropId.KnownValue.PidTagSmtpAddress))
                    return PropertyUtils.GetStringProperty(_propBag, PropId.KnownValue.PidTagSmtpAddress);

                if (_propBag.PropertyExists(PropId.KnownValue.PR_EMAIL_ADDRESS))
                    return PropertyUtils.GetStringProperty(_propBag, PropId.KnownValue.PR_EMAIL_ADDRESS);

                return string.Empty;
            }
        }

        public string Name
        {
            get
            {
                if (_propBag.PropertyExists(PropId.KnownValue.PidTagRecipientDisplayName))
                    return PropertyUtils.GetStringProperty(_propBag, PropId.KnownValue.PidTagRecipientDisplayName);

                if (_propBag.PropertyExists(PropId.KnownValue.PR_DISPLAY_NAME))
                    return PropertyUtils.GetStringProperty(_propBag, PropId.KnownValue.PR_DISPLAY_NAME);

                return string.Empty;
            }
        }

        public bool HasAccountName
        {
            get { return _propBag.PropertyExists(PropId.KnownValue.PR_ACCOUNT); }
        }

        public bool HasEmailAddress
        {
            get { return _propBag.PropertyExists(PropId.KnownValue.PR_EMAIL_ADDRESS); }
        }

        public RecipientType RecipientType
        {
            get
            {
                if(_propBag.PropertyExists(PropId.KnownValue.PR_RECIPIENT_TYPE))
                {
                    return (RecipientType) BitConverter.ToInt32(_propBag.ReadProperty(PropId.KnownValue.PR_RECIPIENT_TYPE), 0);
                }

                throw new ArgumentOutOfRangeException();
            }
        }
    }
}