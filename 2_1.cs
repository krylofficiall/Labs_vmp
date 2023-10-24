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

        Console.WriteLine("Введите m:");
        int m = Int32.Parse(Console.ReadLine());

        int[] array2 = new int[n];

        Console.WriteLine("Введите массив числовых значений через пробел:");
        string input2 = Console.ReadLine();
        string[] temp2 = input2.Split(new Char[] { ' ' });

        Console.WriteLine("Введите k:");
        int k = Int32.Parse(Console.ReadLine());


        int[] array3 = new int[n+m];
        for (int i = 0; i < k; i++)
        {
            array3[i] = Int32.Parse(temp[i]);
        }


        for (int i = 0; i < m; i++)
        {
            array3[k+i] = Int32.Parse(temp2[i]);
        }

        int counter = 0;
        for (int i = k; i < n; i++)
        {
            array3[k+m+counter] = Int32.Parse(temp[i]);
            counter++;
        }

        //вывод
        Console.WriteLine("Получившийся массив:");
        for (int i = 0; i < n + m; i++)
        {
            Console.Write(array3[i] + " ");
        }
    }
}
