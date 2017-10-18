using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Routine_Manage.Models;

namespace Routine_Manage.Controllers
{
    public class HomeController : Controller
    {
        private readonly routine_managementContext _context;

        public HomeController(routine_managementContext context)
        {
            _context = context;
        }
       
        public IActionResult Student()
        {
            ViewBag.BackgroudImage = "";
            return View();
        }
        [HttpPost]
        public IActionResult Student(Student st)
        {
           ViewData["Class"] = new SelectList(_context.Class, "CStage", "CStage");
            var query = (from t in _context.Student where t.Name == st.Name && t.Password == st.Password  select t).FirstOrDefault();
            if (query != null)
            {
                var ss = st.ClassNavigation;
                //Session["Class"] = query.Class;

                return RedirectToAction("ClRoutine1", "Stu"); //new { user = st.Class }
            }
            else
            {
                ViewBag.Message = "Password or Name is not correct..!";
                return View();
            }
        }
        public IActionResult Registry()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registry(Registry rg)
        {
            var query = (from p in _context.Registry where p.Email == rg.Email && p.Password == rg.Password select p).FirstOrDefault();
            if (query != null)
                return RedirectToAction("Index", "Reg");
            else
            {
                ViewBag.Message = "Password or Email is not correct..!";
                return View();
            }
        }




        public IActionResult Admin()
        {
            return View();
        }





        [HttpPost]
        public IActionResult Admin( Admin ad)
        {
            var query = (from t in _context.Admin where t.Email == ad.Email && t.Password == ad.Password select t).FirstOrDefault();
            if (query != null)
                return RedirectToAction("Index","Ad");
            else
            {
                ViewBag.Message = "Password or Email is not correct..!";
                return View();
            }
        }

        public IActionResult Error()
        {
            return View();
        }

    }
}
