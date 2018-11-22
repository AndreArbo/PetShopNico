using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Project_no1.Models;

namespace Project_no1.DAL
{
    public class PetsInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<PetsDBContext>
    {
        protected override void Seed(PetsDBContext context)
        {
            var TypeUsers = new List<TypeUsers>
            {
                new TypeUsers {ID=0, Name="ChatCustomer", Description="Atendimento de Primeira Linha" },
                new TypeUsers {ID=1, Name="Cliente", Description="User para Clientes normais" },
                new TypeUsers {ID=2, Name="Admin", Description="Administrador da página" }
            };
            TypeUsers.ForEach(s => context.TypeUsers.Add(s));
            context.SaveChanges();

            var Users = new List<Users>
            {
                new Models.Users { ID=0, UserName="Customer01", Password="Password01" , TypeUsersID=0},
                new Models.Users { ID=1, UserName="Client01", Password="Password01", TypeUsersID=1},
                new Models.Users { ID=2, UserName="Admin01", Password="Password01", TypeUsersID=2}
            };
            Users.ForEach(s => context.Users.Add(s));
            context.SaveChanges();


            var Customer = new List<Customers>
            {
                new Models.Customers { ID=0, Name="André Oliveira",Address="Rua do Teste", Email="teste@gmail.com", MobilePhone="917469999" , PostalCode="4430-369",UsersID=1}
            };
            Users.ForEach(s => context.Users.Add(s));
            context.SaveChanges();

            var Employees = new List<Employees>
            {
                new Models.Employees { ID=0, Name="José Rodrigues", Email="Customer01@gmail.com", MobilePhone="9199999229" ,UsersID=0,BeginDate=DateTime.Parse("10-10-2018")},
                new Models.Employees { ID=0, Name="Sergio Conceição", Email="admin01@gmail.com", MobilePhone="936548998" ,UsersID=0,BeginDate=DateTime.Parse("08-10-2008")}
            };
            Employees.ForEach(s => context.Employees.Add(s));
            context.SaveChanges();

        }
    }
}