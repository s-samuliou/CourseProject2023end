using Lab06.MVC.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lab06.MVC.DAL.Repositories.Interfaces
{
    public interface IEnrollmentRepository
    {
        DbSet<CourseEntity> GetCourse();

        DbSet<StudentEntity> GetStudent();

        IIncludableQueryable<EnrollmentEntity, StudentEntity> GetAllEnrollments();

        Task<EnrollmentEntity> GetEnrollmentEntity(int id);

        Task Create(EnrollmentEntity enrollmentEntity);

        Task<EnrollmentEntity> Find(int id);

        Task Update(EnrollmentEntity enrollmentEntity);

        Task DeleteConfirmed(int id);

        Task<List<EnrollmentEntity>> GetEnrollmentList();

        bool EnrollmentEntityExists(int id);
    }
}
