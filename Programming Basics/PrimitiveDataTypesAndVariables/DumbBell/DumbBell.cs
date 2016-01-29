using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumbBell
{
    class Dumbbell
    {
        static void Main(string[] args)
        {
            int dumbbellHeight = int.Parse(Console.ReadLine());
            int middle = dumbbellHeight / 2;

            char dot = '.';
            char outline = '&';
            char filling = '*';
            char bar = '=';

            int outsideDotCount = dumbbellHeight - middle - 1; // Decreasing
            int fillingCount = middle; // Increasing

            #region Top to middle
            for (int i = 0; i < middle; i++)
            {
                if (i == 0)
                {
                    Console.Write(new string(dot, outsideDotCount));
                    Console.Write(new string(outline, middle + 1));
                    Console.Write(new string(dot, dumbbellHeight));
                    Console.Write(new string(outline, middle + 1));
                    Console.Write(new string(dot, outsideDotCount));
                    outsideDotCount--;
                    Console.WriteLine();
                }
                if (i == middle - 1)
                {
                    Console.Write(outline);
                    Console.Write(new string(filling, dumbbellHeight - 2));
                    Console.Write(outline);
                    Console.Write(new string(bar, dumbbellHeight));
                    Console.Write(outline);
                    Console.Write(new string(filling, dumbbellHeight - 2));
                    Console.Write(outline);
                    break;
                }
                Console.Write(new string(dot, outsideDotCount));
                Console.Write(outline + new string(filling, fillingCount) + outline);
                Console.Write(new string(dot, dumbbellHeight));
                Console.Write(outline + new string(filling, fillingCount) + outline);
                Console.Write(new string(dot, outsideDotCount));
                outsideDotCount--;
                fillingCount++;
                Console.WriteLine();
            }
            #endregion

            #region Middle to bottom
            outsideDotCount = 1; // Increasing
            fillingCount = dumbbellHeight - 3; // Decreasing
            Console.WriteLine();
            for (int i = 0; i < middle; i++)
            {
                if (i == middle - 1)
                {
                    Console.Write(new string(dot, outsideDotCount));
                    Console.Write(new string(outline, middle + 1));
                    Console.Write(new string(dot, dumbbellHeight));
                    Console.Write(new string(outline, middle + 1));
                    Console.Write(new string(dot, outsideDotCount));
                    Console.WriteLine();
                    break;
                }
                Console.Write(new string(dot, outsideDotCount));
                Console.Write(outline + new string(filling, fillingCount) + outline);
                Console.Write(new string(dot, dumbbellHeight));
                Console.Write(outline + new string(filling, fillingCount) + outline);
                Console.Write(new string(dot, outsideDotCount));                
                outsideDotCount++;
                fillingCount--;
                Console.WriteLine();
            }
            #endregion
        }
    }
}
