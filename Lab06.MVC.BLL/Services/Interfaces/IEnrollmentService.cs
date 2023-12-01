using Lab06.MVC.BLL.DTO;
using Lab06.MVC.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lab06.MVC.BLL.Services.Interfaces
{
    public interface IEnrollmentService
    {
        DbSet<CourseEntity> GetCourse();

        DbSet<StudentEntity> GetStudent();

        IIncludableQueryable<EnrollmentEntity, StudentEntity> GetAllEnrollments();

        Task<EnrollmentEntity> GetEnrollmentEntity(int id);

        Task Create(EnrollmentDto enrollmentEntity);

        Task<EnrollmentEntity> Find(int id);

        Task Update(EnrollmentDto enrollmentDto);

        Task DeleteConfirmed(int id);

        Task<List<EnrollmentEntity>> GetEnrollmentList();

        bool EnrollmentEntityExists(int id);
    }
}
