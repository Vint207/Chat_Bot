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
            _userBase.baseChangedMessage = EventMethods.UserBaseChangedMessage;
            _userBase.baseChangedEvent += EventMethods.UserBaseChanged;
            _sushiBase.baseChangedMessage = EventMethods.SushiBaseChangedMessage;
            _sushiBase.baseChangedEvent += EventMethods.SushiBaseChanged;
        }

        public void Greeting()
        {
            WriteLine($"{Phrase("Greet")}. Звать меня {_botName}. Ты зарегистрирован?");
            if (ConsoleWork.Chose()) { Intering(); }
            Registration();
        }

        void Intering()
        {
            User user = new();

            user.ChangeProfile();

            User tempUser = _userBase.GetItem(user);

            if (tempUser != null)
            {
                WriteLine($"{tempUser.Name}, ты хочешь изменить данные профиля?)");
                if (ConsoleWork.Chose()) { ChangingProfile(tempUser); }

                Chat(tempUser);
            }           

            Greeting();
        }

        void Registration()
        {           
            WriteLine($"Давай создадим аккаунт.");
            User user = new();

            user.ChangeProfile();

            _userBase.AddItem(user);
            WriteLine($"{Phrase("Praise")}, {user.Name}, теперь ты зарегистрирован в системе.");

            Chat(user);
        }

        void ChangingProfile(User user)
        {
            WriteLine($"Давай изменим данные аккаунта.");

            WriteLine($"Ты хочешь изменить имя?");
            if (ConsoleWork.Chose())
            {
                WriteLine($"Введи новое имя. (Используй только буквы)");
                user.ChangingName();
            }

            WriteLine($"Ты хочешь изменить пароль?");
            if (ConsoleWork.Chose())
            {
                WriteLine("Придумай новый пароль аккаунта. (6 цифр)");
                user.ChangingPassword();
            }

            Chat(user);
        }

        void Chat(User user)
        {
            WriteLine($"{user.Name}, хочешь заказать суши?");
            if (!ConsoleWork.Chose()) { return; }

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
                if (!ConsoleWork.Chose()) { break; }
            }


            Bin order = new Order();
            order = (Order)user.bin;
            user.orderBase.AddItem(order, user);

            WriteLine($"{user.Name}, ты готов оплатить заказ?");

            if (!ConsoleWork.Chose()) { return; }

            if (!user.PayOrder()) 
            { 
                WriteLine($"{user.Name}, на твоем счету недостаточно средств");
                return;
            }          
            
        }
    }
}
