using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Entities
{
    public class Product
    {
        public int ID { get; set; }

        [Required]
        [MinLength(5),MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [Range(0,100000)]
        public decimal Price { get; set; }
        public string ImageURl { get; set; }

        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }

        public virtual ICollection<ScreperURL> SURL { get; set; }
    }
}
