using System;
using System.Collections.Generic;
using System.Text;

namespace _6.FoodShortage
{
    public class Rebel : IControlable, IBuyer
    {
        private string name;
        private string id;
        private string group;
        private int food;

        public Rebel(string name, string id, string group)
        {
            Name = name;
            Id = id;
            Group = group;
            Food = 0;
        }

        public string Name
        {
            get => this.name;
            set
            {
                this.name = value;
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

        public string Group
        {
            get => this.group;
            set
            {
                this.group = value;
            }
        }

        public int Food
        {
            get => this.food;
            set { this.food = value; }
        }

        public void BuyFood()
        {
            this.Food += 5;
        }
    }
}
