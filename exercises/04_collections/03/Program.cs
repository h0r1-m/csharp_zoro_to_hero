// See https://aka.ms/new-console-template for more information

using System;
using System.Linq;

class Program
{
    static void Main()
    {
        //  copilotの指摘：配列の初期化は宣言と同時に
        //  ↑できていないだけで「適切な静的 'Main' メソッドを含んでいません」になる
        string[] s = { "orange", "apple", "grape", "orange", "apple" };

        //  copilotの指摘：配列に格納するときは必ず.ToArray()
        string[] t = s.Distinct().ToArray();
        //  Console.WriteLine(t);
        //  copilotの指摘：配列を表示する場合はforeachか.Join(", ", hoge)が必要
        Console.WriteLine(string.Join(", ", t));

        //  ソートされたリスト→.ToList()
        List<> l = t.OrderBy(x => x).ToList();
        Console.WriteLine(string.Join(", ", l));

    }
}