using System;
using DotNet.Parse.Core.Abstractions;
using DotNet.Parse.Core.Exceptions;

namespace DotNet.Parse.Long
{
    /// <exception cref="ArgumentNullException" />
    /// <exception cref="ImageEmptyOrWhitespaceException" />
    /// <exception cref="NotDigitException" />
    public class Parser : IParser<long>
    {
        const char _minChar = '0';
        const char _maxChar = '9';
        const ushort _minCharCode = _minChar;

        public long Parse(string image)
        {
            int imageLength;

            try
            {
                imageLength = image.Length;
            }
            catch (NullReferenceException ex)
            {
                throw new ArgumentNullException(nameof(image), ex.Message);
            }
            
            if (string.IsNullOrWhiteSpace(image))
                throw new ImageEmptyOrWhitespaceException();

            long result = 0;
            sbyte power = -1;

            for (int rank = imageLength - 1; rank >= 0; rank--)
            {
                var @char = image[rank];

                if (_minChar > @char || @char > _maxChar)
                {
                    throw new NotDigitException(@char);
                }

                result += (long)Math.Pow(10, ++power) * (@char - _minCharCode);
            }

            return result;
        }
    }
}
