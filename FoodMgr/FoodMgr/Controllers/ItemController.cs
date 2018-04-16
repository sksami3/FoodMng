using FoodMgr.AppDataContext;
using FoodMgr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FoodMgr.Controllers
{
    [RoutePrefix("api/Item")]
    public class ItemController : ApiController
    {
        private FoodDataContext db;
        public ItemController()
        {
            db = new FoodDataContext();
        }
        [HttpGet]
        public IEnumerable<Item> Get()
        {
            return db.items.ToList();
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var g = db.items.Find(id);

            if (g != null)
            {
                return Ok(g);
            }
            return Content(HttpStatusCode.NotFound, "Can't find");
        }

        [HttpPost]

        public IHttpActionResult Post(Item model)
        {
            if (ModelState.IsValid)
            {
                db.items.Add(model);
                db.SaveChanges();
                return Ok(model);
            }
            return Content(HttpStatusCode.BadRequest, "cant create");
        }

        [HttpPut]
        public IHttpActionResult Put(int id, Item model)
        {
            var f = db.items.Find(id);
            if(f!=null && ModelState.IsValid)
            {
                f.name = model.name;
                f.price = model.price;
                f.Catagory_id = model.Catagory_id;
                db.SaveChanges();
                return Ok("Updated");
            }
            return Content(HttpStatusCode.NotFound,"Cant update");
        }

        [HttpPut]
        public IHttpActionResult Delete(int id)
        {
            var f = db.items.Find(id);
            if (f != null)
            {
                db.items.Remove(f);
                db.SaveChanges();
                return Ok("Deleted");
            }
            return Content(HttpStatusCode.NotFound, "Cant delete");
        }

        [Route("{itemId}/Catagory")]

        public Catagory GetCatagory(int itemId)
        {
            var i = db.items.SingleOrDefault( x=> x.id ==itemId);
            var ca = db.catagories.SingleOrDefault( c => c.id==i.Catagory_id);
            return ca;
        }
    }
}
