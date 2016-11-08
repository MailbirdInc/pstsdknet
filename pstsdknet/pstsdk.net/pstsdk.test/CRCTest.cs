using pstsdk.layer.util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace pstsdk.test
{
    
    
    /// <summary>
    ///This is a test class for CRCTest and is intended
    ///to contain all CRCTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CRCTest
    {
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

        /// <summary>
        ///A test for ComputeCRC
        ///</summary>
        [TestMethod()]
        public void ComputeCRCTest()
        {
            uint length = 0x1000;
            var bytes = new byte[length];

            for (int i = 0; i < length; i++)
            {
                bytes[i] = (byte)i;
            }
            uint expected = 0x658D2093;

            uint actual = CRC.ComputeCRC(bytes, length);
            Assert.AreEqual(expected, actual);
        }
    }
}
