﻿using static System.Console;

namespace Chat_Bot
{
    class Registration
    {

        public static UserMiddle RegistrateUser(UserBase userBase)
        {
            UserMiddle user = new();

            user.ChangeName();
            user.ChangePassword();
            user.ChangeMail(userBase);
            userBase.AddItem(user);

            return user;
        }

        public static UserMiddle LogInUser(UserBase userBase)
        {
            Clear();
            UserMiddle user = new();

            user.ChangeMail(userBase);
            user.ChangePassword();

            user = userBase.GetItem(user);

            if (user != null) { return user; }

            WriteLine("Данный пользователь не зарегистрирован.");
            ReadKey();

            return null;
        }

        public static UserAdmin LogInAdmin(UserBase userBase)
        {
            UserMiddle user = LogInUser(userBase);

            return (user.Mail == "admin@mail.com") ? new() { Name = "Администратор" } : null;
        }
    }
}
