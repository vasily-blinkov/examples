using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using ArgsMapper;
using DotNet.AdvancedCSharp.Find.AgrsMapping.Commands;
using DotNet.AdvancedCSharp.Find.FileSystemEntriesFinding;
using DotNet.AdvancedCSharp.Find.FileSystemEntriesFinding.Filters;

namespace DotNet.AdvancedCSharp.Find.AgrsMapping
{
    class Args
    {
        public class FindCommand
        {
            public Func<Args, FindFileSystemEntries> GetOptions
            {
                get;
                private set;
            }

            public Expression<Func<Args, FindFileSystemEntries>> MemberExpression
            {
                get;
                private set;
            }

            public FindCommand(Func<Args, FindFileSystemEntries> getter, Expression<Func<Args, FindFileSystemEntries>> memberExpression)
            {
                GetOptions = getter;
                MemberExpression = memberExpression;
            }
        }

        static Args()
        {
            findCommands = new List<FindCommand>();

            foreach (var expression in FindCommandsExpressions)
            {
                findCommands.Add(new FindCommand(expression.Compile(), expression));
            }
        }

        static IEnumerable<Expression<Func<Args, FindFileSystemEntries>>> FindCommandsExpressions
        {
            get
            {
                yield return x => x.Files;
                yield return x => x.Directories;
                yield return x => x.All;
            }
        }

        static readonly List<FindCommand> findCommands;

        public static List<FindCommand> FindCommands
        {
            get
            {
                return findCommands;
            }
        }

        [FileSystemEntriesFilter(typeof(FilesOnlyFilter))] public FindFileSystemEntries Files { get; set; }
        [FileSystemEntriesFilter(typeof(DirectoriesOnlyFilter))] public FindFileSystemEntries Directories { get; set; }
        public FindFileSystemEntries All { get; set; }

        internal static ArgsMapper<Args> Get()
        {
            var mapper = new ArgsMapper<Args>();

            foreach (var command in FindCommands)
            {
                mapper.AddCommand<Args, FindFileSystemEntries>(command.MemberExpression, Setup);
            }

            return mapper;
        }

        static void Setup(ArgsCommandSettings<FindFileSystemEntries> commandSettings)
        {
            commandSettings.AddOption(x => x.Path);
        }
    }
}
