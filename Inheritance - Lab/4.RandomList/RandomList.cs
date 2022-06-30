using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        public string RandomString()
        {
            Random rand = new Random();
            int randomIndex = rand.Next(0, this.Count - 1);
            string stringToRemove = this[randomIndex]; //base[index]
            this.RemoveAt(randomIndex);
            return stringToRemove;
        }

    }
}
