using System;
using System.Collections.Generic;
using System.Text;

namespace _5.BirthdayCelebrations
{
    public class Citizen : IControlable, IBirthable
    {
        private string name;
        private int age;
        private string id;
        private string birthdate;

        public Citizen(string n, int a, string id, string bd)
        {
            this.Name = n;
            this.Age = a;
            this.Id = id;
            this.Birthdate = bd;
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

        public string Birthdate
        {
            get => this.birthdate;
            set
            {
                this.birthdate = value;
            }
        }

    }
}
