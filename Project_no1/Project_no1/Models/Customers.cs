using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project_no1.Models
{
    public class Customers
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Address{ get; set; }

        public string PostalCode { get; set; }

        public string Email { get; set; }

        public string MobilePhone { get; set; }

        public int UsersID { get; set; }

        public virtual Users Users { get; set; }
    }
}