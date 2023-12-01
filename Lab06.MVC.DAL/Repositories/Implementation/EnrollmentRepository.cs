using Lab06.MVC.DAL.Data;
using Lab06.MVC.DAL.Entities;
using Lab06.MVC.DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab06.MVC.DAL.Repositories.Implementation
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly DataContext _context;

        public EnrollmentRepository(DataContext context)
        {
            _context = context;
        }

        public DbSet<CourseEntity> GetCourse()
        {
            return _context.Course;
        }

        public DbSet<StudentEntity> GetStudent()
        {
            return _context.Student;
        }

        public IIncludableQueryable<EnrollmentEntity, StudentEntity> GetAllEnrollments()
        {
            return _context.Enrollment.Include(e => e.Course).Include(e => e.Student);
        }

        public async Task<EnrollmentEntity> GetEnrollmentEntity(int id)
        {
            return await _context.Enrollment
                .Include(e => e.Course)
                .Include(e => e.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task Create(EnrollmentEntity enrollmentEntity)
        {
            _context.Add(enrollmentEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<EnrollmentEntity> Find(int id)
        {
            return await _context.Enrollment.FindAsync(id);
        }

        public async Task Update(EnrollmentEntity enrollmentEntity)
        {
            _context.Update(enrollmentEntity);
            await _context.SaveChangesAsync();
        }        

        public async Task DeleteConfirmed(int id)
        {
            var enrollmentEntity = await _context.Enrollment.FindAsync(id);
            _context.Enrollment.Remove(enrollmentEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<EnrollmentEntity>> GetEnrollmentList()
        {
            return await _context.Enrollment.ToListAsync();
        }

        public bool EnrollmentEntityExists(int id)
        {
            return _context.Enrollment.Any(e => e.Id == id);
        }
    }
}
