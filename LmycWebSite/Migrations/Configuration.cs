namespace LmycWebSite.Migrations
{
    using LmycWebSite.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LmycWebSite.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LmycWebSite.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            //If roles don't yet exist, create them
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            string[] roleNames = { "Admin", "Member" };
            IdentityResult roleResult;
            foreach (var roleName in roleNames)
            {
                if (!RoleManager.RoleExists(roleName))
                {
                    roleResult = RoleManager.Create(new IdentityRole(roleName));
                }
            }

            //Create a UserManager to add users and roles
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            //Create a@a.a and m@m.m if users don't exist
            if (context.Users.Where(u => u.Email == "a@a.a").Count() == 0)
            {
                var user = new ApplicationUser
                {
                    UserName = "a",
                    Email = "a@a.a",
                    FirstName = "adminFirstName",
                    LastName = "adminLastName",
                    Street = "adminStreet",
                    City = "adminCity",
                    Province = "adminProvince",
                    PostalCode = "adminPostalCode",
                    Country = "adminCountry",
                    MobileNumber = "1234567890",
                    SailingExperience = "Exptert"
                };
                UserManager.Create(user, "P@$$w0rd");
            }
            if (context.Users.Where(u => u.Email == "m@m.m").Count() == 0)
            {
                var user = new ApplicationUser
                {
                    UserName = "m",
                    Email = "m@m.m",
                    FirstName = "memberFirstName",
                    LastName = "memberLastName",
                    Street = "memberStreet",
                    City = "memberCity",
                    Province = "memberProvince",
                    PostalCode = "memberPostalCode",
                    Country = "memberCountry",
                    MobileNumber = "1234567890",
                    SailingExperience = "Exptert"
                };
                UserManager.Create(user, "P@$$w0rd");
            }

            //Assign roles to a@a.a and m@m.m
            UserManager.AddToRole(context.Users.Where(u => u.Email == "a@a.a").First().Id, "Admin");
            UserManager.AddToRole(context.Users.Where(u => u.Email == "m@m.m").First().Id, "Member");
        }
    }
}
