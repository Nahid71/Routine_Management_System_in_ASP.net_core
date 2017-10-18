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
    public class SubjectsController : Controller
    {
        private readonly routine_managementContext _context;

        public SubjectsController(routine_managementContext context)
        {
            _context = context;    
        }

        // GET: Subjects
        public async Task<IActionResult> Index()
        {
            var routine_managementContext = _context.Subject.Include(s => s.T);
            return View(await routine_managementContext.ToListAsync());
        }

        // GET: Subjects/Details/5
        public async Task<IActionResult> Details(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subject = await _context.Subject
                .Include(s => s.T)
                .SingleOrDefaultAsync(m => m.SCode == id);
            if (subject == null)
            {
                return NotFound();
            }

            return View(subject);
        }

        // GET: Subjects/Create
        public IActionResult Create()
        {
            ViewData["TId"] = new SelectList(_context.Teacher, "Id", "Name");
            return View();
        }

        // POST: Subjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SCode,SName,SType,TId")] Subject subject)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subject);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["TId"] = new SelectList(_context.Teacher, "Id", "Name", subject.TId);
            return View(subject);
        }

        // GET: Subjects/Edit/5
        public async Task<IActionResult> Edit(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subject = await _context.Subject.SingleOrDefaultAsync(m => m.SCode == id);
            if (subject == null)
            {
                return NotFound();
            }
            ViewData["TId"] = new SelectList(_context.Teacher, "Id", "Name", subject.TId);
            return View(subject);
        }

        // POST: Subjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(short id, [Bind("SCode,SName,SType,TId")] Subject subject)
        {
            if (id != subject.SCode)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubjectExists(subject.SCode))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["TId"] = new SelectList(_context.Teacher, "Id", "Name", subject.TId);
            return View(subject);
        }

        // GET: Subjects/Delete/5
        public async Task<IActionResult> Delete(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subject = await _context.Subject
                .Include(s => s.T)
                .SingleOrDefaultAsync(m => m.SCode == id);
            if (subject == null)
            {
                return NotFound();
            }

            return View(subject);
        }

        // POST: Subjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(short id)
        {
            var subject = await _context.Subject.SingleOrDefaultAsync(m => m.SCode == id);
            _context.Subject.Remove(subject);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool SubjectExists(short id)
        {
            return _context.Subject.Any(e => e.SCode == id);
        }
    }
}
