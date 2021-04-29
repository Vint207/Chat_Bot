using Chat_Bot.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chat_Bot
{
    class OrderBase : ICRUD<Order, User>
    {
        List<Order> _itemList;
        public event BaseChangedEvent<Order, User> baseChangedEvent;
        public BaseChangedMessage<Order, User> baseChangedMessage;

        public OrderBase() { _itemList = new(); }

        public bool AddItem(Order order, User user)
        {
            if (order != null)
            {
                _itemList.Add(order);

                Console.WriteLine();
                baseChangedEvent?.Invoke(order, user);

                return true;
            }
            return false;
        }

        public bool DeleteItem(Order order, User user)
        {
            baseChangedEvent?.Invoke(order, user);

            _itemList.Remove(order);

            return true;
        }

        public Order GetItem(Order order, User user)
        {
            baseChangedEvent?.Invoke(order, user);

            foreach (var item in _itemList)
            {
                if (item.Id.Equals(order?.Id)) { return item; }
            }
            return null;
        }

        public void AddOrder(User user)
        {
            Console.Clear();

            if (user.bin.itemList.Count > 0)
            {
                AddItem(new() { Price = user.bin.Price, itemList = user.bin.itemList }, user);
                Console.WriteLine("Заказ сформирован");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Заказ не был сформирован");
            Console.ReadKey();
        }

        public Order GetLastOrder()
        {
            Console.Clear();

            if (_itemList.Count > 0)
            {
                Order order = _itemList?.Last();
                Console.ReadKey();
                return order;
            }
            Console.WriteLine("Список заказов пуст");
            Console.ReadKey();
            return null;
        }
    }
}
