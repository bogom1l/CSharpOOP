using System;
using System.Collections.Generic;
using System.Text;

namespace _9.ExplicitInterfaces
{
    public class Citizen : IResident, IPerson
    {
        private string name;
        private string country;
        private int age;

        public Citizen(string n, string c, int a)
        {
            this.Name = n;
            this.Age = a;
            this.Country = c;
        }
        public string Name { get; set; }

        public string Country { get; set; }

        public int Age { get; set; }

        string IResident.GetName()
        {
            return $"Mr/Ms/Mrs {this.Name}";
        }

        string IPerson.GetName()
        {
            return this.Name;
        }

    }
}
