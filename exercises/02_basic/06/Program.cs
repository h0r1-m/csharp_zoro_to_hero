// See https://aka.ms/new-console-template for more information

//摂氏→華氏

Console.WriteLine("摂氏温度を入力:");
string input = Console.ReadLine();
if (double.TryParse(input, out double C))
{
    Console.WriteLine($"=> 華氏温度: {(C * 9.0/5 + 32):F1}");
}
else
{
    Console.WriteLine("無効な入力");
}
