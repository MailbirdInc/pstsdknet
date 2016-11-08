using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using pstsdk.layer.pst;
using pstsdk.definition.ltp.nameid;
using pstsdk.layer.ltp.nameid;
using pstsdk.definition.util.primitives;
using MbUnit.Framework;

namespace pstsdk.test.Integration
{
    public class NamedIdMapIntegrationTest
    {
        [Test]
        public void BucketCount_test()
        {
            var namedIdMap = IntegrationUtil.GetNameIdMap();
            Assert.AreEqual(MockConstants.NAMED_IDMAP_BUCKET_COUNT, namedIdMap.BucketCount);
        }

        [Test]
        public void PropertyCount_test()
        {
            var namedIdMap = IntegrationUtil.GetNameIdMap();

            Assert.AreEqual(MockConstants.NAMED_IDMAP_PROPERTY_COUNT, namedIdMap.PropertyCount);
        }


        [Test]
        public void IdExists_Valid_test()
        {
            var namedIdMap = IntegrationUtil.GetNameIdMap();

            Guid guid = new Guid(MockConstants.NAMED_IDMAP_VALID_GUID);


            Assert.AreEqual(true, namedIdMap.IdExists(guid, MockConstants.NAMED_IDMAP_VALID_PROP_ID));
        }

        [Test]
        public void IdExists_Invalid_test()
        {
            var namedIdMap = IntegrationUtil.GetNameIdMap();

            Guid guid = new Guid(MockConstants.NAMED_IDMAP_VALID_GUID);

            Assert.AreEqual(false, namedIdMap.IdExists(guid, MockConstants.NAMED_IDMAP_INVALID_PROPID));
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void IdExists_Null_test()
        {
            var namedIdMap = IntegrationUtil.GetNameIdMap();

            Guid? guid = null;

            namedIdMap.IdExists(guid.Value, MockConstants.NAMED_IDMAP_INVALID_PROPID);
        }





        [Test]
        public void Lookup_Valid_test()
        {
            var namedIdMap = IntegrationUtil.GetNameIdMap();

            PropId propId = 0x8205;
            Guid guid = new Guid(MockConstants.NAMED_IDMAP_VALID_GUID);

            Assert.AreEqual(0x8000, namedIdMap.Lookup(guid, propId));
        }

        [Test]
        [ExpectedException(typeof(pstsdk.definition.exception.PstSdkException))]
        public void Lookup_Invalid_test()
        {
            var namedIdMap = IntegrationUtil.GetNameIdMap();
            Guid guid = new Guid(MockConstants.NAMED_IDMAP_VALID_GUID);

            namedIdMap.Lookup(guid, MockConstants.NAMED_IDMAP_INVALID_PROPID);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Lookup_Null_test()
        {
            var namedIdMap = IntegrationUtil.GetNameIdMap();

            Guid? guid = null;

            namedIdMap.Lookup(guid.Value, MockConstants.NAMED_IDMAP_INVALID_PROPID);
        }





        [Test]
        public void NamedPropertyExists_Valid_test()
        {
            var namedIdMap = IntegrationUtil.GetNameIdMap();

            INamedProperty property = namedIdMap.Lookup(0x8000);

            Assert.AreEqual(true, namedIdMap.NamedPropertyExists(property));
        }

        [Test]
        [ExpectedException(typeof(pstsdk.definition.exception.PstSdkException))]
        public void NamedPropertyExists_Invalid_test()
        {
            var namedIdMap = IntegrationUtil.GetNameIdMap();

            INamedProperty property = namedIdMap.Lookup(0x9999);

            namedIdMap.NamedPropertyExists(property);
        }

        [Test]
        public void NamedPropertyExists_Null_test()
        {
            var namedIdMap = IntegrationUtil.GetNameIdMap();
            INamedProperty property = null;

            Assert.AreEqual(false, namedIdMap.NamedPropertyExists(property));
        }




        [Test]
        public void NameExists_Valid_test()
        {
            var namedIdMap = IntegrationUtil.GetNameIdMap();

            Guid guid = new Guid(MockConstants.NAMED_IDMAP_VALID_GUID2);

            Assert.AreEqual(true, namedIdMap.NameExists(guid, MockConstants.NAMED_IDMAP_VALID_NAME));
        }

        [Test]
        public void NameExists_Invalid_test()
        {
            var namedIdMap = IntegrationUtil.GetNameIdMap();

            string name = "   ";
            Guid guid = new Guid(MockConstants.NAMED_IDMAP_VALID_GUID2);

            Assert.AreEqual(false, namedIdMap.NameExists(guid, name));
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void NameExists_Null_test()
        {
            var namedIdMap = IntegrationUtil.GetNameIdMap();

            Guid? guid = null;
            string name = " ";

            Assert.AreEqual(false, namedIdMap.NameExists(guid.Value, name));
        }






        [Test]
        public void PropertyExists_Valid_test()
        {
            var namedIdMap = IntegrationUtil.GetNameIdMap();

            Assert.AreEqual(true, namedIdMap.PropertyExists(MockConstants.NAMED_IDMAP_VALID_PROP_ID));
        }


        [Test]
        public void PropertyExists_Invalid_test()
        {
            var namedIdMap = IntegrationUtil.GetNameIdMap();

            Assert.AreEqual(false, namedIdMap.PropertyExists(MockConstants.NAMED_IDMAP_INVALID_PROPID));
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PropertyExists_Null_test()
        {
            var namedIdMap = IntegrationUtil.GetNameIdMap();

            PropId? propId = null;

            Assert.AreEqual(false, namedIdMap.PropertyExists(propId.Value));
        }



        [Test]
        public void Properties_Test()
        {
            var namedIdMap = IntegrationUtil.GetNameIdMap();

            PropId propId = namedIdMap.Properties.ElementAt(0);

            Assert.AreEqual(MockConstants.NAMED_IDMAP_VALID_PROPERTY, propId.Value);
        }

        [Test]
        public void NamedProperties_Test()
        {
            var namedIdMap = IntegrationUtil.GetNameIdMap();

            NamedProperty namedProperty = (NamedProperty)namedIdMap.NamedProperties.ElementAt<INamedProperty>(0);

            Assert.AreEqual(MockConstants.NAMED_IDMAP_VALID_NAMED_PROPERTY, namedProperty.ID);
        }

        [Test]
        public void NamedPropertyBag_Test()
        {
            var namedIdMap = IntegrationUtil.GetNameIdMap();

            NamedProperty namedProperty = (NamedProperty)namedIdMap.NamedProperties.ElementAt<INamedProperty>(0);
            
            Assert.AreEqual(MockConstants.NAMED_IDMAP_VALID_NAMED_PROPERTY, namedProperty.ID); 
                       
        }

    }
}
