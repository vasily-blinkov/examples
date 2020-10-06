using System;
using System.Runtime.Serialization;

namespace DotNet.DropCap.Core.Exceptions
{
    [Serializable]
    public class EmptyStringException : Exception
    {
        public EmptyStringException() : base() { }
        public EmptyStringException(string message) : base(message) { }
        public EmptyStringException(string message, Exception innerException) : base(message, innerException) { }
        protected EmptyStringException(SerializationInfo info, StreamingContext context) { }
    }
}
