using Lab06.MVC.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lab06.MVC.BLL.Validators
{
    public class StudentValidator : IUserValidator<StudentEntity>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<StudentEntity> manager, StudentEntity student)
        {
            List<IdentityError> errors = new List<IdentityError>();

            if (student.Email.ToLower().EndsWith("@spam.com"))
            {
                errors.Add(new IdentityError
                {
                    Description = "This domain is in the spam database. Choose another mail service."
                });
            }

            return Task.FromResult(errors.Count == 0 ?
                IdentityResult.Success : IdentityResult.Failed(errors.ToArray()));
        }
    }
}
