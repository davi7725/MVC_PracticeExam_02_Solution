using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionWebApplication.Models
{
    public class Bid
    {
        public int ItemNumber { get; private set; }
        public string Bidder { get; private set; }
        public int BidPrice { get; private set; }
        public DateTime BidTime { get; private set; }

        public Bid(int itemNumber, string bidder, int bidPrice, DateTime bidTime)
        {
            ItemNumber = itemNumber;
            Bidder = bidder;
            BidPrice = bidPrice;
            BidTime = bidTime;
        }
    }
}
