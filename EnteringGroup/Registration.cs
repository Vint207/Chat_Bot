using static Chat_Bot.Phrases;
using static System.Console;

namespace Chat_Bot
{
    class Registration
    {

        public static Admin RegistrateUser(UserBase userBase)
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

        public static User LogInUser(UserBase userBase)
        {
            Clear();
            User user = new();

            WriteLine($"Введи адрес электронной почты:");
            Validation.TryValidate(user, nameof(user.Mail));

            Clear();
            WriteLine($"Введи пароль:");
            Validation.TryValidate(user, nameof(user.Password));

            user = userBase.GetItem(user);

            ReadKey();
            return user;
        }

        public static Admin LogInAdmin(UserBase userBase)
        {
            if (LogInUser(userBase) is User user)
            {
                if (user.Mail == "admin@mail.com")
                { return new() { Name = "Администратор" }; }              
            }
            return null;
        }
    }
}
