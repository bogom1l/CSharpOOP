using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            if (this.Count == 0)
            {
                return true;
            }

            return false;
        }

        public void AddRange(Stack<string> range)
        {
            while(range.Count > 0)
            {
                this.Push(range.Pop());
            }
        }

    }
}
