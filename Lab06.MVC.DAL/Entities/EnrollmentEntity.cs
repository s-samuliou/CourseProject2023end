namespace Lab06.MVC.DAL.Entities
{
    public enum Grade
    {
        A, B, C, D, F
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
