using System;
using System.Collections;

namespace Chat_Bot
{
    public class Bin : SushiBase
    {

        public double Price { get; set; }

        public Bin() { itemList = new(); }

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

        public void EmptyBin(User user)
        {
            Price = 0d;
            itemList.Clear();
        }

        public IEnumerator GetEnumerator() => itemList.GetEnumerator();
    }
}
