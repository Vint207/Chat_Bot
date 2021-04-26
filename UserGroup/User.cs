using System;
using static Chat_Bot.Phrases;
using static Chat_Bot.Validation;
using static System.Console;

namespace Chat_Bot
{
    public sealed class User
    {

        internal Bin bin;
        internal OrderBase orderBase;

        public User() 
        { 
            bin = new();
            orderBase = new();
            bin.baseChangedMessage = EventMethods.BinBaseChangedMessage;
            bin.baseChangedEvent += EventMethods.BinBaseChanged;
            orderBase.baseChangedMessage = EventMethods.OrderBaseChangedMessage;
            orderBase.baseChangedEvent += EventMethods.OrderBaseChanged;
        }

        internal string Name { get; set; }
        internal string Password { get; set; }
        internal double Money { get; set; }

        internal void ChangingName()
        {
            Name = CheckInfo("Name");
            WriteLine($"{Phrase("Greet")}, {Name}.");
        }

        internal void ChangingPassword()
        {
            Password = CheckInfo("Password");
            WriteLine($"Пароль {Password} {Phrase("Prove")}.");
        }

        internal void PutMoney(double sum)
        {       
            if (sum > 0) 
            {
                WriteLine($"На счет {Name} переведено {Money} р");
                Money += sum;
                WriteLine($"Баланс {Name} составляет {Money} р");
            }
            else { WriteLine($"Нельзя положить отрицательную сумму на счет"); }           
        }

        internal bool PayOrder()
        {
            WriteLine($"На счету {Money} р");

            if (orderBase.GetLastOrder().PayOrder(Money))
            {
                Money -= bin.Price;
                return true;
            }
            return false;
        }

        internal void GetInfo() => WriteLine($"Имя: {Name}\nПароль: {Password}\nБаланс: {Money}");
    }
}
