using System;
using System.Text.RegularExpressions;
using static Chat_Bot.Phrases;
using static System.Console;

namespace Chat_Bot
{
    sealed class ChatBot
    {
        UserBase _userBase;
        SushiBase _sushiBase;
        string _botName;

        public ChatBot(UserBase userBase, SushiBase sushiBase)
        {
            _userBase = userBase;
            _sushiBase = sushiBase;
            _botName = "Гробик";
            _userBase.baseChangedMessage = EventMethods.UserBaseChangedMessage;
            _userBase.baseChangedEvent += EventMethods.UserBaseChanged;
            _sushiBase.baseChangedMessage = EventMethods.SushiBaseChangedMessage;
            _sushiBase.baseChangedEvent += EventMethods.SushiBaseChanged;
        }

        public void MainChat()
        {
            User user = new();
            //выбор методов из списка

            while (true)
            {
                WriteLine();
                WriteLine($"--{Phrase("Greet")}. Звать меня {_botName}. Ты зарегистрирован?--");

                if (ConsoleWork.Chose()) { user = Intering(); }
                else { user = Registration(); }

                if (user != null)
                {
                    if (FindOrder(user)) { PayOrder(user); }
                    else if (BuildOrder(user)) { PayOrder(user); }
                }
            }
        }

        User Intering()
        {
            User user = new();
            user.ChangeProfile();
            user = _userBase.GetItem(user);

            if (user != null)
            {
                WriteLine();
                WriteLine($"{user.Name}, ты хочешь изменить данные профиля?");

                if (ConsoleWork.Chose()) { ChangingProfile(user); }
            }
            return user;
        }

        User Registration()
        {
            WriteLine();
            WriteLine($"Давай создадим аккаунт.");

            User user = new();
            user.ChangeProfile();
            _userBase.AddItem(user);

            WriteLine();
            WriteLine($"{Phrase("Praise")}, {user.Name}, теперь ты зарегистрирован в системе.");

            return user;
        }

        void ChangingProfile(User user)
        {
            WriteLine();
            WriteLine($"Ты хочешь изменить имя?");

            if (ConsoleWork.Chose()) { user.ChangingName(); }

            WriteLine();
            WriteLine($"Ты хочешь изменить пароль?");

            if (ConsoleWork.Chose()) { user.ChangingPassword(); }

            return;
        }

        bool BuildOrder(User user)
        {
            WriteLine();
            WriteLine($"{user.Name}, хочешь заказать суши?");

            if (!ConsoleWork.Chose()) { return false; }

            WriteLine();
            WriteLine($"{Phrase("Praise")}, {user.Name}, какие суши ты хочешь?");

            while (true)
            {
                WriteLine();
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
            user.orderBase.AddItem(new() { Price = user.bin.Price, itemList = user.bin.itemList }, user);

            return true;
        }

        bool FindOrder(User user)
        {
            Order order = user.orderBase.GetLastOrder();

            if (order != null && !order.Paid)
            {
                order.GetInfo();
                return true;
            }
            return false;
        }

        void PayOrder(User user)
        {         
            WriteLine($"{user.Name}, ты готов оплатить заказ?");

            if (!ConsoleWork.Chose()) { return; }

            if (!user.PayOrder()) { return; }
        }
    }
}
