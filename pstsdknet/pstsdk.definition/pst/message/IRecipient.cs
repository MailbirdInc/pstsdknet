using System;
using pstsdk.definition.ltp;
using pstsdk.definition.ltp.table;
using pstsdk.definition.util.primitives;

namespace pstsdk.definition.pst.message
{
    /// <summary>
    /// A recipient of a message.  A friendly wrapper around a recipient table row.
    /// </summary> 
    public interface IRecipient : IEquatable<IRecipient>, IPropertyObject
    {
        ///<summary>Get the name of the recipients account</summary>
        string AccountName { get; }
        ///<summary>Get the address type of the recipient</summary>
        string AddressType { get; }
        ///<summary>Get the email address of the recipient</summary>
        string EmailAddress { get; }
        ///<summary>Get the display name of this recipient</summary>
        string Name { get; }
        ///<summary>Checks to see if this recipient has an account name</summary>
        bool HasAccountName { get; }
        ///<summary>Checks to see if this recipient has an email address</summary>
        bool HasEmailAddress { get; }
        ///<summary>Get the type of this recipient</summary>
        RecipientType RecipientType { get; }
    }
}