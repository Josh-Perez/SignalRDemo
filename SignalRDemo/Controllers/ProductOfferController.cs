using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRDemo.Hub;

namespace SignalRDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductOfferController : ControllerBase
    {
        private IHubContext<MessageHub, IMessageHubClient> messageHub;
        public ProductOfferController(IHubContext<MessageHub, IMessageHubClient> _messageHub)
        {
            this.messageHub = _messageHub;
        }

        [HttpPost]
        [Route("productoffers")]
        public string Get()
        {
            List<string> offers = new List<string>();
            offers.Add("20% Off on Iphone 12");
            offers.Add("15% Off on HP Pavillion");
            offers.Add("10% Off on Samsung Galaxy S20");

            messageHub.Clients.All.SendOffersToUser(offers);

            return "Offers sent to all users!";
        }
    }
}
