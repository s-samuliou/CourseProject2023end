using Lab06.MVC.DAL.Entities;

namespace Lab06.MVC.ViewModels
{
    public class EnrollmentViewModel
    {
        public int Id { get; set; }

        public int CourseId { get; set; }

        public string StudentId { get; set; }

        public Grade? Grade { get; set; }

        public string Email { get; set; }
    }
}
