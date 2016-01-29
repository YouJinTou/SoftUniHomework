using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23.LightTheTorches
{
    class LightTheTorches
    {
        static char[] rooms;
        static int currentPos;

        static void UpdateState(int n, string state)
        {
            for (int i = 0, j = 0; i < rooms.Length; i++, j++)
            {
                if (j >= state.Length)
                    j = 0;
                rooms[i] = state[j];
            }
        }

        static void ExecuteCommands(string command)
        {
            string dir = command.Substring(0, command.IndexOf(' '));
            int roomsCount
                = int.Parse(command.Substring(command.IndexOf(' ')));
            if ((dir == "LEFT" && currentPos == 0) // Don't do anything if you're at the edge
                || (dir == "RIGHT" && currentPos == rooms.Length - 1)) // and going in the same direction
                return;
           
            if (dir == "LEFT")
            {
                if ((currentPos - roomsCount - 1) < 0)
                    currentPos = 0;
                else
                    currentPos = currentPos - roomsCount - 1;

                if (rooms[currentPos] == 'D')
                    rooms[currentPos] = 'L';
                else
                    rooms[currentPos] = 'D';
            }
            else
            {
                if ((currentPos + roomsCount + 1 > rooms.Length - 1))
                    currentPos = rooms.Length - 1;
                else
                    currentPos += roomsCount + 1;

                if (rooms[currentPos] == 'D')
                    rooms[currentPos] = 'L';
                else
                    rooms[currentPos] = 'D';
            }
        }

        static int CalculatePrayers()
        {
            int count = 0;
            foreach (char ch in rooms)
            {
                if (ch == 'D')
                    count++;
            }

            char D = 'D';
            int result = D * count;
            return result;
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            rooms = new char[n];
            string state = Console.ReadLine();
            UpdateState(n, state);
            string command = Console.ReadLine();
            
            currentPos = n / 2;
            while (command != "END")
            {
                ExecuteCommands(command);
                command = Console.ReadLine();
            }            
            Console.WriteLine(CalculatePrayers());
        }
    }
}
