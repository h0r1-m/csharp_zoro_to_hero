// See https://aka.ms/new-console-template for more information

using System;
using System.Linq;

class Program
{
    static void Main()
    {
        var list = new List<int>();

        while (true)
        {
            Console.Write("整数を入力してください（終了するにはexitを入力）:");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int result))
            {
                list.Add(result);
            }
            else if(input.ToLower() == "exit")
            {
                break;
            }
            else
            {
                Console.WriteLine("有効な整数を入力してください");
            }
        }

        var evenNumbers = list.Where(x => x % 2 == 0).ToList();

        Console.WriteLine("偶数:");
        foreach (var num in evenNumbers)
        {
            Console.WriteLine(num);
        }
    }
}