using Microsoft.AspNet.Identity.EntityFramework;
using Models;
using System.Data.Entity;

namespace Data
{
    public class NewsSiteDbContext : IdentityDbContext<ApplicationUser>
    {
        public NewsSiteDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public IDbSet<Category> Categories { get; set; }
        public IDbSet<Article> Articles { get; set; }

        public static NewsSiteDbContext Create()
        {
            return new NewsSiteDbContext();
        }
    }
}
