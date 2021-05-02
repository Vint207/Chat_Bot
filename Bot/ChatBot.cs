using System.Collections.Generic;
using static Chat_Bot.Phrases;
using static System.Console;


namespace Chat_Bot
{
    sealed class ChatBot
    {
        UserBase _userBase;
        SushiBase _sushiBase;

        public ChatBot(UserBase userBase, SushiBase sushiBase)
        {
            _userBase = userBase;
            _sushiBase = sushiBase;
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
                        AccauntMenu(Registration.Registrate(_userBase));
                        break;
                    case "Вход":
                        User user = Registration.Entering(_userBase);
                        if (user != null) { AccauntMenu(user); }
                        break;
                }
            }
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
                        break;
                    case "Настроить-аккаунт":
                        ProfileMenu(user);
                        break;
                    case "Пополнить-счет":
                        user.PutMoney();
                        break;
                    case "Меню-суши":
                        user.bin.BuildBin(_sushiBase, user);
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

        internal void ProfileMenu(User user)
        {
            while (true)
            {
                Clear();

                switch (ConsoleWork.Chose(new List<string>() { "Изменить-имя", "Изменить-пароль", "Изменить-почту", "Назад" }))
                {
                    case "Изменить-имя":
                        user.ChangingName();
                        break;
                    case "Изменить-пароль":
                        user.ChangingPassword();
                        break;
                    case "Изменить-почту":
                        user.ChangingMail(_userBase);
                        break;
                    case "Назад":
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
                        user.bin.GetAllItemsFromBin(user);
                        break;
                    case "Добавить-суши":
                        user.bin.BuildBin(_sushiBase, user);
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

                switch (ConsoleWork.Chose(new List<string>() { "Сформировать-заказ", "Просмотреть-заказ", "Оплатить-заказ", "Назад" }))
                {
                    case "Сформировать-заказ":
                        user.orderBase.AddOrder(user);
                        break;
                    case "Просмотреть-заказ":
                        user.orderBase?.GetLastOrder()?.GetInfo();
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
