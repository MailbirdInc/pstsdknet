using System;
using System.IO;

using pstsdk.definition.ltp;
using pstsdk.definition.ltp.propbag;
using pstsdk.definition.util.primitives;

namespace pstsdk.definition.pst.message
{
    ///<summary>
    ///   <para>Encapsulates an attachment to a message</para>
    ///   <para>
    ///      Attachment objects allow you to query for some basic information about
    ///      an attachment, get access to the bytes of the attachment (as a blob or
    ///      stream), as well as open the attachment as a message if applicable.
    ///   </para>
    ///</summary>
    public interface IAttachment : IEquatable<IAttachment>, IPropertyObject
    {
        ///<summary>
        ///     Read the size of the content in this attachment.  The size here is just 
        ///     for the binary data of the attachment.
        ///</summary>
        ///<returns>The size of the data stream of the attachment, in bytes</returns>
        int ContentSize { get; }

        ///<summary>
        ///   <para>The attachment data</para>
        ///</summary>
        ///<returns>An array of Bytes</returns>
        /// <seealso cref="ByteStream"/>
        byte[] Bytes { get; }
        ///<summary>
        ///   Get the filename of this attachment
        ///</summary>
        ///<returns>
        ///   The filename of the attachment
        ///</returns>
        string Filename { get; }

        ///<summary>
        ///   Returns if this attachment is actually an embedded message
        ///</summary>
        ///<returns>True, if this attachment is an attached message; otherwise, False.</returns>
        ///<seealso cref="OpenAsMessage"/>
        bool IsMessage { get; }

        ///<summary>
        ///   <para>Interpret this attachment as a message</para>
        ///   <note type="caution">
        ///      You should check that <see cref="IsMessage"/> is true before using this method.
        ///   </note>
        ///</summary>
        ///<returns>A message object</returns>
        ///<seealso cref="IsMessage"/>
        IMessage OpenAsMessage();

        ///<summary>
        ///   Gets the attachment bytes stream
        ///</summary>
        ///<seealso cref="Bytes"/>
        Stream ByteStream { get; }

        ///<summary>
        ///   <para>The size of the internal attachment object</para>
        ///   <para>
        ///      The size returned here includes metadata, and as such will be
        ///      larger than just the byte stream.  This is the internal pstsdk::attachment
        ///      object that is wrapped.
        ///   </para>
        ///</summary>
        ///<seealso cref="ContentSize"/>
        ///<returns>The size of the internal attachment object, in bytes</returns>
        int Size { get; }

        string MimeTag { get; }

        string ContentId { get; }

        string MimeLocation { get; }

        int MimeSequence { get; }

        int RenderingPosition { get; }

        AttachmentMethod AttachmentMethod { get; }

        AttachmentFlag AttachmentFlag { get; }
    }
}