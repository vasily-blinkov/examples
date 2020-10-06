using System;

namespace DotNet.DropCap.Helpers.Output
{
    class ErrorOut
    {
        internal void Show(string message)
        {
            Console.Error.WriteLine(message);
        }
    }
}
