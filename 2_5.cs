using System;

class HelloWorld
{
    static void Main()
    {
        Console.WriteLine("Введите размер матриц");
        int count = Convert.ToInt32(Console.ReadLine());

        int[] array1 = new int[count * count];
        int[] array2 = new int[count * count];
        int[] result = new int[count * count];
        int counter = 0;
        Random rand = new Random();

        Console.WriteLine("Первая матрица:");
        for (int i = 0; i < count*count; i++)
        {
            array1[i] = rand.Next(10);
        }
        for (int i = 0; i < count*count; i+=count)
        {
            for (int j = 0; j < count; j++)
            {
                Console.Write(array1[i+j] + " ");
            }
            Console.Write("\n");
        }

        Console.WriteLine("Вторая матрица:");
        for (int i = 0; i < count * count; i++)
        {
            array2[i] = rand.Next(10);
        }
        for (int i = 0; i < count * count; i += count)
        {
            for (int j = 0; j < count; j++)
            {
                Console.Write(array2[i + j] + " ");
            }
            Console.Write("\n");
        }

        Console.WriteLine("Матрица произведения:");


        for (int i = 0; i < count; i++)
        {
            for (int j = 0; j < count; j++)
            {
                result[i * count + j] = 0;

                for (int k = 0; k < count; k++)
                {
                    result[i * count + j] += array1[i * count + k] * array2[k * count + j];
                }
            }
        }


        for (int i = 0; i < count * count; i += count)
        {
            for (int j = 0; j < count; j++)
            {
                Console.Write(result[i + j] + " ");
            }
            Console.Write("\n");
        }
    }
}
