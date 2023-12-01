using Lab06.MVC.DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace Lab06.MVC.DAL.Data
{
    public class DataContext : IdentityDbContext<StudentEntity>
    {
        private readonly IConfiguration _configuration;

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DataContext(DbContextOptions<DataContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            Database.EnsureCreated();
        }

        public DbSet<StudentEntity> Student { get; set; }

        public DbSet<CourseEntity> Course { get; set; }

        public DbSet<EnrollmentEntity> Enrollment { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
