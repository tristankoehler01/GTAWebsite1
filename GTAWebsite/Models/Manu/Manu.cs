namespace GTAWebsite.Models.Manu
{
    public class Manu
    {
        public String Position { get; set; }
        public String Qualification { get; set; }
        public String GraderCourses { get; set; }
        public String LabCourses { get; set; }


    }
    public enum Position {  
    Grader,
    LabInstructor
    }
    public enum Qualification
    {
        BS,
        MB,
        PHD

    }
    public enum GraderCourses
    {
        CS20, CS21, CS22, CS23, CS24, CS25, CS26, CS27, CS28,   CS29, CS30, CS31, CS32, CS33
    }
    public enum LabCourses
    {
        BO2, BO3, BO4, BO5, BO6, BO7, BO8, BO9, BO10, BO11, BO12
    }
}
