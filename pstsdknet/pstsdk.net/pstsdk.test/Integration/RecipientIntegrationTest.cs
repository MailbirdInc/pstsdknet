using System;
using System.Text;
using System.IO;
using pstsdk.layer.pst;
using pstsdk.definition.util.primitives;
using MbUnit.Framework;
using pstsdk.test.mocks.MockPropBagConstants;

namespace pstsdk.test.Integration
{
    public class RecipientIntegrationTest
    {
        [Test]
        public void AccountName_Not_Null()
        {
            using (var recipient = IntegrationUtil.GetRecipient())
            {
                Assert.IsNotNull(recipient.AccountName);
            }
        }
        
        [Test]
        public void EmailAddress_Test()
        {

            using (var recipient = IntegrationUtil.GetRecipient())
            {
                Assert.AreEqual(RecipientMockConstants.RECIPIENT_EMAIL_ADDRESS, recipient.EmailAddress);
            }
        }

        [Test]
        public void AddressType_Test()
        {
            using (var recipient = IntegrationUtil.GetRecipient())
            {
                Assert.AreEqual(RecipientMockConstants.RECIPIENT_ADDRESS_TYPE, recipient.AddressType);
            }
        }

        [Test]
        public void HasAccountName_Test()
        {
            using (var recipient = IntegrationUtil.GetRecipient())
            {
                Assert.AreEqual(true, recipient.HasAccountName);
            }

        }

        [Test]
        public void HasEmailAddress_Test()
        {
            using (var recipient = IntegrationUtil.GetRecipient())
            {
                Assert.AreEqual(true, recipient.HasEmailAddress);
            }

        }

        [Test]
        public void Name_Test()
        {
            using (var recipient = IntegrationUtil.GetRecipient())
            {
                Assert.AreEqual(RecipientMockConstants.RECIPIENT_NAME, recipient.Name);
            }
        }

        [Test]
        public void NodeID_Test()
        {
            using (var recipient = IntegrationUtil.GetRecipient())
            {
                Assert.AreEqual(RecipientMockConstants.RECIPIENT_VALID_NODE, (UInt32)recipient.Node); 
            }
        }

        //[Test]
        //public void RecipientType_Test()
        //{
        //    RecipientType Test_type = new RecipientType();
        //    Assert.AreEqual("mapi_to", recipient.RecipientType);
        //}

        [Test]
        public void OpenPropertyStream_Valid_Test()
        {
            using (var recipient = IntegrationUtil.GetRecipient())
            {
                using (var testStream = recipient.OpenPropertyStream(PropId.KnownValue.PidTagRecipientDisplayName))
                {
                    Assert.IsNotNull(testStream);
                    Assert.IsTrue(testStream.Length > RecipientMockConstants.RECIPIENT_OPEN_PROPERTY_STREAM_LENGTH);
                }
            }
        }

        [Test]
        [ExpectedException(typeof(pstsdk.definition.exception.PstSdkException))]
        public void OpenPropertyStream_Invalid_Test()
        {
            using (var recipient = IntegrationUtil.GetRecipient())
            {
                recipient.OpenPropertyStream(RecipientMockConstants.RECIPIENT_INVALID_PROP_ID);
            }
        }

        [Test]
        public void PropertyExists_Valid_Test()
        {
            using (var recipient = IntegrationUtil.GetRecipient())
            {
                Assert.AreEqual(true, recipient.PropertyExists(RecipientMockConstants.RECIPIENT_VALID_PROP_ID));
            }
        }

        [Test]
        public void PropertyExists_Invalid_Test()
        {
            using (var recipient = IntegrationUtil.GetRecipient())
            {
                Assert.AreEqual(false, recipient.PropertyExists(RecipientMockConstants.RECIPIENT_INVALID_PROP_ID)); 
            }
        }


        [Test]
        public void PropertySize_Valid_Test()
        {
            using (var recipient = IntegrationUtil.GetRecipient())
            {
                Assert.AreEqual(RecipientMockConstants.RECIPIENT_PROPERTY_SIZE, recipient.PropertySize(RecipientMockConstants.RECIPIENT_VALID_PROP_ID));
            }
        }

        [Test]
        [ExpectedException(typeof(pstsdk.definition.exception.PstSdkException))]
        public void PropertySize_Invalid_Test()
        {
            using (var recipient = IntegrationUtil.GetRecipient())
            {
                recipient.PropertySize(RecipientMockConstants.RECIPIENT_INVALID_PROP_ID);
            }
        }


        [Test]
        public void ReadProperty_Valid_Test()
        {
            using (var recipient = IntegrationUtil.GetRecipient())
            {
                Byte[] validByte = recipient.ReadProperty(PropId.KnownValue.PidTagRecipientDisplayName);
                Assert.AreEqual(RecipientMockConstants.RECIPIENT_DISPLAY_NAME, Encoding.Unicode.GetString(validByte));
            }
        }

        [Test]
        [ExpectedException(typeof(pstsdk.definition.exception.PstSdkException))]
        public void ReadProperty_Invalid_Test()
        {
            using (var recipient = IntegrationUtil.GetRecipient())
            {
                recipient.ReadProperty(RecipientMockConstants.RECIPIENT_INVALID_PROP_ID);
            }
        }

        [Test]
        public void Equals_Valid_Test()
        {
            using (var recipient = IntegrationUtil.GetRecipient())
            {
                using (var equalRecipient = IntegrationUtil.GetRecipient())
                {
                    Assert.AreEqual(true, recipient.Equals(equalRecipient));
                }
            }
        }

        [Test]
        public void Equals_Invalid_Test()
        {
            using (var recipient = IntegrationUtil.GetRecipient())
            {
                using (var unequalRecipient = IntegrationUtil.GetDifferentRecipient())
                {
                    Assert.AreEqual(false, recipient.Equals(unequalRecipient));
                }
            }

        }

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void Equals_Null_Test()
        {
            using (var recipient = IntegrationUtil.GetRecipient())
            {
                Recipient nullRecipient = null;
                recipient.Equals(nullRecipient);
            }
        }


        [Test]
        public void GetPropertyType_Valid_Test()
        {
            using (var recipient = IntegrationUtil.GetRecipient())
            {
                Assert.AreEqual((UInt32)PropertyType.KnownValue.prop_type_wstring, 
                    recipient.GetPropertyType(RecipientMockConstants.RECIPIENT_VALID_PROP_ID));
            }
        }

        [Test]
        [ExpectedException(typeof(pstsdk.definition.exception.PstSdkException))]
        public void GetPropertyType_Invalid_Test()
        {
            using (var recipient = IntegrationUtil.GetRecipient())
            {
                recipient.GetPropertyType(RecipientMockConstants.RECIPIENT_INVALID_PROP_ID);
            }
        }
       
    }
}