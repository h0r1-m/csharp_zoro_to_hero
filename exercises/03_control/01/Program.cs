// See https://aka.ms/new-console-template for more information


int[] numbers = Enumerable.Range(1, 100).ToArray();

foreach (var v in numbers)
{
    if (v%3 == 0 && v%5 == 0)
    {
        Console.WriteLine("FizzBuzz");
    }

    else if (v%3 == 0)
    {
        Console.WriteLine("Fizz");
    }

    else if (v%5 == 0)
    {
        Console.WriteLine("Buzz");
    }

    else
    {
        Console.WriteLine(v);
    }
}