// See https://aka.ms/new-console-template for more information
// 4

Console.WriteLine(">>");
string name = Console.ReadLine() ?? "";

name = name.Length == 0 ? "(無名)" :
(name.Length < 5 ? "短い名前" : "長い名前");

Console.WriteLine(name);