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

        public UserBase()  { _itemList = new(); }

        public void AddItem(User user)
        {
            baseChangedMessage?.Invoke(user);
            _itemList.Add(user);
            baseChangedEvent?.Invoke(user);
        }

        public void DeleteItem(User user)
        {
            baseChangedMessage?.Invoke(user);
            _itemList.Remove(_itemList.Find(item => item.Name == user.Name && item.Password == user.Password));
            baseChangedEvent?.Invoke(user);
        }

        public User GetItem(User user)
        {
            baseChangedMessage?.Invoke(user);
            baseChangedEvent?.Invoke(user);    
            User tempUser = _itemList.Find(item => item.Name == user.Name && item.Password == user.Password);
            if (tempUser != null) { Console.WriteLine("Данный пользователь не зарегистрирован."); }
            return tempUser;
        }

        public void GetAllItems(User user)
        {
            baseChangedMessage?.Invoke(user);
            foreach (var item in _itemList) { item.GetInfo(); }
            baseChangedEvent?.Invoke(user);
        }
    }
}
