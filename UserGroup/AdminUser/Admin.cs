﻿using System;
using static System.Console;

namespace Chat_Bot
{
    public sealed class Admin : User
    {

        public void FindUserInfo(UserBase userBase)
        {
            Clear();
            User user = new();

            WriteLine($"Введи адрес электронной почты:");
            Validation.TryValidate(user, nameof(user.Mail));

            Clear();
            WriteLine($"Введи пароль:");
            Validation.TryValidate(user, nameof(user.Password));

            if (userBase?.GetItem(user) is User tempUser)
            {
                tempUser.GetInfo();
                return;
            }
            ReadKey();
        }

        public void AllUsersInfo(UserBase userBase)
        {
            Clear();
            userBase.GetAllItemsInfo(new User() { Name = "Администратор" });
            ReadKey();
        }

        public void DeleteUser(UserBase userBase)
        {
            Clear();
            User user = new();

            WriteLine($"Введи адрес электронной почты:");
            Validation.TryValidate(user, nameof(user.Mail));

            Clear();
            WriteLine($"Введи пароль:");
            Validation.TryValidate(user, nameof(user.Password));

            if (userBase?.GetItem(user) is User tempUser)
            {
                WriteLine($"Пользователь {tempUser.Name} удален.");
                userBase.DeleteItem(tempUser);
            }
            ReadKey();
        }
    }
}
