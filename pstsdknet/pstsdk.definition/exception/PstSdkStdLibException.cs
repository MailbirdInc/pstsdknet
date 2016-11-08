using System;
using System.Collections.Generic;
using System.Text;

namespace pstsdk.definition.exception
{
    [global::System.Serializable]
    public class PstSdkStdLibException : PstSdkException
    {
        public PstSdkStdLibException  (string what) : base(what) { }

        protected PstSdkStdLibException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
