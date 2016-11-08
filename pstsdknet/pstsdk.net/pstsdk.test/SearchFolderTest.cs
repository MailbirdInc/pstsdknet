using pstsdk.layer.pst;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using pstsdk.definition.ndb.database;
using pstsdk.definition.util.primitives;
using System.IO;
using pstsdk.definition.pst.message;
using System.Collections.Generic;

namespace pstsdk.test
{
    /// <summary>
    ///This is a test class for SearchFolderTest and is intended
    ///to contain all SearchFolderTest Unit Tests
    ///</summary>
    [TestClass]
    public class SearchFolderTest
    {
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

        /// <summary>
        ///A test for Name
        ///</summary>
        [TestMethod]
        public void NameTest()
        {
            IDBAccessor context = null; // TODO: Initialize to an appropriate value
            NodeID nodeID = new NodeID(); // TODO: Initialize to an appropriate value
            SearchFolder target = new SearchFolder(context, nodeID); // TODO: Initialize to an appropriate value
            string actual;
            actual = target.Name;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Messages
        ///</summary>
        [TestMethod]
        public void MessagesTest()
        {
            IDBAccessor context = null; // TODO: Initialize to an appropriate value
            NodeID nodeID = new NodeID(); // TODO: Initialize to an appropriate value
            SearchFolder target = new SearchFolder(context, nodeID); // TODO: Initialize to an appropriate value
            IEnumerable<IMessage> actual;
            actual = target.Messages;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for MessageCount
        ///</summary>
        [TestMethod]
        public void MessageCountTest()
        {
            IDBAccessor context = null; // TODO: Initialize to an appropriate value
            NodeID nodeID = new NodeID(); // TODO: Initialize to an appropriate value
            SearchFolder target = new SearchFolder(context, nodeID); // TODO: Initialize to an appropriate value
            int actual;
            actual = target.MessageCount;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
