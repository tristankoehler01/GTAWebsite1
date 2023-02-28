namespace GTAWebsite.Models
{
    public class Student : User
    {
        public double GPA { get; set; }
        public bool GTACertified { get; set; }
        public string Degree { get; set; }

    }
}
