using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18.InsideTheBuilding
{
    class InsideTheBuilding
    {
        static void Main(string[] args)
        {
            int blockSize = int.Parse(Console.ReadLine());
            int width = blockSize * 3;
            int height = blockSize * 4;            
            int[] points = new int[10];
            for (int i = 0; i < 10; i++)
            {
                points[i] = int.Parse(Console.ReadLine());
            }

            for (int i = 0; i < 9; i += 2)
            {
                if (points[i] < 0 || points[i] > width
                    || points[i + 1] < 0 || points[i + 1] > height
                    || ((points[i] < blockSize && points[i + 1] > blockSize)
                    || (points[i] > blockSize * 2 && points[i + 1] > blockSize)))
                    Console.WriteLine("outside");
                else
                    Console.WriteLine("inside");
            }
        }
    }
}
