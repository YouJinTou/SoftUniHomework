using System;

namespace DistanceCalculator
{
    public class Service1 : IServiceDistanceCalculator
    {
        public double CalculateDistance(Point start, Point end)
        {
            double differenceX = Math.Pow((end.X - start.X), 2);
            double differenceY = Math.Pow((end.Y - start.Y), 2);
            double distance = Math.Sqrt(differenceX + differenceY);

            return distance;
        }
    }
}
