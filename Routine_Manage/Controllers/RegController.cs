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
    public class RegController : Controller
    {
        private readonly routine_managementContext _context;

        public RegController(routine_managementContext context)
        {
            _context = context;
        }
        // GET: /<controller>/
        public IActionResult One()
        {
            var student = from p in _context.Student where p.Class == "One" select p;
                

            return View(student);
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Two()
        {
            var student = from p in _context.Student where p.Class == "Two" select p;


            return View(student);
        }
        public IActionResult Three()
        {
            var student = from p in _context.Student where p.Class == "Three" select p;


            return View(student);
        }
        public IActionResult Four()
        {
            var student = from p in _context.Student where p.Class == "Four" select p;


            return View(student);
        }
        public IActionResult Five()
        {
            var student = from p in _context.Student where p.Class == "Five" select p;


            return View(student);
        }
    }
}
