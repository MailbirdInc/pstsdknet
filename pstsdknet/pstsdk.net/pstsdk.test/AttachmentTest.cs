using System;
using pstsdk.layer.pst;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using pstsdk.definition.ndb.database;
using pstsdk.definition.util.primitives;
using pstsdk.definition.ltp;
using System.IO;
using System.Linq;
using pstsdk.test.mocks;
using pstsdk.definition.pst.message;
using System.Collections.Generic;

namespace pstsdk.test
{
    /// <summary>
    ///This is a test class for AttachmentTest and is intended
    ///to contain all AttachmentTest Unit Tests
    ///</summary>
    //[TestClass()]
    //public class AttachmentTest
    //{
    //    MockDbContext context = new MockDbContext();
    //    MockPropBag parent = new MockPropBag();

    //    [TestInitialize]
    //    public void TestInitialize()
    //    {
    //        context = new MockDbContext();
    //        parent = new MockPropBag();

    //        context.OnGetSubObjectbyNodeId = () => parent;
    //    }

    //    /// <summary>
    //    ///Gets or sets the test context which provides
    //    ///information about and functionality for the current test run.
    //    ///</summary>
    //    public TestContext TestContext { get; set; }

    //    /// <summary>
    //    ///A test for Bytes
    //    ///</summary>
    //    [TestMethod]
    //    public void BytesTest()
    //    {
    //        //simulate bytes field being empty
    //        parent.OnPropertyExists = (x) => false;
    //        var target = new Attachment(context, 0, parent);
    //        IAttachmentTest.BytesTestExpectsNull(target);

    //        parent.OnPropertyExists = (x) => x == PropId.KnownValue.PidTagAttachDataObject;
    //        parent.OnReadProperty = () => { return new byte[] {0x01, 0x02}; };
    //        IAttachmentTest.BytesTest(target, new byte[] {0x01, 0x02});
    //    }

    //    /// <summary>
    //    ///A test for ContentSize
    //    ///</summary>
    //    [TestMethod]
    //    public void ContentSizeTest()
    //    {
    //        var target = new Attachment(context, 0, parent);

    //        parent.OnPropertyExists = x => false;
    //        IAttachmentTest.ContentSizeTest(target, 0);

    //        parent.OnPropertyExists = x => x == PropId.KnownValue.PidTagAttachDataObject;
    //        parent.OnPropertySize = () => 50;
    //        IAttachmentTest.ContentSizeTest(target, 50);
    //    }

    //    /// <summary>
    //    ///A test for Filename
    //    ///</summary>
    //    [TestMethod]
    //    public void FilenameTest()
    //    {
    //        var target = new Attachment(context, 0, parent);
            
    //        parent.OnGetPropertyType = () => PropertyType.KnownValue.prop_type_wstring;

    //        //Check for no file name
    //        parent.OnPropertyExists = x => false;
    //        IAttachmentTest.FilenameTest(target, string.Empty);

    //        //check for short filename
    //        parent.OnPropertyExists = x => x == PropId.KnownValue.PidTagAttachFilename;
    //        parent.OnReadProperty = () => System.Text.Encoding.Unicode.GetBytes("SHORT");
    //        IAttachmentTest.FilenameTest(target, "SHORT");

    //        //check for long filename
    //        parent.OnPropertyExists = x => x == PropId.KnownValue.PidTagAttachLongFilename;
    //        parent.OnReadProperty = () => System.Text.Encoding.Unicode.GetBytes("LONG");
    //        IAttachmentTest.FilenameTest(target, "LONG");
    //    }

    //    /// <summary>
    //    ///A test for IsMessage
    //    ///</summary>
    //    [TestMethod]
    //    public void IsMessageTest()
    //    {
    //        const int attachMethodMsg = 5;
    //        var target = new Attachment(context, 0, parent);
    //        parent.OnPropertyExists = x => false;
    //        IAttachmentTest.IsMessageTest(target, false);

    //        parent.OnPropertyExists = x => x == PropId.KnownValue.PidTagAttachMethod;
    //        parent.OnReadProperty = () => BitConverter.GetBytes(1);
    //        IAttachmentTest.IsMessageTest(target, false);

    //        parent.OnReadProperty = () => BitConverter.GetBytes(attachMethodMsg);
    //        IAttachmentTest.IsMessageTest(target, true);
    //    }


    //    /// <summary>
    //    ///A test for Size
    //    ///</summary>
    //    [TestMethod()]
    //    public void SizeTest()
    //    {
    //        var target = new Attachment(context, 0, parent); 

    //        parent.OnPropertyExists = x => false;
    //        IAttachmentTest.SizeTest(target, 0);

    //        parent.OnPropertyExists = x => x == PropId.KnownValue.PidTagAttachSize;
    //        parent.OnReadProperty = () => BitConverter.GetBytes(50);
    //        IAttachmentTest.SizeTest(target, 50);
    //    }

    //    /// <summary>
    //    ///A test for Equals
    //    ///</summary>
    //    [TestMethod()]
    //    public void EqualsTest()
    //    {
    //        var newContext = new MockDbContext();

    //        var otherPropBag = new MockPropBag {OnGetNode = () => new NodeID {Value = 4}};
    //        newContext.OnGetSubObjectbyNodeId = () => otherPropBag;
    //        parent.OnGetNode = () => new NodeID {Value = 100};

    //        var attach = new Attachment(context, 0, parent);
    //        var other = new Attachment(newContext, 0, otherPropBag);

    //        Assert.IsFalse(attach.Equals((IAttachment) other));

    //        otherPropBag.OnGetNode = () => new NodeID{ Value = 100};
    //        Assert.IsTrue(attach.Equals((IAttachment)other));
    //    }

    //    /// <summary>
    //    ///A test for OpenAsMessage
    //    ///</summary>
    //    [TestMethod()]
    //    public void OpenAsMessageTest()
    //    {
    //        var attach = new Attachment(context, 0, parent);
    //        parent.OnPropertyExists = x => true;
    //        parent.OnReadProperty = () => BitConverter.GetBytes(1);
    //        IAttachmentTest.OpenAsMessageTestExpectsNull(attach);

    //        parent.OnReadProperty = () => BitConverter.GetBytes(5); //5 = MsgAttachMethod
    //        IAttachmentTest.OpenAsMessageTestExpectsNotNull(attach);
    //    }

    //    [TestMethod()]
    //    public void ByteStreamTest()
    //    {
    //        var attach = new Attachment(context, 0, parent);

    //        IAttachmentTest.ByteStreamTest(attach);
    //    }
    //}
}
