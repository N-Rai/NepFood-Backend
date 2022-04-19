using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProducAPI.DBContext.Model
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public string Name { get; set; }
        [Range(1,100)]
        public double Price { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }       
        public string SpicyLevel { get; set; }
        public string ImageFile { get; set; }


    }
}
