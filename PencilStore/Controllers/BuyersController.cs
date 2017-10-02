using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using PencilStore.Models;

namespace PencilStore.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "GET")]
    public class BuyersController : ApiController
    {
        private StoreContext db = new StoreContext();

        [HttpGet]
        public IHttpActionResult Get()
        {
            var buyers = db.Buyers.Select(buyer => new Buyer
            {
                BuyerId = buyer.BuyerId,
                Name = buyer.Name
            });

            return Ok(buyers);
        }
    }
}
