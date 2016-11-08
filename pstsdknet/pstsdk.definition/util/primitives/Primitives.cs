using System;

namespace pstsdk.definition.util.primitives
{
    public static class Primitives
    {
        // 
        // message specific values
        //

        /// <summary>
        /// A sentinel byte which indicates the message subject contains a prefix, [MS-PST] 2.5.3.1.1.1
        /// </summary>
        public const byte message_subject_prefix_lead_byte = 0x01;

        //
        // GUIDs
        //

        /// <summary>
        /// The NULL guid
        /// </summary>
        public static Guid ps_none = Guid.Empty;
        // { 0, 0, 0, { 0, 0, 0, 0, 0, 0, 0, 0 } };

        /// <summary>
        /// The PS_MAPI guid, [MS-OXPROPS] 1.3.2
        /// </summary>
        public static Guid ps_mapi =
            new Guid(
                new byte[] { 
                    0x00, 0x02, 0x03, 0x28, 
                    0x00, 0x00, 
                    0x00, 0x00, 
                    0xc0, 0x00, 
                    0x00, 0x00, 0x00, 0x00, 0x00, 0x46 
                }
            );

        /// <summary>
        /// The PS_PUBLIC_STRINGS guid, [MS-OXPROPS] 1.3.2
        /// </summary>
        public static Guid ps_public_strings =
            new Guid(
                new byte[] { 
                    0x00, 0x02, 0x03, 0x29, 
                    0x00, 0x00, 
                    0x00, 0x00, 
                    0xc0, 0x00, 
                    0x00, 0x00, 0x00, 0x00, 0x00, 0x46 
                }
            );
    }
}
