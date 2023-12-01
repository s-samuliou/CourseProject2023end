using System;

namespace Lab06.MVC.ViewModels
{
    public class EditStudentViewModel
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public string LastName { get; set; }

        public string FirstMiddleName { get; set; }

        public DateTime EnrollmentDate { get; set; }
    }
}
