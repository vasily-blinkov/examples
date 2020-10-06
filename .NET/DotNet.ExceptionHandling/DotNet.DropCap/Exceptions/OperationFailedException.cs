using System;
using System.Runtime.Serialization;

namespace DotNet.DropCap.Exceptions
{
    [Serializable]
    class OperationFailedException : Exception
    {
        public OperationFailedException() : base() { }
        public OperationFailedException(string message) : base(message) { }
        public OperationFailedException(string message, Exception innerException) : base(message, innerException) { }
        protected OperationFailedException(SerializationInfo info, StreamingContext context) { }
    }
}
