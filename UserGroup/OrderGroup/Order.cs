using System;

namespace Chat_Bot
{
    public class Order : Bin
    {

        public bool Paid { get; }
        public bool Closed { get; set; }
        public Guid Id { get; init; }
        public DateTime OpenDate { get; init; }
        public DateTime CloseDate { get; }

        public Order()
        {
            Id = new();
            OpenDate = DateTime.Now;
            Paid = false;
            Closed = false;
        }

        internal bool CanPayOrder(double money)
        {            
            return Price <= money;
        }

        public void CloseOrder()
        {
            Closed = true;
        }
    }
}
