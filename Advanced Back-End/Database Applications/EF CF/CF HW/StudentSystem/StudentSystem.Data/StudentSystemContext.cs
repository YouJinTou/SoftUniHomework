namespace StudentSystem.Data
{
    using System.Data.Entity;
    using StudentSystem.Models;
    using StudentSystem.Data.Migrations;

    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
            : base("name=StudentSystemContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new
                MigrateDatabaseToLatestVersion<StudentSystemContext, Configuration>());
                        
            base.OnModelCreating(modelBuilder);
        }

        public IDbSet<Student> Students { get; set; }
        public IDbSet<Homework> Homeworks { get; set; }
        public IDbSet<Course> Courses { get; set; }
        public IDbSet<Resource> Resources { get; set; }
        public IDbSet<License> Licenses { get; set; }
    }
}