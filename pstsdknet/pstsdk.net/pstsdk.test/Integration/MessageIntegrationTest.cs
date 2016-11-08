using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using pstsdk.layer.pst;
using System.IO;
using pstsdk.definition.util.primitives;
using MbUnit.Framework;
using pstsdk.test.mocks.MockPropBagConstants;

namespace pstsdk.test.Integration
{
    public class MessageIntegrationTest
    {
        [Test]
        public void AttachmentCount_Not_Null()
        {
            using (var message = IntegrationUtil.GetMessage())
            {
                Assert.IsNotNull(message.AttachmentCount);
            }
        }

        [Test]
        public void Attachments_Not_Null()
        {
            using (var message = IntegrationUtil.GetMessage())
            {
                Assert.IsNotNull(message.Attachments);
            }
        }

        [Test]
        public void Body_Not_Null()
        {
            using (var message = IntegrationUtil.GetMessage())
            {
                Assert.IsNotNull(message.Body);
            }
        }

        [Test]
        public void BodySize_Not_Null()
        {
            using (var message = IntegrationUtil.GetMessage())
            {
                Assert.IsNotNull(message.BodySize);
            }
        }

        [Test]
        public void BodyStream_Not_Null()
        {
            using (var message = IntegrationUtil.GetMessage())
            {
                Assert.IsNotNull(message.BodyStream);
            }
        }

        [Test]
        public void EntryID_Test()
        {
            using (var message = IntegrationUtil.GetMessage())
            {
                Assert.IsNotNull(message.EntryID);
            }
        }

        [Test]
        public void HasBody_Test()
        {
            using (var message = IntegrationUtil.GetMessage())
            {
                Assert.AreEqual(true, message.HasBody);
            }
        }

        [Test]
        public void HasHtmlBody_Test()
        {
            using (var message = IntegrationUtil.GetMessage())
            {
                Assert.AreEqual(false, message.HasHtmlBody);
            }
        }

        [Test]
        public void Body_Test()
        {
            using (var message = IntegrationUtil.GetMessage())
            {
                Assert.AreEqual(MessageMockConstants.MESSAGE_BODY_TEXT, message.Body);
            }
        }

        [Test]
        public void AttachmentCount_Test()
        {
            using (var message = IntegrationUtil.GetMessage())
            {
                Assert.AreEqual(MessageMockConstants.MESSAGE_ATTACHMENT_COUNT, message.AttachmentCount);
            }
        }

        [Test]
        public void MessageSize_Test()
        {
            using (var message = IntegrationUtil.GetMessage())
            {
                Assert.AreEqual(MessageMockConstants.MESSAGE_SIZE, message.Size);
            }
        }

        [Test]
        public void Subject_Compare()
        {
            using (var message = IntegrationUtil.GetMessage())
            {
                Assert.AreEqual(MessageMockConstants.MESSAGE_SUBJECT, message.Subject);
            }
        }

        [Test]
        public void Recipients_Not_Null()
        {
            using (var message = IntegrationUtil.GetMessage())
            {
                Assert.IsNotNull(message.Recipients);
            }
        }

        [Test]
        public void Equals_Valid_Test()
        {
            using (var message = IntegrationUtil.GetMessage())
            {
                using (var equalMessage = message)
                {
                    Assert.AreEqual(true, message.Equals(equalMessage));
                }
            }
        }

        [Test]
        public void Equals_Invalid_Test()
        {
            using (var message = IntegrationUtil.GetMessage())
            {
                using (var unequalMessage = IntegrationUtil.GetDifferentMessage())
                {
                    Assert.AreEqual(false, message.Equals(unequalMessage));
                }
            }
        }

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void Equals_Null_Test()
        {
            using (var message = IntegrationUtil.GetMessage())
            {
                message.Equals(null);
            }
        }


        [Test]
        public void PropertyExists_Valid_Test()
        {
            using (var message = IntegrationUtil.GetMessage())
            {
                Assert.AreEqual(true, message.PropertyExists(PropId.KnownValue.PR_SUBJECT));
            }
        }

        [Test]
        public void PropertyExists_Invalid_Test()
        {
            using (var message = IntegrationUtil.GetMessage())
            {
                Assert.AreEqual(false, message.PropertyExists(MessageMockConstants.MESSAGE_INVALID_PROPERTY));
            }
        }

        [Test]
        public void PropertySize_Valid_Test()
        {
            using (var message = IntegrationUtil.GetMessage())
            {
                Assert.AreEqual(MessageMockConstants.MESSAGE_SUBJECT_SIZE, message.PropertySize(PropId.KnownValue.PR_SUBJECT));
            }
        }

        [Test]
        [ExpectedException(typeof(pstsdk.definition.exception.PstSdkException))]
        public void PropertySize_Invalid_Test()
        {
            using (var message = IntegrationUtil.GetMessage())
            {
                message.PropertySize(MessageMockConstants.MESSAGE_INVALID_PROPERTY);
            }
        }

        [Test]
        public void GetPropertyType_Valid_Test()
        {
            using (var message = IntegrationUtil.GetMessage())
            {
                Assert.AreEqual((UInt32)PropertyType.KnownValue.prop_type_wstring, message.GetPropertyType(PropId.KnownValue.PR_SUBJECT));
            }
        }

        [Test]
        [ExpectedException(typeof(pstsdk.definition.exception.PstSdkException))]
        public void GetPropertyType_Invalid_Test()
        {
            using (var message = IntegrationUtil.GetMessage())
            {
                message.GetPropertyType(MessageMockConstants.MESSAGE_INVALID_PROPERTY);
            }
        }

        [Test]
        public void OpenPropertyStream_Valid_Test()
        {
            using (var message = IntegrationUtil.GetMessage())
            {
                Stream testStream = message.OpenPropertyStream(PropId.KnownValue.PR_SUBJECT);
                Assert.AreEqual(true, testStream.Length > 0);
            }
        }

        [Test]
        [ExpectedException(typeof(pstsdk.definition.exception.PstSdkException))]
        public void OpenPropertyStream_Invalid_Test()
        {
            using (var message = IntegrationUtil.GetMessage())
            {
                Stream testStream = message.OpenPropertyStream(MessageMockConstants.MESSAGE_INVALID_PROPERTY);
            }
        }

        //TODO: Fix this test 
        //[Test]
        //public void ReadProperty_Valid_Test()
        //{
        //    Assert.Inconclusive();
        //    using (var message = IntegrationUtil.GetMessage())
        //    {
        //        Byte[] validByte = message.ReadProperty(PropId.KnownValue.PR_SUBJECT);
        //        Assert.AreEqual(validByte, message.ReadProperty(PropId.KnownValue.PR_SUBJECT));
        //    }
        //}

        [Test]
        [ExpectedException(typeof(pstsdk.definition.exception.PstSdkException))]
        public void ReadProperty_Invalid_Test()
        {
            using (var message = IntegrationUtil.GetMessage())
            {
                message.ReadProperty(MessageMockConstants.MESSAGE_INVALID_PROPERTY);
            }
        }
    }
}
