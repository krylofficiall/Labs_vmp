using System;

namespace lab3_1
{
    public class item
    {
        public int Value { get; } //выделение места для хранения данных
        public item Next { get; set; } //следующий элемент
        public item(int value)
        {
            Value = value; //записываем информацию в место для данных
        }
    }
    public class my_stack
    {
        private item last; //последний элемент
        private int size = 0;

        public void Push(int value)
        {
            item new_item = new item(value);
            new_item.Next = last;
            last = new_item;
            size++;
        }

        public int Pop()
        {
            int value = last.Value;
            last = last.Next;
            size--;
            return value;

        }

        public int Back()
        {
            return last.Value;
        }
        public int Size()
        {
            return size;
        }
        public void Clear()
        {
            size = 0;
            last = null;
        }
    }
}
