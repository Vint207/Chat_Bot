using Chat_Bot.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Chat_Bot
{
    class OrderBase : ICRUD<Order, User>
    {
        List<Order> _itemList;
        public event BaseChangedEvent<Sushi, User> baseChangedEvent;
        public BaseChangedMessage<Sushi, User> baseChangedMessage;

        public OrderBase()
        {
            _itemList = new();
            baseChangedMessage = EventMethods.OrderBaseChangedMessage;
            baseChangedEvent += EventMethods.OrderBaseChanged;
        }

        public void AddItem(Order order, User user)
        {
            _itemList.Add(order);
            baseChangedEvent?.Invoke(order._itemList.Last().Key, user);
        }

        public void DeleteItem(Order order, User user)
        {
            baseChangedEvent?.Invoke(order._itemList.Last().Key, user);
            _itemList.Remove(order);
        }

        public Order GetItem(Order order, User user)
        {
            baseChangedEvent?.Invoke(order._itemList.Last().Key, user);

            foreach (var item in _itemList)
            {
                if (item.Id.Equals(order.Id)) { return item; }
            }
            return null;
        }

        public Order GetLastOrder()
        {
            return _itemList.Last();
        }
    }
}
