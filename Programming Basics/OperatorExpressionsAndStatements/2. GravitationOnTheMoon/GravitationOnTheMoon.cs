using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.GravitationOnTheMoon
{
    class GravitationOnTheMoon
    {
        static void Main(string[] args)
        {
            Console.Write("Man's weight on Earth: ");
            double weight = double.Parse(Console.ReadLine());
            Console.WriteLine("Man's weight on the Moon: " + 0.17 * weight);
        }
    }
}
