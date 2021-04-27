using System;
using static System.Console;
using static System.ConsoleKey;

namespace Chat_Bot
{
    static class ConsoleWork
    {

        public static bool Chose()
        {
            ConsoleKey temp, key = DownArrow;
            CursorVisible = false;
            bool result = false;
            SetCursorPosition(0, GetCursorPosition().Top + 1);
            while (true)
            {
                if (key == UpArrow)
                {
                    SetCursorPosition(0, GetCursorPosition().Top - 1);
                    ForegroundColor = ConsoleColor.Yellow;
                    Write($"->Да \n");
                    ForegroundColor = ConsoleColor.White;
                    Write("Нет  ");
                    ForegroundColor = ConsoleColor.Black;
                    temp = ReadKey().Key;
                    if (temp == DownArrow) { key = temp; }
                    if (temp == Enter) { result = true; break; }
                }
                if (key == DownArrow)
                {
                    SetCursorPosition(0, GetCursorPosition().Top - 1);
                    ForegroundColor = ConsoleColor.White;
                    Write("Да   \n");
                    ForegroundColor = ConsoleColor.Yellow;
                    Write("->Нет");
                    ForegroundColor = ConsoleColor.Black;
                    temp = ReadKey().Key;
                    if (temp == UpArrow) { key = temp; }
                    if (temp == Enter) { result = false; break; }
                }
            }
            SetCursorPosition(0, GetCursorPosition().Top + 1);
            CursorVisible = true;
            ForegroundColor = ConsoleColor.White;
            return result;
        }
    }
}
