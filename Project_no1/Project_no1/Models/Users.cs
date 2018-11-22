using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Project_no1.Models
{
    public class Users
    {
        public int ID { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
        
        public int TypeUsersID { get; set; }

        public virtual TypeUsers TypeUsers { get; set; }
    }
}