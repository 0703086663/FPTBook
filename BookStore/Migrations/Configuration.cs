using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using BookStore.Models;

internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
{
    public Configuration()
    {
        AutomaticMigrationsEnabled = false;
    }

    protected override void Seed(ApplicationDbContext context)
    {
        // Create Roles
        var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

        if (!roleManager.RoleExists("Admin"))
        {
            var role = new IdentityRole { Name = "Admin" };
            roleManager.Create(role);
        }

        if (!roleManager.RoleExists("Staff"))
        {
            var role = new IdentityRole { Name = "Staff" };
            roleManager.Create(role);
        }

        if (!roleManager.RoleExists("Member"))
        {
            var role = new IdentityRole { Name = "Member" };
            roleManager.Create(role);
        }

        // Create Admin User
        var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

        if (userManager.FindByName("admin@gmail.com") == null)
        {
            var user = new ApplicationUser
            {
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com"
            };

            var result = userManager.Create(user, "admin");

            if (result.Succeeded)
            {
                userManager.AddToRole(user.Id, "Admin");
            }
        }

        // Create Staff User
        if (userManager.FindByName("staff@gmail.com") == null)
        {
            var user = new ApplicationUser
            {
                UserName = "staff@gmail.com",
                Email = "staff@gmail.com"
            };

            var result = userManager.Create(user, "staff");

            if (result.Succeeded)
            {
                userManager.AddToRole(user.Id, "Staff");
            }
        }

        // Create Member User
        if (userManager.FindByName("member@gmail.com") == null)
        {
            var user = new ApplicationUser
            {
                UserName = "member@gmail.com",
                Email = "member@gmail.com"
            };

            var result = userManager.Create(user, "member");

            if (result.Succeeded)
            {
                userManager.AddToRole(user.Id, "Member");
            }
        }
    }
}
