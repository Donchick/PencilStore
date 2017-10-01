using System.Linq;
using System.Web.Http;
using PencilStore.Models;
using PencilStore.Entities;
using System.Web.Http.Cors;

namespace PencilStore.Controllers
{
    [EnableCors(origins:"*", headers:"*", methods:"*")]
    public class PencilsController: ApiController
    {
        private StoreContext db = new StoreContext();

        [HttpGet]
        public IHttpActionResult Get()
        {
            var pencils = db.Pencils.Select(pencil => new Pencil
            {
                PencilId = pencil.PencilId,
                Price = pencil.Price,
                Image = pencil.Image,
                Name = pencil.Name,
                Description = pencil.Description,
                BuyersIds = pencil.Buyers.Select(buyer => buyer.BuyerId)
            });

            return Ok(pencils);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var DbPencil = db.Pencils.FirstOrDefault(pencilEntity => pencilEntity.PencilId == id);
            Pencil pencil = new Pencil()
            {
                PencilId = DbPencil.PencilId,
                Price = DbPencil.Price,
                Description = DbPencil.Description,
                Image = DbPencil.Image,
                Name = DbPencil.Name,
                BuyersIds = DbPencil.Buyers.Select(buyer => buyer.BuyerId)
            };

            return Ok(pencil);
        }

        [HttpPost]
        public IHttpActionResult Create(Pencil pencil)
        {
            PencilEntity pencilEntity = new PencilEntity()
            {
                Price = pencil.Price,
                Description = pencil.Description,
                Image = pencil.Image,
                Name = pencil.Name,
                Buyers = db.Buyers.Where(b => pencil.BuyersIds.Contains(b.BuyerId)).ToList()
            };

            db.Pencils.Add(pencilEntity);
            db.SaveChanges();

            pencil = new Pencil
            {
                PencilId = pencilEntity.PencilId,
                Price = pencilEntity.Price,
                Description = pencilEntity.Description,
                Image = pencilEntity.Image,
                Name = pencilEntity.Name,
                BuyersIds = pencilEntity.Buyers.Select(buyer => buyer.BuyerId)
            };

            return Ok(pencil);
        }

        [HttpPatch]
        public IHttpActionResult Update(Pencil pencil)
        {
            PencilEntity dbPencil = db.Pencils.Where(p => p.PencilId == pencil.PencilId).FirstOrDefault();
            dbPencil.Price = pencil.Price;
            dbPencil.Description = pencil.Description;
            dbPencil.Image = pencil.Image;
            dbPencil.Name = pencil.Name;

            var addedBuyers = db.Buyers.Where(b => pencil.BuyersIds.Contains(b.BuyerId)).ToList();
            var removedBuyers = db.Buyers.Where(b => !pencil.BuyersIds.Contains(b.BuyerId)).ToList();

            removedBuyers.ForEach(rb => dbPencil.Buyers.Remove(rb));
            addedBuyers.ForEach(ab => dbPencil.Buyers.Add(ab));
            db.SaveChanges();

            pencil = new Pencil
            {
                PencilId = dbPencil.PencilId,
                Price = dbPencil.Price,
                Description = dbPencil.Description,
                Image = dbPencil.Image,
                Name = dbPencil.Name,
                BuyersIds = dbPencil.Buyers.Select(buyer => buyer.BuyerId)
            };

            return Ok(pencil);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            PencilEntity dbPencil = db.Pencils.Where(p => p.PencilId == id).FirstOrDefault();
            db.Pencils.Remove(dbPencil);
            db.SaveChanges();

            return Ok(dbPencil);
        }
    }
}