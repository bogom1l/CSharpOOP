namespace Animals
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            
            while (true)
            {
                string input1 = Console.ReadLine();
                
                if (input1 == "Beast!")
                {
                    break;
                }

                string input2 = Console.ReadLine();

                string[] tokens = input2.Split();
                string name = tokens[0];
                int age = int.Parse(tokens[1]);

                if (age <= 0)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                if (input1 == "Cat")
                {
                    string gender = tokens[2];

                    Cat cat = new Cat(name, age, gender);
                    Console.WriteLine(cat);
                }
                else if(input1 == "Dog")
                {
                    string gender = tokens[2];

                    Dog dog = new Dog(name, age, gender);
                    Console.WriteLine(dog);
                }
                else if(input1 == "Frog")
                {
                    string gender = tokens[2];

                    Frog frog = new Frog(name, age, gender);
                    Console.WriteLine(frog);
                }
                else if(input1 == "Kitten")
                {
                    Kitten k = new Kitten(name, age);
                    Console.WriteLine(k);
                }
                else if(input1 == "Tomcat")
                {
                    Tomcat t = new Tomcat(name, age);
                    Console.WriteLine(t);
                }

            }


        }
    }
}
