using System;

namespace pstsdk.definition.disk.header
{
    public class unicode_header_crc_locations : header_crc_locations<UInt64>
    {
        public const int partial_start = ansi_header_crc_locations.start;
        public const int partial_end = ansi_header_crc_locations.end;
        public const int partial_length = ansi_header_crc_locations.length;
        public const int full_start = unicodeheader.offset_of_wMagicClient;
        public const int full_end = unicodeheader.offset_of_dwCRCFull;
        public const int full_length = full_end - full_start;
    }
}