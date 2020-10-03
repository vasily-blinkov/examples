# Usage

## Syntax

```
.\DotNet.AdvancedCSharp.Find.exe <type> --path <path>
```

* `<type>` is `files`, or `directories`, or `all`
* `path` is a starting directory to find entries

## Examples

### Find files and directories

```
.\DotNet.AdvancedCSharp.Find.exe all C:\Users\Vasil\source\repos\
```

### Find only files

```
.\DotNet.AdvancedCSharp.Find.exe files "C:\Users\Vasil\My Documents"
```

### Find only directories

```
.\DotNet.AdvancedCSharp.Find.exe directories C:\Users\Vasil\
```

# To do

1. Default `<type>` is `all`
1. Default `--path <path>` is a current working directory
1. Handle relative pathes relatively to the current working directory (including '..' directories)
