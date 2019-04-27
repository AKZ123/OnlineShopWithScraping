using ECom.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECom.Web.ViewModels
{
    public class ScreperProductViewModel
    {
        public int ProductID { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageURL { get; set; }

        public string ScreperName { get; set; }
        public string ScreperURL { get; set; }

    }

    public class ScreperProductCompareViewModel
    {
        public Product Product { get; set; }

        public List<ScreperURL> AvailableScreperSiteNames { get; set; }
    }

    public class Product1
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //public decimal Price { get; set; }
        public string Price { get; set; }
        public string ImageURl { get; set; }
    }
}