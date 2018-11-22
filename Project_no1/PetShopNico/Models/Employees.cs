using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetShopNico.Models
{
    public class Employees
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [DefaultValue("-")]
        public string Role { get; set; }

        public DateTime BeginDate { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string MobilePhone { get; set; }

        public int UsersID { get; set; }

        public virtual Users Users { get; set; }
    }
}