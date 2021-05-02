using Chat_Bot.Interfaces;
using System;
using System.Collections.Generic;

namespace Chat_Bot
{
    public class UserBase : ICRUD<User>
    {

        List<User> _itemList = new() { new() { Name = "Admin", Password = "admin01", Mail = "admin@mail.com" } };
        public event BaseChangedEvent<User> baseChangedEvent;
        public BaseChangedMessage<User> baseChangedMessage;

        public bool AddItem(User user)
        {
            baseChangedMessage?.Invoke(user);
            if (user != null)
            {
                _itemList.Add(user);
                baseChangedEvent?.Invoke(user);
                return true;
            }
            return false;
        }

        public bool DeleteItem(User user)
        {
            baseChangedMessage?.Invoke(user);

            user = _itemList.Find(item => item.Mail == user.Mail && item.Password == user.Password);

            if (user != null)
            {
                _itemList.Remove(user);
                baseChangedEvent?.Invoke(user);
                return true;
            }
            return false;
        }

        public User GetItem(User user)
        {
            baseChangedMessage?.Invoke(user);

            user = _itemList.Find(item => item.Mail == user.Mail && item.Password == user.Password);

            if (user != null)
            {
                baseChangedEvent?.Invoke(user);
                return user;
            }
            Console.WriteLine("Данный пользователь не зарегистрирован.");
            return user;
        }

        public bool GetAllItemsInfo(User user)
        {
            baseChangedMessage?.Invoke(user);

            foreach (var item in _itemList) 
            { item.GetInfo(); }

            baseChangedEvent?.Invoke(user);

            return true;
        }
    }
}
