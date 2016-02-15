namespace Identity.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<Identity.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Identity.Models.ApplicationDbContext context)
        {
            if (context.Roles.Any(r => r.Name == "Administrator"))
            {
                return;
            }

            var roleManager = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(context));

            roleManager.Create(new IdentityRole("Administrator"));

            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));
            var user = new ApplicationUser() { UserName = "admin@admin.com", Email = "admin@admin.com" };

            userManager.Create(user, "Admin0!");

            userManager.AddToRole(user.Id, "Administrator");

            context.SaveChanges();
        }
    }
}
