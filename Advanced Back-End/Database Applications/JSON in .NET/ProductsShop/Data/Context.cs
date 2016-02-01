namespace Data
{
    using System.Data.Entity;
    using Models;
    using Data.Migrations;

    public class Context : DbContext
    {
        public Context()
            : base("Context")
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<Context, Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.UserFriends)
                .WithMany()
                .Map(m =>
                {
                    m.MapLeftKey("UserId");
                    m.MapRightKey("FriendId");
                    m.ToTable("UserFriends");
                });

            base.OnModelCreating(modelBuilder);
        }

        public IDbSet<User> Users { get; set; }
        public IDbSet<Product> Products { get; set; }
        public IDbSet<Category> Categories { get; set; }
    }
}