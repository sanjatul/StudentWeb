using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentWeb.Data.Access;
using StudentWeb.Models;
using StudentWeb.Services.IRepositories;

namespace StudentWeb.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public StudentsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        
        public async Task<IActionResult> Index()
        {
            var students = await _unitOfWork.Student
                        .GetAllAsync("Class");
            return View(students);
        }

        public async Task<IActionResult> Create()
        {
            ViewData["ClassId"] = new SelectList(await _unitOfWork.Class.GetAllAsync(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student student)
        {
            if (ModelState.IsValid)
            {
                student.Id = Guid.NewGuid();
                student.CreatedDate = DateTime.Now;
                await _unitOfWork.Student.AddAsync(student);
                await _unitOfWork.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClassId"] = new SelectList(await _unitOfWork.Class.GetAllAsync(), "Id", "Name");
            return View(student);
        }

        public async Task<IActionResult> Details(Guid? id)
        {
          
            if (id == null)
            {
                return NotFound();
            }
            var student = await _unitOfWork.Student.GetByIdAsync(u => u.Id == id,"Class");
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

       


        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _unitOfWork.Student.GetByIdAsync(u => u.Id == id, "Class");
            if (student == null)
            {
                return NotFound();
            }
            if (student == null)
            {
                return NotFound();
            }
            ViewData["ClassId"] = new SelectList(await _unitOfWork.Class.GetAllAsync(), "Id", "Name");
            return View(student);
        }

    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id,Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                student.ModificationDate = DateTime.Now;
                await _unitOfWork.Student.UpdateAsync(student);
                    await _unitOfWork.SaveChangesAsync();
                
               
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClassId"] = new SelectList(await _unitOfWork.Class.GetAllAsync(), "Id", "Name");
            return View(student);
        }

    
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _unitOfWork.Student.GetByIdAsync(u => u.Id == id, "Class");

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _unitOfWork.Student.GetByIdAsync(u => u.Id == id, "Class");
           
            if (student == null)
            {
                return NotFound();
            }
            if (student != null)
            {
                await _unitOfWork.Student.RemoveAsync(student);
                await _unitOfWork.SaveChangesAsync();
            }
            
            return RedirectToAction(nameof(Index));
        }
    }
}
