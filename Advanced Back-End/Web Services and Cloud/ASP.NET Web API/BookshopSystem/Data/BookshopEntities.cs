namespace Data
{
    using Bookshop.Models;
    using BookshopSystem.Data.Migrations;
    using BookshopSystem.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity;

    public class BookshopEntities : IdentityDbContext<ApplicationUser>
    {
        public BookshopEntities()
            : base("name=BookshopEntities")
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<BookshopEntities, Configuration>());
        }

        public IDbSet<Book> Books { get; set; }
        public IDbSet<Author> Authors { get; set; }
        public IDbSet<Category> Categories { get; set; }
        public IDbSet<Purchase> Purchases { get; set; }

        public static BookshopEntities Create()
        {
            return new BookshopEntities();
        }
    }    
}