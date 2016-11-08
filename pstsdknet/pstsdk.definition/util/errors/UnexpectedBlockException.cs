using System;
using System.Runtime.Serialization;

namespace pstsdk.definition.util.errors
{
    [Serializable]
    public class UnexpectedBlockException : Exception
    {
        public UnexpectedBlockException()
        {
        }

        public UnexpectedBlockException(string message)
            : base(message)
        {
        }

        public UnexpectedBlockException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected UnexpectedBlockException(
            SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}