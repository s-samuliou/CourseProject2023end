using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Lab06.MVC.DAL.Entities
{
    public class StudentEntity : IdentityUser
    {
        public string FirstMiddleName { get; set; }

        public string LastName { get; set; }

        public DateTime EnrollmentDate { get; set; }

        public ICollection<EnrollmentEntity> Enrollments { get; set; }
    }
}
