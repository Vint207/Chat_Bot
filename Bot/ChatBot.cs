using System.Collections.Generic;
using static Chat_Bot.Phrases;
using static System.Console;

namespace Chat_Bot
{
    sealed class ChatBot
    {
        UserBase _userBase;
        SushiBase _sushiBase;
        //string _botName;

        public ChatBot(UserBase userBase, SushiBase sushiBase)
        {
            _userBase = userBase;
            _sushiBase = sushiBase;
            //_botName = "Гробик";
            _userBase.baseChangedMessage = EventMethods.UserBaseChangedMessage;
            _userBase.baseChangedEvent += EventMethods.UserBaseChanged;
            _sushiBase.baseChangedMessage = EventMethods.SushiBaseChangedMessage;
            _sushiBase.baseChangedEvent += EventMethods.SushiBaseChanged;
        }

        public void MainMenu()
        {
            while (true)
            {
                Clear();

                switch (ConsoleWork.Chose(new List<string>() { "Регистрация", "Вход" }))
                {
                    case "Регистрация":
                        AccauntMenu(Registration());
                        break;

                    case "Вход":
                        User user = Intering();
                        if (user != null) { AccauntMenu(user); }
                        break;
                }
            }
        }

        User Intering()
        {
            User user = new();
            user.CreateProfile();
            user = _userBase.GetItem(user);

            ReadKey();

            return user;
        }

        User Registration()
        {
            WriteLine($"Давай создадим аккаунт.");

            User user = new();
            user.CreateProfile();
            _userBase.AddItem(user);

            WriteLine();
            WriteLine($"{Phrase("Praise")}, {user.Name}, теперь ты зарегистрирован в системе.");

            return user;
        }

        bool BuildBin(User user)
        {
            while (true)
            {
                Clear();

                WriteLine($"{user.Name}, Выбери суши для добавления в корзину");

                WriteLine();
                Sushi sushi = _sushiBase.GetItem(new(ConsoleWork.Chose(_sushiBase.GetListItems(user))), user);

                user.bin.AddItemToBin(sushi, user);
                _sushiBase.DeleteItem(sushi, user);

                WriteLine();
                user.bin.GetAllItemsFromBin(user);

                WriteLine();
                WriteLine($"{user.Name}, хочешь заказать еще суши?");

                if (!ConsoleWork.Chose()) { break; }
            }
            WriteLine();

            return true;
        }

        void AccauntMenu(User user)
        {
            while (true)
            {
                Clear();

                switch (ConsoleWork.Chose(new List<string>() { "Просмотреть-аккаунт", "Настроить-аккаунт", "Пополнить-счет", "Меню-суши", "Меню-корзины", "Меню-заказа", "Выйти" }))
                {
                    case "Просмотреть-аккаунт":
                        user.GetInfo();
                        ReadKey();
                        break;

                    case "Настроить-аккаунт":
                        user.ChangeProfile();
                        break;

                    case "Пополнить-счет":
                        user.PutMoney();
                        break;

                    case "Меню-суши":
                        BuildBin(user);
                        break;

                    case "Меню-корзины":
                        BinMenu(user);
                        break;

                    case "Меню-заказа":
                        OrderMenu(user);
                        break;

                    case "Выйти":
                        return;
                }
            }
        }

        void BinMenu(User user)
        {
            while (true)
            {
                Clear();

                switch (ConsoleWork.Chose(new List<string>() { "Просмотеть-корзину", "Добавить-суши", "Оформить-заказ", "Назад" }))
                {
                    case "Просмотеть-корзину":
                        user.bin.GetAllItems(user);
                        ReadKey();
                        break;

                    case "Добавить-суши":
                        BuildBin(user);
                        break;

                    case "Оформить-заказ":
                        OrderMenu(user);
                        break;

                    case "Назад":
                        return;
                }
            }
        }

        void OrderMenu(User user)
        {         
            while (true)
            {
                Clear();

                switch (ConsoleWork.Chose(new List<string>() { "Просмотреть-заказ", "Оплатить-заказ", "Назад" }))
                {
                    case "Сформировать-заказ":
                        user.orderBase.AddOrder(user);
                        ReadKey();
                        break;

                    case "Просмотреть-заказ":
                        user?.orderBase?.GetLastOrder()?.GetInfo();
                        ReadKey();
                        break;

                    case "Оплатить-заказ":
                        user.PayOrder();
                        break;

                    case "Назад":
                        return;
                }
            }
        }
    }
}
