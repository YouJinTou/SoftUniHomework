using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayMatcher
{
    class ArrayMatcher
    {
        static string[] GetTokens(string info)
        {
            string[] tokens = info.Split('\\');
            return tokens;
        }

        static string GetCommand(string[] tokens)
        {
            string command = tokens[2];
            return command;
        }

        static SortedSet<char> JoinArrays(string[] tokens)
        {
            char[] leftArray = tokens[0].ToCharArray();
            char[] rightArray = tokens[1].ToCharArray();
            SortedSet<char> leftSet =
                new SortedSet<char>(leftArray);
            SortedSet<char> rightSet =
                new SortedSet<char>(rightArray);
            SortedSet<char> result =
                new SortedSet<char>();

            result.UnionWith(leftSet);
            result.IntersectWith(leftSet);
            result.IntersectWith(rightSet);
            return result;
        }

        static SortedSet<char> ExcludeRight(SortedSet<char> intersectionResult,
            string[] tokens)
        {
            char[] leftArray = tokens[0].ToCharArray();          
            SortedSet<char> result =
                new SortedSet<char>();

            result.UnionWith(leftArray);
            result.ExceptWith(intersectionResult);          
            return result;
        }

        static SortedSet<char> ExcludeLeft(SortedSet<char> intersectionResult,
            string[] tokens)
        {
            char[] rightArray = tokens[1].ToCharArray();
            SortedSet<char> result =
                new SortedSet<char>();

            result.UnionWith(rightArray);
            result.ExceptWith(intersectionResult);
            return result;
        }

        static void Main(string[] args)
        {
            string info = Console.ReadLine();
            switch (GetCommand(GetTokens(info)))
            {
                case "join":
                    Console.WriteLine(string.Join("",
                        JoinArrays(GetTokens(info))));
                    break;
                case "left exclude":
                    Console.WriteLine(string.Join("",
                    ExcludeLeft(JoinArrays(GetTokens(info)),
                    GetTokens(info))));
                    break;
                case "right exclude":
                    Console.WriteLine(string.Join("",
                    ExcludeRight(JoinArrays(GetTokens(info)),
                    GetTokens(info))));
                    break;
            }
        }
    }
}
