// See https://aka.ms/new-console-template for more information

using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] a = { 9, 5, 3, 6, 2, 0, 2 };
        Console.WriteLine("最小値：" + a.Min());
        Console.WriteLine("最大値：" + a.Max());

        // ソートしてからの挙動
        int[] b = a.OrderBy(x => x).ToArray();
        Console.WriteLine(string.Join(", ", b));

        Console.WriteLine("最小値：" + b[0]);
        Console.WriteLine("最大値：" + b[b.Length - 1]);    // b[^1]でも可

        Console.WriteLine("中央値：" + b[b.Length / 2]);    // 奇数長のみ正しい

        //  copilotの提案：ソート済みの偶数長に対応したメソッド
        double MedianOfSorted(int[] i)
        {
            if (i.Length == 0) throw new InvalidOperationException("空白列の中央値は定義できません。");
            int mid = i.Length / 2;
            return (i.Length % 2 == 1)
                ? i[mid]
                : (i[mid - 1] + i[mid]) / 2.0;
        }

        Console.WriteLine("中央値：" + MedianOfSorted(b));
    }
}