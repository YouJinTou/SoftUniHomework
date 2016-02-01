namespace BookShopSystem.Data
{   
    using System.Data.Entity;
    using BookShopSystem.Data.Migrations;
    using Models;

    public class BookShopContext : DbContext
    {
        public BookShopContext()
            : base("name=BookShopContext")
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<BookShopContext, Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasMany(b => b.RelatedBooks)
                .WithMany()
                .Map(m =>
                {
                    m.MapLeftKey("Book1Id");
                    m.MapRightKey("Book2Id");
                    m.ToTable("BookRelatedBooks");
                });

            base.OnModelCreating(modelBuilder);
        }

        public IDbSet<Book> Books { get; set; }
        public IDbSet<Author> Authors { get; set; }
        public IDbSet<Category> Categories { get; set; }
    }    
}