namespace Chat_Bot
{
    class Program
    {
        static void Main(string[] args)
        {
            UserBase users = new();
            SushiBase sushi = new();

            new ChatBot(users, sushi).MainMenu();
        }
    }
}
