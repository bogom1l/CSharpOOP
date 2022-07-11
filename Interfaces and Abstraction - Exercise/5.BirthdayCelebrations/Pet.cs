using System;
using System.Collections.Generic;
using System.Text;

namespace _5.BirthdayCelebrations
{
    public class Pet : IBirthable
    {
        private string name;
        private string birthdate;

        public Pet(string name, string birthdate)
        {
            Name = name;
            Birthdate = birthdate;
        }

        public string Name
        {
            get => this.name;
            set
            {
                this.name = value;
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
