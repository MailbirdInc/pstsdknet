using System;

namespace pstsdk.definition.disk.header
{
    public class header<T> where T : struct
    {
        /// <summary>
        /// Always hlmagic
        /// </summary>
        public UInt32 dwMagic;                     
        public UInt32 dwCRCPartial;

        /// <summary>
        /// Client magic number, eg pst_magic
        /// </summary>
        public UInt16 wMagicClient;               

        //public const int offset_of_wMagicClient = sizeof(UInt32) + sizeof(UInt32);

        /// <summary>
        /// Version of the file, DatabaseFormat
        /// </summary>
        public UInt16 wVer;

        /// <summary>
        /// Client version, DatabaseType
        /// </summary>
        public UInt16 wVerClient;   

        /// <summary>
        /// Always 0x1
        /// </summary>
        public byte bPlatformCreate;              

        /// <summary>
        /// Always 0x1
        /// </summary>
        public byte bPlatformAccess;              

        /// <summary>
        /// Implementation specific
        /// </summary>
        public UInt32 dwOpenDBID;                  

        /// <summary>
        /// Implementation specific
        /// </summary>
        public UInt32 dwOpenClaimID;

        public const int offset_of_wMagicClient = 8;
    }
}