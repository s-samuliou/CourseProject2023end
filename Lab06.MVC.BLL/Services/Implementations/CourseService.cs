using AutoMapper;
using Lab06.MVC.BLL.DTO;
using Lab06.MVC.BLL.Services.Interfaces;
using Lab06.MVC.DAL.Entities;
using Lab06.MVC.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lab06.MVC.BLL.Services.Implementations
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public CourseService(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository ?? throw new ArgumentNullException(nameof(courseRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<CourseEntity> FindById(int id)
        {
            return await _courseRepository.FindById(id);
        }

        public async Task Create(CreateCourseDto course)
        {
            if (!CourseExists(course.Title))
            {
                await _courseRepository.Add(_mapper.Map<CourseEntity>(course));
            }
        }

        public async Task<CourseEntity> GetCourse(int id)
        {
            return await _courseRepository.GetCourse(id);
        }

        public async Task<List<CourseEntity>> GetAllCourses()
        {
            return await _courseRepository.GetAllCourses();
        }

        public async Task Update(EditCourseDto course)
        {
            await _courseRepository.Update(_mapper.Map<CourseEntity>(course));
        }

        public async Task<CourseEntity> DeleteByID(int id)
        {
            return await _courseRepository.DeleteByID(id);
        }

        public async Task DeleteConfirmed(int id)
        {
            await _courseRepository.DeleteByIDConfirmed(id);
        }

        public bool CourseExists(int id)
        {
            return _courseRepository.CourseExists(id);
        }

        public bool CourseExists(string title)
        {
            return _courseRepository.CourseExists(title);
        }
    }
}
