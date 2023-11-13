namespace lab3_2
{
    public class Program
    {
        static void Main(string[] args)
        {
            my_queue queue = new my_queue();
            string answer = "";

            while (answer != "exit")
            {
                answer = Console.ReadLine();
                if (answer.Split().First() == "push")
                {
                    queue.Push(int.Parse(answer.Split().Last()));
                    Console.WriteLine("ok");
                }
                if (answer == "pop")
                {
                    var item_pop = queue.Pop();
                    Console.WriteLine(item_pop);
                }
                if (answer == "front")
                {
                    Console.WriteLine(queue.Front());
                }
                if (answer == "size")
                {
                    Console.WriteLine(queue.Size());
                }
                if (answer == "clear")
                {
                    queue.Clear();
                    Console.WriteLine("ok");
                }
            }
            Console.WriteLine("bye");
        }

    }

}
