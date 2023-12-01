using Lab06.MVC.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Lab06.MVC.BLL.Services.Interfaces
{
    public interface IAccountService
    {
        Task<IdentityResult> Create(StudentEntity student, string password);

        Task SignIn(StudentEntity student);

        Task<SignInResult> PasswordSignIn(string email, string password, bool rememberMe);

        Task SignOut();

        Task AddToRole(StudentEntity student, string role);
    }
}
