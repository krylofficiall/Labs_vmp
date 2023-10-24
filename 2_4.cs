using System;
class HelloWorld
{
    static void Main()
    {
        int[] array = new int[2];
        string input = Console.ReadLine();
        string[] temp = input.Split(new Char[] { ' ' });

        int[,] nums = new int[Int32.Parse(temp[0]), Int32.Parse(temp[1])];

        for (int i = 0; i < Int32.Parse(temp[0]); i++)
        {
            string input1 = Console.ReadLine();
            string[] temp1 = input1.Split(new Char[] { ' ' });

            for (int j = 0; j < Int32.Parse(temp[1]); j++)
            {
                nums[i, j] = Int32.Parse(temp1[j]);
            }
        }

        int k = Int32.Parse(Console.ReadLine());
        int min_row = 0;
        int count = 0;
        for (int i = 0; i < Int32.Parse(temp[0]); i++)
        {
            if (k > 1)
            {
                for (int j = 0; j < Int32.Parse(temp[1]) - 1; j++)
                {
                    if (nums[i, j] == 0 && nums[i, j + 1] == 0)
                    {
                        if (count == 0)
                        {

                            count = 2;
                        }
                        else
                        {
                            count++;
                        }
                    }
                }
            }
            if (k == 1)
            {
                for (int j = 0; j < Int32.Parse(temp[1]); j++)
                {
                    if (nums[i, j] == 0 && count == 0)
                    {
                        count++;
                    }
                }
            }
            
            if (count > 0)
            {
                if (count >= k && min_row == 0)
                {
                    min_row = i+1;
                    count = 0;
                }
            }
        }
        Console.WriteLine(min_row);
    }
}
