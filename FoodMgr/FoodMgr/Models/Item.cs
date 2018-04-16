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
        public int Catagory_id { get; set; }
        public Catagory Catagory { get; set; }

    }
}