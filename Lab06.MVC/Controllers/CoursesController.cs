using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lab06.MVC.BLL.Services.Interfaces;
using Lab06.MVC.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System;
using AutoMapper;
using Lab06.MVC.BLL.DTO;
using Lab06.MVC.ViewModels;

namespace GodelTechnologies.Controllers
{
    [Authorize(Roles = "admin")]
    public class CoursesController : Controller
    {
        private readonly ICourseService _courseService;
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public CoursesController(ICourseService courseService, IStudentService studentService, IMapper mapper)
        {
            _courseService = courseService ?? throw new ArgumentNullException(nameof(courseService));
            _studentService = studentService ?? throw new ArgumentNullException(nameof(studentService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _courseService.GetAllCourses());
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var course = await _courseService.FindById(id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCourseViewModel model)
        {
            if (ModelState.IsValid)
            {
                CourseEntity course = new CourseEntity
                {
                    Id = model.Id,
                    Title = model.Title,
                    Credits = model.Credits                    
                };

                if (!CourseExists(course.Id))
                {
                    await _courseService.Create(_mapper.Map<CreateCourseDto>(course));
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var course = await _courseService.GetCourse(id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Credits")] EditCourseViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                CourseEntity course = new CourseEntity
                {
                    Id = model.Id,
                    Title = model.Title,
                    Credits = model.Credits
                };

                try
                {
                    await _courseService.Update(_mapper.Map<EditCourseDto>(course));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExists(model.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var course = await _courseService.DeleteByID(id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _courseService.DeleteConfirmed(id);
            return RedirectToAction(nameof(Index));
        }

        private bool CourseExists(int id)
        {
            return _courseService.CourseExists(id);
        }

        [HttpGet]
        public async Task<IActionResult> UserList()
        {
            return View(_studentService.GetStudents());
        }
    }
}
