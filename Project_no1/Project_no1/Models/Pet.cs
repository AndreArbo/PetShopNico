using System.Data.Entity;

namespace Project_no1.Models
{
    public class Pet
    {
        public int ID { get; set; }
        public string Type { get; set; }
        public string Raça { get; set; }

    }
    public class PetsDBContext : DbContext
    {
        public DbSet<Pet> Pets { get; set; }

        public System.Data.Entity.DbSet<Project_no1.Models.TypeUsers> TypeUsers { get; set; }

        public System.Data.Entity.DbSet<Project_no1.Models.Users> Users { get; set; }

        public System.Data.Entity.DbSet<Project_no1.Models.Employees> Employees { get; set; }
    }
}