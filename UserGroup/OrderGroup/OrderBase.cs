using Chat_Bot.Interfaces;
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

        public void AddItem(Order order, User user)
        {
            _itemList.Add(order);
            baseChangedEvent?.Invoke(order, user);
        }

        public void DeleteItem(Order order, User user)
        {
            baseChangedEvent?.Invoke(order, user);
            _itemList.Remove(order);
        }

        public Order GetItem(Order order, User user)
        {
            baseChangedEvent?.Invoke(order, user);

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
