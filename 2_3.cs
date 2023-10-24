using System;

class HelloWorld
{
    static void show(int[] a)
    {
        // displaying the array elements
        for (int i = 0; i < a.Length; i++)
        {
            Console.Write(a[i] + " ");
        }
    }
    static void Main(string[] args)
    {

        int[] initialization(int n)
        {
            int[] a = new int[n];
            for (int i = 0; i < n; i++)
            {
                Random rand = new Random();
                int value = rand.Next(1,100);
                a[i] = value;
            }
            return a;
        }
        int sum(int v1, int v2)
        {
            return v1 + v2;
        }
        int multiply(int v1, int v2)
        {
            return v1 * v2;
        }
        int[] same(int[] a1, int[] a2, int n, int m)
        {
            int[] nums = new int[n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (a1[i] == a2[j])
                        if (!nums.Contains(a1[i]))
                            nums[i] = a1[i];
                }
            }
            return nums;
        }
        void raise(int[] a, int n)
        {
            for(int i = 0; i < n-1; i++)
            {
                for(int j = i + 1; j < n; j++)
                {
                    if (a[i] < a[j])
                    {
                        int x = a[j];
                        a[j] = a[i];
                        a[i] = x;
                    }
                }
            }
        }
        int a_min(int[] a)
        {
            int min = a[0];
            for (int i = 0; i < a.Length; i++)
            {
                min = Math.Min(min, a[i]);
            }
            return min;
        }
        int a_max(int[] a)
        {
            int max = a[0];
            for (int i = 0; i < a.Length; i++)
            {
                max = Math.Max(max, a[i]);
            }
            return max;
        }
        int a_average(int[] a)
        {
            int summary = 0;
            for (int i = 0; i < a.Length; i++)
            {
                summary += a[i];
            }
            return summary/a.Length;
        }

        Console.Write("Введите длину первого массива: ");
        int n = Int32.Parse(Console.ReadLine());
        Console.Write("Введите длину второго массива: ");
        int m = Int32.Parse(Console.ReadLine());
        int[] array1 = new int[n];
        int[] array2 = new int[m];
        int[] both = new int[n];
        int both_counter = 0;
        string answer = "";


        while (answer != "exit")
        {
            Console.WriteLine();
            Console.Write(">> ");
            answer = Console.ReadLine();

            if (answer == "1")
            {
                Console.Write("Массив заполнен случайными числами!");
                array1 = initialization(n);
                array2 = initialization(m);
            }
            if (answer == "2")
            {
                if (n == m)
                {
                    Console.WriteLine("Массивы равны по длине. Выполняется сложение.");
                    Console.Write("Массив при сложении: ");
                    for (int i = 0; i < n; i++)
                    {
                        Console.Write(sum(array1[i], array2[i]) + " ");
                    }
                }
                else
                {
                    Console.Write("Массивы не равны по длине.");
                }
            }
            if (answer == "3")
            {
                Console.Write("Введите множитель для умножения на массив: ");
                int multiplier = Int32.Parse(Console.ReadLine());
                Console.WriteLine();
                for (int i = 0; i < n; i++)
                {
                    Console.Write(multiply(array1[i], multiplier) + " ");
                }
            }
            if (answer == "4")
            {
                Console.Write("Одинаковые значения в массивах: ");

                int[] num = new int[n];
                num = same(array1, array2, n, m); ;
                foreach (var i in num)
                {
                    if (i != 0)
                    {
                        Console.Write(i + " ");
                    }
                }
            }
            if (answer == "5")
            {
                Console.Write("Первый массив: ");
                show(array1);
                Console.WriteLine("");
                Console.Write("Второй массив: ");
                show(array2);
            }
            if (answer == "6")
            {
                Console.WriteLine("Упорядоченный массив:");
                int[] raising_array = array1;
                raise(raising_array, n);
                show(raising_array);
            }
            if (answer == "7")
            {
                Console.Write("Минимальное значение: " + a_min(array1) + "\n");
                Console.Write("Максимальное значение: " + a_max(array1) + "\n");
                Console.Write("Среднее арифметическое значение: " + a_average(array1) + "\n");
            }
        }

    }
}
