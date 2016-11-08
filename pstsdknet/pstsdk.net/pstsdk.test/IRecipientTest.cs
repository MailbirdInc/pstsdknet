using pstsdk.definition.pst.message;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using pstsdk.definition.util.primitives;

namespace pstsdk.test
{
    public class IRecipientTest
    {
        public static void RecipientTypeTest(IRecipient target, RecipientType expected)
        {
            Assert.AreEqual(target.RecipientType, expected);
        }

        public static void NameTest(IRecipient target, string expected)
        {
            Assert.IsTrue(target.Name.CompareTo(expected) == 0);
        }

        public static void HasEmailAddressTest(IRecipient target, bool expected)
        {
            Assert.AreEqual(expected, target.HasEmailAddress);
        }

        public static void HasAccountNameTest(IRecipient target, bool expected)
        {
            Assert.AreEqual(expected, target.HasAccountName);
        }

        public static void EmailAddressTest(IRecipient target, string expected)
        {
            Assert.IsTrue(target.EmailAddress.CompareTo(expected) ==  0);
        }

        public static void AddressTypeTest(IRecipient target, string expected)
        {
            Assert.IsTrue(target.AddressType.CompareTo(expected) == 0);
        }

        public static void AccountNameTest(IRecipient target, string expected)
        {
            Assert.IsTrue(target.AccountName.CompareTo(expected) == 0);
        }
    }
}
