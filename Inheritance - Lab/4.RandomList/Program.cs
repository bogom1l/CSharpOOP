using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList list = new RandomList();
            list.Add("Test1");
            list.Add("Cat");
            list.Add("Cool");
            list.Add("Dog");

            Console.WriteLine(list.RandomString()); 
        }
    }
}
