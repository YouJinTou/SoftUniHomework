using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19.StudentCables
{
    class StudentCables
    {
        static int ParseCable(int length, string unit)
        {
            if (unit == "centimeters")
                return length;
            else
                return length * 100;
        }
        
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            
            int cableTotal = 0;
            int count = 0;
            while (n > 0)
            {
                int length = int.Parse(Console.ReadLine());
                string unit = Console.ReadLine();
                if (length < 20 && unit == "centimeters")
                {
                    n--;
                    continue;
                }
                cableTotal += ParseCable(length, unit);
                n--;
                count++;
            }
            cableTotal -= 3 * (count - 1);           
            int cablesCount = cableTotal / 504;
            int remainder = cableTotal % 504;

            Console.WriteLine(cablesCount);
            Console.WriteLine(remainder);
        }
    }
}