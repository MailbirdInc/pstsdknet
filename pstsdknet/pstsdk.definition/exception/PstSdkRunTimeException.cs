using System;
using System.Collections.Generic;
using System.Text;

namespace pstsdk.definition.exception
{
    [global::System.Serializable]
    public class PstSdkRunTimeException : PstSdkException
    {
        public PstSdkRunTimeException(int errorCode) : base("Unknown Runtime Exception!!!", global::System.Runtime.InteropServices.Marshal.GetExceptionForHR(errorCode)) { }
        public PstSdkRunTimeException(string message, int errorCode) : base(message,  global::System.Runtime.InteropServices.Marshal.GetExceptionForHR(errorCode)) { }
        public PstSdkRunTimeException(string message, Exception inner) : base(message, inner) { }

        protected PstSdkRunTimeException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
