﻿namespace SpaceStation.Models.Planets
{
    using SpaceStation.Models.Planets.Contracts;
    using System;
    using System.Collections.Generic;

    public class Planet : IPlanet
    {
        private string name;
        private readonly List<string> items;

        public Planet(string name)
        {
            this.Name = name;
            this.items = new List<string>();
        }

        public ICollection<string> Items => this.items;

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Invalid name!");
                }
                this.name = value;
            }
        }
    }
}
