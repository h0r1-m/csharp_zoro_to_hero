// See https://aka.ms/new-console-template for more information

using TsvFileFinder;
using TsvLoader;
using InvoiceEntity;


//  ここで実行

var Dir = args.Length > 0 ? args[0] : @"C:\Users\maikohori\OneDrive - 株式会社コアコンセプト・テクノロジー\ドキュメント\2026C#研修";

var files = FileFinder.TsvFileFinder(Dir);

var rows = Loader.Load(files);

foreach (var (path, row) in rows)
{
    Console.WriteLine($"[{System.IO.Path.GetFileName(path)}] {string.Join(" | ", row)}");
}