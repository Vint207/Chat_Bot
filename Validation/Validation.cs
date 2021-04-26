using System.Text.RegularExpressions;
using static Chat_Bot.Phrases;
using static System.Console;

namespace Chat_Bot
{
    sealed class Validation
    {

        internal static bool CheckInfo() => ConsoleWork.Chose();

        internal static string CheckInfo(string request)
        {
            bool match = false;
            string result = ReadLine();
            while (true)
            {
                match = request switch
                {
                    "Name" => Regex.IsMatch(result, @"^[a-z\|а-я]{1,12}$", RegexOptions.IgnoreCase),
                    "Ticket" => Regex.IsMatch(result, @"^[0-9]{7}$"),
                    "Pasport" => Regex.IsMatch(result, @"^[A-W]{2}[0-9]{5}$"),
                    "Password" => Regex.IsMatch(result, @"^[0-9\|a-w]{6}$", RegexOptions.IgnoreCase),
                    _ => false
                };

                if (!string.IsNullOrEmpty(result) & match) { return result; }

                WriteLine($"{Phrase("Wrong1")} {Phrase("Wrong2")}");
                result = ReadLine();
            }
        }
    }
}
