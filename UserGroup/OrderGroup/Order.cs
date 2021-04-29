﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

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
            Clear();

            WriteLine($"Стоимость заказа {Price} р");

            if (money > 0 & Price <= money)
            {
                WriteLine($"Заказ оплачен");
                CloseOrder();
                Paid = true;
                ReadKey();
                return true;
            }
            ReadKey();
            return false;
        }

        async void CloseOrder() => 
            await Task.Run(() => WaitTime());       

        void WaitTime()
        {
            Thread.Sleep(10000);
            Closed = true;
            CloseDate = DateTime.Now;
        }

        public void GetInfo()
        {
            Clear();
            if (itemList.Count > 0)
            {
                WriteLine("Твой последний заказ:");
                foreach (var sushi in itemList) { sushi.Key.GetInfo(sushi.Value); }
                WriteLine($"Открыт {OpenDate}");
                WriteLine($"Закрыт {CloseDate}");
                WriteLine($"- Стоимость заказа: {Price} р");
            }
            WriteLine();
            ReadKey();
        }
    }
}
