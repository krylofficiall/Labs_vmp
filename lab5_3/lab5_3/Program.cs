using System;
using System.Collections;
using System.Collections.Generic;

namespace lab5_3
{
    abstract class Figure
    {
        private string figure_name;
        public Figure(string Name)
        {
            figure_name = Name;
        }
        public string Name
        {
            get 
            {
                return figure_name;
            }
            set
            {
                figure_name = value;
            }
        }

        public abstract double Area2
        {
            get;
            set;
        }

        public abstract double Area();

        public virtual ArrayList Print()
        {
            ArrayList list = new ArrayList();
            list.Add(figure_name);
            return list;
        }
    }
    class Triangle : Figure
    {
        private int а, b, c;
        private double s;

        public Triangle(string Name, int A, int B, int C)
            : base(Name)
        {
            а = A;
            b = B;
            c = C;
        }

        public void SetABC(int A, int B, int C)
        {
            а = A;
            b = B;
            c = C;
        }

        public void GetABC(ref int A, ref int B, ref int C)
        {
            а = A;
            b = B;
            c = C;
        }

        public override double Area2
        {
            get
            {
                return s;
            }
            set
            {
                s = value;
            }
        }

        public override double Area()
        {
            float p = (а + b + c) / 2;
            s = Math.Sqrt(p * (p - а) * (p - b) * (p - c));
            return s;
        }

        public override ArrayList Print()
        {
            ArrayList items = new ArrayList();
            items = base.Print();
            s = this.Area();
            items.Add(s);
            return items;
        }
    }
    class TriangleColor : Triangle
    {
        private string figure_color;
        public TriangleColor(string Name, int A, int B, int C, string Color)
            : base(Name, A, B, C)
        {
            figure_color = Color;
        }

        public string Color
        {
            get
            {
                return figure_color;
            }
            set
            {
                figure_color = value;
            }
        }

        public override double Area2
        {
            get
            {
                return base.Area2;
            }
            set
            {
                base.Area2 = value;
            }
        }

        public override double Area()
        {
            return base.Area();
        }

        public override ArrayList Print()
        {
            ArrayList list = new ArrayList();
            list = base.Print();
            list.Add(figure_color);
            return list;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ввод фигуры");
            Console.Write("Введите название фигуры: ");
            string figure_name = Console.ReadLine();
            Console.Write("Введите длину стороны 1: ");
            int а = Int32.Parse(Console.ReadLine());
            Console.Write("Введите длину стороны 2: ");
            int b = Int32.Parse(Console.ReadLine());
            Console.Write("Введите длину стороны 3: ");
            int c = Int32.Parse(Console.ReadLine());
            Console.Write("Введите цвет фигуры: ");
            string figure_color = Console.ReadLine();

            TriangleColor triangle = new TriangleColor(figure_name, а, b, c, figure_color);
            Console.WriteLine("Данные о фигуре: ");
            foreach (object item in triangle.Print())
                Console.WriteLine(item);
        }
    }
}
