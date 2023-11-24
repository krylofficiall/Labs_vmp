using System;

namespace lab4_1
{
    class Program
    {

        static int min(ref int[] input_array)
        {
            int minimum = input_array[0];
            for (int i = 1; i < input_array.Length; i++)
            {
                if (input_array[i] <= minimum)
                {
                    minimum = input_array[i];
                }
            }
            return minimum;
        }
        static int max(ref int[] input_array)
        {
            int maximum = 0;
            for (int i = 0; i < input_array.Length; i++)
            {
                if (input_array[i] > maximum)
                {
                    maximum = input_array[i];
                }
            }
            return maximum;
        }
        static int sum(ref int[] input_array)
        {
            int summ = 0;
            for (int i = 0; i < input_array.Length; i++)
            {
                summ += input_array[i];
            }
            return summ;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество строк");
            int count_strokes = Int32.Parse(Console.ReadLine());
            string stroke = "";
            string answer = "";
            int[][] array = new int[count_strokes][];
            for (int i = 0; i < count_strokes; i++)
            {
                stroke = Console.ReadLine() + ' ';
                string item = "";
                int value = 0;
                bool space = false;
                int[] array_current = new int[stroke.Length];

                for (int j = 0; j < stroke.Length; j++)
                {
                    if (stroke[j] != ' ')
                    {
                        item += stroke[j];
                    }
                    else
                    {
                        if (int.TryParse(item, out int number))
                        {
                            array_current[value] = Int32.Parse(item);
                            value++;
                        }
                        else
                        {
                            if (item != "")
                            {
                                array_current[value] = 0;
                                value++;
                            }
                        }
                        item = "";
                    }
                }
                Array.Resize(ref array_current, value);
                array[i] = array_current;
            }
            for (int i = 0; i < count_strokes; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < array[i].Length; j++)
                    Console.Write(array[i][j].ToString() + " ");
            }

            while (answer != "exit")
            {
                Console.WriteLine("");
                Console.WriteLine("--------------------------");
                Console.WriteLine("Введите команду");
                Console.WriteLine(">> sum - показать сумму");
                Console.WriteLine(">> min - показать минимум");
                Console.WriteLine(">> max - показать максимум");
                Console.WriteLine(">> exit - выход");
                answer = Console.ReadLine();

                if (answer == "sum")
                {
                    int num = 1;
                    for (int i = 0; i < count_strokes; i++)
                    {
                        Console.WriteLine(num.ToString() + " - " + sum(ref array[i]));
                        num++;
                    }
                }
                if (answer == "min")
                {
                    int num = 1;
                    for (int i = 0; i < count_strokes; i++)
                    {
                        Console.WriteLine(num.ToString() + " - " + min(ref array[i]));
                        num++;
                    }
                }
                if (answer == "max")
                {
                    int num = 1;
                    for (int i = 0; i < count_strokes; i++)
                    {
                        Console.WriteLine(num.ToString() + " - " + max(ref array[i]));
                        num++;
                    }
                }

            }
        }
    }
}
