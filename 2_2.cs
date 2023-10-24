using System;
class HelloWorld
{
    static void Main()
    {
        Console.WriteLine("Введите n:");
        int n = Int32.Parse(Console.ReadLine());

        int[] array = new int[n];

        Console.WriteLine("Введите массив числовых значений через пробел:");
        string input = Console.ReadLine();
        string[] temp = input.Split(new Char[] { ' ' });

        for (int i = 0; i < n; i++)
        {
            array[i] = Int32.Parse(temp[i]);
        }

        int transfer = 0;

        if (n % 2 == 0)
        {
            Console.WriteLine("Массив четный");
            for (int i = 0; i < n/2; i++)
            {
                transfer = array[i];
                array[i] = array[i + n / 2];
                array[i + n / 2] = transfer;
            }

            Console.WriteLine("Зеркальный массив:");
            for (int i = 0; i < n; i++)
            {
                Console.Write(array[i] + " ");
            }
        }
        else
        {
            Console.WriteLine("Массив нечетный");
            for (int i = 0; i < (n - 1) / 2; i++)
            {
                transfer = array[i];
                array[i] = array[i  + ((n - 1) / 2)];
                array[i + ((n - 1) / 2)] = transfer;
            }

            Console.WriteLine("Зеркальный массив:");
            for (int i = 0; i < n; i++)
            {
                Console.Write(array[i] + " ");
            }
        }

    }
}
