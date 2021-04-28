using Chat_Bot.Interfaces;
using System;
using System.Collections.Generic;

namespace Chat_Bot
{
    class UserBase : ICRUD<User>
    {

        List<User> _itemList;
        public event BaseChangedEvent<User> baseChangedEvent;
        public BaseChangedMessage<User> baseChangedMessage;

        public UserBase() { _itemList = new(); }

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

            user = _itemList.Find(item => item.Name == user.Name && item.Password == user.Password);

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

            user = _itemList.Find(item => item.Name == user.Name && item.Password == user.Password);

            if (user != null) 
            { 
                user.GetInfo();
                baseChangedEvent?.Invoke(user);
                return user;
            }
            Console.WriteLine("Данный пользователь не зарегистрирован.");
            return user;
        }

        public bool GetAllItems(User user)
        {
            baseChangedMessage?.Invoke(user);

            foreach (var item in _itemList) { item.GetInfo(); }

            baseChangedEvent?.Invoke(user);

            return true;
        }
    }
}
