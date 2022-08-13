namespace SpaceStation.Models.Bags
{
    using SpaceStation.Models.Bags.Contracts;
    using System.Collections.Generic;

    public class Backpack : IBag
    {
        private readonly List<string> _items;

        public Backpack()
        {
            this._items = new List<string>();
        }

        public ICollection<string> Items => this._items;
    }
}