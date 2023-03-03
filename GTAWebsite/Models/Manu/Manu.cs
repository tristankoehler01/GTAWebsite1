namespace GTAWebsite.Models.Manu
{
    public class Manu
    {
        public String Position { get; set; }
        public String Qualification { get; set; }
        public String GraderCourses { get; set; }
        public String LabCourses { get; set; }

        public static List<String> positions = new List<String>() { "Any", "Grader", "Graduate Teaching Assistant", "Lab Instructor" };
        public static List<String> qualifications = new List<String>() { "Any", "BS", "MB", "PhD" };
        public static List<String> courses = new List<String>() { "Any", "CS101", "CS101L", "CS191", "CS201R", "CS201L", "CS291", "CS303", "CS320", "CS349", "CS394R", "CS404", "CS441", "CS449", "CS456", "CS457", "CS458", "CS461", "CS465R", "CS470", "CS5520", "CS5525", "CS5552A", "CS5565", "CS5573", "CS5590PA", "CS5592", "CS5596A", "CS5596B" };
    }
}
