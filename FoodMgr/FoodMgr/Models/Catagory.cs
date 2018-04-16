﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FoodMgr.Models
{
    [Table("Catagory")]
    public class Catagory
    {
        public int id { get; set; }
        [Required]
        public string name { get; set; }
    }
}