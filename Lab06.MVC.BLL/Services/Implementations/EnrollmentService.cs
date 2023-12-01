using AutoMapper;
using Lab06.MVC.BLL.DTO;
using Lab06.MVC.BLL.Services.Interfaces;
using Lab06.MVC.DAL.Entities;
using Lab06.MVC.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lab06.MVC.BLL.Services.Implementations
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IEnrollmentRepository _enrollmentRepository;
        private readonly IMapper _mapper;

        public EnrollmentService(IEnrollmentRepository enrollmentRepository, IMapper mapper)
        {
            _enrollmentRepository = enrollmentRepository ?? throw new ArgumentNullException(nameof(enrollmentRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public DbSet<CourseEntity> GetCourse()
        {
            return _enrollmentRepository.GetCourse();
        }

        public DbSet<StudentEntity> GetStudent()
        {
            return _enrollmentRepository.GetStudent();
        }

        public IIncludableQueryable<EnrollmentEntity, StudentEntity> GetAllEnrollments()
        {
            return _enrollmentRepository.GetAllEnrollments();
        }

        public async Task<EnrollmentEntity> GetEnrollmentEntity(int id)
        {
            return await _enrollmentRepository.GetEnrollmentEntity(id);
        }

        public async Task Create(EnrollmentDto enrollment)
        {
            await _enrollmentRepository.Create(_mapper.Map<EnrollmentEntity>(enrollment));
        }

        public async Task<EnrollmentEntity> Find(int id)
        {
            return await _enrollmentRepository.Find(id);
        }

        public async Task Update(EnrollmentDto enrollment)
        {
            await _enrollmentRepository.Update(_mapper.Map<EnrollmentEntity>(enrollment));
        }

        public async Task DeleteConfirmed(int id)
        {
            await _enrollmentRepository.DeleteConfirmed(id);
        }

        public async Task<List<EnrollmentEntity>> GetEnrollmentList()
        {
            return await _enrollmentRepository.GetEnrollmentList();
        }

        public bool EnrollmentEntityExists(int id)
        {
            return _enrollmentRepository.EnrollmentEntityExists(id);
        }
    }
}
