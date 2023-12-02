namespace Lab06.MVC.DAL.Entities
{
    public enum Grade
    {
        A = 5, 
        B = 4,
        C = 3,
        D = 2,
        F = 1
    }

    public class EnrollmentEntity
    {
        public int Id { get; set; }

        public int CourseId { get; set; }

        public string StudentId { get; set; }

        public string Email { get; set; }

        public Grade? Grade { get; set; }

        public CourseEntity Course { get; set; }

        public StudentEntity Student { get; set; }
    }
}
