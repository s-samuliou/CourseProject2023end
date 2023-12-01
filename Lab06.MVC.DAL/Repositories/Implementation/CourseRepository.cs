using Lab06.MVC.DAL.Data;
using Lab06.MVC.DAL.Entities;
using Lab06.MVC.DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab06.MVC.DAL.Repositories.Implementation
{
    public class CourseRepository : ICourseRepository
    {
        private readonly DataContext _context;
        private readonly UserManager<StudentEntity> _userManager;

        public CourseRepository(DataContext context, UserManager<StudentEntity> userManager)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        public async Task Add(CourseEntity course)
        {
            _context.Add(course);
            await _context.SaveChangesAsync();
        }

        public async Task<CourseEntity> GetCourse(int id)
        {
            return await _context.Course.FindAsync(id);
        }

        public async Task<List<CourseEntity>> GetAllCourses()
        {
            return await _context.Course.ToListAsync();
        }

        public async Task<CourseEntity> FindById(int id)
        {
            return await _context.Course
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<StudentEntity> FindById(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }

        public async Task Update(CourseEntity course)
        {
            _context.Update(course);
            await _context.SaveChangesAsync();
        }

        public async Task<CourseEntity> DeleteByID(int id)
        {
            return await _context.Course
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task DeleteByIDConfirmed(int id)
        {
            var course = await _context.Course.FindAsync(id);
            _context.Course.Remove(course);
            await _context.SaveChangesAsync();
        }

        public bool CourseExists(int id)
        {
            return _context.Course.Any(e => e.Id == id);
        }

        public bool CourseExists(string title)
        {
            return _context.Course.Any(e => e.Title == title);
        }
    }
}
