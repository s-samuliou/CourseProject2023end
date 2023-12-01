using AutoMapper;
using Lab06.MVC.BLL.Services.Interfaces;
using Lab06.MVC.DAL.Entities;
using Lab06.MVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodelTechnologies.Controllers
{
    [Authorize(Roles = "admin")]
    public class RolesController : Controller
    {
        private readonly IRoleService _roleService;
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public RolesController(IRoleService rolesRepository, IStudentService studentService, IMapper mapper)
        {
            _roleService = rolesRepository ?? throw new ArgumentNullException(nameof(rolesRepository));
            _studentService = studentService ?? throw new ArgumentNullException(nameof(studentService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public IActionResult Index() => View(_roleService.GetAllUserRoles());

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                IdentityResult result = await _roleService.Create(name);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(name);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            IdentityRole role = await _roleService.FindRoleById(id);

            if (role != null)
            {
                IdentityResult result = await _roleService.Delete(role);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UserList() => View(_studentService.GetStudents());

        [HttpGet]
        public async Task<IActionResult> Edit(string userId)
        {
            StudentEntity student = await _studentService.FindById(userId);

            if (student != null)
            {
                var userRoles = await _roleService.GetUserRoles(student);
                var allRoles = _roleService.GetAllUserRoles();

                ChangeRoleViewModel model = new ChangeRoleViewModel
                {
                    UserId = student.Id,
                    UserEmail = student.Email,
                    UserRoles = userRoles,
                    AllRoles = allRoles
                };

                return View(model);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string userId, List<string> roles)
        {
            StudentEntity student = await _studentService.FindById(userId);

            if (student != null)
            {
                var userRoles = await _roleService.GetUserRoles(student);
                var allRoles = _roleService.GetAllUserRoles();

                var addedRoles = roles.Except(userRoles);
                var removedRoles = userRoles.Except(roles);

                await _roleService.RemoveStudentFromRoles(student, removedRoles);
                await _roleService.AddStudentToRoles(student, addedRoles);

                return RedirectToAction("UserList");
            }

            return NotFound();
        }
    }
}
