// See https://aka.ms/new-console-template for more information


int[] numbers = Enumerable.Range(1, 20).ToArray();

List<int> evennumbers = new List<int>();

foreach (int number in numbers)
{
    if (number%2 == 0)
    {
        evennumbers.Add(number);
    }
}

Console.WriteLine("even numbers list");
//Console.WriteLine(string.Join(evennumbers));

foreach (int evennumber in evennumbers)
{
    Console.WriteLine(evennumber);
}