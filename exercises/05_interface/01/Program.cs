// See https://aka.ms/new-console-template for more information

interface IVehicle
{
    void start();
    void stop();
}


class Car : IVehicle
{
    public void start() => Console.WriteLine("ブーン");
    public void stop() => Console.WriteLine("キキー");
}

class Bicycle : IVehicle
{
    public void start() => Console.WriteLine("カラカラ");
    public void stop() => Console.WriteLine("キュッ");
}

