// See https://aka.ms/new-console-template for more information
// 2
Console.WriteLine("input value 1>>");
int.TryParse(Console.ReadLine(), out var x);
Console.WriteLine("input value 2>>");
int.TryParse(Console.ReadLine(), out var y);

Console.WriteLine($"value 1: {x}");
Console.WriteLine($"value 2: {y}");
Console.WriteLine($"{x + y}");
Console.WriteLine($"{x - y}");
Console.WriteLine($"{x * y}");
Console.WriteLine($"{x / y}");
Console.WriteLine($"{x % y}");

