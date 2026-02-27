// See https://aka.ms/new-console-template for more information


int [] n = Enumerable.Range(1, 4).ToArray();
foreach (int i in n){
    switch (i)
{
    case 1:
        Console.WriteLine("One");
        break;
    case 2:
        Console.WriteLine("Two");
        break;
    default:
        Console.WriteLine("Other");
        break;
}}