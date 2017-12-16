using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AuctionWebApplication.Models;

namespace AuctionWebApplication.Controllers
{
    public class HomeController : Controller
    {
        ServiceReference1.AuctionsServiceClient service = new ServiceReference1.AuctionsServiceClient();

        private readonly BidRepository bidRepo;

        public HomeController(BidRepository bidRepository)
        {
            this.bidRepo = bidRepository;
        }

        public async Task<IActionResult> Index()
        {
            List<ServiceReference1.AuctionItem> auctionItems = await service.GetAllAuctionItemsAsync();

            return View(auctionItems);
        }

        [HttpGet]
        public async Task<IActionResult> ItemPage(int partItem)
        {
            ServiceReference1.AuctionItem auctionItem = await service.GetAuctionItemAsync(partItem);

            return View(auctionItem);
        }

        [HttpPost]
        public async Task<IActionResult> ItemPage(int partItem, string name, string phoneNumber, int bid)
        {
            ServiceReference1.AuctionItem auctionItem = await service.GetAuctionItemAsync(partItem);
            if (await service.ProvideBidAsync(partItem, bid, name, phoneNumber) == "OK")
            {
                auctionItem = await service.GetAuctionItemAsync(partItem);
                bidRepo.AddBid(partItem, name, bid, DateTime.Now);
            }

            return View(auctionItem);
        }

        [HttpGet]
        public IActionResult CustomerAuctions(string name)
        {
            List<Bid> listOfCustomersBids = bidRepo.FindBidsByName(name);

            return View(listOfCustomersBids);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
