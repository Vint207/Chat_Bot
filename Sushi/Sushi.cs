﻿using System;

namespace Chat_Bot
{
    public sealed class Sushi
    {

        internal Sushi(string name) { Name = name; }
        internal Sushi(string name, double price) : this(name) { Price = price; }

        internal string Name { get; set; }
        internal double Price { get; set; }

        internal void GetInfo() => Console.Write($"{Name} - {Price} р");
    }
}