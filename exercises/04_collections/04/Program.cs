// See https://aka.ms/new-console-template for more information

using System;
using System.Linq;

class Program
{
    static void Main()
    {
        // 2次元→int[2][];
        int[][] j = new int[2][];
        j[0] = new[] { 7, 9, 3, 5 };
        j[1] = new[] { 0, 3, 2, 8, 9 };

        var sum0 = j[0].Sum();
        Console.WriteLine("sum0: " + sum0);

        var sum1 = j[1].Sum();
        Console.WriteLine("sum1: " + sum1);
    }
}
