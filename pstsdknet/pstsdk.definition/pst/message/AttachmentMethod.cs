using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pstsdk.definition.pst.message
{
    public enum AttachmentMethod
    {
        NoAttachment = 0,
        AttachByValue = 1,
        AttachByReference = 2,
        AttachByRefResolve = 3,
        AttachByRefOnly = 4,
        AttachEmbeddedMsg = 5,
        AttchOle = 6
    }
}
