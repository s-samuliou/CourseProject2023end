using AutoMapper;
using Lab06.MVC.BLL.Services.Interfaces;
using Lab06.MVC.DAL.Entities;
using Lab06.MVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GodelTechnologies.Controllers
{
    [Authorize(Roles = "admin,student")]
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public StudentController(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService ?? throw new ArgumentNullException(nameof(studentService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["CurrentFilter"] = searchString;

            var students = _studentService.GetStudents();

            if (!String.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => s.LastName.Contains(searchString)
                                       || s.FirstMiddleName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "email_desc":
                    students = students.OrderByDescending(s => s.Email);
                    break;
                case "name_desc":
                    students = students.OrderByDescending(s => s.LastName);
                    break;
                case "Date":
                    students = students.OrderBy(s => s.EnrollmentDate);
                    break;
                case "date_desc":
                    students = students.OrderByDescending(s => s.EnrollmentDate);
                    break;
                default:
                    students = students.OrderBy(s => s.LastName);
                    break;
            }

            return View(await students.AsNoTracking().ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _studentService.GetStudent(id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Create(CreateStudentViewModel model)
        {
            if (ModelState.IsValid)
            {
                StudentEntity student = new StudentEntity
                { 
                    Email = model.Email,
                    UserName = model.Email,
                    LastName = model.LastName,
                    FirstMiddleName = model.FirstMiddleName,
                    EnrollmentDate = model.EnrollmentDate
                };

                // Сначала создайте и сохраните студента
                await _studentService.Create(student, model.Password);

                // Дождитесь сохранения студента в базе данных
                if (_studentService.StudentExists(student.Email))
                {
                    await _studentService.AddToRole(student, "student");
                    return RedirectToAction("Index", "Student");
                }

                // Теперь добавьте его в роль
                
            }

            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(string id)
        {
            StudentEntity student = await _studentService.FindById(id);
            if (student == null)
            {
                return NotFound();
            }

            EditStudentViewModel model = new EditStudentViewModel
            { 
                Id = student.Id,
                Email = student.Email,
                LastName = student.LastName,
                EnrollmentDate = student.EnrollmentDate,
                FirstMiddleName = student.FirstMiddleName
            };

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(EditStudentViewModel model)
        {
            if (ModelState.IsValid)
            {
                StudentEntity student = await _studentService.FindById(model.Id);
                if (student != null)
                {
                    student.Email = model.Email;
                    student.UserName = model.FirstMiddleName;
                    student.LastName = model.LastName;
                    student.FirstMiddleName = model.FirstMiddleName;
                    student.EnrollmentDate = model.EnrollmentDate;

                    var result = await _studentService.Update(student);
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
            }
            return View(model);
        }


        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            StudentEntity student = await _studentService.FindById(id);

            if (student != null)
            {
                await _studentService.DeleteCourcesByStudent(id);

                await _studentService.Delete(student);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> ChangePassword(string id)
        {
            StudentEntity student = await _studentService.FindById(id);
            if (student == null)
            {
                return NotFound();
            }

            ChangePasswordViewModel model = new ChangePasswordViewModel 
            { 
                Id = student.Id,
                Email = student.Email
            };

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                StudentEntity student = await _studentService.FindById(model.Id);

                if (student != null)
                {
                    IdentityResult result = await _studentService.ChangePassword(student, model.OldPassword, model.NewPassword);

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
                else
                {
                    ModelState.AddModelError(string.Empty, "User is not found.");
                }
            }
            return View(model);
        }
    }
}
