﻿using System.Collections;
using static System.Console;

namespace Chat_Bot
{
    public class Bin : SushiBase
    {

        public double Price { get; set; }

        public Bin() { itemList = new(); }

        public void AddItemToBin(SushiBase sushiBase, User user)
        {
            while (true)
            {
                Clear();
                WriteLine($"{user.Name}, Выбери суши для добавления в корзину.");

                WriteLine();
                Sushi sushi = sushiBase.GetItem(new(ConsoleWork.Choose(sushiBase.GetListItems(user))), user);

                AddItem(sushi, user);
                sushiBase.DeleteItem(sushi, user);

                Price += sushi.Price;

                WriteLine();
                user.bin.GetAllItemsFromBin(user);

                WriteLine();
                WriteLine($"{user.Name}, хочешь заказать еще суши?");

                if (!ConsoleWork.Choose()) { break; }
            }
        }

        public void DeleteItemFromBin(SushiBase sushiBase, User user)
        {
            while (BinIsNotEmpty())
            {
                Clear();
                WriteLine($"{user.Name}, Выбери суши, которые хочешь удалить из корзины.");

                WriteLine();
                Sushi sushi = GetItem(new(ConsoleWork.Choose(GetListItems(user))), user);

                DeleteItem(sushi, user);
                sushiBase.AddItem(sushi, user);

                Price -= sushi.Price;

                WriteLine();
                user.bin.GetAllItemsFromBin(user);

                WriteLine();
                WriteLine($"{user.Name}, хочешь удалить еще суши?");

                if (!ConsoleWork.Choose()) { return; }
            }
            Clear();
            WriteLine($"Корзина пуста.");
            ReadKey();

            bool BinIsNotEmpty()
            {
                foreach (var item in itemList)
                {
                    if (item.Value > 0)
                    { return true; }
                }
                return false;
            }
        }

        public void GetAllItemsFromBin(User user)
        {
            Clear();
            WriteLine($"Состав корзины:");
            GetAllItemsInfo(user);

            WriteLine();
            WriteLine($"- Стоимость товаров в корзине: {Price} р");
            ReadKey();
        }

        public void EmptyBin(User user)
        {
            Price = 0d;
            itemList.Clear();
            WriteLine($"Корзина очищена");
            ReadKey();
        }

        public IEnumerator GetEnumerator() => itemList.GetEnumerator();
    }
}
