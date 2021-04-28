using System;
using System.Collections.Generic;

namespace Chat_Bot
{
    public class Order
    {
        public Dictionary<Sushi, int> itemList;
        public double Price { get; set; }
        public bool Paid { get; set; }
        public bool Closed { get; set; }
        public Guid Id { get; init; }
        public DateTime OpenDate { get; init; }
        public DateTime CloseDate { get; set; }

        public Order()
        {
            Id = new();
            OpenDate = DateTime.Now;
            Paid = false;
            Closed = false;
        }

        internal bool CheckPayment(double money)
        {
            Console.Clear();

            Console.WriteLine($"Стоимость заказа {Price} р");

            if (money > 0 & Price <= money)
            {
                Console.WriteLine($"Заказ оплачен");
                Console.Read();
                return true;
            }
            return false;
        }

        public void CloseOrder()
        {
            Console.WriteLine();
            Closed = true;
            CloseDate = DateTime.Now;
        }

        public void GetInfo()
        {

            Console.Clear();
            Console.WriteLine("Твой последний заказ:");

            foreach (var sushi in itemList) { sushi.Key.GetInfo(sushi.Value); }

            Console.WriteLine();
            Console.WriteLine($"- Стоимость заказа: {Price} р");
            Console.Read();
        }
    }
}
