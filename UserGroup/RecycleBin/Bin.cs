using System;
using System.Collections;

namespace Chat_Bot
{
    class Bin : SushiBase
    {

        public double Price { get; set; }
        //public  event BaseChangedEvent<Sushi, User> baseChangedEvent;
        //public  BaseChangedMessage<Sushi, User> baseChangedMessage;

        public Bin()
        { 
            _itemList = new();
            baseChangedMessage = EventMethods.BinBaseChangedMessage;
            baseChangedEvent += EventMethods.BinBaseChanged;
        }

        public void AddItemToBin(Sushi sushi, User user)
        {
            AddItem(sushi, user);
            Price += sushi.Price;
        }

        public void DeleteItemFromBin(Sushi sushi, User user)
        {
            DeleteItem(sushi, user);
            Price -= sushi.Price;
        }

        public IEnumerator GetEnumerator() => _itemList.GetEnumerator();
    }
}
