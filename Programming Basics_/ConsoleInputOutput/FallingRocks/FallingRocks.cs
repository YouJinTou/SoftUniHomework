using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace FallingRocks
{
    public class Dwarf
    {
        private const ushort Row = 18; // Where Hero is

        public char icon = 'O'; // Using (O) is a pain as it's 3 characters long   
        public int score = 0;
        private int x = 15;
        Thread moveDwarfThread;

        public Dwarf()
        {
            Console.SetCursorPosition(x, Row);
            Console.Write(icon);
        }

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public void MoveDwarf()
        {
            moveDwarfThread = new Thread(CreateMovementThread);
            moveDwarfThread.Start();
        }

        private void CreateMovementThread()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            if (keyInfo.Key == ConsoleKey.LeftArrow)
            {
                Console.SetCursorPosition(x, Row);
                Console.Write(" ");
                if (x == 1)
                {
                    Console.SetCursorPosition(x, Row); // We are at the edge and can't                    
                }                                      // move any farther
                else
                {
                    x--;
                }
                Console.SetCursorPosition(x, Row);
                Console.Write(icon);
            }
            else if (keyInfo.Key == ConsoleKey.RightArrow)  // There's a weird glitch when Hero
            {                                               // gets close to the right side,
                if (x == Console.BufferWidth - 3)           // so I had to prevent him from going
                {                                           // there in the first place
                    Console.SetCursorPosition(x - 2, Row);
                }
                else
                {
                    Console.SetCursorPosition(x, Row);
                    Console.Write(" ");
                    x++;
                }
                Console.SetCursorPosition(x, Row);
                Console.Write(icon);
            }
        }

        public int TrackScore(DateTime start, DateTime end)
        {
            TimeSpan timeElapsed = start - end;
            score = (int)timeElapsed.TotalSeconds;
            return Math.Abs(score);
        }
    }

    class Rock
    {
        public char[] rockType =
            new char[] { '^', '@', '*', '&', '+', '%', '$', '#', '!', '.', ';', '-' };
        List<List<Rock>> allRows = new List<List<Rock>>();
        public int x;
        public int y;
        public char type;
        public Random rockCount = new Random();
        public Random chooseType = new Random();
        public Random initialX = new Random();

        public Rock()
        {
            x = initialX.Next(1, 28);
            y = 0;
            type = rockType[chooseType.Next(0, 12)];

            Console.SetCursorPosition(x, y);
        }

        public List<Rock> InitializeRow()
        {
            List<Rock> rocks = new List<Rock>();
            int count = rockCount.Next(1, 5);
            for (int i = 0; i < count; i++)
            {
                rocks.Add(new Rock());
                Thread.Sleep(10); // Remove to make the game easy
            }
            return rocks;
        }

        // We have logic checking if the game is over in this 
        // method as well
        public bool ReignChaos(int heroPosition)
        {
            bool gameOver = false;
            allRows.Add(InitializeRow());
            if (allRows.Count > 21)
            {
                allRows.RemoveAt(0); // We don't need to keep rocks that have gone past the screen
            }
            foreach (List<Rock> row in allRows)
            {
                foreach (Rock rock in row)
                {
                    gameOver = checkGameState(rock, heroPosition);

                    if (rock.y != 0) // Avoid out of buffer-size bounds
                    {
                        Console.SetCursorPosition(rock.x, rock.y - 1);
                        Console.Write(" ");
                    }
                    if (rock.y == Console.BufferHeight)
                    {
                        Console.SetCursorPosition(rock.x, 0);
                    }
                    else // The default statement to draw rocks
                    {
                        Console.SetCursorPosition(rock.x, rock.y);
                        Console.Write(rock.type);
                        rock.y++;
                    }
                    if (gameOver)
                    {
                        Console.SetCursorPosition(rock.x, rock.y - 1);
                        Console.Write("X");
                        return gameOver;
                    }
                }
            }
            return gameOver;
        }

        public static bool checkGameState(Rock rock, int heroPosition)
        {
            bool gameOver = false;
            if (rock.y == 18                // Collision where Hero is
                && rock.x == heroPosition)
            {
                gameOver = true;
            }
            return gameOver;
        }
    }

    class Battlefield
    {
        public Battlefield()
        {
            Console.WindowHeight = 20;
            Console.BufferHeight = 20;
            Console.WindowWidth = 30;
            Console.BufferWidth = 30;
            Console.CursorVisible = false;
        }
    }
    
    class GameInitialization
    {
        static void Main()
        {
            Battlefield battlefield = new Battlefield();
            Instructions();
            Dwarf hero = new Dwarf();
            Rock rock = new Rock();
            DateTime start = DateTime.Now;
            int score = 0;

            while (true)
            {
                hero.MoveDwarf();
                if (rock.ReignChaos(hero.X))
                {
                    Thread.Sleep(1500);
                    Console.Clear();
                    break;
                }
                Thread.Sleep(150);
            }
            DateTime end = DateTime.Now;
            score = hero.TrackScore(start, end);

            Console.SetCursorPosition(7, 9);
            Console.WriteLine("G A M E  O V E R");
            Console.SetCursorPosition(7, 10);
            Console.WriteLine("Your score: {0}", score);
        }

        public static void Instructions()
        {
            Console.SetCursorPosition(10, 6);
            Console.WriteLine("Left <-");
            Console.SetCursorPosition(10, 8);
            Console.WriteLine("Right ->");
            Console.SetCursorPosition(10, 10);
            Console.WriteLine("Don't die.");
            Console.SetCursorPosition(10, 12);
            Console.WriteLine("Good luck.");
            Console.SetCursorPosition(10, 12);

            Thread.Sleep(4000);
        }
    }
}