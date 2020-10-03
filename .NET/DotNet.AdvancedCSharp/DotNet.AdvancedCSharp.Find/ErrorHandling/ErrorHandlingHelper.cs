using System;
using ArgsMapper;

namespace DotNet.AdvancedCSharp.Find.ErrorHandling
{
    static class ErrorHandlingHelper
    {
        public static void Handle(ArgsMapperErrorResult errorResult)
        {
            Console.WriteLine(errorResult.ErrorMessage);
        }
    }
}
