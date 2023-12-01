using Lab06.MVC.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lab06.MVC.BLL.Services.Interfaces
{
    public interface IRoleService
    {
        Task<IdentityResult> Create(string name);

        Task<IdentityRole> FindRoleById(string id);

        Task<IdentityResult> Delete(IdentityRole identityRole);

        List<IdentityRole> GetAllUserRoles();

        Task<IList<string>> GetUserRoles(StudentEntity student);

        Task AddStudentToRoles(StudentEntity student, IEnumerable<string> addedRoles);

        Task RemoveStudentFromRoles(StudentEntity student, IEnumerable<string> addedRoles);
    }
}
