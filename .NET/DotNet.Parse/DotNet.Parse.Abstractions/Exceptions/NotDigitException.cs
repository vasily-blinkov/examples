using System;
using System.Runtime.Serialization;

namespace DotNet.Parse.Core.Exceptions
{
    [Serializable]
    public class NotDigitException : Exception
    {
        public NotDigitException() : base($"The character (should sit in the {nameof(WrongCharacter)} property) does not represent a digit") { }
        public NotDigitException(string message) : base(message) { }
        public NotDigitException(string message, Exception innerException) : base(message, innerException) { }
        protected NotDigitException(SerializationInfo info, StreamingContext context) { }

        public NotDigitException(char wrongCharacter) : base($"The '{wrongCharacter}' does not represent a digit")
        {
            WrongCharacter = wrongCharacter;
        }

        public char WrongCharacter { get; set; }
    }
}
