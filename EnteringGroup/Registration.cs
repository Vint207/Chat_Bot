using static Chat_Bot.Phrases;
using static System.Console;

namespace Chat_Bot
{
    class Registration
    {

        public static Admin Registrate(UserBase userBase)
        {
            Admin user = new();

            user.ChangingName();
            user.ChangingPassword();
            user.ChangingMail(userBase);
            userBase.AddItem(user);

            WriteLine();
            WriteLine($"{Phrase("Praise")}, {user.Name}, теперь ты зарегистрирован в системе.");

            return user;
        }

        public static User Entering(UserBase userBase)
        {
            Clear();
            WriteLine($"Для входа введи адрес электронной почты.");

            User user = new();
            Validation.TryValidate(user, nameof(user.Mail));

            user = userBase.GetItem(user);

            ReadKey();
            return user;
        }
    }
}
