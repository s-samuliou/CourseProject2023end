using AutoMapper;
using Lab06.MVC.BLL.Services.Interfaces;
using Lab06.MVC.DAL.Entities;
using Lab06.MVC.DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lab06.MVC.BLL.Services.Implementations
{
    public class RoleService : IRoleService
    {
        private readonly IRolesRepository _rolesRepository;
        private readonly IMapper _mapper;

        public RoleService(IRolesRepository rolesRepository, IMapper mapper)
        {
            _rolesRepository = rolesRepository ?? throw new ArgumentNullException(nameof(rolesRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IdentityResult> Create(string name)
        {
            return await _rolesRepository.Create(name);
        }

        public async Task<IdentityRole> FindRoleById(string id)
        {
            return await _rolesRepository.FindByIdRole(id);
        }

        public async Task<IdentityResult> Delete(IdentityRole identityRole)
        {
            return await _rolesRepository.Delete(identityRole);
        }

        public List<IdentityRole> GetAllUserRoles()
        {
            return _rolesRepository.GetAllUserRoles();
        }

        public async Task<IList<string>> GetUserRoles(StudentEntity student)
        {
            return await _rolesRepository.GetUserRoles(_mapper.Map<StudentEntity>(student));
        }

        public async Task AddStudentToRoles(StudentEntity student, IEnumerable<string> addedRoles)
        {
            await _rolesRepository.AddStudentToRoles(_mapper.Map<StudentEntity>(student), addedRoles);
        }

        public async Task RemoveStudentFromRoles(StudentEntity student, IEnumerable<string> removedRoles)
        {
            await _rolesRepository.RemoveStudentFromRoles(_mapper.Map<StudentEntity>(student), removedRoles);
        }
    }
}
