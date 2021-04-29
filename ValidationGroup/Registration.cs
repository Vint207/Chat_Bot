using static Chat_Bot.Phrases;
using static System.Console;

namespace Chat_Bot
{
    class Registration
    {

        public static User Registrate(UserBase userBase)
        {
            User user = new();
            user.CreateProfile();
            userBase.AddItem(user);

            WriteLine();
            WriteLine($"{Phrase("Praise")}, {user.Name}, теперь ты зарегистрирован в системе.");

            return user;
        }

        public static User Entering(UserBase userBase)
        {
            User user = new();
            user.CreateProfile();
            user = userBase.GetItem(user);

            return user;
        }
    }
}
