using System.ComponentModel.DataAnnotations;
using static Chat_Bot.Phrases;
using static System.Console;

namespace Chat_Bot
{
    public class User : Guest
    {

        public OrderBase orderBase;

        public User()
        {
            bin = new();
            orderBase = new();
            //bin.baseChangedMessage = EventMethods.BinBaseChangedMessage;
            //bin.baseChangedEvent += EventMethods.BinBaseChanged;
            //orderBase.baseChangedMessage = EventMethods.OrderBaseChangedMessage;
            //orderBase.baseChangedEvent += EventMethods.OrderBaseChanged;
        }

        [Required]
        [RegularExpression(@"^[a-z\|A-Z\|0-9]{6,12}$", ErrorMessage = "Некорректный формат пароля")]
        public string Password { get; set; }

        [Required]
        [RegularExpression(@"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
         @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$", ErrorMessage = "Недопустимый адрес электронной почты")]
        public string Mail { get; set; }

        [Required]
        [Range(1, 999999, ErrorMessage = "Сумма должна быть в диапазоне 1 - 999999 р")]
        public double Money { get; set; }

        [Required]
        [Range(1, 9999, ErrorMessage = "Сумма должна быть в диапазоне 1 - 9999")]
        public double LastTransaction { get; set; }


        internal void ChangeName()
        {
            Clear();

            WriteLine($"Введи имя. (Используй только буквы)");

            Validation.TryValidate(this, nameof(Name));

            WriteLine($"{Phrase("Greet")}, {Name}.");
        }

        internal void ChangePassword()
        {
            Clear();

            WriteLine("Введи пароль аккаунта. (6-12 букв латинского алфавита или цифр)");

            Validation.TryValidate(this, nameof(Password));

            WriteLine($"Пароль {Password} {Phrase("Prove")}.");
        }

        internal void ChangeMail(UserBase userBase)
        {
            Clear();

            WriteLine("Введи адрес электронной почты.");

            while (true)
            {
                Validation.TryValidate(this, nameof(Mail));

                if (userBase.GetItem(new Admin() { Mail = Mail }) == null)
                {
                    WriteLine($"Адрес электронной почты {Mail} {Phrase("Prove")}.");
                    ReadKey();
                    return;
                }
                WriteLine("Данный адрес электронной почты уже зарегистрирован. Попробуй другой.");
                ReadKey();
            }
        }

        internal void PutMoney()
        {
            Clear();

            WriteLine($"На счету {Name} {Money} р");

            WriteLine($"Введи сумму для перевода:");

            Validation.TryValidate(this, nameof(LastTransaction));

            Money += LastTransaction;

            WriteLine($"Баланс {Name} составляет {Money} р");

            ReadKey();
        }

        public void PayOrder()
        {
            Order order = orderBase.GetLastOrder();

            if (order != null)
            {
                if (!order.Paid && order.PayOrder((Admin)this))
                {
                    Money -= order.Price;
                    return;
                }
                if (order.Paid)
                { WriteLine($"Последний заказ оплачен"); }

                ReadKey();
            }
        }

        internal void GetInfo()
        {
            Clear();
            WriteLine($"Данные пользователя:");
            WriteLine($"Имя: {Name}\nПароль: {Password}\nБаланс: {Money} р\nПочта: {Mail}");
            ReadKey();
        }        
    }
}
