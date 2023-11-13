using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3_2
{
    public class item
    {
        public int Value { get; }
        public item Next { get; set; }
        public item(int value)
        {
            Value = value;
        }
    }
    public class my_queue
    {
        private item last;
        private int size = 0;

        public void Push(int value)
        {
            item new_item = new item(value);
            item last_item = last;
            if (size > 0)
            {
                for (int i = 0; i < size; i++)
                {
                    if (last_item.Next != null)
                    {
                        last_item = last_item.Next;
                    }
                    else
                    {
                        last_item.Next = new_item;
                    }
                }

            }
            else
            {
                last = new_item;
            }
            size++;
        }
        public int Pop()
        {
            int value = last.Value;
            last = last.Next;
            size--;
            return value;
        }
        public int Front()
        {
            return last.Value;
        }
        public int Size()
        {
            return size;
        }
        public void Clear()
        {
            last = null;
            size = 0;
        }
    }
}
