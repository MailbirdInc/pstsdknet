using pstsdk.definition.pst.message;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using pstsdk.definition.util.primitives;

namespace pstsdk.test
{
    
    
    /// <summary>
    ///This is a test class for IMessageTest and is intended
    ///to contain all IMessageTest Unit Tests
    ///</summary>
    [TestClass()]
    public class IMessageTest
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
        ///A test for Subject
        ///</summary>
        [TestMethod()]
        public void SubjectTest()
        {
            IMessage target = CreateIMessage(); // TODO: Initialize to an appropriate value
            string actual;
            actual = target.Subject;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Size
        ///</summary>
        [TestMethod()]
        public void SizeTest()
        {
            IMessage target = CreateIMessage(); // TODO: Initialize to an appropriate value
            int actual;
            actual = target.Size;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Recipients
        ///</summary>
        [TestMethod()]
        public void RecipientsTest()
        {
            IMessage target = CreateIMessage(); // TODO: Initialize to an appropriate value
            IEnumerable<IRecipient> actual;
            actual = target.Recipients;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for RecipientCount
        ///</summary>
        [TestMethod()]
        public void RecipientCountTest()
        {
            IMessage target = CreateIMessage(); // TODO: Initialize to an appropriate value
            int actual;
            actual = target.RecipientCount;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for HtmlBodyStream
        ///</summary>
        [TestMethod()]
        public void HtmlBodyStreamTest()
        {
            IMessage target = CreateIMessage(); // TODO: Initialize to an appropriate value
            Stream actual;
            actual = target.HtmlBodyStream;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for HtmlBodySize
        ///</summary>
        [TestMethod()]
        public void HtmlBodySizeTest()
        {
            IMessage target = CreateIMessage(); // TODO: Initialize to an appropriate value
            int actual;
            actual = target.HtmlBodySize;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for HtmlBody
        ///</summary>
        [TestMethod()]
        public void HtmlBodyTest()
        {
            IMessage target = CreateIMessage(); // TODO: Initialize to an appropriate value
            byte[] actual;
            actual = target.HtmlBody;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for HasSubject
        ///</summary>
        [TestMethod()]
        public void HasSubjectTest()
        {
            IMessage target = CreateIMessage(); // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.HasSubject;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for HasHtmlBody
        ///</summary>
        [TestMethod()]
        public void HasHtmlBodyTest()
        {
            IMessage target = CreateIMessage(); // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.HasHtmlBody;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for HasBody
        ///</summary>
        [TestMethod()]
        public void HasBodyTest()
        {
            IMessage target = CreateIMessage(); // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.HasBody;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for EntryID
        ///</summary>
        [TestMethod()]
        public void EntryIDTest()
        {
            IMessage target = CreateIMessage(); // TODO: Initialize to an appropriate value
            EntryID actual;
            actual = target.EntryID;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for BodyStream
        ///</summary>
        [TestMethod()]
        public void BodyStreamTest()
        {
            IMessage target = CreateIMessage(); // TODO: Initialize to an appropriate value
            Stream actual;
            actual = target.BodyStream;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for BodySize
        ///</summary>
        [TestMethod()]
        public void BodySizeTest()
        {
            IMessage target = CreateIMessage(); // TODO: Initialize to an appropriate value
            int actual;
            actual = target.BodySize;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Body
        ///</summary>
        [TestMethod()]
        public void BodyTest()
        {
            IMessage target = CreateIMessage(); // TODO: Initialize to an appropriate value
            string actual;
            actual = target.Body;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Attachments
        ///</summary>
        [TestMethod()]
        public void AttachmentsTest()
        {
            IMessage target = CreateIMessage(); // TODO: Initialize to an appropriate value
            IEnumerable<IAttachment> actual;
            actual = target.Attachments;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        internal virtual IMessage CreateIMessage()
        {
            // TODO: Instantiate an appropriate concrete class.
            IMessage target = null;
            return target;
        }

        /// <summary>
        ///A test for AttachmentCount
        ///</summary>
        [TestMethod()]
        public void AttachmentCountTest()
        {
            IMessage target = CreateIMessage(); // TODO: Initialize to an appropriate value
            int actual;
            actual = target.AttachmentCount;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
