using System;
using System.Collections.Generic;
using System.Text;

namespace pstsdk.definition.exception
{
    [global::System.Serializable]
    public class NoViableAlternativeException : PstSdkException
    {
        public NoViableAlternativeException() { }
        public NoViableAlternativeException(string message) : base(message) { }
        public NoViableAlternativeException(string message, Exception inner) : base(message, inner) { }
        protected NoViableAlternativeException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
