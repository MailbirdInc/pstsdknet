using pstsdk.definition.pst.folder;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using pstsdk.definition.ndb.database;
using pstsdk.definition.pst.message;
using System.Collections.Generic;

namespace pstsdk.test
{
    
    
    /// <summary>
    ///This is a test class for ISearchFolderTest and is intended
    ///to contain all ISearchFolderTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ISearchFolderTest
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
        ///A test for Name
        ///</summary>
        [TestMethod()]
        public void NameTest()
        {
            ISearchFolder target = CreateISearchFolder(); // TODO: Initialize to an appropriate value
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
            ISearchFolder target = CreateISearchFolder(); // TODO: Initialize to an appropriate value
            IEnumerable<IMessage> actual;
            actual = target.Messages;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for MessageCount
        ///</summary>
        [TestMethod()]
        public void MessageCountTest()
        {
            ISearchFolder target = CreateISearchFolder(); // TODO: Initialize to an appropriate value
            int actual;
            actual = target.MessageCount;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        internal virtual ISearchFolder CreateISearchFolder()
        {
            // TODO: Instantiate an appropriate concrete class.
            ISearchFolder target = null;
            return target;
        }

        /// <summary>
        ///A test for DatabaseContext
        ///</summary>
        [TestMethod()]
        public void DatabaseContextTest()
        {
            ISearchFolder target = CreateISearchFolder(); // TODO: Initialize to an appropriate value
            IDBAccessor actual;
            actual = target.DatabaseContext;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
