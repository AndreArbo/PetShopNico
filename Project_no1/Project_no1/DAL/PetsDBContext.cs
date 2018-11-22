using System.Data.Entity;
using Project_no1.Models;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace Project_no1.DAL
{
    public class PetsDBContext : DbContext
    {
        public PetsDBContext() : base("PetsDBContext")
        {
        }

        public DbSet<TypeUsers> TypeUsers { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Employees> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}