using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public abstract class Animal //abstract?
    {
        private string name;
        private int age;
        private string gender;
        public string Name { 
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    //throw new ArgumentNullException(nameof(this.name), "Name cannot be null or white space!");
                }
                this.name = value;
            }
        }
        public int Age { 
            get
            {
                return this.age;
            }
            set
            {
                if (age <= 0)
                {
                    //throw new ArgumentException(nameof(this.age), "Age must be positive number!");
                }
                this.age = value;
            }
        }
        public string Gender {
            get 
            { 
                return this.gender;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    //throw new ArgumentNullException(nameof(this.gender), "Gender cannot be null or white space!");
                }
                this.gender = value;
            }
        }

        public Animal(string name, int age, string gender) //protected
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        public abstract string ProduceSound();

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{base.GetType().Name}");
            sb.AppendLine($"{Name} {Age} {Gender}");
            sb.AppendLine($"{ProduceSound()}");

            return sb.ToString().TrimEnd();
        }
    }
}
