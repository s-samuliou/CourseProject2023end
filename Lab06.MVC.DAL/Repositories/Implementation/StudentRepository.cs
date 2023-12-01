using Lab06.MVC.DAL.Data;
using Lab06.MVC.DAL.Entities;
using Lab06.MVC.DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Lab06.MVC.DAL.Repositories.Implementation
{
    public class StudentRepository : IStudentRepository
    {
        private readonly UserManager<StudentEntity> _userManager;
        private readonly DataContext _context;

        public StudentRepository(UserManager<StudentEntity> userManager, DataContext context)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IQueryable<StudentEntity> GetStudents()
        {
            return from s in _context.Users select s;
        }

        public async Task<IdentityResult> Create(StudentEntity student, string password)
        {
            return await _userManager.CreateAsync(student, password);
        }

        public async Task<StudentEntity> GetStudent(string id)
        {
            return await _context.Users
                .Include(s => s.Enrollments)
                .ThenInclude(e => e.Course)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => Convert.ToString(m.Id) == id);                
        }

        public async Task<StudentEntity> FindById(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }

        public async Task<IdentityResult> Update(StudentEntity student)
        {
            return await _userManager.UpdateAsync(student);
        }

        public async Task<IdentityResult> Delete(StudentEntity student)
        {
            return await _userManager.DeleteAsync(student);
        }

        public async Task<IdentityResult> ChangePassword(StudentEntity student, string oldPassWord, string newPassword)
        {
            return await _userManager.ChangePasswordAsync(student, oldPassWord, newPassword);
        }

        public async Task AddToRole(StudentEntity student, string role)
        {
            await _userManager.AddToRoleAsync(student, role);
        }

        public bool StudentExists(string email)
        {
            return _context.Users.Any(e => e.Email == email);
        }
    }
}
