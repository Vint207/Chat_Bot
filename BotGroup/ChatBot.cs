using System.Collections.Generic;
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

                switch (ConsoleWork.Choose(new List<string>() { "Регистрация", "Вход-пользователь", "Вход-гость" }))
                {
                    case "Регистрация":
                        UserMenu(Registration.Registrate(_userBase));
                        break;
                    case "Вход-пользователь":
                        User user = new Admin();
                        user = Registration.LogIn(_userBase);
                        if (user != null)
                        {
                            if (user.Mail != "admin@mail.com")
                            { UserMenu(user); }
                            else
                            { AdminMenu(new() { Name = "Администратор"}); }
                        }
                        break;
                    case "Вход-гость":
                        GuestMenu(new User());
                        break;
                }
            }
        }

        void UserMenu(User user)
        {
            while (true)
            {
                Clear();

                switch (ConsoleWork.Choose(new List<string>() { "Просмотреть-аккаунт", "Настроить-аккаунт", "Пополнить-счет", "Меню-суши", "Меню-корзины", "Меню-заказа", "Выйти" }))
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
                        Clear();
                        _sushiBase.GetAllItemsInfo(user);
                        ReadKey();
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

        void GuestMenu(Guest guest)
        {
            while (true)
            {
                Clear();

                switch (ConsoleWork.Choose(new List<string>() { "Меню-суши", "Выйти" }))
                {
                    case "Меню-суши":
                        Clear();
                        _sushiBase.GetAllItemsInfo(guest);
                        ReadKey();
                        break;
                    case "Выйти":
                        return;
                }
            }
        }

        void AdminMenu(Admin admin)
        {
            while (true)
            {
                Clear();

                switch (ConsoleWork.Choose(new List<string>() { "Просмотреть-пользователей", "Просмотреть-пользователя", "Удалить-пользователя", "Выйти" }))
                {
                    case "Просмотреть-пользователей":
                        admin.AllUsersInfo(_userBase);
                        break;
                    case "Просмотреть-пользователя":
                        admin.FindUserInfo(_userBase);
                        break;
                    case "Удалить-пользователя":
                        admin.AllUsersInfo(_userBase);
                        break;
                    case "Выйти":
                        return;
                }
            }
        }

        void ProfileMenu(User user)
        {
            while (true)
            {
                Clear();

                switch (ConsoleWork.Choose(new List<string>() { "Изменить-имя", "Изменить-пароль", "Изменить-почту", "Назад" }))
                {
                    case "Изменить-имя":
                        user.ChangeName();
                        break;
                    case "Изменить-пароль":
                        user.ChangePassword();
                        break;
                    case "Изменить-почту":
                        user.ChangeMail(_userBase);
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

                switch (ConsoleWork.Choose(new List<string>() { "Просмотеть-корзину", "Добавить-суши", "Удалить-суши", "Назад" }))
                {
                    case "Просмотеть-корзину":
                        user.bin.GetAllItemsFromBin(user);
                        break;
                    case "Добавить-суши":
                        user.bin.AddItemToBin(_sushiBase, user);
                        break;
                    case "Удалить-суши":
                        user.bin.DeleteItemFromBin(_sushiBase, user);
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

                switch (ConsoleWork.Choose(new List<string>() { "Сформировать-заказ", "Просмотреть-заказ", "Оплатить-заказ", "Назад" }))
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
