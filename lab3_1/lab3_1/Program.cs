using System;
using System.Text.RegularExpressions;

namespace lab3_1
{
    public class Program
    {
        static void Main(string[] args)
        {
            my_stack stack = new my_stack();

            string answer = "";

            while (answer != "exit")
            {
                answer = Console.ReadLine();
                
                if (answer.Split().First() == "push")
                {
                    stack.Push(int.Parse(answer.Split().Last()));
                    Console.WriteLine("ok");
                }
                if (answer == "pop")
                {
                    var item_pop = stack.Pop();
                    Console.WriteLine(item_pop);
                }
                if (answer == "back")
                {
                    Console.WriteLine(stack.Back());
                }
                if (answer == "size")
                {
                    Console.WriteLine(stack.Size());
                }
                if (answer == "clear")
                {
                    stack.Clear();
                    Console.WriteLine("ok");
                }
            }
            Console.WriteLine("bye");
        }
    }
}