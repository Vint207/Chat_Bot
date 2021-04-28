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

            if (sushi != null) { Price += sushi.Price; }
        }

        public void DeleteItemFromBin(Sushi sushi, User user)
        {
            DeleteItem(sushi, user);

            if (sushi != null) { Price -= sushi.Price; }
        }

        public void GetAllItemsFromBin(User user)
        {
            GetAllItems(user);

            Console.WriteLine();
            Console.WriteLine($"- Стоимость товаров в корзине: {Price} р");
            Console.WriteLine();
        }

        public void EmptyBin(User user)
        {
            Price = 0d;
            itemList.Clear();
        }

        public IEnumerator GetEnumerator() => itemList.GetEnumerator();
    }
}
