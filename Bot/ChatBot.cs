using static Chat_Bot.Phrases;
using static Chat_Bot.Validation;
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
        }

        public void Greeting()
        {
            WriteLine($"{Phrase("Greet")}. Звать меня {_botName}. Ты зарегистрирован?");

            if (CheckInfo()) { Intering(); }

            Registration();
        }

        void Intering()
        {
            string name, password;
            WriteLine("Введи свое имя, чтобы войти в аккаунт.");
            name = CheckInfo("Name");

            WriteLine("Введи пароль. (6 цифр)");
            password = CheckInfo("Password");

            User tempUser = _userBase.GetItem(new User() { Name = name, Password = password });

            if (tempUser != null)
            {
                WriteLine($"{tempUser.Name}, ты хочешь изменить данные профиля?)");
                if (CheckInfo()) { ChangingProfile(tempUser); }

                Chat(tempUser);
            }

            WriteLine("данный пользователь не зарегистрирован.");

            Greeting();
        }

        void Registration()
        {
            User user = new();

            WriteLine($"Давай создадим аккаунт.");

            WriteLine($"Введи свое имя. (Используй только буквы)");
            user.ChangingName();

            WriteLine("Придумай пароль аккаунта. (6 цифр)");
            user.ChangingPassword();

            _userBase.AddItem(user);
            WriteLine($"{Phrase("Praise")}, {user.Name}, теперь ты зарегистрирован в системе.");

            Chat(user);
        }

        void ChangingProfile(User user)
        {
            WriteLine($"Давай изменим данные аккаунта.");

            WriteLine($"Ты хочешь изменить имя?");
            if (CheckInfo())
            {
                WriteLine($"Введи новое имя. (Используй только буквы)");
                user.ChangingName();
            }

            WriteLine($"Ты хочешь изменить пароль?");
            if (CheckInfo())
            {
                WriteLine("Придумай новый пароль аккаунта. (6 цифр)");
                user.ChangingPassword();
            }

            Chat(user);
        }

        void Chat(User user)
        {
            WriteLine($"{user.Name}, хочешь заказать суши?");
            if (!CheckInfo()) { return; }

            WriteLine($"{Phrase("Praise")}, {user.Name}, какие суши ты хочешь?");
            _sushiBase.GetAllItems(user);

            while (true)
            {
                WriteLine($"{user.Name}, Введи суши для добавления в корзину");

                Sushi sushi = _sushiBase.GetItem(new(ReadLine()), user);

                if (sushi == null) { WriteLine("Таких суши нет, попробуй другие"); }

                user.bin.AddItem(sushi, user);
                _sushiBase.DeleteItem(sushi, user);
                WriteLine();
                _sushiBase.GetAllItems(user);
                WriteLine();
                user.bin.GetAllItems(user);

                WriteLine($"{user.Name}, хочешь заказать еще суши?");
                if (!CheckInfo()) { break; }
            }

            user.orderBase.AddItem(user.bin as Order, user);

            WriteLine($"{user.Name}, ты готов оплатить заказ?");

            if (!CheckInfo()) { return; }

            if (!user.PayOrder()) 
            { 
                WriteLine($"{user.Name}, на твоем счету недостаточно средств");
                return;
            }          
            
        }
    }
}
