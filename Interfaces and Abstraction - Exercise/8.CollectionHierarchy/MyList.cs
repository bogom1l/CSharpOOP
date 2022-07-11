using _8.CollectionHierarchy.Models.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace _8.CollectionHierarchy
{
    public class MyList<T> : IMyList<T>
    {
        private readonly List<T> data;

        public MyList()
        {
            this.data = new List<T>();
        }

        public int Used { get; set; }

        public int Add(T item)
        {
            this.data.Insert(0, item);
            return 0;
        }

        public T Remove()
        {
            T elementToRemove = this.data.FirstOrDefault();

            if (elementToRemove != null)
            {
                this.data.Remove(elementToRemove); //RemoveAt(0);
            }
            
            return elementToRemove;
        }
    }
}
