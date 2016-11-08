using pstsdk.layer.ltp.nameid;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using pstsdk.definition.ndb.database;
using pstsdk.definition.ltp;
using pstsdk.definition.util.primitives;
using System.Collections.Generic;
using pstsdk.definition.ltp.nameid;
using System;

namespace pstsdk.test
{
    
    
    /// <summary>
    ///This is a test class for NameIdMapTest and is intended
    ///to contain all NameIdMapTest Unit Tests
    ///</summary>
    [TestClass()]
    public class NameIdMapTest
    {
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

        /// <summary>
        ///A test for BuildNamedProperty
        ///</summary>
        [TestMethod()]
        [DeploymentItem("pstsdk.dll")]
        public void BuildNamedPropertyTest1()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            NameIdMap_Accessor target = new NameIdMap_Accessor(param0); // TODO: Initialize to an appropriate value
            PropId id = new PropId(); // TODO: Initialize to an appropriate value
            NamedProperty expected = null; // TODO: Initialize to an appropriate value
            NamedProperty actual;
            actual = target.BuildNamedProperty(id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for BuildNamedProperty
        ///</summary>
        [TestMethod()]
        [DeploymentItem("pstsdk.dll")]
        public void BuildNamedPropertyTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            NameIdMap_Accessor target = new NameIdMap_Accessor(param0); // TODO: Initialize to an appropriate value
            NameId id = new NameId(); // TODO: Initialize to an appropriate value
            NamedProperty expected = null; // TODO: Initialize to an appropriate value
            NamedProperty actual;
            actual = target.BuildNamedProperty(id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ComputeHashBase
        ///</summary>
        [TestMethod()]
        [DeploymentItem("pstsdk.dll")]
        public void ComputeHashBaseTest()
        {
            INamedProperty n = null; // TODO: Initialize to an appropriate value
            uint expected = 0; // TODO: Initialize to an appropriate value
            uint actual;
            actual = NameIdMap_Accessor.ComputeHashBase(n);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ComputeHashValue
        ///</summary>
        [TestMethod()]
        [DeploymentItem("pstsdk.dll")]
        public void ComputeHashValueTest()
        {
            ushort guidIndex = 0; // TODO: Initialize to an appropriate value
            INamedProperty n = null; // TODO: Initialize to an appropriate value
            uint expected = 0; // TODO: Initialize to an appropriate value
            uint actual;
            actual = NameIdMap_Accessor.ComputeHashValue(guidIndex, n);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetBucketProperty
        ///</summary>
        [TestMethod()]
        [DeploymentItem("pstsdk.dll")]
        public void GetBucketPropertyTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            NameIdMap_Accessor target = new NameIdMap_Accessor(param0); // TODO: Initialize to an appropriate value
            uint hashValue = 0; // TODO: Initialize to an appropriate value
            PropId expected = new PropId(); // TODO: Initialize to an appropriate value
            PropId actual;
            actual = target.GetBucketProperty(hashValue);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetGuidIndex
        ///</summary>
        [TestMethod()]
        [DeploymentItem("pstsdk.dll")]
        public void GetGuidIndexTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            NameIdMap_Accessor target = new NameIdMap_Accessor(param0); // TODO: Initialize to an appropriate value
            Guid guid = new Guid(); // TODO: Initialize to an appropriate value
            ushort expected = 0; // TODO: Initialize to an appropriate value
            ushort actual;
            actual = target.GetGuidIndex(guid);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for IdExists
        ///</summary>
        [TestMethod()]
        public void IdExistsTest()
        {
            IDBAccessor database = null; // TODO: Initialize to an appropriate value
            NameIdMap target = new NameIdMap(database); // TODO: Initialize to an appropriate value
            Guid guid = new Guid(); // TODO: Initialize to an appropriate value
            int id = 0; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.IdExists(guid, id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Lookup
        ///</summary>
        [TestMethod()]
        public void LookupTest3()
        {
            IDBAccessor database = null; // TODO: Initialize to an appropriate value
            NameIdMap target = new NameIdMap(database); // TODO: Initialize to an appropriate value
            Guid guid = new Guid(); // TODO: Initialize to an appropriate value
            string name = string.Empty; // TODO: Initialize to an appropriate value
            PropId expected = new PropId(); // TODO: Initialize to an appropriate value
            PropId actual;
            actual = target.Lookup(guid, name);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Lookup
        ///</summary>
        [TestMethod()]
        public void LookupTest2()
        {
            IDBAccessor database = null; // TODO: Initialize to an appropriate value
            NameIdMap target = new NameIdMap(database); // TODO: Initialize to an appropriate value
            PropId id = new PropId(); // TODO: Initialize to an appropriate value
            INamedProperty expected = null; // TODO: Initialize to an appropriate value
            INamedProperty actual;
            actual = target.Lookup(id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Lookup
        ///</summary>
        [TestMethod()]
        public void LookupTest1()
        {
            IDBAccessor database = null; // TODO: Initialize to an appropriate value
            NameIdMap target = new NameIdMap(database); // TODO: Initialize to an appropriate value
            INamedProperty namedProperty = null; // TODO: Initialize to an appropriate value
            PropId expected = new PropId(); // TODO: Initialize to an appropriate value
            PropId actual;
            actual = target.Lookup(namedProperty);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Lookup
        ///</summary>
        [TestMethod()]
        public void LookupTest()
        {
            IDBAccessor database = null; // TODO: Initialize to an appropriate value
            NameIdMap target = new NameIdMap(database); // TODO: Initialize to an appropriate value
            Guid guid = new Guid(); // TODO: Initialize to an appropriate value
            int id = 0; // TODO: Initialize to an appropriate value
            PropId expected = new PropId(); // TODO: Initialize to an appropriate value
            PropId actual;
            actual = target.Lookup(guid, id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for NamedPropertyExists
        ///</summary>
        [TestMethod()]
        public void NamedPropertyExistsTest()
        {
            IDBAccessor database = null; // TODO: Initialize to an appropriate value
            NameIdMap target = new NameIdMap(database); // TODO: Initialize to an appropriate value
            INamedProperty namedProperty = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.NamedPropertyExists(namedProperty);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for NameExists
        ///</summary>
        [TestMethod()]
        public void NameExistsTest()
        {
            IDBAccessor database = null; // TODO: Initialize to an appropriate value
            NameIdMap target = new NameIdMap(database); // TODO: Initialize to an appropriate value
            Guid guid = new Guid(); // TODO: Initialize to an appropriate value
            string name = string.Empty; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.NameExists(guid, name);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for PropertyExists
        ///</summary>
        [TestMethod()]
        public void PropertyExistsTest()
        {
            IDBAccessor database = null; // TODO: Initialize to an appropriate value
            NameIdMap target = new NameIdMap(database); // TODO: Initialize to an appropriate value
            PropId id = new PropId(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.PropertyExists(id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ReadGuid
        ///</summary>
        [TestMethod()]
        [DeploymentItem("pstsdk.dll")]
        public void ReadGuidTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            NameIdMap_Accessor target = new NameIdMap_Accessor(param0); // TODO: Initialize to an appropriate value
            NameId id = new NameId(); // TODO: Initialize to an appropriate value
            Guid expected = new Guid(); // TODO: Initialize to an appropriate value
            Guid actual;
            actual = target.ReadGuid(id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ReadString
        ///</summary>
        [TestMethod()]
        [DeploymentItem("pstsdk.dll")]
        public void ReadStringTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            NameIdMap_Accessor target = new NameIdMap_Accessor(param0); // TODO: Initialize to an appropriate value
            NameId id = new NameId(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.ReadString(id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for BucketCount
        ///</summary>
        [TestMethod()]
        [DeploymentItem("pstsdk.dll")]
        public void BucketCountTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            NameIdMap_Accessor target = new NameIdMap_Accessor(param0); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.BucketCount = expected;
            actual = target.BucketCount;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for NamedProperties
        ///</summary>
        [TestMethod()]
        public void NamedPropertiesTest()
        {
            IDBAccessor database = null; // TODO: Initialize to an appropriate value
            NameIdMap target = new NameIdMap(database); // TODO: Initialize to an appropriate value
            IEnumerable<INamedProperty> actual;
            actual = target.NamedProperties;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Properties
        ///</summary>
        [TestMethod()]
        public void PropertiesTest()
        {
            IDBAccessor database = null; // TODO: Initialize to an appropriate value
            NameIdMap target = new NameIdMap(database); // TODO: Initialize to an appropriate value
            IEnumerable<PropId> actual;
            actual = target.Properties;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for PropertyBag
        ///</summary>
        [TestMethod()]
        public void PropertyBagTest()
        {
            IDBAccessor database = null; // TODO: Initialize to an appropriate value
            NameIdMap target = new NameIdMap(database); // TODO: Initialize to an appropriate value
            IPropertyObject actual;
            actual = target.PropertyBag;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for PropertyCount
        ///</summary>
        [TestMethod()]
        public void PropertyCountTest()
        {
            IDBAccessor database = null; // TODO: Initialize to an appropriate value
            NameIdMap target = new NameIdMap(database); // TODO: Initialize to an appropriate value
            int actual;
            actual = target.PropertyCount;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
