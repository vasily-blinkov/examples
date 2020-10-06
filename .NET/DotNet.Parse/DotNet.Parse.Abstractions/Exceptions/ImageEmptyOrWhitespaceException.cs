using System;
using System.Runtime.Serialization;

namespace DotNet.Parse.Core.Exceptions
{
    [Serializable]
    public class ImageEmptyOrWhitespaceException : Exception
    {
        public ImageEmptyOrWhitespaceException() : base("A string for parse must have a value.") { }
        public ImageEmptyOrWhitespaceException(string message) : base(message) { }
        public ImageEmptyOrWhitespaceException(string message, Exception innerException) : base(message, innerException) { }
        protected ImageEmptyOrWhitespaceException(SerializationInfo info, StreamingContext context) { }
    }
}
