using Lab06.MVC.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace Lab06.MVC.BLL.Services.Interfaces
{
    public interface IStudentService
    {
        IQueryable<StudentEntity> GetStudents();

        Task<StudentEntity> GetStudent(string id);

        Task Create(StudentEntity student, string password);

        Task<StudentEntity> FindById(string id);

        Task<IdentityResult> Update(StudentEntity student);

        Task<IdentityResult> Delete(StudentEntity student);

        Task DeleteCourcesByStudent(string id);

        Task SignIn(StudentEntity student);

        Task<IdentityResult> ChangePassword(StudentEntity student, string oldPassword, string newPassword);

        Task AddToRole(StudentEntity student, string role);

        bool StudentExists(string email);
    }
}
