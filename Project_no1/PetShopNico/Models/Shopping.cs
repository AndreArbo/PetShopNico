using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetShopNico.Models
{
    public class Shopping
    {
        public int ID { get; set; }

        [Required]
        public Guid ShoppingNumber { get; set; }

        [Required]
        public DateTimeOffset StartShippingDate{ get; set; }
        
        public DateTimeOffset ConfirmationShippingDate { get; set; }

        
        //[Required]
        //public string Email { get; set; }

        //[Required]
        //public string MobilePhone { get; set; }

        public int CustomersID { get; set; }

        public virtual Customers Customers { get; set; }

        public virtual ICollection<Products> Products { get; set; }
    }
}