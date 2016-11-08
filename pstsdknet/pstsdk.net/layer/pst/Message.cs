using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using pstsdk.definition.ltp;

using pstsdk.definition.ndb.database;
using pstsdk.definition.pst.message;
using pstsdk.definition.util.primitives;
using pstsdk.layer.util;
using pstsdk.mcpp.util.prop;

namespace pstsdk.layer.pst
{
    public class Message : IMessage
    {
        public Message(IDBAccessor context, IPropertyObject propBag)
        {
            _dbContext = context;
            _propBag = propBag;
        }
        public Message(IDBAccessor context, NodeID nodeID)
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

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            _propBag.Dispose();
        }

        public Stream OpenPropertyStream(PropId id)
        {
            return _propBag.OpenPropertyStream(id);
        }

        #endregion

        #region IEquatable<IMessage> Members

        public bool Equals(IMessage other)
        {
            return Node.Equals(other.Node);
        }

        #endregion

        #region IMessage Members

        public int AttachmentCount
        {
            get
            {
                try
                {

                    return _dbContext.GetSubObjectCountByNodeId(
                        _propBag, (uint)NodeID.Predefined.nid_attachment_table); //NodeID.make_nid(NidType.nid_type_attachment_table, NodeID.get_nid_index(_propBag.Node)));
                }
                catch(Exception)
                {
                    return 0;
                }
            }
        }
        public IEnumerable<IAttachment> Attachments
        {
            get
            {
                if (AttachmentCount > 0)
                {
                    foreach (var propbag in _dbContext.GetSubObjectsByNodeId(_propBag, (uint)NodeID.Predefined.nid_attachment_table ))
                    {
                        //if (NodeID.get_nid_type(propbag.Node) == NidType.nid_type_message) 
                        yield return new Attachment(_dbContext, propbag, _propBag);
                        //else throw new Exception("Why did we get a non message in the content table?");
                    }
                }
            }
        }

        public int RecipientCount
        {
            get
            {
                try
                {
                    return _dbContext.GetSubObjectCountByNodeId(
                        _propBag, (uint)NodeID.Predefined.nid_recipient_table);
                }
                catch (Exception)
                {
                    return 0;
                }
            }
        }

        public IEnumerable<IRecipient> Recipients
        {
            get
            {
                if (RecipientCount > 0)
                {
                    foreach (var propbag in _dbContext.GetSubObjectsByNodeId(_propBag, (uint)NodeID.Predefined.nid_recipient_table))
                    {
                        yield return new Recipient(_dbContext, propbag);
                    }
                }
            }
        }

        public EntryID EntryID
        {
            get
            {
                //TODO: Should check if this is a sub message
                return PropertyUtils.GenerateEntryID(Node, _dbContext);
            }
        }

        public string Body
        {
            get
            {
                if(HasBody)
                    return PropertyUtils.GetStringProperty(_propBag, PropId.KnownValue.PidTagBody);

                return string.Empty;
            }
        }

        public byte[] HtmlBody
        {
            get
            {
                if (HasHtmlBody)
                {
                    return _propBag.ReadProperty(PropId.KnownValue.PidTagBodyHtml);
                }

                return default(byte[]);
            }
        }

        public string HtmlBodyString
        {
            get
            {
                if (HasHtmlBody)
                {
                    return Encoding.GetString(_propBag.ReadProperty(PropId.KnownValue.PidTagBodyHtml));
                }

                return string.Empty;
            }
        }

        public Encoding Encoding
        {
            get
            {
                if(_propBag.PropertyExists(PropId.KnownValue.PidTagInternetCodepage))
                    return GetEncoding(PropertyHelper.GetInt32Property(_propBag.ReadProperty(PropId.KnownValue.PidTagInternetCodepage)));
                else if (_propBag.PropertyExists(PropId.KnownValue.PidTagMessageCodepage))
                    return GetEncoding(PropertyHelper.GetInt32Property(_propBag.ReadProperty(PropId.KnownValue.PidTagMessageCodepage)));
                else 
                    return Encoding.UTF8;
            }
        }

        public string Subject
        {
            get
            {
                if (HasSubject)
                {
                    return
                        PropertyUtils.RemoveSubjectPaddingCharacter(
                            PropertyUtils.GetStringProperty(_propBag, PropId.KnownValue.PR_SUBJECT));
                } 
                
                return string.Empty;
            }
        }

        public int BodySize
        {
            get { return (int)_propBag.PropertySize(PropId.KnownValue.PidTagBody); }
        }

        public bool HasBody
        {
            get { return _propBag.PropertyExists(PropId.KnownValue.PidTagBody); }
        }

        public bool HasHtmlBody
        {
            get { return _propBag.PropertyExists(PropId.KnownValue.PidTagBodyHtml); }
        }

        public bool HasSubject
        {
            get { return _propBag.PropertyExists(PropId.KnownValue.PR_SUBJECT); }
        }

        public int HtmlBodySize
        {
            get { return (int) _propBag.PropertySize(PropId.KnownValue.PidTagBodyHtml); }
        }

        public Stream BodyStream
        {
            get { return _propBag.OpenPropertyStream(PropId.KnownValue.PidTagBody); }
            //new) HnidStream(_propBag, PropId.KnownValue.PidTagBody); }
        }

        public Stream HtmlBodyStream
        {
            get { return _propBag.OpenPropertyStream(PropId.KnownValue.PidTagBodyHtml); }
            //new HnidStream(_propBag, PropId.KnownValue.PidTagBodyHtml); }
        }

        public int Size
        {
            get
            {
                if (_propBag.PropertyExists(PropId.KnownValue.PR_SUBJECT))
                    return BitConverter.ToInt32(_propBag.ReadProperty(PropId.KnownValue.PR_MESSAGE_SIZE), 0);

                return 0;
            }
        }

        public string TransportMessageHeaders
        {
            get
            {
                if (_propBag.PropertyExists(PropId.KnownValue.PidTagTransportMessageHeaders))
                    return PropertyUtils.GetStringProperty(_propBag, PropId.KnownValue.PidTagTransportMessageHeaders);

                return string.Empty;
            }
        }

        public string DisplayBcc
        {
            get
            {
                if (_propBag.PropertyExists(PropId.KnownValue.PidTagDisplayBcc))
                    return PropertyUtils.GetStringProperty(_propBag, PropId.KnownValue.PidTagDisplayBcc);

                return string.Empty;
            }
        }

        public string DisplayCc
        {
            get
            {
                if (_propBag.PropertyExists(PropId.KnownValue.PidTagDisplayCc))
                    return PropertyUtils.GetStringProperty(_propBag, PropId.KnownValue.PidTagDisplayCc);

                return string.Empty;
            }
        }

        public string DisplayTo
        {
            get
            {
                if (_propBag.PropertyExists(PropId.KnownValue.PidTagDisplayTo))
                    return PropertyUtils.GetStringProperty(_propBag, PropId.KnownValue.PidTagDisplayTo);

                return string.Empty;
            }
        }

        public string DisplayName
        {
            get
            {
                if (_propBag.PropertyExists(PropId.KnownValue.PidTagDisplayName))
                    return PropertyUtils.GetStringProperty(_propBag, PropId.KnownValue.PidTagDisplayName);

                return string.Empty;
            }
        }

        public string FromName
        {
            get
            {
                if (_propBag.PropertyExists(PropId.KnownValue.PR_SENT_REPRESENTING_NAME))
                    return PropertyUtils.GetStringProperty(_propBag, PropId.KnownValue.PR_SENT_REPRESENTING_NAME);
                else if (_propBag.PropertyExists(PropId.KnownValue.PR_SENDER_EMAIL_NAME))
                    return PropertyUtils.GetStringProperty(_propBag, PropId.KnownValue.PR_SENDER_EMAIL_NAME);

                return string.Empty;
            }
        }

        public string FromAddress
        {
            get
            {
                if (_propBag.PropertyExists(PropId.KnownValue.PR_SENT_REPRESENTING_EMAIL_ADDRESS))
                    return PropertyUtils.GetStringProperty(_propBag, PropId.KnownValue.PR_SENT_REPRESENTING_EMAIL_ADDRESS);
                else if (_propBag.PropertyExists(PropId.KnownValue.PR_SENDER_EMAIL_ADDRESS))
                    return PropertyUtils.GetStringProperty(_propBag, PropId.KnownValue.PR_SENDER_EMAIL_ADDRESS);

                return string.Empty;
            }
        }

        public DateTime OriginalDeliveryTime
        {
            get
            {
                if (_propBag.PropertyExists(PropId.KnownValue.PidTagOriginalDeliveryTime))
                    return PropertyHelper.GetTimeProperty(_propBag.ReadProperty(PropId.KnownValue.PidTagOriginalDeliveryTime));

                return DateTime.MinValue;
            }
        }

        public DateTime SentTime
        {
            get
            {
                if (_propBag.PropertyExists(PropId.KnownValue.PidTagClientSubmitTime))
                    return PropertyHelper.GetTimeProperty(_propBag.ReadProperty(PropId.KnownValue.PidTagClientSubmitTime));

                return DateTime.MinValue;
            }
        }

        public string InternetId
        {
            get
            {
                if (_propBag.PropertyExists(PropId.KnownValue.PidTagInternetMessageId))
                    return PropertyUtils.GetStringProperty(_propBag, PropId.KnownValue.PidTagInternetMessageId);

                return string.Empty;
            }
        }

        public string InReplyTo
        {
            get
            {
                if (_propBag.PropertyExists(PropId.KnownValue.PR_IN_REPLY_TO_ID))
                    return PropertyUtils.GetStringProperty(_propBag, PropId.KnownValue.PR_IN_REPLY_TO_ID);

                return string.Empty;
            }
        }

        public string InternetReferences
        {
            get
            {
                if (_propBag.PropertyExists(PropId.KnownValue.PR_INTERNET_REFERENCES))
                    return PropertyUtils.GetStringProperty(_propBag, PropId.KnownValue.PR_INTERNET_REFERENCES);

                return string.Empty;
            }
        }

        public string MessageClass
        {
            get
            {
                if (_propBag.PropertyExists(PropId.KnownValue.PidTagMessageClass))
                    return PropertyUtils.GetStringProperty(_propBag, PropId.KnownValue.PidTagMessageClass);

                return string.Empty;
            }
        }

        public string Uid
        {
            get
            {
                if (_propBag.PropertyExists(PropId.KnownValue.PR_EMS_AB_USN_CHANGED))
                    return Encoding.Unicode.GetString(_propBag.ReadProperty(PropId.KnownValue.PR_EMS_AB_USN_CHANGED));
                else if (_propBag.PropertyExists(PropId.KnownValue.PR_EMS_AB_CONTENT_TYPE))
                    return Encoding.Unicode.GetString(_propBag.ReadProperty(PropId.KnownValue.PR_EMS_AB_CONTENT_TYPE));
                else if (_propBag.PropertyExists(PropId.KnownValue.PR_EMS_AB_PF_CONTACTS_O))
                    return Encoding.Unicode.GetString(_propBag.ReadProperty(PropId.KnownValue.PR_EMS_AB_PF_CONTACTS_O));

                return string.Empty;
            }
        }

        #endregion

        private Encoding GetEncoding(int codepage)
        {
            return Encoding.GetEncoding(codepage);
        }
    }
}