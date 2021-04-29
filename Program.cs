using System.Collections.Generic;
using static System.Console;

namespace Chat_Bot
{
    class Program
    {
        static void Main(string[] args)
        {
            UserBase users = new();
            SushiBase sushi = new();

            while (true)
            {
                new ChatBot(users, sushi).MainMenu();
                ReadLine();
            }
        }
    }
}
