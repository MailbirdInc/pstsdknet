using System;
using System.Linq;
using pstsdk.definition.ltp.nameid;
using pstsdk.layer.ltp.nameid;
using pstsdk.definition.util.primitives;
using MbUnit.Framework;
using pstsdk.test.mocks.MockPropBagConstants;

namespace pstsdk.test.Integration
{
    public class NameIdMapIntegrationTest
    {
        [Test]
        public void BucketCount_test()
        {
            var namedIdMap = IntegrationUtil.GetNameIdMap();
            Assert.AreEqual(NameIdMapMockConstants.NAMED_IDMAP_BUCKET_COUNT, namedIdMap.BucketCount);
        }

        [Test]
        public void PropertyCount_test()
        {
            var namedIdMap = IntegrationUtil.GetNameIdMap();

            Assert.AreEqual(NameIdMapMockConstants.NAMED_IDMAP_PROPERTY_COUNT, namedIdMap.PropertyCount);
        }

        //TODO: Fix this test 
        //[Test]
        //public void IdExists_Valid_test()
        //{
        //    var namedIdMap = IntegrationUtil.GetNameIdMap();

        //    Guid guid = new Guid(NameIdMapMockConstants.NAMED_IDMAP_VALID_GUID);


        //    Assert.AreEqual(true, namedIdMap.IdExists(guid, NameIdMapMockConstants.NAMED_IDMAP_VALID_PROP_ID));
        //}

        [Test]
        public void IdExists_Invalid_test()
        {
            var namedIdMap = IntegrationUtil.GetNameIdMap();

            Guid guid = new Guid(NameIdMapMockConstants.NAMED_IDMAP_VALID_GUID);

            Assert.AreEqual(false, namedIdMap.IdExists(guid, NameIdMapMockConstants.NAMED_IDMAP_INVALID_PROPID));
        }

        //TODO: Fix this test 
        //[Test]
        //public void Lookup_Valid_test()
        //{
        //    var namedIdMap = IntegrationUtil.GetNameIdMap();

        //    Guid guid = new Guid(NameIdMapMockConstants.NAMED_IDMAP_VALID_GUID);

        //    Assert.AreEqual(NameIdMapMockConstants.LOOK_UP_VALID_TEST_PROP_ID, 
        //        namedIdMap.Lookup(guid, NameIdMapMockConstants.LOOK_UP_VALID_TEST_PROP_ID));
        //}

        [Test]
        [ExpectedException(typeof(pstsdk.definition.exception.PstSdkException))]
        public void Lookup_Invalid_test()
        {
            var namedIdMap = IntegrationUtil.GetNameIdMap();
            Guid guid = new Guid(NameIdMapMockConstants.NAMED_IDMAP_VALID_GUID);

            namedIdMap.Lookup(guid, NameIdMapMockConstants.NAMED_IDMAP_INVALID_PROPID);
        }

        //TODO: Fix this test 
        //[Test]
        //public void NamedPropertyExists_Valid_test()
        //{
        //    var namedIdMap = IntegrationUtil.GetNameIdMap();
        //    INamedProperty property = namedIdMap.Lookup(NameIdMapMockConstants.NAMED_PROPERTY_EXISTS_VALID_PROP_ID);

        //    Assert.AreEqual(true, namedIdMap.NamedPropertyExists(property));
        //}

        [Test]
        [ExpectedException(typeof(pstsdk.definition.exception.PstSdkException))]
        public void NamedPropertyExists_Invalid_test()
        {
            var namedIdMap = IntegrationUtil.GetNameIdMap();

            INamedProperty property = namedIdMap.Lookup(NameIdMapMockConstants.NAMED_IDMAP_INVALID_PROP_ID);

            namedIdMap.NamedPropertyExists(property);
        }

        [Test]
        public void NamedPropertyExists_Null_test()
        {
            var namedIdMap = IntegrationUtil.GetNameIdMap();

            Assert.AreEqual(false, namedIdMap.NamedPropertyExists(null));
        }




        //TODO: Fix this test 
        //[Test]
        //public void NameExists_Valid_test()
        //{
        //    var namedIdMap = IntegrationUtil.GetNameIdMap();

        //    Guid guid = new Guid(NameIdMapMockConstants.NAMED_IDMAP_VALID_GUID2);

        //    Assert.AreEqual(true, namedIdMap.NameExists(guid, NameIdMapMockConstants.NAMED_IDMAP_VALID_NAME));
        //}

        [Test]
        public void NameExists_Invalid_test()
        {
            var namedIdMap = IntegrationUtil.GetNameIdMap();

            string name = "   ";
            Guid guid = new Guid(NameIdMapMockConstants.NAMED_IDMAP_VALID_GUID2);

            Assert.AreEqual(false, namedIdMap.NameExists(guid, name));
        }


        [Test]
        public void PropertyExists_Valid_test()
        {
            var namedIdMap = IntegrationUtil.GetNameIdMap();

            Assert.AreEqual(true, namedIdMap.PropertyExists(NameIdMapMockConstants.NAMED_IDMAP_VALID_PROP_ID));
        }


        [Test]
        public void PropertyExists_Invalid_test()
        {
            var namedIdMap = IntegrationUtil.GetNameIdMap();

            Assert.AreEqual(false, namedIdMap.PropertyExists(NameIdMapMockConstants.NAMED_IDMAP_INVALID_PROP_ID));
        }

        [Test]
        public void Properties_Test()
        {
            var namedIdMap = IntegrationUtil.GetNameIdMap();

            PropId propId = namedIdMap.Properties.ElementAt(NameIdMapMockConstants.NAME_ID_MAP_FIRST_ELEMENT);

            Assert.AreEqual(NameIdMapMockConstants.NAMED_IDMAP_VALID_PROPERTY, propId.Value);
        }

        [Test]
        public void NamedProperties_Test()
        {
            var namedIdMap = IntegrationUtil.GetNameIdMap();

            NamedProperty namedProperty = (NamedProperty)namedIdMap.NamedProperties.ElementAt(NameIdMapMockConstants.NAME_ID_MAP_FIRST_ELEMENT);

            Assert.AreEqual(NameIdMapMockConstants.NAMED_IDMAP_VALID_NAMED_PROPERTY, namedProperty.ID);
        }

        [Test]
        public void NamedPropertyBag_Test()
        {
            var namedIdMap = IntegrationUtil.GetNameIdMap();

            NamedProperty namedProperty = (NamedProperty)namedIdMap.NamedProperties.ElementAt(NameIdMapMockConstants.NAME_ID_MAP_FIRST_ELEMENT);
            
            Assert.AreEqual(NameIdMapMockConstants.NAMED_IDMAP_VALID_NAMED_PROPERTY, namedProperty.ID); 
                       
        }

    }
}
