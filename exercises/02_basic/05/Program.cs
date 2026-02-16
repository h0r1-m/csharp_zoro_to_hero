// See https://aka.ms/new-console-template for more information

var numbers = new List<int> { 10, 20, 30 };
Console.WriteLine($"要素数: {numbers.Count}");
Console.WriteLine($"合計: {numbers[0] + numbers[1] + numbers[2]}");
Console.WriteLine($"最初の要素: {numbers[0]}");
Console.WriteLine($"最後の要素: {numbers[^1]}");