using Lab06.MVC.BLL.Services.Interfaces;
using Lab06.MVC.DAL.Entities;
using Lab06.MVC.DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab06.MVC.BLL.Services.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IEnrollmentRepository _enrollmentRepository;
        private readonly SignInManager<StudentEntity> _signInManager;

        public StudentService(IStudentRepository studentRepository, SignInManager<StudentEntity> signInManager, IEnrollmentRepository enrollmentRepository)
        {            
            _studentRepository = studentRepository ?? throw new ArgumentNullException(nameof(studentRepository));
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
            _enrollmentRepository = enrollmentRepository ?? throw new ArgumentNullException(nameof(enrollmentRepository));
        }

        public IQueryable<StudentEntity> GetStudents()
        {
            return _studentRepository.GetStudents();
        }

        public async Task<StudentEntity> GetStudent(string id)
        {
            return await _studentRepository.GetStudent(id);
        }

        public async Task Create(StudentEntity student, string password)
        {
            if (!StudentExists(student.Email))
            {
                await _studentRepository.Create(student, password);
            }
        }

        public async Task<StudentEntity> FindById(string id)
        {
            return await _studentRepository.FindById(id);
        }

        public async Task<IdentityResult> Update(StudentEntity student)
        {
            return await _studentRepository.Update(student);
        }

        public async Task<IdentityResult> Delete(StudentEntity student)
        {
            return await _studentRepository.Delete(student);
        }

        public Task SignIn(StudentEntity student)
        {
            return _signInManager.SignInAsync(student, false);
        }

        public async Task DeleteCourcesByStudent(string id)
        {
            List<EnrollmentEntity> enrollments = await _enrollmentRepository.GetEnrollmentList();

            foreach (EnrollmentEntity enrollmentEntity in enrollments)
            {
                if (enrollmentEntity.StudentId == id)
                {
                    await _enrollmentRepository.DeleteConfirmed(enrollmentEntity.Id);
                }
            }
        }

        public async Task<IdentityResult> ChangePassword(StudentEntity student, string oldPassword, string newPassword)
        {
            return await _studentRepository.ChangePassword(student, oldPassword, newPassword);
        }

        public async Task AddToRole(StudentEntity student, string role)
        {
            await _studentRepository.AddToRole(student, role);
        }

        public bool StudentExists(string email)
        {
            return _studentRepository.StudentExists(email);
        }
    }
}
