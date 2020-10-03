using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace DotNet.AdvancedCSharp.FileSystemVisitors
{
    public class FileSystemVisitor
    {
        readonly string path;
        readonly FileSystemEntriesFilterDelegate fileSystemEntriesFilter;

        public FileSystemVisitor(string path)
        {
            this.path = path;
        }

        public FileSystemVisitor(string path, FileSystemEntriesFilterDelegate fileSystemEntriesFilter) : this(path)
        {
            this.fileSystemEntriesFilter = fileSystemEntriesFilter;
        }

        public IEnumerable<string> Find()
        {
            if (!new DirectoryInfo(this.path).Exists)
            {
                yield break;
            }

            foreach (var name in Directory.EnumerateFileSystemEntries(this.path, string.Empty, SearchOption.AllDirectories))
            {
                if (this.fileSystemEntriesFilter == null || this.fileSystemEntriesFilter(name))
                    yield return name;
            }
        }
    }
}
