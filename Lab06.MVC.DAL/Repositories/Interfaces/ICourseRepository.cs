using Lab06.MVC.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lab06.MVC.DAL.Repositories.Interfaces
{
    public interface ICourseRepository
    {
        Task Add(CourseEntity course);

        Task<CourseEntity> GetCourse(int id);

        Task<List<CourseEntity>> GetAllCourses();

        Task<CourseEntity> FindById(int id);

        Task Update(CourseEntity course);

        Task<CourseEntity> DeleteByID(int id);

        Task DeleteByIDConfirmed(int id);

        bool CourseExists(int id);

        bool CourseExists(string title);
    }
}
