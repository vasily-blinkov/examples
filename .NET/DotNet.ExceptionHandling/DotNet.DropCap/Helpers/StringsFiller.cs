using System;
using System.Collections.Generic;

namespace DotNet.DropCap.Helpers
{
    internal sealed class StringsFiller
    {
        const string _prompt = "< ";
        const string _stopMarker = ".";

        readonly List<string> _strings = new List<string>();

        internal IEnumerable<string> Fill()
        {
            bool added;

            do
            {
                Console.Write(_prompt);
                added = TryAdd(Console.ReadLine());
            } while (added);

            return _strings;
        }

        /// <returns>True if added, False otherwise</returns>
        bool TryAdd(string @string)
        {
            var shouldAdd = !IsStopMarker(@string);

            if (shouldAdd)
                _strings.Add(@string);

            return shouldAdd;
        }

        bool IsStopMarker(string @string)
        {
            return _stopMarker.Equals(@string, StringComparison.InvariantCultureIgnoreCase);
        }

        internal void Reset()
        {
            _strings.Clear();
        }
    }
}
