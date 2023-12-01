using Lab06.MVC.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lab06.MVC.DAL.Repositories.Interfaces
{
    public interface IRolesRepository
    {
        Task<IdentityResult> Create(string name);

        Task<IdentityRole> FindByIdRole(string id);

        Task<IdentityResult> Delete(IdentityRole role);

        Task<IList<string>> GetUserRoles(StudentEntity student);

        List<IdentityRole> GetAllUserRoles();

        Task AddStudentToRoles(StudentEntity student, IEnumerable<string> addedRoles);

        Task RemoveStudentFromRoles(StudentEntity student, IEnumerable<string> removedRoles);
    }
}
