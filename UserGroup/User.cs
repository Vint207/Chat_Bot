using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static Chat_Bot.Phrases;
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

        [Required]
        [RegularExpression(@"^[a-z\nA-Z\nа-я\nА-Я]{1,12}$", ErrorMessage = "Некорректный формат имени")]
        public string Name { get; set; } = "";

        [Required]
        [RegularExpression(@"^[a-z\|0-9]{6}$", ErrorMessage = "Некорректный формат пароля")]
        public string Password { get; set; } = "";

        [Required]
        [Range(1, 9999, ErrorMessage = "Сумма должна быть в диапазоне 1 - 9999 р")]
        public double Money { get; set; }


        internal void ChangingName()
        {
            WriteLine($"Введи имя. (Используй только буквы)");

            Validation.TryValidate(this, nameof(Name));

            WriteLine($"{Phrase("Greet")}, {Name}.");

            Clear();
        }

        internal void ChangingPassword()
        {
            WriteLine("Введи пароль аккаунта. (6 букв латинского алфавита или цифры)");

            Validation.TryValidate(this, nameof(Password));

            WriteLine($"Пароль {Password} {Phrase("Prove")}.");

            Clear();
        }

        internal void PutMoney()
        {
            Clear();
            
            WriteLine($"На счету {Name} {Money} р");

            WriteLine($"Введи сумму для перевода:");

            Validation.TryValidate(this, nameof(Money));

            WriteLine($"Баланс {Name} составляет {Money} р");

            Read();
        }

        internal void ChangeProfile()
        {
            while (true)
            {
                Clear();

                switch (ConsoleWork.Chose(new List<string>() { "Изменить-имя", "Изменить-пароль", "Назад" }))
                {
                    case "Изменить-имя":
                        ChangingName();
                        break;
                    case "Изменить-пароль":
                        ChangingPassword();
                        break;
                    case "Назад":
                        return;
                }
            }
        }

        internal void CreateProfile()
        {
            Clear();           
            ChangingName();
            ChangingPassword();
        }


        internal bool PayOrder()
        {
            WriteLine();
            WriteLine($"На счету {Money} р");

            Order order = orderBase.GetLastOrder();

            if (order.CheckPayment(Money))
            {
                Money -= bin.Price;
                return true;
            }
            WriteLine($"{Name}, на твоем счету недостаточно средств");
            return false;
        }

        internal void GetInfo()
        {
            Clear();

            WriteLine($"Имя: {Name}\nПароль: {Password}\nБаланс: {Money} р");

            Read();
        }
    }
}
