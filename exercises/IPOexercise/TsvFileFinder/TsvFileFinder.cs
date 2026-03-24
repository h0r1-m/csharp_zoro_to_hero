// See https://aka.ms/new-console-template for more information

using System;
using System.IO;
using System.Linq;

namespace TsvFileFinder;

public class FileFinder
{
    public static string[] TsvFileFinder(string Dir)
    {
        if (!Directory.Exists(Dir)) return null;

        return Directory.EnumerateFiles(Dir, "*.tsv", SearchOption.TopDirectoryOnly).Select(Path.GetFullPath).ToArray();
    }
}