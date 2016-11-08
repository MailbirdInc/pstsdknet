using System;
using System.Text;

using pstsdk.definition.ltp;

namespace pstsdk.definition.util.primitives
{
    public struct PropId : IComparable<PropId>, IComparable<UInt16>, IComparable<PropId.KnownValue>
    {
        public UInt16 Value { get; set; }

        public static implicit operator PropId(UInt16 value)
        {
            return new PropId { Value = value };
        }

        public override string ToString()
        {
            return "0x" + Value.ToString("X4");
        }

        public static implicit operator UInt16(PropId value)
        {
            return value.Value;
        }

        public static implicit operator PropId(KnownValue value)
        {
            return (UInt16)value;
        }

        public static implicit operator KnownValue(PropId value)
        {
            return (KnownValue)value.Value;
        }

        public int CompareTo(PropId other)
        {
            return Value.CompareTo(other.Value);
        }

        public int CompareTo(ushort other)
        {
            return Value.CompareTo(other);
        }
        
        public int CompareTo(KnownValue other)
        {
            return Value.CompareTo(other);
        }

        public enum KnownValue : ushort
        {
            //PST SPECIFIC
            PidTagIpmSubTreeEntryId = 0x35E0,
            PidTagIpmWastebasketEntryId = 0x35E3,
            PidTagIpmSentMailEntryId = 0x35E4,
            PidTagIpmOutboxEntryId = 0x35E2,
            PidTagNameidBucketCount = 0x0001,
            PidTagNameidStreamGuid = 0x0002,
            PidTagNameidStreamEntry = 0x0003,
            PidTagNameidStreamString = 0x0004,
            PidTagNameidBucketBase = 0x1000,
            PidTagItemTemporaryFlags = 0x1097,
            PidTagPstBodyPrefix = 0x6619,
            PidTagPstBestBodyProptag = 0x661D,
            PidTagPstLrNoRestrictions = 0x6633,
            PidTagPstHiddenCount = 0x6635,
            PidTagPstHiddenUnread = 0x6636,
            PidTagLatestPstEnsure = 0x66FA,
            PidTagPstIpmsubTreeDescendant = 0x6705,
            PidTagPstSubTreeContainer = 0x6772,
            PidTagLtpParentNid = 0x67f1,
            PidTagLtpRowId = 0x67f2,
            PidTagLtpRowVer = 0x67f3,
            PidTagPstPassword = 0x67ff,
            PidTagMapiFormComposeCommand = 0x682f,
            PidTagContainerClass = 0x3613,
            PidTagMessageClass = 0x001a,
            //END PST SPECIFIC

            PR_ACCOUNT = 0x3A00,
            PR_DISPLAY_NAME = 0x3001,
            PR_EMAIL_ADDRESS = 0x3003,
            PR_MESSAGE_SIZE = 0xE08,
            PR_RECIPIENT_TYPE = 0xC15,
            PR_SUBJECT = 0x0037,
            PR_ORIGINAL_ENTRYID = 0x3a12,
            PR_ENTRYID = 0x0FFF,
            PR_RECORD_KEY = 0x0FF9,
            PR_TARGET_ENTRYID = 0x3010,
            PR_IPM_DRAFTS_ENTRYID = 0x36d7,
            PR_ADDITIONAL_REN_ENTRYIDS = 0x36d8,
            PR_ADDITIONAL_REN_ENTRYIDS_EX = 0x36d9,
            PR_IN_REPLY_TO_ID = 0x1042,
            PR_EMS_AB_USN_CHANGED = 0x8029,
            PR_EMS_AB_CONTENT_TYPE = 0x8186,
            PR_EMS_AB_PF_CONTACTS_O = 0x8038,
            PR_INTERNET_REFERENCES = 0x1039,
            PR_SENT_REPRESENTING_EMAIL_ADDRESS = 0x0065,
            PR_SENT_REPRESENTING_NAME = 0x0042,
            PR_SENDER_EMAIL_ADDRESS = 0x0C1F,
            PR_SENDER_EMAIL_NAME = 0x0C1A,
            PidTagInternetMessageId = 0x1035,
            PidTagAddressType = 0x3002,
            PidTagAssociatedContentCount = 0x3617,
            PidTagAttachSize = 0x0E20,
            PidTagAttachMethod = 0x3705,
            PidTagAttachLongFilename = 0x3707,
            PidTagAttachFilename = 0x3704,
            PidTagAttachDataObject = 0x3701,
            PidTagBody = 0x1000,
            PidTagBodyHtml = 0x1013,
            PidTagContentCount = 0x3602,
            PidTagContentUnreadCount = 0x3603,
            PidTagRecipientDisplayName = 0x5FF6,
            PidTagSmtpAddress = 0x39FE,
            PidTagTransportMessageHeaders = 0x007D,
            PidTagDisplayBcc = 0x0E02,
            PidTagDisplayCc = 0x0E03,
            PidTagDisplayTo = 0x0E04,
            PidTagDisplayName = 0x3001,
            PidTagOriginalDeliveryTime = 0x0e06,
            PidTagClientSubmitTime = 0x0039,
            PidTagInternetCodepage = 0x3fde,
            PidTagMessageCodepage = 0x3ffd,
            PidTagAttachMimeTag = 0x370e,
            PidTagAttachContentId = 0x3712,
            PidTagAttachContentLocation = 0x3713,
            PidTagRenderingPosition = 0x370b,
            PidTagAttachMimeSequence = 0x3710,
            PidTagAttachFlags = 0x3714
        }
    }
}