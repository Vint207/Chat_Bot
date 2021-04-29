using System;
using System.Runtime.CompilerServices;
using static System.Console;

namespace Chat_Bot
{
    public delegate void BaseChangedEvent<in T, in T1>(T obj, T1 obj1, [CallerMemberName] string method = "");
    public delegate void BaseChangedMessage<in T, in T1>(T obj, T1 obj1, [CallerMemberName] string method = "");
    public delegate void BaseChangedEvent<in T>(T obj, [CallerMemberName] string method = "");
    public delegate void BaseChangedMessage<in T>(T obj, [CallerMemberName] string method = "");

    public static class EventMethods
    {

        public static void SushiBaseChanged(Sushi sushi, User user, [CallerMemberName] string method = "")
        {
            if (sushi != null || method.Equals("GetAllItems"))
            {
                ForegroundColor = ConsoleColor.Green;
                switch (method)
                {
                    case "AddItem":
                        WriteLine($"--В базу добавлены суши {sushi.Name} - {sushi.Price} р--");
                        break;
                    case "DeleteItem":
                        WriteLine($"--Из базы удалены суши {sushi.Name} - {sushi.Price} р--");
                        break;
                    case "GetItem":
                        WriteLine($"--Данные о суши {sushi.Name} просмотрены в базе--");
                        break;
                    case "GetAllItems":
                        WriteLine($"--Список суши в базе просмотрен--");
                        break;
                }
                ForegroundColor = ConsoleColor.White;
            }          
        }

        public static void SushiBaseChangedMessage(Sushi sushi, User user, [CallerMemberName] string method = "")
        {
            if (sushi != null || method.Equals("GetAllItems"))
            {
                ForegroundColor = ConsoleColor.Blue;
                switch (method)
                {
                    case "AddItem":
                        WriteLine($"--Добавление суши {sushi.Name} - {sushi.Price} р в базу--");
                        break;
                    case "DeleteItem":
                        WriteLine($"--Удаление суши {sushi.Name} - {sushi.Price} р из базы--");
                        break;
                    case "GetItem":
                        WriteLine($"--Просмотр суши {sushi.Name} базе--");
                        break;
                    case "GetAllItems":
                        WriteLine($"--Просмотр списка суши в базе--");
                        break;
                }
                ForegroundColor = ConsoleColor.White;
            }
        }

        public static void UserBaseChanged(User user, [CallerMemberName] string method = "")
        {
            ForegroundColor = ConsoleColor.Green;
            switch (method)
            {
                case "AddItem":
                    WriteLine($"--Администратором добавлен пользователь {user.Name}--");
                    break;
                case "DeleteItem":
                    WriteLine($"--Администратором удален пользователь {user.Name}--");
                    break;
                case "GetItem":
                    WriteLine($"--Профиль пользователя {user.Name} просмотрен--");
                    break;
                case "GetAllItems":
                    WriteLine($"--Список пользователей просмотрен--");
                    break;
            }
            ForegroundColor = ConsoleColor.White;
        }

        public static void UserBaseChangedMessage(User user, [CallerMemberName] string method = "")
        {
            ForegroundColor = ConsoleColor.Blue;
            switch (method)
            {
                case "AddItem":
                    WriteLine($"--Добавление пользователя {user.Name} в базу--");
                    break;
                case "DeleteItem":
                    WriteLine($"--Удаление пользователя {user.Name} из базы--");
                    break;
                case "GetItem":
                    WriteLine($"--Просмотр профиля пользователя {user.Name}--");
                    break;
                case "GetAllItems":
                    WriteLine($"--Просмотр списка пользователей--");
                    break;
            }
            ForegroundColor = ConsoleColor.White;
        }

        public static void BinBaseChanged(Sushi sushi, User user, [CallerMemberName] string method = "")
        {
            if (sushi != null || method.Equals("GetAllItems"))
            {
                ForegroundColor = ConsoleColor.Green;
                switch (method)
                {
                    case "AddItem":
                        WriteLine($"--В корзину пользователя {user.Name} добавлены суши {sushi.Name} - {sushi.Price} р--");
                        break;
                    case "DeleteItem":
                        WriteLine($"--Из корзины пользователя {user.Name} удалены суши {sushi.Name} - {sushi.Price} р--");
                        break;
                    case "GetItem":
                        WriteLine($"--Суши {sushi.Name} просмотрены в корзине пользователя {user.Name}--");
                        break;
                    case "GetAllItems":
                        WriteLine($"--Список суши в корзине пользователя {user.Name} просмотрен--");
                        break;
                }
                ForegroundColor = ConsoleColor.White;
            }
        }

        public static void BinBaseChangedMessage(Sushi sushi, User user, [CallerMemberName] string method = "")
        {
            if (sushi != null || method.Equals("GetAllItems"))
            {
                ForegroundColor = ConsoleColor.Blue;
                switch (method)
                {
                    case "AddItem":
                        WriteLine($"--Добавление суши {sushi.Name} - {sushi.Price} р в корзину пользователя {user.Name}--");
                        break;
                    case "DeleteItem":
                        WriteLine($"--Из корзины пользователя {user.Name} удалены суши {sushi.Name} - {sushi.Price} р--");
                        break;
                    case "GetItem":
                        WriteLine($"--Данные о суши {sushi.Name} просмотрены в корзине пользователя {user.Name}--");
                        break;
                    case "GetAllItems":
                        WriteLine($"--Список суши в корзине пользователя {user.Name}--");
                        break;
                }
                ForegroundColor = ConsoleColor.White;
            }
        }

        public static void OrderBaseChanged(Order order, User user, [CallerMemberName] string method = "")
        {
            ForegroundColor = ConsoleColor.Green;
            switch (method)
            {
                case "AddItem":
                    WriteLine($"--Пользователь {user.Name} открыл заказ {order.OpenDate}--");
                    break;
            }
            ForegroundColor = ConsoleColor.White;
        }

        public static void OrderBaseChangedMessage(Order order, User user, [CallerMemberName] string method = "")
        {
            ForegroundColor = ConsoleColor.Green;
            switch (method)
            {
                case "AddItem":
                    WriteLine($"--Пользователь {user.Name} открывает заказ {order.OpenDate}--");
                    break;
            }
            ForegroundColor = ConsoleColor.White;
        }
    }
}
