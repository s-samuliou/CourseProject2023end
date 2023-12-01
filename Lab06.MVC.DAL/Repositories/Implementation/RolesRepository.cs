using Lab06.MVC.DAL.Entities;
using Lab06.MVC.DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab06.MVC.DAL.Repositories.Implementation
{
    public class RolesRepository : IRolesRepository
    {
        RoleManager<IdentityRole> _roleManager;
        UserManager<StudentEntity> _userManager;

        public RolesRepository(RoleManager<IdentityRole> roleManager, UserManager<StudentEntity> userManager)
        {
            _roleManager = roleManager ?? throw new ArgumentNullException(nameof(roleManager));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        public async Task<IdentityResult> Create(string name)
        {
            return await _roleManager.CreateAsync(new IdentityRole(name));
        }

        public async Task<IdentityRole> FindByIdRole(string id)
        {
            return await _roleManager.FindByIdAsync(id);
        }

        public async Task<IdentityResult> Delete(IdentityRole role)
        {
            return await _roleManager.DeleteAsync(role);
        }

        public async Task<IList<string>> GetUserRoles(StudentEntity student)
        {
            return await _userManager.GetRolesAsync(student);
        }

        public List<IdentityRole> GetAllUserRoles()
        {
            return _roleManager.Roles.ToList();
        }

        public async Task AddStudentToRoles(StudentEntity student, IEnumerable<string> addedRoles)
        {
            await _userManager.AddToRolesAsync(student, addedRoles);
        }

        public async Task RemoveStudentFromRoles(StudentEntity student, IEnumerable<string> removedRoles)
        {
            await _userManager.RemoveFromRolesAsync(student, removedRoles);
        }
    }
}
