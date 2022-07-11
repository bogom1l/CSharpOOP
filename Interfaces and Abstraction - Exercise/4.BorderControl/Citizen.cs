using System;
using System.Collections.Generic;
using System.Text;

namespace _4.BorderControl
{
    public class Citizen : IControlable
    {
        private string name;
        private int age;
        private string id;

        public Citizen(string n, int a, string id)
        {
            this.Name = n;
            this.Age = a;
            this.Id = id;
        }

        public string Name
        {
            get => this.name;
            set
            {
                this.name = value;
            }
        }

        public int Age
        {
            get => this.age;
            set
            {
                this.age = value;
            }
        }

        public string Id
        {
            get => this.id;
            set
            {
                this.id = value;
            }
        }
    }
}
