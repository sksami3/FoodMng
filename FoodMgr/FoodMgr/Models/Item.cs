using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FoodMgr.Models
{
    [Table("Item")]
    public class Item
    {
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public double price { get; set; }
        [Required]
        [ForeignKey("Catagory")]
        [NotMapped]
        public int Catagory_id { get; set; }
        public Catagory Catagory { get; set; }
        [NotMapped]
        public IEnumerable<Link> Link
        {
            get
            {
                return new List<Link>()
                {
                    new Link()
                    {
                        Href=$"http://localhost:1224/api/Item/{this.id}",
                        Rel="Details",
                        Method="Get"
                    },

                    new Link()
                    {
                        Href=$"http://localhost:1224/api/Item/{this.id}",
                        Rel="Delete",
                        Method="Delete"
                    },
                    new Link()
                    {
                        Href=$"http://localhost:1224/api/Item/{this.id}/Catagory",
                        Rel="CAtagories's Details",
                        Method="Get"
                    }
                };
            }
        }

    }
}