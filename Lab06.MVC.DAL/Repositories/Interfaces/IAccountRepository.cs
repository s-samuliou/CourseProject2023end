using Lab06.MVC.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Lab06.MVC.DAL.Repositories.Interfaces
{
    public interface IAccountRepository
    {
        Task<IdentityResult> Create(StudentEntity student, string password);

        Task AddToRole(StudentEntity student, string role);
    }
}
