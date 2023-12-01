using AutoMapper;
using Lab06.MVC.BLL.DTO;
using Lab06.MVC.DAL.Entities;

namespace Lab06.MVC.BLL.Mappers
{
    public class BLLMaper : Profile
    {
        public BLLMaper()
        {
            CreateMap<StudentDto, StudentEntity>().ReverseMap();
            CreateMap<ChangePasswordDto, StudentEntity>().ReverseMap();
            CreateMap<CreateStudentDto, StudentEntity>().ReverseMap();
            CreateMap<EditStudentDto, StudentEntity>().ReverseMap();

            CreateMap<ChangeRoleDto, StudentEntity>().ReverseMap();

            CreateMap<LoginDto, StudentEntity>().ReverseMap();
            CreateMap<RegisterDto, StudentEntity>().ReverseMap();

            CreateMap<EditCourseDto, CourseEntity>().ReverseMap();
            CreateMap<CreateCourseDto, CourseEntity>().ReverseMap();

            CreateMap<EnrollmentDto, EnrollmentEntity>().ReverseMap();
        }
    }
}
