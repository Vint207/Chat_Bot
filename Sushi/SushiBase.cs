using Chat_Bot.Interfaces;
using System;
using System.Collections.Generic;

namespace Chat_Bot
{
    public class SushiBase : ICRUD<Sushi, User>
    {

        public Dictionary<Sushi, int> itemList;
        public event BaseChangedEvent<Sushi, User> baseChangedEvent;
        public BaseChangedMessage<Sushi, User> baseChangedMessage;

        public SushiBase()
        {
            itemList = new()
            {
                { new Sushi("Сяке-Маке", 100), 99 },
                { new Sushi("Филадельфия", 100), 99 },
                { new Sushi("Суши-Кавасаки", 100), 99 },
                { new Sushi("Хонда-Ролл", 100), 99 },
                { new Sushi("Фукусима-Глоу", 100), 99 },
                { new Sushi("Гуро-Харакири", 100), 99 },
                { new Sushi("Z", 100), 99 },
                { new Sushi("Субару-Импреза", 99999), 99 },
            };
        }

        public bool AddItem(Sushi sushi, User user)
        {
            baseChangedMessage?.Invoke(sushi, user);

            foreach (var item in itemList)
            {
                if (item.Key.Name.Equals(sushi?.Name))
                {
                    itemList[item.Key]++;
                    return true;
                }
            }
            if (sushi != null)
            {
                itemList.Add(sushi, 1);
                baseChangedEvent?.Invoke(sushi, user);
                return true;
            }
            return false;
        }

        public bool DeleteItem(Sushi sushi, User user)
        {
            baseChangedMessage?.Invoke(sushi, user);

            foreach (var item in itemList)
            {
                if (item.Key.Name.Equals(sushi?.Name))
                {
                    itemList[item.Key]--;
                    baseChangedEvent?.Invoke(sushi, user);
                    return true;
                }
            }
            return false;
        }

        public Sushi GetItem(Sushi sushi, User user)
        {
            baseChangedMessage?.Invoke(sushi, user);

            foreach (var item in itemList)
            {
                if (item.Key.Name.Equals(sushi?.Name))
                {
                    baseChangedEvent?.Invoke(sushi, user);
                    return item.Key;
                }
            }
            Console.WriteLine("Таких суши нет, попробуй другие");
            return null;
        }

        public bool GetAllItems(User user)
        {
            baseChangedMessage?.Invoke(null, user);

            foreach (var item in itemList) { item.Key.GetInfo(item.Value); }

            baseChangedEvent?.Invoke(null, user);

            return true;
        }

        public List<string> GetListItems(User user)
        {
            baseChangedMessage?.Invoke(null, user);

            List<string> sushiList = new();

            foreach (var item in itemList) { sushiList.Add($" {item.Key.Name}. Цена {item.Key.Price} р. Количество {item.Value} шт"); }

            baseChangedEvent?.Invoke(null, user);

            return sushiList;
        }
    }
}
