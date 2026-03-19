// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Genetic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Linq;

public static class TsvLoader
{
    public static IEnumerablet<string FilePath, string[] row> Load(List<string[]> filePath)
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

        foreach (string[] file in filePath)
        {
            using var sr = new StreamReader(file, Encoding.GetEncoding("sift_jis"), detectEncodingFromByteOrderMarks: true);
            string? line;
            while ((line = sr.ReadLine()) != null)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                yield return (file, line.Split('\t'));
            }
        }     

    }
}