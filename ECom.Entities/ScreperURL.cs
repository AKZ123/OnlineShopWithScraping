using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Entities
{
    public class ScreperURL
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string SUrl { get; set; }

        public int ProductID { get; set; }
        public Product SProduct { get; set; }
    }
}
