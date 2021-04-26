using Chat_Bot.Interfaces;
using System;
using System.Collections.Generic;

namespace Chat_Bot
{
    class SushiBase : ICRUD<Sushi, User>
    {

        protected internal Dictionary<Sushi, int> _itemList;
        public event BaseChangedEvent<Sushi, User> baseChangedEvent;
        public BaseChangedMessage<Sushi, User> baseChangedMessage;

        public SushiBase() 
        {
            _itemList = new()
            {
                { new Sushi("Сяке-Маке", 100), 99 },
                { new Sushi("Филадельфия", 100), 99 },
                { new Sushi("Суши-Кавасаки", 100), 99 },
                { new Sushi("Хонда-Ролл", 100), 99 },
                { new Sushi("Фукусима-Глоу", 100), 99 },
                { new Sushi("Z", 100), 99 },
                { new Sushi("Субару-Импреза", 99999), 99 },
            };
            baseChangedMessage = EventMethods.SushiBaseChangedMessage;
            baseChangedEvent += EventMethods.SushiBaseChanged;
        }

        public void AddItem(Sushi sushi, User user)
        {
            baseChangedMessage?.Invoke(sushi, user);
            baseChangedEvent?.Invoke(sushi, user);

            foreach (var item in _itemList)
            {
                if (item.Key.Name.Equals(sushi.Name))
                {
                    _itemList[item.Key]++;
                    return;
                }
            }
            _itemList.Add(sushi, 1);
        }

        public void DeleteItem(Sushi sushi, User user)
        {
            baseChangedMessage?.Invoke(sushi, user);

            foreach (var item in _itemList)
            {
                if (item.Key.Name.Equals(sushi.Name))
                {
                    _itemList[item.Key]--;
                    baseChangedEvent?.Invoke(sushi, user);
                    break;
                }
            }
        }

        public Sushi GetItem(Sushi sushi, User user)
        {
            baseChangedMessage?.Invoke(sushi, user);

            foreach (var item in _itemList)
            {
                if (item.Key.Name.Equals(sushi.Name))
                {
                    baseChangedEvent?.Invoke(sushi, user);
                    return item.Key;
                }
            }
            return null;
        }

        public void GetAllItems(User user)
        {
            baseChangedMessage?.Invoke(null, user);
            foreach (var item in _itemList)
            {
                item.Key.GetInfo();
                Console.Write($" осталось {item.Value} \n");
            }
            baseChangedEvent?.Invoke(null, user);
        }
    }
}
