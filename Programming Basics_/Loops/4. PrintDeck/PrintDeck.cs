    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.PrintDeck
{
    class PrintDeck
    {
        static void Main(string[] args)
        {
            for (int i = 2; i < 15; i++)
            {
                char card = '0'; // Initialize card               
                if (i == 10)
                    card = 'T';
                else if (i == 11)
                    card = 'J';
                else if (i == 12)
                    card = 'Q';
                else if (i == 13)
                    card = 'K';
                else if (i == 14)
                    card = 'A';
                for (int j = 0; j < 4; j++)
                {
                    switch (j)
                    {
                        case 0:
                            if (i < 10) // For some reason, ((i < 10) ? i : card) doesn't work
                                Console.Write("{0}c ", i); 
                            else
                                Console.Write("{0}c ", card);
                            break;
                        case 1:
                            if (i < 10)
                                Console.Write("{0}d ", i);
                            else
                                Console.Write("{0}d ", card);
                            break;
                        case 2:
                            if (i < 10)
                                Console.Write("{0}h ", i);
                            else
                                Console.Write("{0}h ", card);
                            break;
                        case 3:
                            if (i < 10)
                                Console.WriteLine("{0}s ", i);
                            else
                                Console.WriteLine("{0}s ", card);
                            break;
                    }
                }
            }
                
        }
    }
}
