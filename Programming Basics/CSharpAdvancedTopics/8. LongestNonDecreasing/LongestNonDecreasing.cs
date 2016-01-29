/// I am not capable of solving this task.
/// 
///
///
///
///
///
///
///
///
///
///
///
///
///
///
///
///
///
///
/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.LongestNonDecreasing
{
    class LongestNonDecreasingSubsequence
    {
        static List<int> AddSubset(int number)
        {
            List<int> newSubset = new List<int>();
            newSubset.Add(number);
            return newSubset;
        }

        static int GetBestTailIndex(List<List<int>> subsets)
        {
            int maxCount = subsets.Max(s => s.Count);
            int index = subsets.FindIndex(s => s.Count == maxCount);
            return index;
        }

        static int GetNextBestIndex(List<List<int>> subsets,
        int element)
        {
            if (subsets.Count == 1)
                return 0;
            int index = subsets.FindLastIndex(s => s.Max() < element);
            return index;
        }
        
        static void PerformEqualLengthCheck(List<List<int>> subsets)
        {
            for (int i = 0; i < subsets.Count - 1; i++)
            {
                if (subsets.Last().Count == subsets[i].Count)
                    subsets.RemoveAt(i);
            }
        }

        static void Main(string[] args)
        {
            int[] set = new int[] { 1, 1, 1, 3, 3, 3, 2, 2, 2, 2 };
            List<List<int>> subsets = new List<List<int>>();
            subsets.Add(new List<int> { set.ElementAt(0) });

            for (int i = 1; i < set.Length; i++)
            {
                int minTail = subsets.Min(s => s.Min()); // Current smallest end of subset
                int maxTail = subsets.Max(s => s.Max()); // Current largest end of subset
                if (set[i] < minTail)
                    subsets.Add(AddSubset(set[i]));
                else if (set[i] >= maxTail)
                {                    
                    int index = GetBestTailIndex(subsets);
                    subsets[index].Add(set[i]);
                    subsets.Add(AddSubset(set[i]));                    
                }
                else if (minTail <= set[i] && set[i] <= maxTail)
                {
                    int index = GetNextBestIndex(subsets, set[i]);
                    if (subsets[index].Count != 1)
                        if (set[i] <= subsets[index][subsets[index].Count - 2]) // Check if next-to-last element 
                            continue;                                           // is bigger than set[i]
                    if (subsets[index][subsets[index].Count - 1] > set[i]) // Check if the last element is 
                    {                                                      // bigger than set[i]
                        subsets[index].RemoveAt(subsets[index].Count - 1); // Remove last element in the list
                        subsets[index].Add(set[i]); // Add set[i]
                    }                        
                    else
                        subsets[index].Add(set[i]); // If the last element isn't bigger, just add set[i]
                }
                PerformEqualLengthCheck(subsets); // Check if there exist subsets with the same size we can eliminate
            }
        }
    }
}*/