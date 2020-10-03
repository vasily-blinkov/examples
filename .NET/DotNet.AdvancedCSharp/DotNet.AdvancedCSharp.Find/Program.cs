using DotNet.AdvancedCSharp.Find.AgrsMapping;
using DotNet.AdvancedCSharp.Find.ErrorHandling;
using DotNet.AdvancedCSharp.Find.FileSystemEntriesFinding;

namespace DotNet.AdvancedCSharp.Find
{
    class Program
    {
        static void Main(string[] args)
        {
            Args.Get().Execute(args, FileSystemEntriesFindHelper.Find, ErrorHandlingHelper.Handle);
        }
    }
}
