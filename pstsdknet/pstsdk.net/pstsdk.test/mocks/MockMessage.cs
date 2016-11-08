using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using pstsdk.definition.pst.message;
using System.IO;
using pstsdk.definition.util.primitives;
using pstsdk.layer.pst;
using pstsdk.test.mocks.MockDBContexts;
using pstsdk.test.mocks.MockPropBags;

namespace pstsdk.test.mocks
{
    public class MockMessage : IMessage
    {
        public int AttachmentCount
        {
            get { return Attachments.Count(); }
        }

        public IEnumerable<IAttachment> Attachments
        {
            get 
            {
                var attachments = new List<IAttachment>
                                      {
                                          new Attachment(new AttachmentMockDBContext(), new AttachmentMockPropBag(), this),
                                          new Attachment(new DifferentMockDBContext(), new DifferentMockPropBag(), this)
                                      };

                return attachments;
            }
        }

        public int RecipientCount
        {
            get { return Recipients.Count(); }
        }

        public IEnumerable<IRecipient> Recipients
        {
            get 
            {
                var receipients = new List<IRecipient>
                                      {
                                          new Recipient(new RecipientMockDBContext(), new RecipientMockPropBag()),
                                          new Recipient(new DifferentMockDBContext(), new DifferentMockPropBag())
                                      };

                return receipients;
            }
        }

        public EntryID EntryID
        {
            get { throw new NotImplementedException(); }
        }

        public string Body
        {
            get { return "Body Text"; }
        }

        public byte[] HtmlBody
        {
            get { return Encoding.Unicode.GetBytes("Html Body"); }
        }

        public string Subject
        {
            get { return "Subject Text"; }
        }

        public int BodySize
        {
            get { return 1234; }
        }

        public bool HasBody
        {
            get { return true; }
        }

        public bool HasHtmlBody
        {
            get { return true; }
        }

        public bool HasSubject
        {
            get { return true; }
        }

        public int HtmlBodySize
        {
            get { return 1234; }
        }

        public Stream BodyStream
        {            
            get 
            {
                byte[] byteBuffer = {1, 2, 3, 4 };
                return new MemoryStream(byteBuffer);
            }
        }

        public Stream HtmlBodyStream
        {
            get 
            {
                byte[] byteBuffer = { 1, 2, 3, 4 };
                return new MemoryStream(byteBuffer);
            }
        }

        public int Size
        {
            get { return 1234; }
        }

        public bool Equals(IMessage other)
        {
            return false;
        }


        public NodeID Node
        {
            get { return NodeID.Predefined.nid_message_store; }
        }

        public IEnumerable<PropId> Properties
        {
            get 
            {
                var props = new List<PropId> {PropId.KnownValue.PR_SUBJECT, PropId.KnownValue.PR_MESSAGE_SIZE};

                return props; 
            }
        }

        public PropertyType GetPropertyType(PropId id)
        {
            return (new MessageMockPropBag()).GetPropertyType(id);
        }

        public bool PropertyExists(PropId id)
        {
            return (new MessageMockPropBag()).PropertyExists(id);
        }

        public uint PropertySize(PropId id)
        {
            return (new MessageMockPropBag()).PropertySize(id);
        }

        public byte[] ReadProperty(PropId id)
        {
            return (new MessageMockPropBag()).ReadProperty(id);
        }

        public Stream OpenPropertyStream(PropId id)
        {
            return (new MessageMockPropBag()).OpenPropertyStream(id);
        }


        public void Dispose()
        {
            return;
        }

    }
}
