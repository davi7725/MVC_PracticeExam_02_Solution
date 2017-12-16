using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionWebApplication.Models
{
    public class BidRepository
    {
        List<Bid> listOfBids;

        public BidRepository()
        {
            listOfBids = new List<Bid>();
        }
        public void AddBid(int itemNumber, string bidder, int bidPrice, DateTime bidTime)
        {
            Bid b = new Bid(itemNumber, bidder, bidPrice, bidTime);
            listOfBids.Add(b);
        }

        public List<Bid> FindBidsByName(string name)
        {
            List<Bid> returnList = new List<Bid>();

            foreach(Bid b in listOfBids)
            {
                if (b.Bidder == name)
                    returnList.Add(b);
            }

            return returnList;
        }

    }
}
