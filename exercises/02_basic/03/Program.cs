// See https://aka.ms/new-console-template for more information
// 3
int a = 42;
double b = 3.14;

double a_as_double = (double)a;
Console.WriteLine($"{a_as_double}");

int b_as_int = (int)b;
Console.WriteLine($"{b_as_int}");

int? maybe = null;
Console.WriteLine($"maybe = {maybe}");
maybe = 100;
Console.WriteLine($"maybe = {maybe}");