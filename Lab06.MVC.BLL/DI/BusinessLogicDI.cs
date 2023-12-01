using Lab06.MVC.BLL.Services.Implementations;
using Lab06.MVC.BLL.Services.Interfaces;
using Lab06.MVC.BLL.Validators;
using Lab06.MVC.DAL.Data;
using Lab06.MVC.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Lab06.MVC.BLL.DI
{
    public static class BusinessLogicDI
    {
        public static void AddBusinessLogic(this IServiceCollection service)
        {
            service.AddScoped<IStudentService, StudentService>();
            service.AddScoped<ICourseService, CourseService>();
            service.AddScoped<IAccountService, AccountService>();
            service.AddScoped<IRoleService, RoleService>();
            service.AddScoped<IEnrollmentService, EnrollmentService>();

            service.AddIdentity<StudentEntity, IdentityRole>(opts => {
                opts.Password.RequiredLength = 5;
                opts.Password.RequireNonAlphanumeric = true;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = true;
                opts.Password.RequireDigit = true;
            })
            .AddEntityFrameworkStores<DataContext>();

            service.AddTransient<IUserValidator<StudentEntity>, StudentValidator>();
        }
    }
}
