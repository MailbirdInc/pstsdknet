using System;
using System.Collections.Generic;

using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Text;

using pstsdk.definition.pst.message;
using pstsdk.definition.util.primitives;
//using pstsdk.mcpp.util.primitives;
using pstsdk.layer.util;
using pstsdk.mcpp.util.prop;

namespace PSTExplorer
{
    public interface IMessageWriter
    {
        void Write(IMessage message, Stream stream);
    }

    public class MimeMessageWriter : IMessageWriter
    {
        public void Write(IMessage message, Stream stream)
        {

            var outMessage = new DotNetOpenMail.EmailMessage();
            
            // assuming this is right for unicode support? 
            outMessage.HeaderEncoding = DotNetOpenMail.Encoding.EncodingType.QuotedPrintable;
            outMessage.HeaderCharSet = Encoding.UTF8;
            
            if (message.HasSubject)
            {
                outMessage.Subject = message.Subject;
            }

            if (message.RecipientCount > 0)
            {
                foreach (var recipient in message.Recipients)
                {

                    var mailAddress =
                        new DotNetOpenMail.EmailAddress(
                            recipient.HasEmailAddress ? recipient.EmailAddress : " ", recipient.Name,
                            DotNetOpenMail.Encoding.EncodingType.QuotedPrintable, Encoding.UTF8
                            );

                    switch (recipient.RecipientType)
                    {
                        case RecipientType.mapi_to:
                            outMessage.AddToAddress(mailAddress);
                            //outMessage.To.Add(mailAddress);
                            break;
                        case RecipientType.mapi_cc:
                            outMessage.AddCcAddress(mailAddress);
                            //outMessage.CC.Add(mailAddress);
                            break;
                        case RecipientType.mapi_bcc:
                            outMessage.AddBccAddress(mailAddress);
                            //outMessage.Bcc.Add(mailAddress);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }
            if (message.AttachmentCount > 0)
            {
                foreach (var attachment in message.Attachments)
                {
                    var filename = attachment.Filename;

                    if (attachment.IsMessage)
                    {
                        var embeddedMessage = attachment.OpenAsMessage();
                        var messageWriter = new MimeMessageWriter();
                        var msgStream = new MemoryStream();
                        messageWriter.Write(embeddedMessage, msgStream);

                        //msgStream = new MemoryStream(msgStream.ToArray());
                        //.Flush();
                        //msgStream.Seek(0, SeekOrigin.Begin);

                        var messageAttachment = 
                            new DotNetOpenMail.FileAttachment(msgStream.ToArray());
                        messageAttachment.ContentType = "message/rfc822";
                        messageAttachment.FileName = filename + ".eml";
                            //new Attachment(msgStream, filename + ".eml", "message/rfc822");

                        outMessage.AddMixedAttachment(messageAttachment);
                        //outMessage.Attachments.Add(messageAttachment);
                    }
                    else
                    {
                        var fileAttachment =
                            new DotNetOpenMail.FileAttachment(attachment.Bytes);
                        fileAttachment.FileName = filename;
                        fileAttachment.ContentType = "application/octet-stream";

                        //    new Attachment(new MemoryStream(attachment.Bytes), filename);
                        //outMessage.Attachments.Add(fileAttachment);
                        outMessage.AddMixedAttachment(fileAttachment);
                    }
                }
            }
            if (message.HasBody && message.HasHtmlBody)
            {
                //first we create the Plain Text part
                //var plainTextBody = AlternateView.CreateAlternateViewFromString(message.Body, null, "text/plain");
                //then we create the Html part
                //var htmlBody = AlternateView.CreateAlternateViewFromString(message.HtmlBody, null, "text/html");

                //outMessage.AlternateViews.Add(plainTextBody);
                //outMessage.AlternateViews.Add(htmlBody);
                outMessage.TextPart = new DotNetOpenMail.TextAttachment(message.Body);
                outMessage.TextPart.CharSet = Encoding.UTF8;
                outMessage.TextPart.Encoding = DotNetOpenMail.Encoding.EncodingType.QuotedPrintable;

                outMessage.HtmlPart = new DotNetOpenMail.HtmlAttachment(Encoding.UTF8.GetString(message.HtmlBody));
                outMessage.HtmlPart.CharSet = Encoding.UTF8;
                outMessage.HtmlPart.Encoding = DotNetOpenMail.Encoding.EncodingType.QuotedPrintable;

            }
            else if (message.HasBody)
            {
                //outMessage.Body = message.Body;
                //outMessage.BodyText = message.Body;
                outMessage.TextPart = new DotNetOpenMail.TextAttachment(message.Body);
                outMessage.TextPart.CharSet = Encoding.UTF8;
                outMessage.TextPart.Encoding = DotNetOpenMail.Encoding.EncodingType.QuotedPrintable;

            }
            else if (message.HasHtmlBody)
            {
#warning Encoding is not detected
                //outMessage.TextPart = new DotNetOpenMail.TextAttachment("");
                outMessage.HtmlPart = new DotNetOpenMail.HtmlAttachment(Encoding.UTF8.GetString(message.HtmlBody));
                outMessage.HtmlPart.CharSet = Encoding.UTF8;
                outMessage.HtmlPart.Encoding = DotNetOpenMail.Encoding.EncodingType.QuotedPrintable;

                
                //outMessage.Body = message.HtmlBody;
                //outMessage.IsBodyHtml = true;
            }
            // attempt to get sender details

            PropId senderDisplayNameProp = 0x0C1A; // sender display name
            PropId senderEmailAddressProp = 0x0C1F; // sender email address 
            PropId senderDisplayNameProp_Alt = 0x0042; // sender "representing" display name
            PropId senderEmailAddressProp_Alt = 0x0065; // sender "representing" email address 

            string senderDisplayname = string.Empty;

            if (message.PropertyExists(senderDisplayNameProp))
            {
                senderDisplayname =
                    message.GetPropertyType(senderDisplayNameProp).Value == (ushort)PropertyType.KnownValue.prop_type_string
                    ? PropertyHelper.GetEncodedStringProperty(message.ReadProperty(senderDisplayNameProp), Encoding.Default)
                    : PropertyHelper.GetUnicodeStringProperty(message.ReadProperty(senderDisplayNameProp));
            }
            else if (message.PropertyExists(senderDisplayNameProp_Alt))
            {
                senderDisplayname =
                    message.GetPropertyType(senderDisplayNameProp_Alt).Value == (ushort)PropertyType.KnownValue.prop_type_string
                    ? PropertyHelper.GetEncodedStringProperty(message.ReadProperty(senderDisplayNameProp_Alt), Encoding.Default)
                    : PropertyHelper.GetUnicodeStringProperty(message.ReadProperty(senderDisplayNameProp_Alt));
            }

            string senderEmailAddress = string.Empty;
            if (message.PropertyExists(senderEmailAddressProp))
            {
                senderEmailAddress =
                    message.GetPropertyType(senderEmailAddressProp).Value == (ushort)PropertyType.KnownValue.prop_type_string
                    ? PropertyHelper.GetEncodedStringProperty(message.ReadProperty(senderEmailAddressProp), Encoding.Default)
                    : PropertyHelper.GetUnicodeStringProperty(message.ReadProperty(senderEmailAddressProp));
            }
            else if (message.PropertyExists(senderEmailAddressProp_Alt))
            {
                senderEmailAddress =
                    message.GetPropertyType(senderEmailAddressProp_Alt).Value == (ushort)PropertyType.KnownValue.prop_type_string
                    ? PropertyHelper.GetEncodedStringProperty(message.ReadProperty(senderEmailAddressProp_Alt), Encoding.Default)
                    : PropertyHelper.GetUnicodeStringProperty(message.ReadProperty(senderEmailAddressProp_Alt));
            }

            var senderAddress =
                new DotNetOpenMail.EmailAddress(string.IsNullOrEmpty(senderEmailAddress) ? " " : senderEmailAddress, senderDisplayname, DotNetOpenMail.Encoding.EncodingType.QuotedPrintable, Encoding.UTF8);
                //new MailAddress(string.IsNullOrEmpty(senderEmailAddress) ? "missing@address.com" : senderEmailAddress, senderDisplayname);
            //if (senderAddress.Address == "missing@address.com")
            //    SetEmptyAddress(senderAddress);
            outMessage.FromAddress = senderAddress;
            
            //outMessage.Sender = senderAddress;
            //outMessage.From = senderAddress;

            // TODO: pull this prop from IMessage instance... -th
            //outMessage.ReplyTo = senderAddress;

            // for now, this is pointless, since the implementation of MailMessage.Send 
            // overwrites this with current time... <sigh> -th
            PropId sentTimeProp = 0x0039; // "client submit" time

            if (message.PropertyExists(sentTimeProp))
            {
                var sentTime = (DateTime)PropertyHelper.GetTimeProperty(message.ReadProperty(sentTimeProp));

                outMessage.AddCustomHeader("Date", sentTime.ToString("ddd, dd MMM yyyy HH:mm:ss zzz", System.Globalization.CultureInfo.InvariantCulture).Remove(29, 1));
                    //MimeDateTime(sentTime));
                //outMessage.Headers.Add("Date", MimeDateTime(sentTime));
            }
            using (var sw = new StreamWriter(stream))
                sw.Write(outMessage.ToDataString());
            
            //outMessage.Save(stream);
        }


        // from http://www.west-wind.com/Weblog/posts/4321.aspx
        ///
        /// Converts the passed date time value to Mime formatted time string
        ///
        ///
        public static string MimeDateTime(DateTime Time)
        {
            TimeSpan Offset = TimeZone.CurrentTimeZone.GetUtcOffset(Time);

            string sOffset = null;
            if (Offset.Hours < 0)
                sOffset = "-" + (Offset.Hours * -1).ToString().PadLeft(2, '0');
            else
                sOffset = "+" + Offset.Hours.ToString().PadLeft(2, '0');

            sOffset += Offset.Minutes.ToString().PadLeft(2, '0');

            return Time.ToString("ddd, dd MMM yyyy hh:mm:ss",
                                                          System.Globalization.CultureInfo.InvariantCulture) +
                                                          " " + sOffset;
        }

        private static void SetEmptyAddress(MailAddress address)
        {
            var addressField = address.GetType().GetField("address", BindingFlags.NonPublic | BindingFlags.Instance);
            addressField.SetValue(address, " ");
            var hostField = address.GetType().GetField("host", BindingFlags.NonPublic | BindingFlags.Instance);
            hostField.SetValue(address, " ");
            var userNameField = address.GetType().GetField("userName", BindingFlags.NonPublic | BindingFlags.Instance);
            userNameField.SetValue(address, " ");
        }
    }

    public class StructuredStorageMessageWriter : IMessageWriter
    {
        private const string nameOfNameIDStorage = "__nameid_version1.0";
        private const string nameOfSubStorageStream_Format = "__substg1.0_{0}{1}";
        private const string nameOfRecipStorage_Format = "__recip_version1.0_#{0}";
        private const string nameOfAttachStorage_Format = "__attach_version1.0_#{0}";
        
        private const string nameOfPropertiesStream = "__properties_version1.0";
        private const string nameOfEmbeddedMessageStream = "__substg1.0_3701000D";
        #region IMessageWriter Members

        public void Write(IMessage message, Stream stream)
        {
            var outMessage = new dotnetpcf.CompoundFile.CompoundFile();
            outMessage.OpenFile(stream);
            
            //outMessage.WorkingDirectory.CreateFile("
            
        }

        private string MakeSubStorageStreamName(int propID, int propType)
        {
            return string.Format(nameOfSubStorageStream_Format, string.Format("X", propID).PadLeft(4, '0'), string.Format("X", propType).PadLeft(4, '0'));
        }

        private string MakeRecipStorageName(int recipientIncrement)
        {
            return string.Format(nameOfRecipStorage_Format, recipientIncrement.ToString().PadLeft(8, '0'));
        }
        private string MakeAttachStorageName(int attachmentIncrement)
        {
            return string.Format(nameOfAttachStorage_Format, attachmentIncrement.ToString().PadLeft(8, '0'));
        }


        #endregion
    }

    //public class MimeMessageWriter_old : IMessageWriter
    //{
    //    public void Write(IMessage message, Stream stream)
    //    {
    //        MailMessage outMessage = new MailMessage();
            
    //        if (message.HasSubject)
    //        {
    //            outMessage.Subject = message.Subject;
    //            outMessage.SubjectEncoding = Encoding.UTF8;
    //        }

    //        if (message.RecipientCount > 0)
    //        {
    //            foreach (var recipient in message.Recipients)
    //            {
                    
    //                var mailAddress = new MailAddress(
    //                    recipient.HasEmailAddress ? recipient.EmailAddress : "missing@address.com", recipient.Name);
                    
    //                if (mailAddress.Address == "missing@address.com")
    //                    SetEmptyAddress(mailAddress);

    //                switch (recipient.RecipientType)
    //                {
    //                    case RecipientType.mapi_to:
    //                        outMessage.To.Add(mailAddress);
    //                        break;
    //                    case RecipientType.mapi_cc:
    //                        outMessage.CC.Add(mailAddress);
    //                        break;
    //                    case RecipientType.mapi_bcc:
    //                        outMessage.Bcc.Add(mailAddress);
    //                        break;
    //                    default:
    //                        throw new ArgumentOutOfRangeException();
    //                }
    //            }
    //        }
    //        if (message.AttachmentCount > 0)
    //        {
    //            foreach (var attachment in message.Attachments)
    //            {
    //                var filename = attachment.Filename;

    //                if (attachment.IsMessage)
    //                {
    //                    var embeddedMessage = attachment.OpenAsMessage();
    //                    var messageWriter = new MimeMessageWriter();
    //                    var msgStream = new MemoryStream();
    //                    messageWriter.Write(embeddedMessage, msgStream);
                        
    //                    msgStream = new MemoryStream(msgStream.ToArray());
    //                        //.Flush();
    //                    //msgStream.Seek(0, SeekOrigin.Begin);

    //                    var messageAttachment = new Attachment(msgStream, filename + ".eml", "message/rfc822");
    //                    outMessage.Attachments.Add(messageAttachment);
    //                }
    //                else
    //                {
    //                    var fileAttachment = new Attachment(new MemoryStream(attachment.Bytes), filename);
    //                    outMessage.Attachments.Add(fileAttachment);
    //                }
    //            }
    //        }
    //        if (message.HasBody && message.HasHtmlBody)
    //        {
    //            //first we create the Plain Text part
    //            var plainTextBody = AlternateView.CreateAlternateViewFromString(message.Body, null, "text/plain");
    //            //then we create the Html part
    //            var htmlBody = AlternateView.CreateAlternateViewFromString(message.HtmlBody, null, "text/html");
    //            outMessage.AlternateViews.Add(plainTextBody);
    //            outMessage.AlternateViews.Add(htmlBody);
    //        }
    //        else if (message.HasBody)
    //        {
    //            outMessage.Body = message.Body;

    //        }
    //        else if (message.HasHtmlBody)
    //        {
    //            outMessage.Body = message.HtmlBody;
    //            outMessage.IsBodyHtml = true;
    //        }
    //        // attempt to get sender details

    //        var senderDisplayNameProp = new PropId(0x0C1A); // sender display name
    //        var senderEmailAddressProp = new PropId(0x0C1F); // sender email address 
    //        var senderDisplayNameProp_Alt = new PropId(0x0042); // sender "representing" display name
    //        var senderEmailAddressProp_Alt = new PropId(0x0065); // sender "representing" email address 

    //        string senderDisplayname = string.Empty;
            
    //        if (message.PropertyExists(senderDisplayNameProp))
    //        {
    //            senderDisplayname = 
    //                message.GetPropertyType(senderDisplayNameProp).PropType == (ushort)PropType.prop_type_string 
    //                ? PropertyHelper.GetEncodedStringProperty(message.ReadProperty(senderDisplayNameProp), Encoding.Default) 
    //                : PropertyHelper.GetUnicodeStringProperty(message.ReadProperty(senderDisplayNameProp));
    //        }
    //        else if (message.PropertyExists(senderDisplayNameProp_Alt))
    //        {
    //            senderDisplayname = 
    //                message.GetPropertyType(senderDisplayNameProp_Alt).PropType == (ushort)PropType.prop_type_string 
    //                ? PropertyHelper.GetEncodedStringProperty(message.ReadProperty(senderDisplayNameProp_Alt), Encoding.Default) 
    //                : PropertyHelper.GetUnicodeStringProperty(message.ReadProperty(senderDisplayNameProp_Alt));
    //        }
            
    //        string senderEmailAddress = string.Empty;
    //        if (message.PropertyExists(senderEmailAddressProp))
    //        {
    //            senderEmailAddress = 
    //                message.GetPropertyType(senderEmailAddressProp).PropType == (ushort)PropType.prop_type_string 
    //                ? PropertyHelper.GetEncodedStringProperty(message.ReadProperty(senderEmailAddressProp), Encoding.Default) 
    //                : PropertyHelper.GetUnicodeStringProperty(message.ReadProperty(senderEmailAddressProp));
    //        }
    //        else if (message.PropertyExists(senderEmailAddressProp_Alt))
    //        {
    //            senderEmailAddress = 
    //                message.GetPropertyType(senderEmailAddressProp_Alt).PropType == (ushort)PropType.prop_type_string 
    //                ? PropertyHelper.GetEncodedStringProperty(message.ReadProperty(senderEmailAddressProp_Alt), Encoding.Default) 
    //                : PropertyHelper.GetUnicodeStringProperty(message.ReadProperty(senderEmailAddressProp_Alt));
    //        }
            
    //        var senderAddress = 
    //            new MailAddress(string.IsNullOrEmpty(senderEmailAddress) ? "missing@address.com" : senderEmailAddress, senderDisplayname);
    //        if (senderAddress.Address == "missing@address.com")
    //            SetEmptyAddress(senderAddress);

    //        outMessage.Sender = senderAddress;
    //        outMessage.From = senderAddress;
            
    //        // TODO: pull this prop from IMessage instance... -th
    //        outMessage.ReplyTo = senderAddress;

    //        // for now, this is pointless, since the implementation of MailMessage.Send 
    //        // overwrites this with current time... <sigh> -th
    //        var sentTimeProp = new PropId(0x0039); // "client submit" time
            
    //        if(message.PropertyExists(sentTimeProp))
    //        {
    //            var sentTime = (DateTime)PropertyHelper.GetTimeProperty(message.ReadProperty(sentTimeProp));
                
    //            outMessage.Headers.Add("Date", MimeDateTime(sentTime));
    //        }
    //        outMessage.Save(stream);
    //    }
    

    //    // from http://www.west-wind.com/Weblog/posts/4321.aspx
    //    ///
    //    /// Converts the passed date time value to Mime formatted time string
    //    ///
    //    ///
    //    public static string MimeDateTime(DateTime Time)
    //    {
    //        TimeSpan Offset = TimeZone.CurrentTimeZone.GetUtcOffset(Time);
         
    //        string sOffset = null;
    //        if (Offset.Hours < 0)
    //            sOffset = "-" + (Offset.Hours * -1).ToString().PadLeft(2, '0');
    //        else
    //            sOffset = "+" + Offset.Hours.ToString().PadLeft(2, '0');
         
    //        sOffset += Offset.Minutes.ToString().PadLeft(2, '0');
         
    //        return DateTime.Now.ToString("ddd, dd MMM yyyy hh:mm:ss",
    //                                                      System.Globalization.CultureInfo.InvariantCulture) +
    //                                                      " " + sOffset;
    //    }

    //    private static void SetEmptyAddress(MailAddress address)
    //    {
    //        var addressField = address.GetType().GetField("address", BindingFlags.NonPublic | BindingFlags.Instance);
    //        addressField.SetValue(address, " ");
    //        var hostField = address.GetType().GetField("host", BindingFlags.NonPublic | BindingFlags.Instance);
    //        hostField.SetValue(address, " ");
    //        var userNameField = address.GetType().GetField("userName", BindingFlags.NonPublic | BindingFlags.Instance);
    //        userNameField.SetValue(address, " ");
    //    }
    //}

    //// From http://www.codeproject.com/KB/IP/smtpclientext.aspx
    //public static class MailMessageExt
    //{
    //    public static void Save(this MailMessage Message, string FileName)
    //    {
    //        using (FileStream _fileStream = new FileStream(FileName, FileMode.Create))
    //        {
    //            Save(Message, _fileStream);
    //        }
    //    }

    //    public static void Save(this MailMessage Message, Stream outStream)
    //    {
    //        Assembly assembly = typeof(SmtpClient).Assembly;
    //        Type _mailWriterType = assembly.GetType("System.Net.Mail.MailWriter");

    //        // Get reflection info for MailWriter contructor
    //        ConstructorInfo _mailWriterContructor =
    //            _mailWriterType.GetConstructor(
    //                BindingFlags.Instance | BindingFlags.NonPublic,
    //                null,
    //                new Type[] { typeof(Stream) },
    //                null);

    //        // Construct MailWriter object with our FileStream
    //        object _mailWriter = _mailWriterContructor.Invoke(new object[] { outStream });

    //        // Get reflection info for Send() method on MailMessage
    //        MethodInfo _sendMethod =
    //            typeof(MailMessage).GetMethod(
    //                "Send",
    //                BindingFlags.Instance | BindingFlags.NonPublic);

    //        // Call method passing in MailWriter
    //        _sendMethod.Invoke(
    //            Message,
    //            BindingFlags.Instance | BindingFlags.NonPublic,
    //            null,
    //            new object[] { _mailWriter, true },
    //            null);

    //        // Finally get reflection info for Close() method on our MailWriter
    //        MethodInfo _closeMethod =
    //            _mailWriter.GetType().GetMethod(
    //                "Close",
    //                BindingFlags.Instance | BindingFlags.NonPublic);

    //        // Call close method
    //        _closeMethod.Invoke(
    //            _mailWriter,
    //            BindingFlags.Instance | BindingFlags.NonPublic,
    //            null,
    //            new object[] { },
    //            null);
    //    }
    //}
}
