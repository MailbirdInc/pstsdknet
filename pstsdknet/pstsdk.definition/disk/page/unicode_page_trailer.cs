using System;

using pstsdk.definition.util.primitives;

namespace pstsdk.definition.disk.page
{
    public class unicode_page_trailer : page_trailer
    {
        public unicode_page_trailer()
        {
            
        }

        public const int size_of = 16;
        /// <summary>
        /// CRC of this page, as calculated by the compute_crc function
        /// </summary>
        public UInt32 crc;

        /// <summary>
        /// The id of this page
        /// </summary>
        public BlockID bid;

        public override byte[] GetBytes()
        {
            byte[] bytes = new byte[size_of];
            bytes[0] = this.page_type;
            bytes[1] = this.page_type_repeat;
            
            var signatureBytes = BitConverter.GetBytes(this.signature);
            bytes[2] = signatureBytes[0];
            bytes[3] = signatureBytes[1];
            
            var crcBytes = BitConverter.GetBytes(this.crc);
            bytes[4] = crcBytes[0];
            bytes[5] = crcBytes[1];
            bytes[6] = crcBytes[2];
            bytes[7] = crcBytes[3];

            var bidBytes = BitConverter.GetBytes(this.bid.Value);
            bytes[8] = bidBytes[0];
            bytes[9] = bidBytes[1];
            bytes[10] = bidBytes[2];
            bytes[11] = bidBytes[3];
            bytes[12] = bidBytes[4];
            bytes[13] = bidBytes[5];
            bytes[14] = bidBytes[6];
            bytes[15] = bidBytes[7];

            return bytes;
        }

        public override void FromBytes(byte[] bytes)
        {
            this.page_type = bytes[0];
            this.page_type_repeat = bytes[1];

            this.signature = BitConverter.ToUInt16(bytes, 2);

            this.crc = BitConverter.ToUInt32(bytes, 4);

            this.bid = BitConverter.ToUInt64(bytes, 8);
        }

        public override int Size()
        {
            return size_of;
        }
    }
}