using static Chat_Bot.Phrases;
using static System.Console;

namespace Chat_Bot
{
    class Registration
    {

        public static Admin Registrate(UserBase userBase)
        {
            Admin user = new();

            user.ChangeName();
            user.ChangePassword();
            user.ChangeMail(userBase);
            userBase.AddItem(user);

            WriteLine();
            WriteLine($"{Phrase("Praise")}, {user.Name}, теперь ты зарегистрирован в системе.");

            return user;
        }

        public static User LogIn(UserBase userBase)
        {
            Clear();
            User user = new();

            WriteLine($"Введи адрес электронной почты.");
            Validation.TryValidate(user, nameof(user.Mail));

            Clear();
            WriteLine($"Введи пароль.");
            Validation.TryValidate(user, nameof(user.Password));

            user = userBase.GetItem(user);

            ReadKey();
            return user;
        }
    }
}
