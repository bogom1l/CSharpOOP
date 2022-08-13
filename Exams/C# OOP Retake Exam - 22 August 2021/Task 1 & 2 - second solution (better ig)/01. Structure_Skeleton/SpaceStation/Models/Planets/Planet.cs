namespace SpaceStation.Models.Planets
{
    using SpaceStation.Models.Planets.Contracts;
    using System;
    using System.Collections.Generic;

    public class Planet : IPlanet
    {
        private string _name;
        private readonly List<string> _items;

        public Planet(string name)
        {
            this._items = new List<string>();
            this.Name = name;
        }

        public ICollection<string> Items => this._items;

        public string Name
        {
            get => this._name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Invalid name!");
                }

                this._name = value;
            }
        }

    }
}
