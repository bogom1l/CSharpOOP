using _8.CollectionHierarchy.Models.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace _8.CollectionHierarchy
{
    public class AddRemoveCollection<T> : IAddRemoveCollection<T>
    {
        private readonly List<T> data;

        public AddRemoveCollection()
        {
            this.data = new List<T>();
        }

        public int Add(T item)
        {
            this.data.Insert(0, item);
            return 0;
        }

        public T Remove()
        {
            T elementToRemove = this.data.LastOrDefault();

            if (elementToRemove != null)
            {
                this.data.Remove(elementToRemove);
            }

            return elementToRemove;
        }
    }
}
