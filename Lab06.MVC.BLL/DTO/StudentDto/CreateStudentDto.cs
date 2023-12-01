using System;

namespace Lab06.MVC.BLL.DTO
{
    public class CreateStudentDto
    {
        public string Email { get; set; }

        public string LastName { get; set; }

        public string FirstMiddleName { get; set; }

        public DateTime EnrollmentDate { get; set; }

        public string Password { get; set; }
    }
}
