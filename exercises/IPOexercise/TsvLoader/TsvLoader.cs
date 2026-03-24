// See https://aka.ms/new-console-template for more information

using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TsvLoader;

public class Loader
{
    public static IEnumerable<(string FilePath, string[] row)> Load(IEnumerable<string> filePath)
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

        foreach (string file in filePath)
        {
            using var sr = new StreamReader(file, Encoding.GetEncoding("shift_jis"), detectEncodingFromByteOrderMarks: true);
            string? line;
            while ((line = sr.ReadLine()) != null)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                yield return (file, line.Split('\t'));
            }
        }     

    }
}