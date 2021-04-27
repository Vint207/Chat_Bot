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
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^[a-z\|0-9]{6}$", ErrorMessage = "Некорректный формат пароля")]
        public string Password { get; set; }

        [Required]
        [Range(1, 9999, ErrorMessage = "Сумма должна быть в диапазоне 1 - 9999 р")]
        public double Money { get; set; }


        internal void ChangingName()
        {
            WriteLine($"Введи свое имя. (Используй только буквы)");
            Validation.TryValidate(this, "Name");
            WriteLine($"{Phrase("Greet")}, {Name}.");
        }

        internal void ChangingPassword()
        {
            WriteLine("Введи ароль аккаунта. (6 букв латинского алфавита)");
            Validation.TryValidate(this, "Password");
            WriteLine($"Пароль {Password} {Phrase("Prove")}.");
        }

        internal void PutMoney(double sum)
        {
            WriteLine($"На счет {Name} переведено {Money} р");
            Validation.TryValidate(this, "Money");
            Money += sum;
            WriteLine($"Баланс {Name} составляет {Money} р");
        }

        internal void ChangeProfile()
        {
            ChangingName();
            ChangingPassword();
        }

        internal bool PayOrder()
        {
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
            WriteLine($"Имя: {Name}\nПароль: {Password}\nБаланс: {Money}");
        }
    }
}
