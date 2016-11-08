using System;
using System.Runtime.Serialization;

namespace pstsdk.definition.util.errors
{
    [Serializable]
    public class SignatureMismatchException : Exception
    {
        public SignatureMismatchException()
        {
        }

        public SignatureMismatchException(string message)
            : base(message)
        {
        }

        public SignatureMismatchException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected SignatureMismatchException(
            SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}