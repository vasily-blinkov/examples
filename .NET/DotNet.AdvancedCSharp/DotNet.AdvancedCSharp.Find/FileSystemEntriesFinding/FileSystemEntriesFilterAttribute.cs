using System;

namespace DotNet.AdvancedCSharp.Find.FileSystemEntriesFinding
{
    class FileSystemEntriesFilterAttribute : Attribute
    {
        internal Type Filter
        {
            get;
            private set;
        }

        public FileSystemEntriesFilterAttribute(Type filter)
        {
            Filter = filter;
        }
    }
}
