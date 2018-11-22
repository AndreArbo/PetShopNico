using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_no1.Models
{
    public class Employees
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Role { get; set; }

        public DateTime BeginDate { get; set; }

        public string Email { get; set; }

        public string MobilePhone { get; set; }

        public int UsersID { get; set; }

        public virtual Users Users { get; set; }
    }
}