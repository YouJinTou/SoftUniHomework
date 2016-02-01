using StudentSystem.Data;

namespace StudentSystem.Client
{
    class StudentSystem
    {
        static void Main()
        {
            var db = new StudentSystemContext();

            // Problem 3 ************************************************************
            // Part 1************************************************************
            //var homeworks = db.Homeworks
            //    .Select(h => new
            //    {
            //        h.Content,
            //        h.ContentType,
            //        h.Student.Name
            //    });

            //foreach (var hw in homeworks)
            //{
            //    Console.WriteLine("Student name: " + hw.Name);
            //    Console.WriteLine("Content: " + hw.Content);
            //    Console.WriteLine("Content type: " + hw.ContentType);
            //    Console.WriteLine("---");
            //}

            // Part 2************************************************************
            //var resources = db.Resources
            //    .Select(r => new
            //    {
            //        r.Course.Name,
            //        r.Course.Description,
            //        ResourceName = r.Name,
            //        r.ResourceType,
            //        r.URL
            //    });

            //foreach (var r in resources)
            //{
            //    Console.WriteLine("Course name: " + r.Name);
            //    Console.WriteLine("Course description: " + r.Description);
            //    Console.WriteLine("Resource name: " + r.ResourceName);
            //    Console.WriteLine("Resource type: " + r.ResourceType);
            //    Console.WriteLine("Resource URL: " + r.URL);
            //    Console.WriteLine("----");
            //}

            // Part 3************************************************************
            //var courses = db.Courses
            //    .Where(c => c.Resources.Count > 0)
            //    .OrderByDescending(c => c.Resources.Count)
            //    .OrderByDescending(c => c.StartDate)
            //    .Select(c => new
            //    {
            //        c.Name,
            //        c.Resources.Count
            //    });

            //foreach (var c in courses)
            //{
            //    // Prints nothing as I don't have 5 or more resources per course.
            //    // I've decreased the count to 0 as there is only one resource per course
            //    Console.WriteLine("Course name: " + c.Name);
            //    Console.WriteLine("Resources count: " + c.Count);
            //    Console.WriteLine("-----");
            //}

            // Part 4************************************************************
            //var courses = db.Courses
            //    .Where(c => c.StartDate.Month == 2)
            //    .Select(c => new
            //    {
            //        c.Name,
            //        c.StartDate,
            //        c.EndDate,
            //        Duration = DbFunctions.DiffDays(c.StartDate, c.EndDate),
            //        c.Students.Count
            //    })
            //    .OrderByDescending(c => c.Count)
            //    .OrderByDescending(c => c.Duration);

            //foreach (var c in courses)
            //{
            //    Console.WriteLine("course name: " + c.Name);
            //    Console.WriteLine("Start date: " + c.StartDate);
            //    Console.WriteLine("End date: " + c.EndDate);
            //    Console.WriteLine("Duration: {0} days", c.Duration);
            //    Console.WriteLine("Students count: " + c.Count);
            //    Console.WriteLine("-----");
            //}

            // Part 5************************************************************
            //var students = db.Students
            //    .Select(s => new
            //    {
            //        s.Name,
            //        s.Courses.Count,
            //        TotalPrice = (decimal?)s.Courses.Sum(c => c.Price),
            //        AveragePrice = (decimal?)s.Courses.Average(c => c.Price)
            //    })
            //    .OrderByDescending(s => s.TotalPrice)
            //    .OrderByDescending(s => s.Count)
            //    .OrderBy(s => s.Name);

            //foreach (var s in students)
            //{
            //    Console.WriteLine("Student name: " + s.Name);
            //    Console.WriteLine("Courses count: " + s.Count);
            //    Console.WriteLine("Total course price: " + s.TotalPrice);
            //    Console.WriteLine("Average course price: " + s.AveragePrice);
            //    Console.WriteLine("-----");
            //}

            // Problem 4 **************************************************************************          
            //var resources = db.Resources;
            //int counter = 0;

            //// Adding a license to existing resources
            //foreach (var r in resources)
            //{
            //    var license = new License()
            //    {
            //        Name = "L" + counter.ToString()
            //    };

            //    r.Licenses.Add(license);
            //    counter++;
            //}

            //db.SaveChanges();

            //foreach (var r in resources)
            //{
            //    Console.WriteLine("Resource: " + r.Name);
            //    Console.WriteLine("\t--" + string.Join(", ", r.Licenses.Select(l => l.Name)));
            //}
        }
    }
}
