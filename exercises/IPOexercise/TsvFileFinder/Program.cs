// See https://aka.ms/new-console-template for more information

using System;
using System.IO;
using System.Linq;


public static class TsvFileFinder
{
    public static string[] TsvFileFinder(string Dir)
    {
        if (!Directry.Exists(Dir)) return null;

        return Directory.EnumerateFiles(Dir, "*.tsv", SearchOption.TopDirectoryOnly).Select(Path.GetFullPath).ToArray();
    }
}