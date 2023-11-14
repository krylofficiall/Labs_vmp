namespace lab3_4
{
    public class DoublyNode<T>
    {
        public T Data;
        public DoublyNode<T> Prev;
        public DoublyNode<T> Next;
        public DoublyNode(T d)
        {
            Data = d;
            Prev = null;
            Next = null;
        }
    }

    public class DoublyList<T>
    {
        public DoublyNode<T> start;

        public void Push(T data)
        {
            DoublyNode<T> item = new DoublyNode<T>(data);

            if (start != null)
            {
                item.Next = start;
                start.Prev = item;
                start = item;
            }
            else
            {
                start = item;
            }
        }
        public void Add(T data)
        {
            DoublyNode<T> item = new DoublyNode<T>(data);
            if (start != null)
            {
                DoublyNode<T> last = start;
                while (last.Next != null)
                {
                    last = last.Next;
                }
                last.Next = item;
                item.Prev = last;
            }
            else
            {
                start = item;
            }
        }
        public void Removal(T data)
        {
            DoublyNode<T> item = start;
            while (item != null)
            {
                if (data.Equals(item.Data) && item != start && item.Next != null)
                {
                    item.Prev.Next = item.Next;
                    item.Next.Prev = item.Prev;
                }
                if (data.Equals(item.Data) && item == start)
                {
                    start = start.Next;
                }
                if (data.Equals(item.Data) && item.Next == null)
                {
                    item.Prev.Next = null;
                }
                item = item.Next;
            }
        }
        public void Removalitem()
        {
            start = start.Next;
        }
        public void RemovalLast()
        {

            DoublyNode<T> item = start;
            while (item.Next != null)
            {
                item = item.Next;
            }
            item.Prev.Next = null;
        }
        public void Print()
        {
            DoublyNode<T> item = start;
            Console.WriteLine("Вывод очереди: ");
            while (item != null)
            {
                Console.Write(item.Data + " ");
                item = item.Next;
            }
            Console.WriteLine("");
        }
        public int Search(T data)
        {
            DoublyNode<T> item = start;
            int position_number = 0;
            int i = 0;
            while (item != null)
            {
                if (data.Equals(item.Data))
                {
                    position_number = i + 1;
                    Console.Write(position_number + " ");
                }
                item = item.Next;
                i++;
            }
            Console.WriteLine("");
            return position_number;
        }
    }
}
