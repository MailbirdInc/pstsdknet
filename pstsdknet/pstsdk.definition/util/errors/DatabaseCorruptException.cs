using System;
using System.Runtime.Serialization;

namespace pstsdk.definition.util.errors
{
    [Serializable]
    public class DatabaseCorruptException : Exception
    {
        public DatabaseCorruptException()
        {
        }

        public DatabaseCorruptException(string message)
            : base(message)
        {
        }

        public DatabaseCorruptException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected DatabaseCorruptException(
            SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}