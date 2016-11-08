using pstsdk.layer.pst;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using pstsdk.definition.util.primitives;
using pstsdk.definition.pst.folder;
using System.IO;
using pstsdk.definition.pst.message;
using pstsdk.definition.ndb.database;
using System.Collections.Generic;
using pstsdk.definition.ltp.nameid;

namespace pstsdk.test
{
    /// <summary>
    ///This is a test class for PstTest and is intended
    ///to contain all PstTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PstTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for Properties
        ///</summary>
        [TestMethod()]
        public void PropertiesTest()
        {
            string path = string.Empty; // TODO: Initialize to an appropriate value
            Pst target = new Pst(path); // TODO: Initialize to an appropriate value
            IEnumerable<PropId> actual;
            actual = target.Properties;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Node
        ///</summary>
        [TestMethod()]
        public void NodeTest()
        {
            string path = string.Empty; // TODO: Initialize to an appropriate value
            Pst target = new Pst(path); // TODO: Initialize to an appropriate value
            NodeID actual;
            actual = target.Node;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for NameIDMap
        ///</summary>
        [TestMethod()]
        public void NameIDMapTest()
        {
            string path = string.Empty; // TODO: Initialize to an appropriate value
            Pst target = new Pst(path); // TODO: Initialize to an appropriate value
            INameIDMap actual;
            actual = target.NameIDMap;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Name
        ///</summary>
        [TestMethod()]
        public void NameTest()
        {
            string path = string.Empty; // TODO: Initialize to an appropriate value
            Pst target = new Pst(path); // TODO: Initialize to an appropriate value
            string actual;
            actual = target.Name;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Messages
        ///</summary>
        [TestMethod()]
        public void MessagesTest()
        {
            string path = string.Empty; // TODO: Initialize to an appropriate value
            Pst target = new Pst(path); // TODO: Initialize to an appropriate value
            IEnumerable<IMessage> actual;
            actual = target.Messages;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Folders
        ///</summary>
        [TestMethod()]
        public void FoldersTest()
        {
            string path = string.Empty; // TODO: Initialize to an appropriate value
            Pst target = new Pst(path); // TODO: Initialize to an appropriate value
            IEnumerable<IFolder> actual;
            actual = target.Folders;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for DatabaseAccessor
        ///</summary>
        [TestMethod()]
        public void DatabaseAccessorTest()
        {
            string path = string.Empty; // TODO: Initialize to an appropriate value
            Pst target = new Pst(path); // TODO: Initialize to an appropriate value
            IDBAccessor actual;
            actual = target.DatabaseAccessor;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ReadProperty
        ///</summary>
        [TestMethod()]
        public void ReadPropertyTest()
        {
            string path = string.Empty; // TODO: Initialize to an appropriate value
            Pst target = new Pst(path); // TODO: Initialize to an appropriate value
            PropId id = new PropId(); // TODO: Initialize to an appropriate value
            byte[] expected = null; // TODO: Initialize to an appropriate value
            byte[] actual;
            actual = target.ReadProperty(id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for PropertySize
        ///</summary>
        [TestMethod()]
        public void PropertySizeTest()
        {
            string path = string.Empty; // TODO: Initialize to an appropriate value
            Pst target = new Pst(path); // TODO: Initialize to an appropriate value
            PropId id = new PropId(); // TODO: Initialize to an appropriate value
            uint expected = 0; // TODO: Initialize to an appropriate value
            uint actual;
            actual = target.PropertySize(id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for PropertyExists
        ///</summary>
        [TestMethod()]
        public void PropertyExistsTest()
        {
            string path = string.Empty; // TODO: Initialize to an appropriate value
            Pst target = new Pst(path); // TODO: Initialize to an appropriate value
            PropId id = new PropId(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.PropertyExists(id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Pst Constructor
        ///</summary>
        [TestMethod()]
        public void PstConstructorTest()
        {
            string path = string.Empty; // TODO: Initialize to an appropriate value
            Pst target = new Pst(path);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Dispose
        ///</summary>
        [TestMethod()]
        public void DisposeTest()
        {
            string path = string.Empty; // TODO: Initialize to an appropriate value
            Pst target = new Pst(path); // TODO: Initialize to an appropriate value
            target.Dispose();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for GetPropertyType
        ///</summary>
        [TestMethod()]
        public void GetPropertyTypeTest()
        {
            string path = string.Empty; // TODO: Initialize to an appropriate value
            Pst target = new Pst(path); // TODO: Initialize to an appropriate value
            PropId id = new PropId(); // TODO: Initialize to an appropriate value
            PropertyType expected = new PropertyType(); // TODO: Initialize to an appropriate value
            PropertyType actual;
            actual = target.GetPropertyType(id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for OpenFolder
        ///</summary>
        [TestMethod()]
        public void OpenFolderTest1()
        {
            string path = string.Empty; // TODO: Initialize to an appropriate value
            Pst target = new Pst(path); // TODO: Initialize to an appropriate value
            NodeID nodeID = new NodeID(); // TODO: Initialize to an appropriate value
            IFolder expected = null; // TODO: Initialize to an appropriate value
            IFolder actual;
            actual = target.OpenFolder(nodeID);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for OpenFolder
        ///</summary>
        [TestMethod()]
        public void OpenFolderTest()
        {
            string path = string.Empty; // TODO: Initialize to an appropriate value
            Pst target = new Pst(path); // TODO: Initialize to an appropriate value
            string name = string.Empty; // TODO: Initialize to an appropriate value
            IFolder expected = null; // TODO: Initialize to an appropriate value
            IFolder actual;
            actual = target.OpenFolder(name);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for OpenMessage
        ///</summary>
        [TestMethod()]
        public void OpenMessageTest()
        {
            string path = string.Empty; // TODO: Initialize to an appropriate value
            Pst target = new Pst(path); // TODO: Initialize to an appropriate value
            NodeID nodeID = new NodeID(); // TODO: Initialize to an appropriate value
            IMessage expected = null; // TODO: Initialize to an appropriate value
            IMessage actual;
            actual = target.OpenMessage(nodeID);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for OpenPropertyStream
        ///</summary>
        [TestMethod()]
        public void OpenPropertyStreamTest()
        {
            string path = string.Empty; // TODO: Initialize to an appropriate value
            Pst target = new Pst(path); // TODO: Initialize to an appropriate value
            PropId id = new PropId(); // TODO: Initialize to an appropriate value
            Stream expected = null; // TODO: Initialize to an appropriate value
            Stream actual;
            actual = target.OpenPropertyStream(id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for OpenRootFolder
        ///</summary>
        [TestMethod()]
        public void OpenRootFolderTest()
        {
            string path = string.Empty; // TODO: Initialize to an appropriate value
            Pst target = new Pst(path); // TODO: Initialize to an appropriate value
            IFolder expected = null; // TODO: Initialize to an appropriate value
            IFolder actual;
            actual = target.OpenRootFolder();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for OpenSearchFolder
        ///</summary>
        [TestMethod()]
        public void OpenSearchFolderTest()
        {
            string path = string.Empty; // TODO: Initialize to an appropriate value
            Pst target = new Pst(path); // TODO: Initialize to an appropriate value
            NodeID nodeID = new NodeID(); // TODO: Initialize to an appropriate value
            ISearchFolder expected = null; // TODO: Initialize to an appropriate value
            ISearchFolder actual;
            actual = target.OpenSearchFolder(nodeID);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
