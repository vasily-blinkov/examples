using System;
using System.Collections.Generic;
using System.Linq;
using DotNet.DropCap.Core.Abstractions;
using DotNet.DropCap.Core.Exceptions;
using DotNet.DropCap.Core.Resources;

namespace DotNet.DropCap.Core.Implementations
{
    public class CapDropper : ICapDropper
    {
        const string _separator = " ";

        public string DropCaps(IEnumerable<string> strings)
        {
            return string.Join(_separator, from s in strings select GetFirstChar(s));
        }

        char GetFirstChar(string @string)
        {
            try
            {
                return @string[0];
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new EmptyStringException(Error.EmptyString, ex);
            }
        }
    }
}
