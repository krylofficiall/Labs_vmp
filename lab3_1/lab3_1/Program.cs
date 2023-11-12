using System;
using System.Text.RegularExpressions;

namespace lab3_1
{
    public class Program
    {
        static void Main(string[] args)
        {
            var stack = new my_stack<int>();
            void clear()
            {
                int stack_size = stack.Count;
                for (int i = 0; i < stack_size; i++)
                {
                    stack.Pop();
                }
                Console.WriteLine("ok");
            }

            string answer = "";
            while (answer != "exit")
            {
                answer = Console.ReadLine();
                if (answer.Split().First() == "push")
                {
                    stack.Push(int.Parse(answer.Split().Last()));
                }
                if (answer == "size")
                {
                    Console.WriteLine($"{stack.Count}");
                }
                if (answer == "back")
                {
                    var item_back = stack.Back();
                    Console.WriteLine($"{item_back}");
                }
                if (answer == "pop")
                {
                    var item_pop = stack.Pop();
                    Console.WriteLine($"{item_pop}");
                }
                if (answer == "clear")
                {
                    clear();
                }
            }
            Console.WriteLine("bye");
        }
    }
}