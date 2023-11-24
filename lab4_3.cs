using System;
using System.Collections.Generic;

namespace lab4_3
{
    class Program
    {

        class Array
        {
            private List<int> array = new List<int>();
            private int array_size;
            public Array(int count)
            {
                array_size = count;
                array = new List<int>(count);
            }
            public int Size()
            {
                return array_size;
            }
            public void InputData(int item)
            {
                array.Add(item);
            }
            public void InputDataRandom()
            {
                Random random = new Random();
                for (int i = 0; i < array_size; i++)
                {
                    array.Add(random.Next(100));
                }
            }
            public List<int> Print(ref int lower_border, ref int upper_border)
            {
                List<int> printed_tems = new List<int>();
                if (lower_border >= 0 && lower_border < array_size && lower_border < upper_border && upper_border >= 0 && upper_border < array_size)
                {
                    for (int i = lower_border; i <= upper_border; i++)
                    {
                        printed_tems.Add(array[i]);
                    }
                }
                else
                {
                    return null;
                }
                return printed_tems;
            }
            public List<int> FindValue(int item_to_find)
            {
                List<int> founded_items = new List<int>();

                for (int i = 0; i < array_size; i++)
                {
                    if (array[i] == item_to_find)
                    {
                        founded_items.Add(i);
                    }
                }
                return founded_items;
            }
            public void DelValue(int item_to_delete)
            {
                List<int> undeleted_items = new List<int>(array_size);
                for (int i = 0; i < array_size; i++)
                {
                    if (array[i] != item_to_delete)
                    {
                        undeleted_items.Add(array[i]);
                    }
                }
                array_size = undeleted_items.Count;
                array = undeleted_items;
            }
            public int FindMax()
            {
                int max_item = array[0];
                for (int i = 0; i < array_size; i++)
                {
                    if (array[i] > max_item)
                    {
                        max_item = array[i];
                    }
                }
                return max_item;
            }
            public List<int> Add()
            {
                Random random = new Random();
                List<int> added_array = new List<int>(array_size);
                for (int i = 0; i < array_size; i++)
                    added_array.Add(array[i] + random.Next(100));
                return added_array;
            }
            public void Sort()
            {
                //сортировка пузырьком
                int bubble;
                for (var i = 1; i < array_size; i++)
                {
                    for (var j = 0; j < array_size - i; j++)
                    {
                        if (array[j] > array[j + 1])
                        {
                            bubble = array[j];
                            array[j] = array[j + 1];
                            array[j + 1] = bubble;
                        }
                    }
                }
            }

        }

        static void Main(string[] args)
        {
            Console.Write("Укажите размер массива: ");
            int array_count = Int32.Parse(Console.ReadLine());
            Array my_array = new Array(array_count);
            string answer = "";
            Console.WriteLine("Введите help чтобы увидеть список команд");

            while (answer != "exit")
            {
                Console.Write(">> ");
                answer = Console.ReadLine();
                if (answer == "help")
                {
                    Console.WriteLine("fill user - Заполнение массива пользователем");
                    Console.WriteLine("fill rand - Заполнение массива рандомными значениями");
                    Console.WriteLine("size - Вывести размер массива");
                    Console.WriteLine("print - Вывести массив из диапазона");
                    Console.WriteLine("find - Вывести список индексов для введенного элемента");
                    Console.WriteLine("del - Удалить все элементы с данным значением");
                    Console.WriteLine("max - Вывести максимальное значение массива");
                    Console.WriteLine("add - Сложить с массивом одинаковой длины");
                    Console.WriteLine("sort - Выполнить сортировку по возрастанию");
                    Console.WriteLine("exit - Выйти из программы");
                }
                else if (answer == "fill user"){
                    Console.WriteLine("Введите массив поэлементно по строкам");
                        for (int i = 1; i <= array_count; i++)
                        {
                            int array_item = Int32.Parse(Console.ReadLine());
                            my_array.InputData(array_item);
                        }
                        Console.WriteLine("Массив заполнен!");
                }
                else if (answer == "fill rand")
                {
                    my_array.InputDataRandom();
                    Console.WriteLine("Массив заполнен!");
                }
                else if (answer == "size")
                {
                    Console.WriteLine(my_array.Size());
                }
                else if (answer == "print")
                {
                    Console.WriteLine("Введите нижнюю и верхнюю границы через пробел");
                    string borders = Console.ReadLine();
                    int lower_border = Int32.Parse(borders.Split().First());
                    int upper_border = Int32.Parse(borders.Split().Last());
                    Console.WriteLine(String.Join(" ", my_array.Print(ref lower_border, ref upper_border)));
                }
                else if (answer == "del")
                {
                    Console.WriteLine("Введите элемент, который нужно удалить: ");
                    int item_del = Int32.Parse(Console.ReadLine());
                    my_array.DelValue(item_del);
                    Console.WriteLine("Элемент удален!");
                }
                else if (answer == "find")
                {
                    Console.Write("Введите элемент, индекс которого нужно найти: ");
                    int item_find = Int32.Parse(Console.ReadLine());
                    Console.WriteLine(String.Join(" ", my_array.FindValue(item_find)));
                }
                else if (answer == "max")
                {
                    Console.WriteLine(my_array.FindMax());
                }
                else if (answer == "add")
                {
                    Console.WriteLine(String.Join(" ", my_array.Add()));
                }
                else if (answer == "sort")
                {
                    my_array.Sort();
                    Console.WriteLine("Сортировка завершена!");
                }
                else
                {
                    Console.WriteLine("Неизвестная команда");
                }
            }
        }
    }
}
