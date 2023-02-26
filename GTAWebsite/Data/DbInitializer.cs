using GTAWebsite.Models;
using NuGet.Packaging;

namespace GTAWebsite.Data
{
    public class DbInitializer
    {
        public static void Initialize(GTAWebsiteContext context)
        {
            if (context.Course.Any())
            {
                return;
            }

            var courses = new Course[]
            {
                new Course{courseName = "CS101", courseDescription = "Test.", positionName = "Graduate Teaching Assistant"},
                new Course{courseName = "CS303", courseDescription = "Test.", positionName = "Grader"}
            };

            context.Course.AddRange(courses);
            context.SaveChanges();
        }
    }
}
