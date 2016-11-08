using System;
using pstsdk.layer.ltp.nameid;
using MbUnit.Framework;
using pstsdk.test.mocks.MockPropBagConstants;

namespace pstsdk.test.Integration
{
    public class NamedPropertyIntegrationTest
    {
        [Test]
        public void Guid_Valid()
        {
            var namedProperty = IntegrationUtil.GetNamedProperty();
            Guid propGuid = new Guid(NamedPropertyMockConstants.NAMED_PROPERTY_VALID_GUID);

            Assert.AreEqual(namedProperty.Guid.ToString(), propGuid.ToString());
        }

        [Test]
        public void ID_Valid()
        {
            var namedProperty = IntegrationUtil.GetNamedProperty();
                
            Assert.AreEqual(namedProperty.ID, NamedPropertyMockConstants.NAMED_PROPERTY_VALID_ID);
        }

        [Test]
        public void IsString_Valid()
        {
            var namedProperty = IntegrationUtil.GetNamedProperty();

            Assert.IsTrue(namedProperty.IsString);
        }

        [Test]
        public void Name_Valid()
        {
            var namedProperty = IntegrationUtil.GetNamedProperty();

            Assert.AreEqual(NamedPropertyMockConstants.NAMED_PROPERTY_VALID_NAME, namedProperty.Name);
        }

        [Test]
        public void GetType_Valid()
        {
            var namedProperty = IntegrationUtil.GetNamedProperty();

            Assert.IsTrue(namedProperty.GetType() == typeof(NamedProperty));
        }
    }
}
