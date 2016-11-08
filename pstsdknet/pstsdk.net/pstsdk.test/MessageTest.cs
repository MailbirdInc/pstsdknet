using pstsdk.layer.pst;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using pstsdk.definition.ndb.database;
using pstsdk.definition.ltp;
using pstsdk.definition.util.primitives;
using System.IO;
using pstsdk.definition.pst.message;
using System.Collections.Generic;

namespace pstsdk.test
{


    /// <summary>
    /// This is a test class for MessageTest and is intended
    /// to contain all MessageTest Unit Tests
    /// </summary>
    [TestClass()]
    public class MessageTest
    {
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

        /// <summary>
        ///A test for HtmlBody
        ///</summary>
        [TestMethod()]
        public void HtmlBodyTest()
        {
            IDBAccessor context = null; // TODO: Initialize to an appropriate value
            IPropertyObject propBag = null; // TODO: Initialize to an appropriate value
            Message target = new Message(context, propBag); // TODO: Initialize to an appropriate value
            byte[] actual;
            actual = target.HtmlBody;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for HtmlBodySize
        ///</summary>
        [TestMethod()]
        public void HtmlBodySizeTest()
        {
            IDBAccessor context = null; // TODO: Initialize to an appropriate value
            IPropertyObject propBag = null; // TODO: Initialize to an appropriate value
            Message target = new Message(context, propBag); // TODO: Initialize to an appropriate value
            int actual;
            actual = target.HtmlBodySize;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for HtmlBodyStream
        ///</summary>
        [TestMethod()]
        public void HtmlBodyStreamTest()
        {
            IDBAccessor context = null; // TODO: Initialize to an appropriate value
            IPropertyObject propBag = null; // TODO: Initialize to an appropriate value
            Message target = new Message(context, propBag); // TODO: Initialize to an appropriate value
            Stream actual;
            actual = target.HtmlBodyStream;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Node
        ///</summary>
        [TestMethod()]
        public void NodeTest()
        {
            IDBAccessor context = null; // TODO: Initialize to an appropriate value
            IPropertyObject propBag = null; // TODO: Initialize to an appropriate value
            Message target = new Message(context, propBag); // TODO: Initialize to an appropriate value
            NodeID actual;
            actual = target.Node;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Properties
        ///</summary>
        [TestMethod()]
        public void PropertiesTest()
        {
            IDBAccessor context = null; // TODO: Initialize to an appropriate value
            IPropertyObject propBag = null; // TODO: Initialize to an appropriate value
            Message target = new Message(context, propBag); // TODO: Initialize to an appropriate value
            IEnumerable<PropId> actual;
            actual = target.Properties;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for RecipientCount
        ///</summary>
        [TestMethod()]
        public void RecipientCountTest()
        {
            IDBAccessor context = null; // TODO: Initialize to an appropriate value
            IPropertyObject propBag = null; // TODO: Initialize to an appropriate value
            Message target = new Message(context, propBag); // TODO: Initialize to an appropriate value
            int actual;
            actual = target.RecipientCount;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Recipients
        ///</summary>
        [TestMethod()]
        public void RecipientsTest()
        {
            IDBAccessor context = null; // TODO: Initialize to an appropriate value
            IPropertyObject propBag = null; // TODO: Initialize to an appropriate value
            Message target = new Message(context, propBag); // TODO: Initialize to an appropriate value
            IEnumerable<IRecipient> actual;
            actual = target.Recipients;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Size
        ///</summary>
        [TestMethod()]
        public void SizeTest()
        {
            IDBAccessor context = null; // TODO: Initialize to an appropriate value
            IPropertyObject propBag = null; // TODO: Initialize to an appropriate value
            Message target = new Message(context, propBag); // TODO: Initialize to an appropriate value
            int actual;
            actual = target.Size;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Subject
        ///</summary>
        [TestMethod()]
        public void SubjectTest()
        {
            IDBAccessor context = null; // TODO: Initialize to an appropriate value
            IPropertyObject propBag = null; // TODO: Initialize to an appropriate value
            Message target = new Message(context, propBag); // TODO: Initialize to an appropriate value
            string actual;
            actual = target.Subject;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Message Constructor
        ///</summary>
        [TestMethod()]
        public void MessageConstructorTest1()
        {
            IDBAccessor context = null; // TODO: Initialize to an appropriate value
            NodeID nodeID = new NodeID(); // TODO: Initialize to an appropriate value
            Message target = new Message(context, nodeID);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Message Constructor
        ///</summary>
        [TestMethod()]
        public void MessageConstructorTest()
        {
            IDBAccessor context = null; // TODO: Initialize to an appropriate value
            IPropertyObject propBag = null; // TODO: Initialize to an appropriate value
            Message target = new Message(context, propBag);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Dispose
        ///</summary>
        [TestMethod()]
        public void DisposeTest()
        {
            IDBAccessor context = null; // TODO: Initialize to an appropriate value
            IPropertyObject propBag = null; // TODO: Initialize to an appropriate value
            Message target = new Message(context, propBag); // TODO: Initialize to an appropriate value
            target.Dispose();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Equals
        ///</summary>
        [TestMethod()]
        public void EqualsTest()
        {
            IDBAccessor context = null; // TODO: Initialize to an appropriate value
            IPropertyObject propBag = null; // TODO: Initialize to an appropriate value
            Message target = new Message(context, propBag); // TODO: Initialize to an appropriate value
            IMessage other = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.Equals(other);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetPropertyType
        ///</summary>
        [TestMethod()]
        public void GetPropertyTypeTest()
        {
            IDBAccessor context = null; // TODO: Initialize to an appropriate value
            IPropertyObject propBag = null; // TODO: Initialize to an appropriate value
            Message target = new Message(context, propBag); // TODO: Initialize to an appropriate value
            PropId id = new PropId(); // TODO: Initialize to an appropriate value
            PropertyType expected = new PropertyType(); // TODO: Initialize to an appropriate value
            PropertyType actual;
            actual = target.GetPropertyType(id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for OpenPropertyStream
        ///</summary>
        [TestMethod()]
        public void OpenPropertyStreamTest()
        {
            IDBAccessor context = null; // TODO: Initialize to an appropriate value
            IPropertyObject propBag = null; // TODO: Initialize to an appropriate value
            Message target = new Message(context, propBag); // TODO: Initialize to an appropriate value
            PropId id = new PropId(); // TODO: Initialize to an appropriate value
            Stream expected = null; // TODO: Initialize to an appropriate value
            Stream actual;
            actual = target.OpenPropertyStream(id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for PropertyExists
        ///</summary>
        [TestMethod()]
        public void PropertyExistsTest()
        {
            IDBAccessor context = null; // TODO: Initialize to an appropriate value
            IPropertyObject propBag = null; // TODO: Initialize to an appropriate value
            Message target = new Message(context, propBag); // TODO: Initialize to an appropriate value
            PropId id = new PropId(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.PropertyExists(id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for PropertySize
        ///</summary>
        [TestMethod()]
        public void PropertySizeTest()
        {
            IDBAccessor context = null; // TODO: Initialize to an appropriate value
            IPropertyObject propBag = null; // TODO: Initialize to an appropriate value
            Message target = new Message(context, propBag); // TODO: Initialize to an appropriate value
            PropId id = new PropId(); // TODO: Initialize to an appropriate value
            uint expected = 0; // TODO: Initialize to an appropriate value
            uint actual;
            actual = target.PropertySize(id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ReadProperty
        ///</summary>
        [TestMethod()]
        public void ReadPropertyTest()
        {
            IDBAccessor context = null; // TODO: Initialize to an appropriate value
            IPropertyObject propBag = null; // TODO: Initialize to an appropriate value
            Message target = new Message(context, propBag); // TODO: Initialize to an appropriate value
            PropId id = new PropId(); // TODO: Initialize to an appropriate value
            byte[] expected = null; // TODO: Initialize to an appropriate value
            byte[] actual;
            actual = target.ReadProperty(id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for AttachmentCount
        ///</summary>
        [TestMethod()]
        public void AttachmentCountTest()
        {
            IDBAccessor context = null; // TODO: Initialize to an appropriate value
            IPropertyObject propBag = null; // TODO: Initialize to an appropriate value
            Message target = new Message(context, propBag); // TODO: Initialize to an appropriate value
            int actual;
            actual = target.AttachmentCount;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Attachments
        ///</summary>
        [TestMethod()]
        public void AttachmentsTest()
        {
            IDBAccessor context = null; // TODO: Initialize to an appropriate value
            IPropertyObject propBag = null; // TODO: Initialize to an appropriate value
            Message target = new Message(context, propBag); // TODO: Initialize to an appropriate value
            IEnumerable<IAttachment> actual;
            actual = target.Attachments;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Body
        ///</summary>
        [TestMethod()]
        public void BodyTest()
        {
            IDBAccessor context = null; // TODO: Initialize to an appropriate value
            IPropertyObject propBag = null; // TODO: Initialize to an appropriate value
            Message target = new Message(context, propBag); // TODO: Initialize to an appropriate value
            string actual;
            actual = target.Body;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for BodySize
        ///</summary>
        [TestMethod()]
        public void BodySizeTest()
        {
            IDBAccessor context = null; // TODO: Initialize to an appropriate value
            IPropertyObject propBag = null; // TODO: Initialize to an appropriate value
            Message target = new Message(context, propBag); // TODO: Initialize to an appropriate value
            int actual;
            actual = target.BodySize;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for BodyStream
        ///</summary>
        [TestMethod()]
        public void BodyStreamTest()
        {
            IDBAccessor context = null; // TODO: Initialize to an appropriate value
            IPropertyObject propBag = null; // TODO: Initialize to an appropriate value
            Message target = new Message(context, propBag); // TODO: Initialize to an appropriate value
            Stream actual;
            actual = target.BodyStream;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for EntryID
        ///</summary>
        [TestMethod()]
        public void EntryIDTest()
        {
            IDBAccessor context = null; // TODO: Initialize to an appropriate value
            IPropertyObject propBag = null; // TODO: Initialize to an appropriate value
            Message target = new Message(context, propBag); // TODO: Initialize to an appropriate value
            EntryID actual;
            actual = target.EntryID;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for HasBody
        ///</summary>
        [TestMethod()]
        public void HasBodyTest()
        {
            IDBAccessor context = null; // TODO: Initialize to an appropriate value
            IPropertyObject propBag = null; // TODO: Initialize to an appropriate value
            Message target = new Message(context, propBag); // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.HasBody;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for HasHtmlBody
        ///</summary>
        [TestMethod()]
        public void HasHtmlBodyTest()
        {
            IDBAccessor context = null; // TODO: Initialize to an appropriate value
            IPropertyObject propBag = null; // TODO: Initialize to an appropriate value
            Message target = new Message(context, propBag); // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.HasHtmlBody;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for HasSubject
        ///</summary>
        [TestMethod()]
        public void HasSubjectTest()
        {
            IDBAccessor context = null; // TODO: Initialize to an appropriate value
            IPropertyObject propBag = null; // TODO: Initialize to an appropriate value
            Message target = new Message(context, propBag); // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.HasSubject;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
