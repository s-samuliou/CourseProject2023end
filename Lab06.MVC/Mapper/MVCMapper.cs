using AutoMapper;
using Lab06.MVC.BLL.DTO;
using Lab06.MVC.DAL.Entities;
using Lab06.MVC.ViewModels;

namespace Lab06.MVC.Mapper
{
    public class MVCMapper : Profile
    {
        public MVCMapper()
        {
            CreateMap<StudentViewModel, StudentEntity>().ReverseMap();
            CreateMap<ChangePasswordViewModel, ChangePasswordDto>().ReverseMap();
            CreateMap<ChangeRoleViewModel, ChangeRoleDto>().ReverseMap();
            CreateMap<CreateStudentViewModel, CreateStudentDto>().ReverseMap();
            CreateMap<EditStudentViewModel, EditStudentDto>().ReverseMap();
            CreateMap<LoginViewModel, LoginDto>().ReverseMap();
            CreateMap<RegisterViewModel, RegisterDto>().ReverseMap();
            CreateMap<CreateCourseViewModel, CreateCourseDto>().ReverseMap();
            CreateMap<EditCourseViewModel, EditCourseDto>().ReverseMap();
            CreateMap<EnrollmentViewModel, EnrollmentDto>().ReverseMap();
        }
    }
}
