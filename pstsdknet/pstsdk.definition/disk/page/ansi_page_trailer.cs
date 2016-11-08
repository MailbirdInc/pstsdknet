using System;

using pstsdk.definition.util.primitives;

namespace pstsdk.definition.disk.page
{
    public class ansi_page_trailer : page_trailer
    {
        public ansi_page_trailer()
        {
            
        }

        public const int size_of = 12;

        /// <summary>
        /// The id of this page
        /// </summary>
        public BlockID bid;

        /// <summary>
        /// CRC of this page, as calculated by the compute_crc function
        /// </summary>
        public UInt32 crc;


        public override byte[] GetBytes()
        {
            byte[] bytes = new byte[size_of];
            bytes[0] = this.page_type;
            bytes[1] = this.page_type_repeat;

            var signatureBytes = BitConverter.GetBytes(this.signature);
            bytes[2] = signatureBytes[0];
            bytes[3] = signatureBytes[1];

            var bidBytes = BitConverter.GetBytes((UInt32)this.bid.Value);
            bytes[4] = bidBytes[0];
            bytes[5] = bidBytes[1];
            bytes[6] = bidBytes[2];
            bytes[7] = bidBytes[3];

            var crcBytes = BitConverter.GetBytes(this.crc);
            bytes[8] = crcBytes[0];
            bytes[9] = crcBytes[1];
            bytes[10] = crcBytes[2];
            bytes[11] = crcBytes[3];

            return bytes;
        }

        public override void FromBytes(byte[] bytes)
        {
            this.page_type = bytes[0];
            this.page_type_repeat = bytes[1];

            this.signature = BitConverter.ToUInt16( bytes, 2);
            this.bid = BitConverter.ToUInt32(bytes, 4);
            this.crc = BitConverter.ToUInt32(bytes, 8);
        }
        public override int Size()
        {
            return size_of;
        }

    }
}