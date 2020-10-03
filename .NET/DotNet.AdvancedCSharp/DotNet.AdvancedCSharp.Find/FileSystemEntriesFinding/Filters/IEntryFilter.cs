namespace DotNet.AdvancedCSharp.Find.FileSystemEntriesFinding.Filters
{
    interface IEntryFilter
    {
        bool IsMatch(string entry);
    }
}
