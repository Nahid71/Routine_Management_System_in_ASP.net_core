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
    public class ExamRoutinesController : Controller
    {
        private readonly routine_managementContext _context;

        public ExamRoutinesController(routine_managementContext context)
        {
            _context = context;    
        }

        // GET: ExamRoutines
        public async Task<IActionResult> Index()
        {
            var routine_managementContext = _context.ExamRoutine.Include(e => e.CStageNavigation).Include(e => e.RoomNoNavigation).Include(e => e.SCodeNavigation);
            return View(await routine_managementContext.ToListAsync());
        }

        // GET: ExamRoutines/Details/5
        public async Task<IActionResult> Details(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var examRoutine = await _context.ExamRoutine
                .Include(e => e.CStageNavigation)
                .Include(e => e.RoomNoNavigation)
                .Include(e => e.SCodeNavigation)
                .SingleOrDefaultAsync(m => m.Serial == id);
            if (examRoutine == null)
            {
                return NotFound();
            }

            return View(examRoutine);
        }

        // GET: ExamRoutines/Create
        public IActionResult Create()
        {
            ViewData["CStage"] = new SelectList(_context.Class, "CStage", "CStage");
            ViewData["RoomNo"] = new SelectList(_context.Room, "RoomNo", "RoomNo");
            ViewData["SCode"] = new SelectList(_context.Subject, "SCode", "SName");
            return View();
        }

        // POST: ExamRoutines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Serial,SCode,CStage,RoomNo,Date,Time")] ExamRoutine examRoutine)
        {
            if (ModelState.IsValid)
            {
                _context.Add(examRoutine);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["CStage"] = new SelectList(_context.Class, "CStage", "CStage", examRoutine.CStage);
            ViewData["RoomNo"] = new SelectList(_context.Room, "RoomNo", "RoomNo", examRoutine.RoomNo);
            ViewData["SCode"] = new SelectList(_context.Subject, "SCode", "SName", examRoutine.SCode);
            return View(examRoutine);
        }

        // GET: ExamRoutines/Edit/5
        public async Task<IActionResult> Edit(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var examRoutine = await _context.ExamRoutine.SingleOrDefaultAsync(m => m.Serial == id);
            if (examRoutine == null)
            {
                return NotFound();
            }
            ViewData["CStage"] = new SelectList(_context.Class, "CStage", "CStage", examRoutine.CStage);
            ViewData["RoomNo"] = new SelectList(_context.Room, "RoomNo", "RoomNo", examRoutine.RoomNo);
            ViewData["SCode"] = new SelectList(_context.Subject, "SCode", "SName", examRoutine.SCode);
            return View(examRoutine);
        }

        // POST: ExamRoutines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(short id, [Bind("Serial,SCode,CStage,RoomNo,Date,Time")] ExamRoutine examRoutine)
        {
            if (id != examRoutine.Serial)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(examRoutine);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExamRoutineExists(examRoutine.Serial))
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
            ViewData["CStage"] = new SelectList(_context.Class, "CStage", "CStage", examRoutine.CStage);
            ViewData["RoomNo"] = new SelectList(_context.Room, "RoomNo", "RoomNo", examRoutine.RoomNo);
            ViewData["SCode"] = new SelectList(_context.Subject, "SCode", "SName", examRoutine.SCode);
            return View(examRoutine);
        }

        // GET: ExamRoutines/Delete/5
        public async Task<IActionResult> Delete(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var examRoutine = await _context.ExamRoutine
                .Include(e => e.CStageNavigation)
                .Include(e => e.RoomNoNavigation)
                .Include(e => e.SCodeNavigation)
                .SingleOrDefaultAsync(m => m.Serial == id);
            if (examRoutine == null)
            {
                return NotFound();
            }

            return View(examRoutine);
        }

        // POST: ExamRoutines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(short id)
        {
            var examRoutine = await _context.ExamRoutine.SingleOrDefaultAsync(m => m.Serial == id);
            _context.ExamRoutine.Remove(examRoutine);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ExamRoutineExists(short id)
        {
            return _context.ExamRoutine.Any(e => e.Serial == id);
        }
    }
}
