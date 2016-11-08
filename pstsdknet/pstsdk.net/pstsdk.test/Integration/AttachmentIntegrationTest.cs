using System;
using System.Linq;
using System.Text;
using pstsdk.layer.pst;
using pstsdk.definition.pst.message;
using System.IO;
using pstsdk.definition.util.primitives;
using MbUnit.Framework;
using pstsdk.test.mocks.MockPropBagConstants;

namespace pstsdk.test.Integration
{
    public class AttachmentIntegrationTest
    {
        [Test]
        public void Bytes_Test()
        {
            using (var attachment = IntegrationUtil.GetAttachment())
            {
                Assert.IsNotNull(attachment.Bytes);
            }
        }

        [Test]
        public void ByteStream_Test()
        {
            using (var attachment = IntegrationUtil.GetAttachment())
            {
                Assert.AreEqual(AttachmentMockConstants.ATTACHMENT_BYTE_STREAM_LENGTH, attachment.ByteStream.Length);
            }
        }

        [Test]
        public void ContentSize_Test()
        {
            using (var attachment = IntegrationUtil.GetAttachment())
            {
                Assert.AreEqual(AttachmentMockConstants.ATTACHMENT_CONTENT_SIZE, attachment.ContentSize);
            }
        }





        [Test]
        public void FileName_Test()
        {
            using (var attachment = IntegrationUtil.GetAttachment())
            {
                Assert.AreEqual(AttachmentMockConstants.ATTACHMENT_FILE_NAME, attachment.Filename);
            }
        }


        [Test]
        public void IsMessage_Test()
        {
            using (var attachment = IntegrationUtil.GetAttachment())
            {
                Assert.AreEqual(true, attachment.IsMessage);
            }
        }

        [Test]
        public void Node_Test()
        {
            using (var attachment = IntegrationUtil.GetAttachment())
            {
                Assert.AreEqual(AttachmentMockConstants.ATTACHMENT_NODE, (UInt32)attachment.Node);
            }
        }

        [Test]
        public void Properties_Test()
        {
            using (var attachment = IntegrationUtil.GetAttachment())
            {
                Assert.IsNotNull(attachment.Properties);
                Assert.AreEqual(AttachmentMockConstants.ATTACHMENT_PROPERTIES_COUNT, attachment.Properties.Count());

                foreach (var property in attachment.Properties)
                {
                    Assert.IsNotNull(property);
                }
            }
        }


        [Test]
        public void Size_Test()
        {
            using (var attachment = IntegrationUtil.GetAttachment())
            {
                Assert.AreEqual(AttachmentMockConstants.ATTACHMENT_SIZE, attachment.Size);
            }
        }


        [Test]
        public void OpenAsMessage_Valid_Test()
        {
            using (var attachment = IntegrationUtil.GetAttachment())
            {
                IMessage test = attachment.OpenAsMessage();
                Assert.AreEqual(AttachmentMockConstants.ATTACHMENT_OPEN_AS_MESSAGE_SIZE, test.Size);
            }
        }

        //[Test]
        //[ExpectedException(typeof(pstsdk.definition.exception.PstSdkException))]
        //public void OpenAsMessage_Invalid_Test()
        //{
        //    Assert.Inconclusive();

        //    using (var attachment = IntegrationUtil.GetAttachment())
        //    {
        //        IMessage test;
        //        test = attachment.OpenAsMessage();
        //        Assert.AreEqual(7816, test.Size);
        //    }
        //}

        [Test]
        public void PropertyExists_Valid_Test()
        {
            using (var attachment = IntegrationUtil.GetAttachment())
            {
                Assert.AreEqual(true, attachment.PropertyExists(PropId.KnownValue.PR_DISPLAY_NAME));
            }
        }

        [Test]
        public void PropertyExists_Invalid_Test()
        {
            using (var attachment = IntegrationUtil.GetAttachment())
            {
                Assert.AreEqual(false, attachment.PropertyExists(PropId.KnownValue.PidTagNameidStreamString));
            }
        }

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void PropertyExists_Null_Test()
        {
            using (var attachment = IntegrationUtil.GetAttachment())
            {
                object nullObject = null;
                PropId nullId = (PropId)nullObject;
                attachment.PropertyExists(nullId);
            }
        }



        [Test]
        public void ReadProperty_Valid_Test()
        {
            using (var attachment = IntegrationUtil.GetAttachment())
            {
                Byte[] validByte = attachment.ReadProperty(PropId.KnownValue.PR_SUBJECT);
                Assert.AreEqual(AttachmentMockConstants.ATTACHMENT_READ_PROP_SUBJECT, Encoding.Unicode.GetString(validByte));
            }
        }

        [Test]
        [ExpectedException(typeof(pstsdk.definition.exception.PstSdkException))]
        public void ReadProperty_Invalid_Test()
        {
            using (var attachment = IntegrationUtil.GetAttachment())
            {
                attachment.ReadProperty(AttachmentMockConstants.ATTACHMENT_INVALID_PROP_ID);
            }
        }


        [Test]
        public void PropertySize_Valid_Test()
        {
            using (var attachment = IntegrationUtil.GetAttachment())
            {
                Assert.AreEqual(AttachmentMockConstants.ATTACHMENT_PROPERTY_SIZE, attachment.PropertySize(PropId.KnownValue.PR_DISPLAY_NAME));
            }
        }

        [Test]
        [ExpectedException(typeof(pstsdk.definition.exception.PstSdkException))]
        public void PropertySize_Invalid_Test()
        {
            using (var attachment = IntegrationUtil.GetAttachment())
            {
                attachment.PropertySize(PropId.KnownValue.PidTagNameidStreamString);
            }
        }
      

        [Test]
        public void Equals_Valid_Test()
        {
            using (var attachment = IntegrationUtil.GetAttachment())
            {
                using (var mockMessage = IntegrationUtil.GetMockMessage())
                {
                    Attachment equalAttachment = (Attachment)mockMessage.Attachments
                        .ElementAt(AttachmentMockConstants.ATTACHMENT_FIRST_ELEMENT);

                    Assert.AreEqual(true, attachment.Equals(equalAttachment));
                }
            }
        }

        [Test]
        public void Equals_Invalid_Test()
        {
            using (var attachment = IntegrationUtil.GetAttachment())
            {
                var unequalAttachment = IntegrationUtil.GetDifferentAttachment();
                Assert.AreEqual(false, attachment.Equals(unequalAttachment));
            }
        }

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void Equals_Null_Test()
        {
            using (var attachment = IntegrationUtil.GetAttachment())
            {
                object nullObject = null;
                Attachment nullAttachment = (Attachment)nullObject;
                attachment.Equals(nullAttachment);
            }
        }



        [Test]
        public void OpenPropertyStream_Valid_Test()
        {
            using (var attachment = IntegrationUtil.GetAttachment())
            {
                Stream testStream = attachment.OpenPropertyStream(PropId.KnownValue.PR_DISPLAY_NAME);
                Assert.IsNotNull(testStream);
                Assert.IsTrue(testStream.Length > AttachmentMockConstants.ATTACHMENT_OPEN_PROP_STREAM_VALID_LENGTH);
            }
        }

        [Test]
        [ExpectedException(typeof(pstsdk.definition.exception.PstSdkException))]
        public void OpenPropertyStream_Invalid_Test()
        {
            using (var attachment = IntegrationUtil.GetAttachment())
            {
                attachment.OpenPropertyStream(AttachmentMockConstants.ATTACHMENT_INVALID_PROP_ID);
            }
        }


        [Test]
        public void GetPropertyType_Valid_Test()
        {
            using (var attachment = IntegrationUtil.GetAttachment())
            {
                Assert.AreEqual(AttachmentMockConstants.ATTACHMENT_GET_PROP_TYPE_VALID_RESULT, 
                    attachment.GetPropertyType(PropId.KnownValue.PR_DISPLAY_NAME));
            }
        }

        [Test]
        [ExpectedException(typeof(pstsdk.definition.exception.PstSdkException))]
        public void GetPropertyType_Invalid_Test()
        {
            using (var attachment = IntegrationUtil.GetAttachment())
            {
                attachment.GetPropertyType(AttachmentMockConstants.ATTACHMENT_INVALID_PROP_ID);
            }
        }
    }
}