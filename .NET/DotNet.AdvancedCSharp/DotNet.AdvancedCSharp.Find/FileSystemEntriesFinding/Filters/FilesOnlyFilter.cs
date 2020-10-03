using System.IO;

namespace DotNet.AdvancedCSharp.Find.FileSystemEntriesFinding.Filters
{
    class FilesOnlyFilter : IEntryFilter
    {
        public bool IsMatch(string entry)
        {
            return new FileInfo(entry).Exists;
        }
    }
}
