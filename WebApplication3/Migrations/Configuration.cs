using IdentitySample.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebApplication3.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration
    {

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "WebApplication3.Models.ApplicationDbContext";
        }

        //protected override void Seed(ApplicationDbContext context)
        //{
        //    var UserManager = new UserManager<IdentityUser>(new 

        //                                        UserStore<IdentityUser>(context)); 

        //        var RoleManager = new RoleManager<IdentityRole>(new 
        //                                  RoleStore<IdentityRole>(context));
        //      string name = "Admin";
        //         string password = "123456";

     
        //        //Create Role Admin if it does not exist
        //        if (!RoleManager.RoleExists(name))
        //        {
        //            var roleresult = RoleManager.Create(new IdentityRole(name));
        //        }
     
        //        //Create User=Admin with password=123456
        //        var user = new IdentityUser();
        //        user.UserName = name;
        //        var adminresult = UserManager.Create(user, password);
     
        //        //Add User Admin to Role Admin
        //        if (adminresult.Succeeded)
        //        {
        //            var result = UserManager.AddToRole(user.Id, name);
        //        }
        //        base.Seed(context);
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
        }
    }

