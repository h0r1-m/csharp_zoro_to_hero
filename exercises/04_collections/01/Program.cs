// See https://aka.ms/new-console-template for more information

using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] a = new int[3];

        // 自分で書いたコード
        //        try
        //        {
        //            Console.WriteLine("1つ目の数字>>");
        //            a[0] = int.Parse(Console.ReadLine());
        //            Console.WriteLine("2つ目の数字>>");
        //            a[1] = int.Parse(Console.ReadLine());
        //            Console.WriteLine("3つ目の数字>>");
        //            a[2] = int.Parse(Console.ReadLine());
        //        }
        //        catch (FormatException)
        //        {
        //            Console.WriteLine("数字を入力してください");
        //        }
        //        catch(Exception ex)
        //        {
        //            Console.WriteLine(ex.Message);
        //        }


        // chatGPTに添削してもらったコード

        for (int i = 0; i < a.Length; i++)
        {
            while (true)
            {
                Console.WriteLine($"{i + 1}つ目の数字>>");
                string input = Console.ReadLine();
                if (int.TryParse(input, out int result))
                {
                    a[i] = result;
                    break;
                }
                else
                {
                    Console.WriteLine("数字を入力してください");
                }
            }
        }
        // ここまで

        Console.WriteLine("合計:");
        var sum = a.Sum();
        Console.WriteLine(sum);

        Console.WriteLine("平均:");
        var ave = a.Average();
        Console.WriteLine(ave);
    }
}

