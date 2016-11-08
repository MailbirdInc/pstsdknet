using System;

namespace pstsdk.definition.disk.header
{
    public class  ansi_header_crc_locations : header_crc_locations<UInt32>
    {
        public const int start = ansi_header.offset_of_wMagicClient;
        public const int end = ansi_header.offset_of_bLockSemaphore;
        public const int length = end - start;
    }
}