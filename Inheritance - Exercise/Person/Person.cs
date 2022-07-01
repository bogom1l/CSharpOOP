using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(String.Format($"Name: {this.Name}, Age: {this.Age}")); //without StringFormat?

            return sb.ToString(); //TrimEnd()?
        }
    }
}
