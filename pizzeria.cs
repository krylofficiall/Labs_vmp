using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System.Text.Json;
using System.Timers;
using System.Linq;
using System.Text;

namespace pizzeria
{
    internal class Program
    {
        internal interface InterfacePeople
        {
            public int order_count
            {
                get;
                set;
            }
            public int time
            {
                get;
                set;
            }
            public bool task_taken
            {
                get;
                set;
            }
            public bool pizza_taken
            {
                get;
                set;
            }
        }

        internal class Deliver : InterfacePeople
        {
            int count_order = 0;
            public int order_count
            {
                set { count_order = value; }
                get { return count_order; }
            }

            int delivery_speed;
            public int time
            {
                set { delivery_speed = value; }
                get { return delivery_speed; }
            }

            int volumeBackPack;
            public int backpack_weight
            {
                set { volumeBackPack = value; }
                get { return volumeBackPack; }
            }

            int backRack = 0;
            public int BackPack
            {
                set { backRack = value; }
                get { return backRack; }
            }

            bool task = false;
            public bool task_taken
            {
                set { task = value; }
                get { return task; }
            }

            bool pizza_have = false;
            public bool pizza_taken
            {
                set { pizza_have = value; }
                get { return pizza_have; }
            }

            int taskDistanse = 0;
            public void TaskDistans(int pred)
            {
                taskDistanse += pred;
            }

            List<int> numOrders = new List<int>();
            public List<int> NumOrders
            {
                set { numOrders = value; }
                get { return numOrders; }
            }

            public void Delivery()
            {
                while (true)
                {
                    if (task == true)
                    {
                        Thread.Sleep(1000 * delivery_speed * taskDistanse);
                        task = false;
                        taskDistanse = 0;
                    }
                }
            }
        }

        internal class Baker : InterfacePeople
        {
            int count_order = 0;
            public int order_count
            {
                set { count_order = value; }
                get { return count_order; }
            }
            int cook_time;
            public int time
            {
                set { cook_time = value; }
                get { return cook_time; }
            }

            bool task = false;
            public bool task_taken
            {
                set { task = value; }
                get { return task; }
            }

            bool wait = false;
            public bool order_wait
            {
                set { wait = value; }
                get { return wait; }
            }

            bool pizza_have = false;
            public bool pizza_taken
            {
                set { pizza_have = value; }
                get { return pizza_have; }
            }

            public void Cook()
            {
                while (true)
                {
                    if (task == true && wait == false)
                    {
                        Thread.Sleep(1000 * cook_time);
                        task = false;
                    }
                }
            }
        }

        internal class Order
        {
            int numerOrder;
            public int order_number
            {
                set { numerOrder = value; }
                get { return numerOrder; }
            }

            int distanse;
            public int Distanse
            {
                set { distanse = value; }
                get { return distanse; }
            }

            int order_pizza_number;
            public int CountPizze
            {
                set { order_pizza_number = value; }
                get { return order_pizza_number; }
            }

            int order_baker_count = 0;
            public int order_bakers_count
            {
                set { order_baker_count = value; }
                get { return order_baker_count; }
            }

            bool order_baker_done = false;
            public bool baker_done
            {
                set { order_baker_done = value; }
                get { return order_baker_done; }
            }

            int order_baker_take = 0;
            public int baker_take
            {
                set { order_baker_take = value; }
                get { return order_baker_take; }
            }

            bool takeDeliver = false;
            public bool deliver_take
            {
                set { takeDeliver = value; }
                get { return takeDeliver; }
            }
        }

        internal class WaitOrder
        {
            bool wait = false;
            public bool order_wait
            {
                set { wait = value; }
                get { return wait; }
            }

            bool stop = false;
            public bool order_stop
            {
                set { stop = value; }
                get { return stop; }
            }
        }

        static void Main()
        {
            List<Deliver> delivers = new List<Deliver>();
            List<Thread> threads = new List<Thread>();
            List<Baker> bakers = new List<Baker>();
            List<Order> orders = new List<Order>();
            WaitOrder wait = new WaitOrder();
            int pizza_queue = 0;
            int count_order = 0;
            int sumPizze = 0;
            int timeStoke = 0;

            Console.WriteLine("Добро пожаловать в систему управления пиццерией");
            Console.WriteLine("Укажите количество пекарей:");
            Console.Write(">> ");
            int bakers_count = Int32.Parse(Console.ReadLine());

            for (int i = 0; i < bakers_count; i++)
            {
                Baker baker = new Baker();
                Console.Write("Введите время приготовления одной пиццы для " + (i+1).ToString() + "-го пекаря: ");
                baker.time = Int32.Parse(Console.ReadLine());
                bakers.Add(baker);

                Thread t = new Thread(baker.Cook);
                threads.Add(t);
            }

            Console.WriteLine("Данные введены!");
            Console.WriteLine("Укажите количество курьеров: ");
            Console.Write(">> ");
            int deliver_count = Int32.Parse(Console.ReadLine());
            for (int i = 0; i < deliver_count; i++)
            {
                Deliver deliver = new Deliver();
                Console.Write("Введите объем багажника " + (i + 1).ToString() + "-го курьера: ");
                deliver.backpack_weight = Int32.Parse(Console.ReadLine());

                Console.Write("Введите время доставки " + (i + 1).ToString() + "-го курьера: ");
                deliver.time = Int32.Parse(Console.ReadLine());
                delivers.Add(deliver);

                Thread t = new Thread(deliver.Delivery);
                threads.Add(t);
            }

            Console.WriteLine("Укажите объем склада: ");
            Console.Write(">> ");
            int warehouse_size = Int32.Parse(Console.ReadLine());

            //запускаем потоки для всех сотрудников
            for (int i = 0; i < bakers_count + deliver_count; i++)
            {
                threads[i].Start();
            }

            Console.WriteLine("---- Панель управления ----");
            Console.WriteLine("1 - Сделать заказ");
            Console.WriteLine("2 - Закончить смену");
            Console.Write(">> ");

            void WaitOrder()
            {
                while (true)
                {
                    if (wait.order_wait == false)
                    {
                        string answer = Console.ReadLine();
                        if (answer == "2")
                            wait.order_stop = true;
                        wait.order_wait = true;
                    }
                }
            }
            Thread tr = new Thread(WaitOrder);
            tr.Start();

            while (wait.order_stop == false)
            {
                if (wait.order_wait == true)
                {
                    Order order = new Order();
                    int X, order_pizza_number = 0;

                    Console.Write("Введите дистанцию заказа и количество заказанных пицц: ");
                    string[] answer = Console.ReadLine().Split();

                    while (!((int.TryParse(answer[0], out X)) && (int.TryParse(answer[1], out order_pizza_number))))
                        answer = Console.ReadLine().Split("-");

                    int distanse = X;

                    count_order++;
                    order.order_number = count_order;
                    order.Distanse = distanse;
                    order.CountPizze = order_pizza_number;
                    orders.Add(order);
                    Console.WriteLine("Заказ " + order.order_number + " принят");
                    wait.order_wait = false;
                    sumPizze += order_pizza_number;

                    Console.WriteLine("---- Панель управления ----");
                    Console.WriteLine("1 - Сделать заказ");
                    Console.WriteLine("2 - Закончить смену");
                    Console.Write(">> ");
                }

                foreach (Order elem in orders)
                {
                    if (elem.baker_done == false)
                    {
                        foreach (Baker people in bakers) //выбор свободного пекаря
                        {
                            if (people.task_taken == false && sumPizze > 0 && people.pizza_taken == false) //если есть пицца которую не начали готовить
                            {
                                people.task_taken = true; //пекарь берет пиццу и его поток остановливается, после возобновляется
                                people.order_count += 1; //увеличили количество взятых пицц
                                sumPizze--;
                                people.pizza_taken = true;
                            }
                        }

                        foreach (Baker people in bakers)
                        {
                            if (people.task_taken == false && elem.order_bakers_count < elem.CountPizze && people.pizza_taken == true) //пицца приготовлена
                            {
                                people.pizza_taken = false;
                                elem.order_bakers_count++; //увеличиваем количество готовых пицц
                                pizza_queue++;
                                Console.WriteLine("Пицца " +  elem.order_number + " сделана поваром " + elem.order_bakers_count + " для дистанции " + elem.CountPizze + " приготовлена!");
                                //здесь мы должны отнести пиццу на склад, если склад полный, people.wait = true;
                                if (pizza_queue > warehouse_size)
                                {
                                    timeStoke++;
                                    people.order_wait = true; //в таком случае задача на пекаре висит и он не может принять следующий заказ
                                    people.task_taken = true;
                                }
                                if (pizza_queue <= warehouse_size)
                                {
                                    people.order_wait = false;
                                    people.task_taken = false;
                                }

                                if (elem.order_bakers_count == elem.CountPizze) //пекари готовят непрерывно, если есть заказы
                                {
                                    elem.baker_done = true;
                                    Console.WriteLine("Заказ " + elem.order_number + " готов");
                                }
                            }
                        }
                    }
                }

                foreach (Deliver people in delivers)
                {
                    int pred = 0;
                    //дальше заказ берет курьер
                    if (people.task_taken == false && pizza_queue > 0) //
                    {
                        foreach (Order elem in orders)
                        {
                            if (elem.deliver_take == false && elem.baker_done == true && people.BackPack + elem.CountPizze <= people.backpack_weight) //выбираем невзятый заказ курьером, но выполненый пекарем b влезают в рюкзак
                            {
                                elem.deliver_take = true;
                                pizza_queue -= elem.CountPizze;
                                people.TaskDistans(pred);
                                people.task_taken = true; // берет пиццу и его поток остановливается, после возобновляется
                                people.order_count += 1;
                                people.BackPack += elem.CountPizze;
                                people.NumOrders.Add(elem.order_number);
                                people.pizza_taken = true;
                                Console.WriteLine("Заказ " + elem.order_number + " доставлен клиенту");
                            }
                        }
                    }
                }

                foreach (Deliver people in delivers)
                {
                    if (people.task_taken == false && people.pizza_taken == true) //пицца 
                    {
                        people.pizza_taken = false;
                        foreach (Order elem in orders)
                        {
                            if (people.NumOrders.Contains(elem.order_number))
                            {
                                people.BackPack -= elem.CountPizze;
                                Console.WriteLine("Заказ " + elem.order_number + " выполнен");
                            }
                        }
                        people.NumOrders.Clear();
                    }
                }
                //курьеры ожидают появления нового заказа(if order.take==false) , берет у кого в рюкзак влезают пиццы, остановили поток курьера на время S/V
                // закончил доставлять курьер.готов = правда
            }


            if (timeStoke > 0)
                Console.WriteLine("Необходимо расширение склада, тк есть долгое время ожидания");
            else
                Console.WriteLine("Необходимо увеличить количество заказов");

            int max = 0, min = 10000, indexMax = 0, indexMin = 0, j = 0;
            foreach (Baker people in bakers)
            {
                j++;
                if (people.order_count > max)
                {
                    max = people.order_count;
                    indexMax = j;
                }
                if (people.order_count < min)
                {
                    min = people.order_count;
                    indexMin = j;
                }

            }
            Console.WriteLine("Вам нужно нанять " + indexMax + " пекарей и уволить " + indexMin + " пекарей");

            max = 0; min = 10000; indexMax = 0; indexMin = 0; j = 0;
            foreach (Deliver people in delivers)
            {
                j++;
                if (people.order_count > max)
                { max = people.order_count; indexMax = j; }
                if (people.order_count < min)
                { min = people.order_count; indexMin = j; }

            }
            Console.WriteLine("Вам нужно нанять " + indexMax + " курьеров и уволить " + indexMin + " курьеров");
        }
    }
}