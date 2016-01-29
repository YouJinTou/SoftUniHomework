using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.SortingNumbers
{
    class SortingNumbers
    {
        static int[] FillArray(int n)
        {
            int[] numbers = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("Element: ");
                numbers[i] = int.Parse(Console.ReadLine());
            }
            return numbers;
        }

        static int[] SortNumbers(int[] numbers) // Selection sort
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                int min = i;                
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[j] < numbers[min])
                    {
                        min = j;
                    }                    
                }
                if (min != i)
                {
                    int swap = numbers[i];
                    numbers[i] = numbers[min];
                    numbers[min] = swap;
                }
            }
            return numbers;
        }

        static void PrintSortedNumbers(int[] numbers)
        {
            foreach (int number in numbers)
                Console.WriteLine(number);
        }

        static void Main(string[] args)
        {
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
            PrintSortedNumbers(SortNumbers(FillArray(n)));
        }
    }
}
