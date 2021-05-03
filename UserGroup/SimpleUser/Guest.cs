using System;
using System.ComponentModel.DataAnnotations;

namespace Chat_Bot
{
    public class Guest
    {

        public Bin bin;
        Guid ID { get; init; }
        bool Status { get; set; }

        [Required(ErrorMessage = "Поле не может быть пустым. Введи новое имя:")]
        [RegularExpression(@"^[a-z\nA-Z\nа-я\nА-Я]{1,12}$", ErrorMessage = "Некорректный формат имени. Введи новое имя:")]
        public string Name { get; set; } = "Гость";

        public Guest() { ID = new(); }
    }
}
