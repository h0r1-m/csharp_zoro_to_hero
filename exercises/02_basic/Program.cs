// See https://aka.ms/new-console-template for more information
// 課題 1
string text = "Hello World";
int number = 10;
bool flag = true;

Console.WriteLine($"number: {number}");
Console.WriteLine($"text: {text}");
Console.WriteLine($"flag: {flag}");


// 課題 2
Console.WriteLine("値1を入力してください>>");
int.TryParse(Console.ReadLine(), out var x);
Console.WriteLine("値2を入力してください>>");
int.TryParse(Console.ReadLine(), out var y);

Console.WriteLine($"数値1: {x}");
Console.WriteLine($"数値2: {y}");
Console.WriteLine($"合計: {x + y}");
Console.WriteLine($"差分: {x - y}");
Console.WriteLine($"積: {x * y}");
Console.WriteLine($"商: {x / y}");
Console.WriteLine($"余り: {x % y}");

// 課題 3
