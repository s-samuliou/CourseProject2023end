using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab06.MVC.BLL.Services.Interfaces;
using System;
using Lab06.MVC.BLL.DTO;
using AutoMapper;
using Lab06.MVC.ViewModels;

namespace Lab06.MVC.Controllers
{
    public class EnrollmentController : Controller
    {
        private readonly IEnrollmentService _enrollmentService;
        private readonly IMapper _mapper;

        public EnrollmentController(IEnrollmentService enrollmentService, IMapper mapper)
        {
            _enrollmentService = enrollmentService ?? throw new ArgumentNullException(nameof(enrollmentService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var dataContext = _enrollmentService.GetAllEnrollments();

            return View(await dataContext.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var enrollmentEntity = await _enrollmentService.GetEnrollmentEntity(id);

            if (enrollmentEntity == null)
            {
                return NotFound();
            }

            return View(enrollmentEntity);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_enrollmentService.GetCourse(), "Id", "Title");
            ViewData["StudentId"] = new SelectList(_enrollmentService.GetStudent(), "Id", "Email");
           
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CourseId,StudentId,Email,Grade")] EnrollmentViewModel enrollmentModel)
        {
            if (ModelState.IsValid)
            {
                await _enrollmentService.Create(_mapper.Map<EnrollmentDto>(enrollmentModel));
                return RedirectToAction(nameof(Index));
            }

            ViewData["CourseId"] = new SelectList(_enrollmentService.GetCourse(), "Id", "Title", enrollmentModel.CourseId);
            ViewData["StudentId"] = new SelectList(_enrollmentService.GetStudent(), "Id", "Email", enrollmentModel.StudentId);
            
            return View(enrollmentModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var enrollmentEntity = await _enrollmentService.Find(id);
            
            if (enrollmentEntity == null)
            {
                return NotFound();
            }
            
            ViewData["CourseId"] = new SelectList(_enrollmentService.GetCourse(), "Id", "Title", enrollmentEntity.CourseId);
            ViewData["StudentId"] = new SelectList(_enrollmentService.GetStudent(), "Id", "Email", enrollmentEntity.StudentId);
            
            return View(enrollmentEntity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CourseId,StudentId,Email,Grade")] EnrollmentViewModel enrollmentModel)
        {
            if (id != enrollmentModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _enrollmentService.Update(_mapper.Map<EnrollmentDto>(enrollmentModel));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnrollmentEntityExists(enrollmentModel.Id))
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
            
            ViewData["CourseId"] = new SelectList(_enrollmentService.GetCourse(), "Id", "Title", enrollmentModel.CourseId);
            ViewData["StudentId"] = new SelectList(_enrollmentService.GetStudent(), "Id", "Email", enrollmentModel.StudentId);
            
            return View(enrollmentModel);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var enrollmentEntity = await _enrollmentService.Find(id);

            if (enrollmentEntity == null)
            {
                return NotFound();
            }

            return View(enrollmentEntity);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _enrollmentService.DeleteConfirmed(id);

            return RedirectToAction(nameof(Index));
        }

        private bool EnrollmentEntityExists(int id)
        {
            return _enrollmentService.EnrollmentEntityExists(id);
        }
    }
}
