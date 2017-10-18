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
    public class ClassRoutinesController : Controller
    {
        private readonly routine_managementContext _context;

        public ClassRoutinesController(routine_managementContext context)
        {
            _context = context;    
        }

        // GET: ClassRoutines
        public async Task<IActionResult> Index()
        {
            var routine_managementContext = _context.ClassRoutine.Include(c => c.CStageNavigation).Include(c => c.RoomNoNavigation).Include(c => c.SCodeNavigation);
            return View(await routine_managementContext.ToListAsync());
        }

        // GET: ClassRoutines/Details/5
        public async Task<IActionResult> Details(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classRoutine = await _context.ClassRoutine
                .Include(c => c.CStageNavigation)
                .Include(c => c.RoomNoNavigation)
                .Include(c => c.SCodeNavigation)
                .SingleOrDefaultAsync(m => m.Serial == id);
            if (classRoutine == null)
            {
                return NotFound();
            }

            return View(classRoutine);
        }

        // GET: ClassRoutines/Create
        public IActionResult Create()
        {
            ViewData["CStage"] = new SelectList(_context.Class, "CStage", "CStage");
            ViewData["RoomNo"] = new SelectList(_context.Room, "RoomNo", "RoomNo");
            ViewData["SCode"] = new SelectList(_context.Subject, "SCode", "SName");
            return View();
        }

        // POST: ClassRoutines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Serial,CStage,SCode,RoomNo,Day,Time")] ClassRoutine classRoutine)
        {
            if (ModelState.IsValid)
            {
                _context.Add(classRoutine);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["CStage"] = new SelectList(_context.Class, "CStage", "CStage", classRoutine.CStage);
            ViewData["RoomNo"] = new SelectList(_context.Room, "RoomNo", "RoomNo", classRoutine.RoomNo);
            ViewData["SCode"] = new SelectList(_context.Subject, "SCode", "SName", classRoutine.SCode);
            return View(classRoutine);
        }

        // GET: ClassRoutines/Edit/5
        public async Task<IActionResult> Edit(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classRoutine = await _context.ClassRoutine.SingleOrDefaultAsync(m => m.Serial == id);
            if (classRoutine == null)
            {
                return NotFound();
            }
            ViewData["CStage"] = new SelectList(_context.Class, "CStage", "CStage", classRoutine.CStage);
            ViewData["RoomNo"] = new SelectList(_context.Room, "RoomNo", "RoomNo", classRoutine.RoomNo);
            ViewData["SCode"] = new SelectList(_context.Subject, "SCode", "SName", classRoutine.SCode);
            return View(classRoutine);
        }

        // POST: ClassRoutines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(short id, [Bind("Serial,CStage,SCode,RoomNo,Day,Time")] ClassRoutine classRoutine)
        {
            if (id != classRoutine.Serial)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(classRoutine);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassRoutineExists(classRoutine.Serial))
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
            ViewData["CStage"] = new SelectList(_context.Class, "CStage", "CStage", classRoutine.CStage);
            ViewData["RoomNo"] = new SelectList(_context.Room, "RoomNo", "RoomNo", classRoutine.RoomNo);
            ViewData["SCode"] = new SelectList(_context.Subject, "SCode", "SName", classRoutine.SCode);
            return View(classRoutine);
        }

        // GET: ClassRoutines/Delete/5
        public async Task<IActionResult> Delete(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classRoutine = await _context.ClassRoutine
                .Include(c => c.CStageNavigation)
                .Include(c => c.RoomNoNavigation)
                .Include(c => c.SCodeNavigation)
                .SingleOrDefaultAsync(m => m.Serial == id);
            if (classRoutine == null)
            {
                return NotFound();
            }

            return View(classRoutine);
        }

        // POST: ClassRoutines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(short id)
        {
            var classRoutine = await _context.ClassRoutine.SingleOrDefaultAsync(m => m.Serial == id);
            _context.ClassRoutine.Remove(classRoutine);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ClassRoutineExists(short id)
        {
            return _context.ClassRoutine.Any(e => e.Serial == id);
        }
    }
}
