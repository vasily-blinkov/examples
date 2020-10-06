using System.Collections.Generic;

namespace DotNet.DropCap.Core.Abstractions
{
    public interface ICapDropper
    {
        /// <exception cref="Exceptions.EmptyStringException" />
        string DropCaps(IEnumerable<string> strings);
    }
}
