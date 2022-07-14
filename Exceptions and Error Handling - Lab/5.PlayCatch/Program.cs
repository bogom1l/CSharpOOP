using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.PlayCatch
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            int sumOfExceptions = 0;

            while (true)
            {
                if (sumOfExceptions >= 3)
                {
                    break;
                }

                string input = Console.ReadLine();
                string[] tokens = input.Split();
                string action = tokens[0];

                try
                {
                    if (action == "Replace")
                    {
                        CheckNumbersForReplaceMethod(numbers, tokens);

                        int index = int.Parse(tokens[1]);
                        int element = int.Parse(tokens[2]);
                        numbers[index] = element;
                    }
                    else if (action == "Print")
                    {
                        CheckNumbersForPrintMethod(numbers, tokens);

                        int startIndex = int.Parse(tokens[1]);
                        int endIndex = int.Parse(tokens[2]);
                        Console.WriteLine(String.Join(", ", numbers.GetRange(startIndex, endIndex - startIndex + 1)));
                    }
                    else if (action == "Show")
                    {
                        CheckNumbersForShowMethod(numbers, tokens);

                        int index = int.Parse(tokens[1]);
                        Console.WriteLine(numbers[index]);
                    }
                }
                catch (IndexOutOfRangeException ie)
                {
                    sumOfExceptions++;
                    Console.WriteLine(ie.Message);
                }
                catch (InvalidOperationException ioe)
                {
                    sumOfExceptions++;
                    Console.WriteLine(ioe.Message);
                }

            }

            Console.WriteLine(String.Join(", ", numbers));
        }

        static bool CheckIndex(List<int> list, int index)
        {
            if (index < 0 || index >= list.Count) // > ?
            {
                return false;
            }
            return true;
        }

        static bool CheckNumberFormat(string possibleNumber)
        {
            int numberToOut;
            bool success = int.TryParse(possibleNumber, out numberToOut);

            if (!success)
            {
                return false;
            }
            return true;
        }

        static void CheckNumbersForReplaceMethod(List<int> numbers, string[] tokens)
        {
            if (!CheckNumberFormat(tokens[1]))
            {
                throw new InvalidOperationException("The variable is not in the correct format!");
            }
            if (!CheckNumberFormat(tokens[2]))
            {
                throw new InvalidOperationException("The variable is not in the correct format!");
            }

            if (!CheckIndex(numbers, int.Parse(tokens[1])))
            {
                throw new IndexOutOfRangeException("The index does not exist!");
            }
        }

        static void CheckNumbersForPrintMethod(List<int> numbers, string[] tokens)
        {
            if (!CheckNumberFormat(tokens[1]))
            {
                throw new InvalidOperationException("The variable is not in the correct format!");
            }
            if (!CheckNumberFormat(tokens[2]))
            {
                throw new InvalidOperationException("The variable is not in the correct format!");
            }

            if (!CheckIndex(numbers, int.Parse(tokens[1])))
            {
                throw new IndexOutOfRangeException("The index does not exist!");
            }

            if (!CheckIndex(numbers, int.Parse(tokens[2])))
            {
                throw new IndexOutOfRangeException("The index does not exist!");
            }
        }

        static void CheckNumbersForShowMethod(List<int> numbers, string[] tokens)
        {
            if (!CheckNumberFormat(tokens[1]))
            {
                throw new InvalidOperationException("The variable is not in the correct format!");
            }

            if (!CheckIndex(numbers, int.Parse(tokens[1])))
            {
                throw new IndexOutOfRangeException("The index does not exist!");
            }
        }

    }
}