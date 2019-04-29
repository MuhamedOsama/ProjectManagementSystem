namespace ProjectManagementSystem.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using ProjectManagementSystem.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProjectManagementSystem.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ProjectManagementSystem.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            if (!context.Roles.Any())
            {
                context.Roles.AddOrUpdate(x => x.Id,
                    new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "Admin" },
                    new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "Customer" },
                    new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "Developer" },
                    new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "TeamLeader" },
                    new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "ProjectManager" }
                    );
                context.SaveChanges();
            }
        }
    }
}
