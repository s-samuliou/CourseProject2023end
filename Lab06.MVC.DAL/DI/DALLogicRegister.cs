using Lab06.MVC.DAL.Data;
using Lab06.MVC.DAL.Repositories.Interfaces;
using Lab06.MVC.DAL.Repositories.Implementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lab06.MVC.DAL.DI
{
    public static class DALLogicRegister
    {
        public static void AddDataLogic(this IServiceCollection service, IConfiguration config)
        {
            service.AddScoped<IStudentRepository, StudentRepository>();
            service.AddScoped<ICourseRepository, CourseRepository>();
            service.AddScoped<IAccountRepository, AccountRepository>();
            service.AddScoped<IRolesRepository, RolesRepository>();
            service.AddScoped<IEnrollmentRepository, EnrollmentRepository>();

            service.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });
        }
    }
}
