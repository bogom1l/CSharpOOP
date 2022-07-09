using _8.CollectionHierarchy.Models.Interfaces;
using System;

namespace _8.CollectionHierarchy
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int removeOpCount = int.Parse(Console.ReadLine());

            IAddCollection<string> addCollection = new AddCollection<string>();
            IAddRemoveCollection<string> addRemoveCollection = new AddRemoveCollection<string>();
            IMyList<string> myList = new MyList<string>();

            AddToAnyCollection(words, addCollection);
            AddToAnyCollection(words, addRemoveCollection);
            AddToAnyCollection(words, myList);

            RemoveFromAnyCollection(removeOpCount, addRemoveCollection);
            RemoveFromAnyCollection(removeOpCount, myList);
            
        }

        private static void AddToAnyCollection(string[] words, IAddCollection<string> collection)
        {
            foreach (string word in words)
            {
                Console.Write(collection.Add(word) + " ");
            }
            Console.WriteLine();
        }

        private static void RemoveFromAnyCollection(int cnt, IAddRemoveCollection<string> collection)
        {
            for (int i = 0; i < cnt; i++)
            {
                Console.Write(collection.Remove() + " ");
            }
            Console.WriteLine();
        }

    }
}
