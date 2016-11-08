using System;
using System.Collections.Generic;
using System.Text;

namespace pstsdk.definition.exception
{
    [global::System.Serializable]
    public class PstSdkException : Exception
    {
        public PstSdkException() { }
        public PstSdkException(string message) : base(message) { }
        public PstSdkException(string message, Exception inner) : base(message, inner) { }
        protected PstSdkException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
