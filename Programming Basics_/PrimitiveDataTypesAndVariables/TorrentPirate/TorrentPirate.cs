using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorrentPirate
{
    class TorrentPirate
    {
        private const byte WifiSpeed = 2;

        static void Main(string[] args)
        {            
            int d = int.Parse(Console.ReadLine());           
            int p = int.Parse(Console.ReadLine());            
            int w = int.Parse(Console.ReadLine());

            double timeToDownloadInHours = (d / WifiSpeed) / 3600d;
            double mallPrice = w * timeToDownloadInHours;
            double numberOfMovies = d / 1500d;
            double cinemaPrice = numberOfMovies * p;

            if (mallPrice > cinemaPrice)
            {
                Console.WriteLine("cinema -> {0:0.00}lv", cinemaPrice);
            }            
            else
            {
                Console.WriteLine("mall -> {0:0.00}lv", mallPrice);
            }
        }
    }
}
