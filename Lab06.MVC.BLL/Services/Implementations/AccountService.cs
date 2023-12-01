using Lab06.MVC.BLL.Services.Interfaces;
using Lab06.MVC.DAL.Entities;
using Lab06.MVC.DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace Lab06.MVC.BLL.Services.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly SignInManager<StudentEntity> _signInManager;

        public AccountService(IAccountRepository accountRepository, SignInManager<StudentEntity> signInManager)
        {
            _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
        }

        public async Task<IdentityResult> Create(StudentEntity student, string password)
        {
            return await _accountRepository.Create(student, password);
        }

        public Task SignIn(StudentEntity student)
        {
            return _signInManager.SignInAsync(student, false);
        }

        public async Task<SignInResult> PasswordSignIn(string email, string password, bool rememberMe)
        {
            return await _signInManager.PasswordSignInAsync(email, password, rememberMe, false);
        }

        public async Task SignOut()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task AddToRole(StudentEntity student, string role)
        {
            await _accountRepository.AddToRole(student, role);
        }
    }
}
