using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Routine_Manage.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Routine_Manage.Controllers
{
    public class StuController : Controller
    {
        private readonly routine_managementContext _context;

        public StuController(routine_managementContext context)
        {
            _context = context;
        }
        
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewData["Class"] = new SelectList(_context.Class, "CStage", "CStage");

            return View();
        }
        public IActionResult ClRoutine1()
        {
            ViewData["Class"] = new SelectList(_context.Class, "CStage", "CStage");


            return View();

        }
        [HttpPost]
        public IActionResult ClRoutine( Student s)
        {
            // 
            
            var st = from r in _context.ClassRoutine where r.CStage == s.Class select r;

            return View(st);
            
            

        }
        public IActionResult ExRoutine1()
        {
            ViewData["Class"] = new SelectList(_context.Class, "CStage", "CStage");


            return View();
        }
        [HttpPost]
        public IActionResult ExRoutine(Student s)
        {
            var st = from r in _context.ExamRoutine where r.CStage == s.Class select r;

            return View(st);
        }
    }
}
