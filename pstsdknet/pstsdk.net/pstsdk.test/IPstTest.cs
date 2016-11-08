using pstsdk.definition.pst;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using pstsdk.definition.pst.folder;
using pstsdk.definition.util.primitives;
using pstsdk.definition.pst.message;
using pstsdk.definition.ndb.database;
using System.Collections.Generic;
using pstsdk.definition.ltp.nameid;

namespace pstsdk.test
{
    
    
    /// <summary>
    ///This is a test class for IPstTest and is intended
    ///to contain all IPstTest Unit Tests
    ///</summary>
    [TestClass()]
    public class IPstTest
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
        ///A test for NameIDMap
        ///</summary>
        [TestMethod()]
        public void NameIDMapTest()
        {
            IPst target = CreateIPst(); // TODO: Initialize to an appropriate value
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
            IPst target = CreateIPst(); // TODO: Initialize to an appropriate value
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
            IPst target = CreateIPst(); // TODO: Initialize to an appropriate value
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
            IPst target = CreateIPst(); // TODO: Initialize to an appropriate value
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
            IPst target = CreateIPst(); // TODO: Initialize to an appropriate value
            IDBAccessor actual;
            actual = target.DatabaseAccessor;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for OpenSearchFolder
        ///</summary>
        [TestMethod()]
        public void OpenSearchFolderTest()
        {
            IPst target = CreateIPst(); // TODO: Initialize to an appropriate value
            NodeID nodeID = new NodeID(); // TODO: Initialize to an appropriate value
            ISearchFolder expected = null; // TODO: Initialize to an appropriate value
            ISearchFolder actual;
            actual = target.OpenSearchFolder(nodeID);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for OpenRootFolder
        ///</summary>
        [TestMethod()]
        public void OpenRootFolderTest()
        {
            IPst target = CreateIPst(); // TODO: Initialize to an appropriate value
            IFolder expected = null; // TODO: Initialize to an appropriate value
            IFolder actual;
            actual = target.OpenRootFolder();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for OpenMessage
        ///</summary>
        [TestMethod()]
        public void OpenMessageTest()
        {
            IPst target = CreateIPst(); // TODO: Initialize to an appropriate value
            NodeID nodeID = new NodeID(); // TODO: Initialize to an appropriate value
            IMessage expected = null; // TODO: Initialize to an appropriate value
            IMessage actual;
            actual = target.OpenMessage(nodeID);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for OpenFolder
        ///</summary>
        [TestMethod()]
        public void OpenFolderTest1()
        {
            IPst target = CreateIPst(); // TODO: Initialize to an appropriate value
            NodeID nodeID = new NodeID(); // TODO: Initialize to an appropriate value
            IFolder expected = null; // TODO: Initialize to an appropriate value
            IFolder actual;
            actual = target.OpenFolder(nodeID);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        internal virtual IPst CreateIPst()
        {
            // TODO: Instantiate an appropriate concrete class.
            IPst target = null;
            return target;
        }

        /// <summary>
        ///A test for OpenFolder
        ///</summary>
        [TestMethod()]
        public void OpenFolderTest()
        {
            IPst target = CreateIPst(); // TODO: Initialize to an appropriate value
            string name = string.Empty; // TODO: Initialize to an appropriate value
            IFolder expected = null; // TODO: Initialize to an appropriate value
            IFolder actual;
            actual = target.OpenFolder(name);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
