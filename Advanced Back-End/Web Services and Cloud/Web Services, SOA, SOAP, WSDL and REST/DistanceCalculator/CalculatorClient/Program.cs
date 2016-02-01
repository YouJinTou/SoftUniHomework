using System;
using CalculatorClient.DistanceService;

class Program
{
    static void Main()
    {
        var client = new ServiceDistanceCalculatorClient();
        Point startPoint = new Point();
        startPoint.X = 10;
        startPoint.Y = 10;
        Point endPoint = new Point();
        endPoint.X = 15;
        endPoint.Y = 15;

        double distance = client.CalculateDistance(startPoint, endPoint);

        Console.WriteLine(distance);
    }
}