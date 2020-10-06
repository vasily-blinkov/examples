using System;

namespace DotNet.DropCap.Helpers.Output
{
    class NormalOut
    {
        const string _outFormat = "> {0}";

        internal void Show(string @string)
        {
            Console.WriteLine(_outFormat, @string);
        }
    }
}
