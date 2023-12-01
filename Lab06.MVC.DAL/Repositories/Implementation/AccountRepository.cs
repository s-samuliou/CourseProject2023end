using Lab06.MVC.DAL.Entities;
using Lab06.MVC.DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace Lab06.MVC.DAL.Repositories.Implementation
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<StudentEntity> _userManager;

        public AccountRepository(UserManager<StudentEntity> userManager)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        public async Task<IdentityResult> Create(StudentEntity student, string password)
        {
            return await _userManager.CreateAsync(student, password);
        }

        public async Task AddToRole(StudentEntity student, string role)
        {
            await _userManager.AddToRoleAsync(student, role);
        }
    }
}
