using System;

namespace Chat_Bot
{
    sealed class Phrases
    {
        internal static readonly string[] Greeting = new string[] { "Привет", "Здравствуй", "Салют", "Будь здоров", "Как дела", "Hello", "Hi", "Что как",
        "Приетствую тебя", "Хеллоу", "Хай", "Как сам", "Даров"};

        internal static readonly string[] Prove = new string[] { "принят", "учтен", "прошел обработку", "подтвержден", "одобрен", "валидирован", "подходит" };

        internal static readonly string[] WrongPhrase1 = new string[] {"Что?", "Не понял.", "Ерунду написал.", "Неразбериха какая-то!",
        "Не могу разобрать.", "Слишком мелко.", "Это на каком языке?", "Чего?", "Каво?", "Неправда!", "Не понимаю.", "Я догадываться должен?",
        "Это некорректный ввод.", "Данные введены неверно!", "Ошибка протокола.", "Ошибка контрольных сумм.", "Хаха, офигенно!", "Прикольно получилось!"};

        internal static readonly string[] WrongPhrase2 = new string[] { "Вводи по новой:", "Напиши еще раз:", "Повтори набор:", "Ты знаешь, что делать:",
        "Вводи опять:", "Давай по новой, Миша:", "Пиши сначала:", "Набирай аккуратнее:", "Повторяй:", "Давай еще раз:"};

        internal static readonly string[] Praise = new string[] { "Молодец", "Красавчик", "Все правильно", "Так держать", "Четко", "Отлично", "Хорошо" };

        internal static readonly string[] Upset = new string[] { "Почему?", "Мда...", "Это так сложно?", "Тогда ничем не могу помочь.", "Касса возле входа.", "Как так?",
         "Это несложно.", "Чего ты ждешь?", "Жду.", "Буду ждать."};

        internal static string Phrase(string s)
        {
            Random rand = new();
            return s switch
            {
                "Greet" => Greeting[rand.Next(0, Greeting.Length)],
                "Prove" => Prove[rand.Next(0, Prove.Length)],
                "Wrong1" => WrongPhrase1[rand.Next(0, WrongPhrase1.Length)],
                "Wrong2" => WrongPhrase2[rand.Next(0, WrongPhrase2.Length)],
                "Praise" => Praise[rand.Next(0, Praise.Length)],
                "Upset" => Upset[rand.Next(0, Upset.Length)],
                _ => "???"
            };
        }
    }
}
