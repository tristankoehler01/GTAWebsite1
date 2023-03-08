namespace GTAWebsite.Models
{
    public class Menu
    {
        public string Position { get; set; }
        public string Qualification { get; set; }
        public string GraderCourses { get; set; }
        public string LabCourses { get; set; }

        public static List<string> positions = new List<string>() { "Any", "Grader", "Graduate Teaching Assistant", "Lab Instructor" };
        public static List<string> qualifications = new List<string>() { "Any", "BS", "MB", "PhD" };
        public static List<string> courses = new List<string>() { "Any", "CS101", "CS101L", "CS191", "CS201R", "CS201L", "CS291", "CS303", "CS320", "CS349", "CS394R", "CS404", "CS441", "CS449", "CS456", "CS457", "CS458", "CS461", "CS465R", "CS470", "CS5520", "CS5525", "CS5552A", "CS5565", "CS5573", "CS5590PA", "CS5592", "CS5596A", "CS5596B" };
    }
}
