using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab06.MVC.DAL.Entities
{
    public class CourseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string Title { get; set; }

        public int Credits { get; set; }

        public ICollection<EnrollmentEntity> Enrollments { get; set; }
    }
}
