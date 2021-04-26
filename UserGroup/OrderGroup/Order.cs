using System;

namespace Chat_Bot
{
    class Order : Bin
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
        }

        internal bool PayOrder(double money)
        {            
            return Price <= money;
        }

        public void CloseOrder()
        {
            Closed = true;
        }
    }
}
