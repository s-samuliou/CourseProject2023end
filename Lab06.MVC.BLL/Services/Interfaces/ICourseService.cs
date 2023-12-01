using Lab06.MVC.BLL.DTO;
using Lab06.MVC.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lab06.MVC.BLL.Services.Interfaces
{
    public interface ICourseService
    {
        Task<CourseEntity> FindById(int id);

        Task Create(CreateCourseDto course);

        Task<CourseEntity> GetCourse(int id);

        Task<List<CourseEntity>> GetAllCourses();

        Task Update(EditCourseDto course);

        Task<CourseEntity> DeleteByID(int id);

        Task DeleteConfirmed(int id);

        bool CourseExists(int id);
    }
}
