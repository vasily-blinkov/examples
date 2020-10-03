using System;
using System.Collections;
using System.Linq;
using System.Linq.Expressions;
using DotNet.AdvancedCSharp.FileSystemVisitors;
using DotNet.AdvancedCSharp.Find.AgrsMapping;
using DotNet.AdvancedCSharp.Find.FileSystemEntriesFinding.Filters;

namespace DotNet.AdvancedCSharp.Find.FileSystemEntriesFinding
{
    static class FileSystemEntriesFindHelper
    {
        internal static void Find(Args args)
        {
            foreach (var command in Args.FindCommands)
            {
                var options = command.GetOptions(args);

                if (options != null)
                {
                    IEntryFilter filter = GetFilter(command);
                    var fileSystemVisitor = new FileSystemVisitor(options.Path, filter != null ? filter.IsMatch : (FileSystemEntriesFilterDelegate)null);

                    foreach (var entry in fileSystemVisitor.Find())
                    {
                        Console.WriteLine(entry);
                    }
                }
            }
        }

        static IEntryFilter GetFilter(Args.FindCommand command)
        {
            var commandName = typeof(Args).GetMember(((MemberExpression)command.MemberExpression.Body).Member.Name);
            var commandInfo = commandName.Length == 1 ? commandName[0] : null;

            if (commandInfo != null)
            {
                var filterAttributes = from a in commandInfo.GetCustomAttributes(false) where a is FileSystemEntriesFilterAttribute select a;

                if (filterAttributes.SingleOrDefault() is FileSystemEntriesFilterAttribute attribute)
                {
                    return GetFilter(attribute.Filter);
                }
            }

            return null;
        }

        static IEntryFilter GetFilter(Type filterType)
        {
            return (IEntryFilter)Activator.CreateInstance(filterType);
        }
    }
}
