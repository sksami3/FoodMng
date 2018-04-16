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
    public class CatagoryController : ApiController
    {
        private FoodDataContext _db;

        public CatagoryController()
        {
            _db = new FoodDataContext();
        }
        [HttpGet]
        public IEnumerable<Catagory> Get()
        {
            return _db.catagories.ToList();
        }
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var findbyid = _db.catagories.Find(id);
            if (findbyid != null) return Ok(findbyid);
            return Content(HttpStatusCode.BadRequest, "Not found");
        }
        [HttpPost]
        public IHttpActionResult Post(Catagory model)
        {
            if (!ModelState.IsValid) return BadRequest("Can't insert");
            _db.catagories.Add(model);
            _db.SaveChanges();
            return Ok("Inserted Catagory");

        }
        public IHttpActionResult Put(Catagory model)
        {
            var cat = _db.catagories.Find(model.id);
            if(cat !=null && ModelState.IsValid)
            {
                cat.name = model.name;
                _db.SaveChanges();
                return Ok(model);
            }
            return BadRequest("Can't modify");
        }
        public IHttpActionResult Delete(int id)
        {
            var del = _db.catagories.Find(id);
            if(del != null)
            {
                _db.catagories.Remove(del);
                _db.SaveChanges();
                return Ok("deleted");
            }
            return NotFound();
        }

    }
}
