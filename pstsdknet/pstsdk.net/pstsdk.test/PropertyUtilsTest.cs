using System;
using System.Collections.Generic;
using pstsdk.layer.util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using pstsdk.definition.util.primitives;
using pstsdk.definition.ndb.database;
using pstsdk.definition.ltp;
using pstsdk.test.mocks;

namespace pstsdk.test
{

    ///// <summary>
    /////This is a test class for PropertyUtilsTest and is intended
    /////to contain all PropertyUtilsTest Unit Tests
    /////</summary>
    //[TestClass()]
    //public class PropertyUtilsTest
    //{
    //    /// <summary>
    //    ///Gets or sets the test context which provides
    //    ///information about and functionality for the current test run.
    //    ///</summary>
    //    public TestContext TestContext { get; set; }

    //    /// <summary>
    //    ///A test for RemoveSubjectPaddingCharacter
    //    ///</summary>
    //    [TestMethod]
    //    public void RemoveSubjectPaddingCharacterTest()
    //    {
    //        //The symbols are intentional.  Do not remove.
    //        var rawSubjectValue = "test";
    //        var expected = "test";

    //        //with padding
    //        var actual = PropertyUtils.RemoveSubjectPaddingCharacter(rawSubjectValue);
    //        Assert.AreEqual(expected, actual, "Padding was not removed from string correctly");

    //        //no padding
    //        rawSubjectValue = "test";
    //        actual = PropertyUtils.RemoveSubjectPaddingCharacter(rawSubjectValue);
    //        Assert.AreEqual(expected, actual, "Padding was removed for a string with no padding!");
    //    }

    //    /// <summary>
    //    ///A test for GetStringProperty
    //    ///</summary>
    //    [TestMethod]
    //    public void GetStringPropertyTest()
    //    {
    //        var expected = "expected value";
    //        var propBag = new MockPropBag();

    //        //Ascii String
    //        propBag.OnGetPropertyType = () => PropertyType.KnownValue.prop_type_string;
    //        propBag.OnReadProperty = () => System.Text.Encoding.ASCII.GetBytes(expected);
    //        string actual = PropertyUtils.GetStringProperty(propBag, 0);

    //        Assert.AreEqual(expected, actual, "string was not returned correctly from ascii property");
                       
    //        //Unicode String
    //        propBag.OnGetPropertyType = () => PropertyType.KnownValue.prop_type_wstring;
    //        propBag.OnReadProperty = () => System.Text.Encoding.Unicode.GetBytes(expected);
    //        actual = PropertyUtils.GetStringProperty(propBag, 0);

    //        Assert.AreEqual(expected, actual, "string was not returned correctly from unicode property");
    //    }

    //    [TestMethod]
    //    [ExpectedException(typeof(ArgumentException), "Invalid Property Type")]
    //    public void GetStringPropertyNonStringTypeTest()
    //    {
    //        var propBag = new MockPropBag();

    //        //Not string data or property type
    //        propBag.OnGetPropertyType = () => PropertyType.KnownValue.prop_type_mv_longlong;
    //        propBag.OnReadProperty = () => BitConverter.GetBytes(315684);
            
    //        PropertyUtils.GetStringProperty(propBag, 0);
    //    }
    //}
}
