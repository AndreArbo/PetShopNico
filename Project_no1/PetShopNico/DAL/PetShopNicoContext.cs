using PetShopNico.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace PetShopNico.DAL
{
    public class PetShopNicoContext : DbContext
    {
        public PetShopNicoContext() : base("PetShopNicoContext")
        {
        }

        public virtual DbSet<Brands> Brands { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<PetsType> PetsTypes { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<ProductsType> ProductsTypes { get; set; }
        public virtual DbSet<Shopping> Shoppings { get; set; }
        public virtual DbSet<TypeUsers> TypeUsers { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}