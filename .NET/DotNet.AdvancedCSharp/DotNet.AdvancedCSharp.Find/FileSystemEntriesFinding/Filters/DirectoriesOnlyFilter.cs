using System.IO;

namespace DotNet.AdvancedCSharp.Find.FileSystemEntriesFinding.Filters
{
    class DirectoriesOnlyFilter : IEntryFilter
    {
        public bool IsMatch(string entry)
        {
            return new DirectoryInfo(entry).Exists;
        }
    }
}
