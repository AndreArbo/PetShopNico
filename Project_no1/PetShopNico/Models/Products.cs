using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetShopNico.Models
{
    public class Products
    {
        public int ID { get; set; }

        [Required]
        public string ProductNumber { get; set; }
        
        public string ImageName { get; set; }

        [Required]
        public decimal Price { get; set; }

        public int ProductTypeID { get; set; }
        public virtual ProductsType ProductType { get; set; }

        public int PetTypeID { get; set; }
        public virtual PetsType  PetType { get; set; }

        public int BrandID { get; set; }
        public virtual Brands Brand { get; set; }

        public virtual ICollection<Shopping> Shopping { get; set; }
    }
}