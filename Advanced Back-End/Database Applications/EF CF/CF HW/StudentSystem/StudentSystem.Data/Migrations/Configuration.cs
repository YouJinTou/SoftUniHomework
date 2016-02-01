namespace StudentSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using Models;
    using System.Linq;
    using System.IO;

    internal sealed class Configuration : DbMigrationsConfiguration<StudentSystem.Data.StudentSystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(StudentSystem.Data.StudentSystemContext context)
        {
            if (context.Students.Any() || context.Courses.Any() || context.Homeworks.Any() || context.Resources.Any())
            {
                return;
            } // Thanks to HPenchev for this check
            
            using (StreamReader sr = new StreamReader("Sample Data\\students.txt"))
            {
                string line = sr.ReadLine();

                while (line != null)
                {
                    string name = line;
                    Student student = new Student()
                    {
                        Name = name,
                        RegistrationDate = DateTime.Now
                    };
                    
                    context.Students.AddOrUpdate(student);

                    line = sr.ReadLine();
                }
            }
            context.SaveChanges();
            
            using (StreamReader sr = new StreamReader("Sample Data\\courses.txt"))
            {
                string line = sr.ReadLine();

                while (line != null)
                {
                    string[] data = line.Split('\\');
                    string name = data[0];
                    DateTime startDate = DateTime.Parse(data[1]);
                    DateTime endDate = DateTime.Parse(data[2]);
                    decimal price = decimal.Parse(data[3]);

                    Course course = new Course()
                    {
                        Name = name,
                        StartDate = startDate,
                        EndDate = endDate,
                        Price = price
                    };
                    
                    context.Courses.AddOrUpdate(course);

                    line = sr.ReadLine();
                }
            }
            context.SaveChanges();

            using (StreamReader sr = new StreamReader("Sample Data\\homeworks.txt"))
            {
                string line = sr.ReadLine();

                while (line != null)
                {
                    string[] data = line.Split('\\');
                    string homeworkContent = data[0];
                    int contentType = int.Parse(data[1]);
                    DateTime submissionDate = DateTime.Parse(data[2]);
                    int studentId = int.Parse(data[3]);
                    int courseId = int.Parse(data[4]);

                    Homework homework = new Homework()
                    {
                        Content = homeworkContent,
                        ContentType = (ContentType)contentType,
                        SubmissionDate = submissionDate,
                        StudentId = studentId,
                        CourseId = courseId
                    };

                    context.Homeworks.AddOrUpdate(homework);

                    line = sr.ReadLine();
                }
            }
            context.SaveChanges();

            using (StreamReader sr = new StreamReader("Sample Data\\resources.txt"))
            {
                string line = sr.ReadLine();

                while (line != null)
                {
                    string[] data = line.Split('\\');
                    string name = data[0];
                    int resourceType = int.Parse(data[1]);
                    string url = data[2];
                    int courseId = int.Parse(data[3]);
                    string licenseName = data[4];

                    Resource resource = new Resource()
                    {
                        Name = name,
                        ResourceType = (ResourceType)resourceType,
                        URL = url,
                        CourseId = courseId
                    };

                    License license = new License();
                    license.Name = licenseName;
                    resource.Licenses.Add(license);

                    context.Resources.AddOrUpdate(resource);

                    line = sr.ReadLine();
                }
            }
            context.SaveChanges();

            // Filling out the intermediary tables
            var students = context.Students;
            var courses = context.Courses;
            var resources = context.Resources;
            var licenses = context.Licenses;
            Random random = new Random();

            foreach (var student in students)
            {
                student.Courses.Add(courses.Find(
                    random.Next(1, courses.Count() + 1)));
            }

            foreach (var resource in resources)
            {
                resource.Licenses.Add(licenses.Find(
                    random.Next(1, licenses.Count() + 1)));
            }

            context.SaveChanges();
        }
    }
}
