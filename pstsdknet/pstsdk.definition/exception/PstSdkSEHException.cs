using System;
using System.Collections.Generic;
using System.Text;

namespace pstsdk.definition.exception
{
    [global::System.Serializable]
    public class PstSdkSEHException : PstSdkException
    {
        public PstSdkSEHException(global::System.Runtime.InteropServices.SEHException inner) : base("Unknown Unmanaged Exception!!!", inner) { }
        public PstSdkSEHException(string message, global::System.Runtime.InteropServices.SEHException inner) : base(message, inner) { }

        protected PstSdkSEHException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
