using System;
using System.Linq;
using pstsdk.layer.pst;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using pstsdk.definition.ndb.database;
using pstsdk.definition.util.primitives;
using pstsdk.definition.pst.message;
using System.Collections.Generic;
using pstsdk.definition.pst.folder;
using System.IO;
using pstsdk.definition.ltp;
using pstsdk.test.mocks;

namespace pstsdk.test
{
    ///// <summary>
    /////This is a test class for FolderTest and is intended
    /////to contain all FolderTest Unit Tests
    /////</summary>
    //[TestClass()]
    //public class FolderTest
    //{
    //    /// <summary>
    //    ///Gets or sets the test context which provides
    //    ///information about and functionality for the current test run.
    //    ///</summary>
    //    public TestContext TestContext { get; set; }

    //    /// <summary>
    //    ///A test for SubFolders
    //    ///</summary>
    //    [TestMethod]
    //    public void SubFoldersTest()
    //    {
    //        var context = new MockDbContext();
    //        var propBag = new MockPropBag();
    //        var target = new Folder(context, propBag);

    //        //Make sure it returns a vaild but empty enumeration
    //        //when there are no subfolders
    //        context.OnGetSubObjectCountByNidType = () => 0;

    //        var actual = target.SubFolders;
    //        Assert.IsTrue(actual.Count() == 0);

    //        //Make sure it returns an enumeration when there
    //        //are subfolders present
    //        context.OnGetSubObjectCountByNidType = () => 1;
    //        var pb = new MockPropBag
    //                     {
    //                         OnGetNode = () => NodeID.make_nid(NidType.nid_type_folder, 0)
    //                     };

    //        context.OnGetSubObjectsByNidType = () => new[] {pb};

    //        actual = target.SubFolders;
    //        Assert.IsTrue(actual.Count() == 1);
    //    }

    //    /// <summary>
    //    ///A test for OpenSubFolder
    //    ///</summary>
    //    [TestMethod]
    //    public void OpenSubFolderTest()
    //    {
    //        var propBag = new MockPropBag();
    //        var context = new MockDbContext
    //                  {
    //                      OnGetSubObjectCountByNidType = () => 0,
    //                      OnGetSubObjectsByNidType = () => new[]
    //                           { new MockPropBag {
    //                               OnReadProperty = () => System.Text.Encoding.Unicode.GetBytes("myFolder"),
    //                               OnGetNode = () => NodeID.make_nid(NidType.nid_type_folder, 100),
    //                               OnPropertyExists = (x) => true,
    //                               OnGetPropertyType = () => PropertyType.KnownValue.prop_type_wstring
    //                           } }
    //                  };

    //        var target = new Folder(context, propBag);

    //        //Has no subfolders
    //        IFolderTest.OpenSubFolderTestExpectsNull(target, "n");

    //        //Has subfolders, but searched name doesn't exist (case sensitive)
    //        context.OnGetSubObjectCountByNidType = () => 1;
    //        IFolderTest.OpenSubFolderTestExpectsNull(target, "MyFolder");

    //        //Successfully find a folder
    //        IFolderTest.OpenSubFolderTest(target, "myFolder");
    //    }

    //    /// <summary>
    //    ///A test for AssociatedMessageCount
    //    ///</summary>
    //    [TestMethod]
    //    public void AssociatedMessageCountTest()
    //    {
    //        IDBAccessor context = null;
    //        var propBag = new MockPropBag()
    //                          {
    //                              OnPropertyExists = (x) => false,
    //                              OnReadProperty = () => BitConverter.GetBytes(4)
    //                          };
    //        var target = new Folder(context, propBag);

    //        //Make sure no count is returned if the property doesn't exist
    //        IFolderTest.AssociatedMessageCountTest(target, 0);

    //        propBag.OnPropertyExists = (x) => x == PropId.KnownValue.PidTagAssociatedContentCount;
    //        IFolderTest.AssociatedMessageCountTest(target, 4);
    //    }

    //    /// <summary>
    //    ///A test for AssociatedMessages
    //    ///</summary>
    //    [TestMethod]
    //    public void AssociatedMessagesTest()
    //    {
    //        IDBAccessor context = null; // TODO: Initialize to an appropriate value
    //        NodeID nodeID = new NodeID(); // TODO: Initialize to an appropriate value
    //        Folder target = new Folder(context, nodeID); // TODO: Initialize to an appropriate value
    //        IEnumerable<IMessage> actual;
    //        actual = target.AssociatedMessages;
    //        Assert.Inconclusive("Verify the correctness of this test method.");
    //    }

    //    /// <summary>
    //    ///A test for MessageCount
    //    ///</summary>
    //    [TestMethod]
    //    public void MessageCountTest()
    //    {
    //        IDBAccessor context = null;
    //        var propBag = new MockPropBag()
    //                          {
    //                              OnPropertyExists = (x) => false,
    //                              OnReadProperty = () => BitConverter.GetBytes(4)
    //                          };
    //        var target = new Folder(context, propBag);

    //        //Make sure message count = 0 when the property doesn't exist
    //        IFolderTest.MessageCountTest(target, 0);

    //        //return message count when it exists
    //        propBag.OnPropertyExists = (x) => x == PropId.KnownValue.PidTagContentCount;
    //        IFolderTest.MessageCountTest(target, 4);
    //    }

    //    /// <summary>
    //    ///A test for Messages
    //    ///</summary>
    //    [TestMethod]
    //    public void MessagesTest()
    //    {
    //        IDBAccessor context = null; // TODO: Initialize to an appropriate value
    //        NodeID nodeID = new NodeID(); // TODO: Initialize to an appropriate value
    //        Folder target = new Folder(context, nodeID); // TODO: Initialize to an appropriate value
    //        IEnumerable<IMessage> actual;
    //        actual = target.Messages;
    //        Assert.Inconclusive("Verify the correctness of this test method.");
    //    }

    //    /// <summary>
    //    ///A test for Name
    //    ///</summary>
    //    [TestMethod]
    //    public void NameTest()
    //    {
    //        IDBAccessor context = null;
    //        var propBag = new MockPropBag()
    //                          {
    //                              OnPropertyExists = (x) => false,
    //                              OnGetPropertyType = () => PropertyType.KnownValue.prop_type_string,
    //                              OnReadProperty = () => System.Text.Encoding.ASCII.GetBytes("test value")
    //                          };
    //        var target = new Folder(context, propBag);
            
    //        IFolderTest.NameTest(target, string.Empty);

    //        propBag.OnPropertyExists = (x) => x == PropId.KnownValue.PR_DISPLAY_NAME;

    //        IFolderTest.NameTest(target, "test value");
    //    }
    //}
}
