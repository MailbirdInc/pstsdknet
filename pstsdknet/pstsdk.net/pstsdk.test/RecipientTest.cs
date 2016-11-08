using System;
using pstsdk.layer.pst;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using pstsdk.definition.ndb.database;
using pstsdk.definition.ltp;
using pstsdk.definition.util.primitives;
using pstsdk.definition.pst.message;
using System.IO;
using System.Collections.Generic;
using pstsdk.test.mocks;

namespace pstsdk.test
{
    /// <summary>
    ///This is a test class for RecipientTest and is intended
    ///to contain all RecipientTest Unit Tests
    ///</summary>
    //[TestClass()]
    //public class RecipientTest
    //{
    //    /// <summary>
    //    ///Gets or sets the test context which provides
    //    ///information about and functionality for the current test run.
    //    ///</summary>
    //    public TestContext TestContext { get; set; }

    //    public MockDbContext Context { get; set; }
    //    public MockPropBag PropBag { get; set; }
        
    //    [TestInitialize()]
    //    public void InitializeTest()
    //    {
    //        Context = new MockDbContext();
    //        PropBag = new MockPropBag();

    //        Context.OnGetPropertyObjectByNodeId = () => PropBag;
    //    }

    //    /// <summary>
    //    ///A test for RecipientType
    //    ///</summary>
    //    [TestMethod()]
    //    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    //    public void RecipientTypeTestExpectsException()
    //    {
    //        var target = new Recipient(Context, 0);
    //        PropBag.OnPropertyExists = (x) => false;
    //        IRecipientTest.RecipientTypeTest(target, RecipientType.mapi_bcc);
    //    }

    //    /// <summary>
    //    ///A test for RecipientType
    //    ///</summary>
    //    [TestMethod()]
    //    public void RecipientTypeTest()
    //    {
    //        var target = new Recipient(Context, 0);
    //        PropBag.OnPropertyExists = (x) => x == PropId.KnownValue.PR_RECIPIENT_TYPE;

    //        PropBag.OnReadProperty = () => BitConverter.GetBytes((int)RecipientType.mapi_to);
    //        IRecipientTest.RecipientTypeTest(target, RecipientType.mapi_to);

    //        PropBag.OnReadProperty = () => BitConverter.GetBytes((int)RecipientType.mapi_cc);
    //        IRecipientTest.RecipientTypeTest(target, RecipientType.mapi_cc);

    //        PropBag.OnReadProperty = () => BitConverter.GetBytes((int)RecipientType.mapi_bcc);
    //        IRecipientTest.RecipientTypeTest(target, RecipientType.mapi_bcc);
    //    }

    //    /// <summary>
    //    ///A test for Name
    //    ///</summary>
    //    [TestMethod()]
    //    public void NameTest()
    //    {
    //        var target = new Recipient(Context, 0);

    //        PropBag.OnPropertyExists = (x) => false;
    //        PropBag.OnGetPropertyType = () => PropertyType.KnownValue.prop_type_wstring;
    //        IRecipientTest.NameTest(target, string.Empty);

    //        PropBag.OnPropertyExists = (x) => x == PropId.KnownValue.PidTagRecipientDisplayName;
    //        PropBag.OnReadProperty = () => System.Text.Encoding.Unicode.GetBytes("OMGLOL");

    //        IRecipientTest.NameTest(target, "OMGLOL");
    //    }

    //    /// <summary>
    //    /// A Test for HasEmailAddress
    //    /// </summary>
    //    [TestMethod()]
    //    public void HasEmailAddressTest()
    //    {
    //        var target = new Recipient(Context, 0);

    //        PropBag.OnPropertyExists = x => false;
    //        IRecipientTest.HasEmailAddressTest(target, false);

    //        PropBag.OnPropertyExists = x => x == PropId.KnownValue.PR_EMAIL_ADDRESS;
    //        IRecipientTest.HasEmailAddressTest(target, true);
    //    }

    //    /// <summary>
    //    ///A test for EmailAddress
    //    ///</summary>
    //    [TestMethod()]
    //    public void EmailAddressTest()
    //    {
    //        var target = new Recipient(Context, 0); // TODO: Initialize to an appropriate value

    //        PropBag.OnPropertyExists = (x) => false;
    //        PropBag.OnGetPropertyType = () => PropertyType.KnownValue.prop_type_wstring;
    //        IRecipientTest.EmailAddressTest(target, string.Empty);

    //        PropBag.OnPropertyExists = (x) => x == PropId.KnownValue.PidTagSmtpAddress;
    //        PropBag.OnReadProperty = () => System.Text.Encoding.Unicode.GetBytes("herp@derp.com");
    //        IRecipientTest.EmailAddressTest(target, "herp@derp.com");
    //    }

    //    /// <summary>
    //    ///A test for AddressType
    //    ///</summary>
    //    [TestMethod()]
    //    public void AddressTypeTest()
    //    {
    //        var target = new Recipient(Context, 0);

    //        PropBag.OnPropertyExists = (x) => false;
    //        PropBag.OnGetPropertyType = () => PropertyType.KnownValue.prop_type_wstring;
    //        IRecipientTest.AddressTypeTest(target, string.Empty);

    //        PropBag.OnPropertyExists = (x) => x == PropId.KnownValue.PidTagAddressType;
    //        PropBag.OnReadProperty = () => System.Text.Encoding.Unicode.GetBytes("SMTP");
    //        IRecipientTest.AddressTypeTest(target, "SMTP");
    //    }

    //    /// <summary>
    //    /// A test for HasAccountName
    //    /// </summary>
    //    [TestMethod()]
    //    public void HasAccountNameTest()
    //    {
    //        var target = new Recipient(Context, 0);

    //        PropBag.OnPropertyExists = (x) => false;
    //        IRecipientTest.HasAccountNameTest(target, false);

    //        PropBag.OnPropertyExists = x => x == PropId.KnownValue.PR_ACCOUNT;
    //        IRecipientTest.HasAccountNameTest(target, true);
    //    }

    //    /// <summary>
    //    ///A test for AccountName
    //    ///</summary>
    //    [TestMethod()]
    //    public void AccountNameTest()
    //    {
    //        var target = new Recipient(Context, 0);

    //        PropBag.OnPropertyExists = (x) => false;
    //        PropBag.OnGetPropertyType = () => PropertyType.KnownValue.prop_type_wstring;
    //        IRecipientTest.AccountNameTest(target, string.Empty);

    //        PropBag.OnPropertyExists = x => x == PropId.KnownValue.PR_ACCOUNT;
    //        PropBag.OnReadProperty = () => System.Text.Encoding.Unicode.GetBytes("Christopher Currens");
    //        IRecipientTest.AccountNameTest(target, "Christopher Currens");
    //    }

    //    /// <summary>
    //    ///A test for Equals
    //    ///</summary>
    //    [TestMethod()]
    //    public void EqualsTest()
    //    {
    //        IDBAccessor context = null; // TODO: Initialize to an appropriate value
    //        NodeID nodeID = new NodeID(); // TODO: Initialize to an appropriate value
    //        Recipient target = new Recipient(context, nodeID); // TODO: Initialize to an appropriate value
    //        IRecipient other = null; // TODO: Initialize to an appropriate value
    //        bool expected = false; // TODO: Initialize to an appropriate value
    //        bool actual;
    //        actual = target.Equals(other);
    //        Assert.AreEqual(expected, actual);
    //        Assert.Inconclusive("Verify the correctness of this test method.");
    //    }
    //}
}
