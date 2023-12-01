using Lab06.MVC.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab06.MVC.DAL.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        IQueryable<StudentEntity> GetStudents();

        Task<IdentityResult> Create(StudentEntity student, string password);

        Task<StudentEntity> GetStudent(string id);

        Task<StudentEntity> FindById(string id);

        Task<IdentityResult> Update(StudentEntity student);

        Task<IdentityResult> Delete(StudentEntity student);

        Task<IdentityResult> ChangePassword(StudentEntity student, string oldPassWord, string newPassword);

        Task AddToRole(StudentEntity student, string role);

        bool StudentExists(string email);
    }
}
