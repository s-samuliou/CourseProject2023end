using System;

namespace Lab06.MVC.BLL.DTO
{
    public class EditStudentDto
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public string LastName { get; set; }

        public string FirstMiddleName { get; set; }

        public DateTime EnrollmentDate { get; set; }
    }
}
