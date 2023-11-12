using System;

namespace lab3_1
{
    public class my_stack<T>
    {
        private List<T> items = new List<T>();
        public int Count => items.Count;    
        public void Push(T item)
        {
            items.Add(item);
            Console.WriteLine("ok");
        }

        public T Pop()
        {
            var item = top_item();
            items.Remove(item);
            return item;
        }
        public T Back()
        {
            var item = top_item();
            return item;
        }

        private T top_item()
        {
            var item = items.LastOrDefault();
            if (item == null)
            {
                throw new NullReferenceException("Стек пуст.");
            }
            return item;
        }
    }
}
