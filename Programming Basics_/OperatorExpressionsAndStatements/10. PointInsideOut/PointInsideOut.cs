using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.PointInsideOut
{
    class PointInsideOut
    {
        static bool CheckCircleBounds(
            double x, double y, double radius,
            double centerX, double centerY)
        {
            if ((Math.Pow(x - centerX, 2)
                + Math.Pow(y - centerY, 2) <=
                Math.Pow(radius, 2)))
            {
                return true;
            }
            else return false;            
        }

        static bool CheckRectangleBounds(
            double x, double y)
        {
            if ((x >= -1 && x <= 5)
                && (y >= -1 && y <= 1))
            {
                return true;
            }
            else return false;
        }

        static void Main(string[] args)
        {
            Console.Write("X coordinate: ");
            double x = double.Parse(Console.ReadLine());
            Console.Write("Y coordinate: ");
            double y = double.Parse(Console.ReadLine());

            if (CheckCircleBounds(x, y, 1, 1, 1.5) == true
                && CheckRectangleBounds(x, y) == false)
            {
                Console.WriteLine("This point satisfies the condition.");
            }
            else
            {
                Console.WriteLine("This point does NOT satisfy the condition.");
            }
        }
    }
}
