namespace lab3_4
{
    public class Program
    {
        static void Main(string[] args)
        {
            DoublyList<int> list = new DoublyList<int>();
            string answer = "";
            while (answer != "exit")
            {
                answer = Console.ReadLine();
                if (answer.Split().First() == "search")
                {
                    list.Search(int.Parse(answer.Split().Last()));
                }
                if (answer.Split().First() == "push")
                {
                    list.Push(int.Parse(answer.Split().Last()));
                    Console.WriteLine("ok");
                }
                if (answer.Split().First() == "add")
                {
                    list.Add(int.Parse(answer.Split().Last()));
                    Console.WriteLine("ok");
                }
                if (answer.Split().First() == "print")
                {
                    list.Print();
                }
                if (answer.Split().First() == "del")
                {
                    if (answer.Split().Last() == "start")
                    {
                        list.Removalitem();
                        Console.WriteLine("ok");
                    }
                    if (answer.Split().Last() == "last")
                    {
                        list.RemovalLast();
                        Console.WriteLine("ok");
                    }
                    else
                    {
                        list.Removal(int.Parse(answer.Split().Last()));
                        Console.WriteLine("ok");
                    }
                }
            }
        }
    }
}