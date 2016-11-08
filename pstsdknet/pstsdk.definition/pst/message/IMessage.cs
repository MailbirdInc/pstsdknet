using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using pstsdk.definition.ltp;
using pstsdk.definition.ltp.propbag;
using pstsdk.definition.ltp.table;
using pstsdk.definition.util.primitives;

namespace pstsdk.definition.pst.message
{
    /// <summary>
    ///     Represents a message in a PST file
    ///  <para>
    ///     A message is the basic abstraction exposed by MAPI - everything is a
    ///     message; a mail item, a calendar item, a contact, etc.
    ///  </para>
    ///  <para>
    ///     This class exposes some common properties on messages
    ///     as well as iteration mechanisms to get to the attachments and recipients
    ///     on the message. You will most likely find it necessary to get the 
    ///     underylying property bag and look up specific properties not exposed here.
    ///  </para>
    /// </summary>
    public interface IMessage : IEquatable<IMessage>, IPropertyObject
    {
        /// <summary>
        ///     Get the number of attachments on this message
        /// </summary>
        int AttachmentCount { get; }
        /// <summary>
        /// An enumeration of all the <see cref="IAttachment" /> in an <see cref="IMessage"/>
        /// </summary>
        IEnumerable<IAttachment> Attachments { get; }

        /// <summary>
        ///     Get the number of recipients on this message
        /// </summary>
        int RecipientCount { get; }
        /// <summary>
        /// An enumeration of all the <see cref="IRecipient" /> in an <see cref="IMessage"/>
        /// </summary>
        IEnumerable<IRecipient> Recipients { get; }

        EntryID EntryID { get; }
        /// <summary>
        ///     Get the body of this message
        /// </summary>
        string Body { get; }
        /// <summary>
        ///     Get the HTML body of this message
        /// </summary>
        byte[] HtmlBody { get; }

        string HtmlBodyString { get; }

        Encoding Encoding { get; }

        /// <summary>
        ///     Get the subject of this message
        /// </summary>
        string Subject { get; }

        /// <summary>
        ///     Size of the body, in bytes
        /// </summary>
        int BodySize { get; }
        /// <summary>
        ///     Checks to see if this message has a body
        /// </summary>
        bool HasBody { get; }
        /// <summary>
        ///     Checks to see if this message has a HTML body
        /// </summary>
        bool HasHtmlBody { get; }
        /// <summary>
        ///     Check to see if a subject is set on this message
        /// </summary>
        bool HasSubject { get; }

        /// <summary>
        ///     Size of the HTML body, in bytes
        /// </summary>
        int HtmlBodySize { get; }

        /// <summary>
        ///     Gets/opens a stream on the Body property of the IMessage
        /// </summary>
        /// <seealso cref="HtmlBodyStream"/>
        Stream BodyStream { get; }
        /// <summary>
        ///     Gets/opens a stream on the HtmlBody property of the IMessage
        /// </summary>
        /// <seealso cref="BodyStream"/>
        Stream HtmlBodyStream { get; }

        /// <summary>
        ///     Get the total size of this message
        /// </summary>
        int Size { get; }

        /// <summary>
        ///     Get the transport headers of this message
        /// </summary>
        string TransportMessageHeaders { get; }

        string DisplayCc { get; }
        string DisplayBcc { get; }
        string DisplayTo { get; }
        string DisplayName { get; }

        DateTime OriginalDeliveryTime { get; }

        DateTime SentTime { get; }

        string InternetId { get; }

        string InReplyTo { get; }

        string InternetReferences { get; }

        string MessageClass { get; }

        string Uid { get; }

        string FromAddress { get; }

        string FromName { get; }
    }
}
