using System;
using System.Runtime.Serialization;

namespace pstsdk.definition.util.errors
{
    [Serializable]
    public class CRCFailureException : Exception
    {
        public CRCFailureException()
        {
        }

        public CRCFailureException(string message)
            : base(message)
        {
        }

        public CRCFailureException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected CRCFailureException(
            SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}