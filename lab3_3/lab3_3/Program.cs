namespace lab3_2
{
    public class Program
    {
        static void Main()
        {
            string answer = "))(()(";
            int brackets = 0;
            int position = -1;
            bool flag = false;
            for (int i = 0; i < answer.Length; i++)
            {
                if (brackets >= 0 && answer[i] == '(')
                {
                    brackets++;
                }
                if (brackets == -1)
                {
                    if (position == -1)
                    {
                        position = i;
                    }
                    brackets++;
                    if (answer[i] == '(')
                    {
                        brackets++;
                    }
                }
                if (answer[i] == ')')
                {
                    brackets--;
                }
                
            }
            if (brackets == 0)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
                if (position != -1)
                {
                    Console.WriteLine($"First excess close brackets in position: {position}");
                }
                if (brackets > 0)
                {
                    Console.WriteLine($"Count of excess open brackets: {brackets}");
                }
            }
        }
    }
}