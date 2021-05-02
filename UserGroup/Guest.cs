using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Bot
{
    public class Guest
    {

        public Bin bin;
        Guid ID { get; init; }
        bool Status { get; set; }

        [Required]
        [RegularExpression(@"^[a-z\nA-Z\nа-я\nА-Я]{1,12}$", ErrorMessage = "Некорректный формат имени")]
        public string Name { get; set; } = $"Гость";

        public Guest() 
        {
            bin = new();
            ID = new();
        }
    }
}
