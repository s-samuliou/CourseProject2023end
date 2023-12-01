using Lab06.MVC.DAL.Entities;

namespace Lab06.MVC.BLL.DTO
{
    public class EnrollmentDto
    {
        public int Id { get; set; }

        public int CourseId { get; set; }

        public string StudentId { get; set; }

        public Grade? Grade { get; set; }

        public string Email { get; set; }
    }
}
