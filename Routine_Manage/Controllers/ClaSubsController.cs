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
    public class ClaSubsController : Controller
    {
        private readonly routine_managementContext _context;

        public ClaSubsController(routine_managementContext context)
        {
            _context = context;    
        }

        // GET: ClaSubs
        public async Task<IActionResult> Index()
        {
            var routine_managementContext = _context.ClaSub.Include(c => c.CStageNavigation).Include(c => c.SCodeNavigation);
            return View(await routine_managementContext.ToListAsync());
        }

        // GET: ClaSubs/Details/5
        public async Task<IActionResult> Details(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var claSub = await _context.ClaSub
                .Include(c => c.CStageNavigation)
                .Include(c => c.SCodeNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (claSub == null)
            {
                return NotFound();
            }

            return View(claSub);
        }

        // GET: ClaSubs/Create
        public IActionResult Create()
        {
            ViewData["CStage"] = new SelectList(_context.Class, "CStage", "CStage");
            ViewData["SCode"] = new SelectList(_context.Subject, "SCode", "SName");
            return View();
        }

        // POST: ClaSubs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CStage,SCode")] ClaSub claSub)
        {
            if (ModelState.IsValid)
            {
                _context.Add(claSub);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["CStage"] = new SelectList(_context.Class, "CStage", "CStage", claSub.CStage);
            ViewData["SCode"] = new SelectList(_context.Subject, "SCode", "SName", claSub.SCode);
            return View(claSub);
        }

        // GET: ClaSubs/Edit/5
        public async Task<IActionResult> Edit(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var claSub = await _context.ClaSub.SingleOrDefaultAsync(m => m.Id == id);
            if (claSub == null)
            {
                return NotFound();
            }
            ViewData["CStage"] = new SelectList(_context.Class, "CStage", "CStage", claSub.CStage);
            ViewData["SCode"] = new SelectList(_context.Subject, "SCode", "SName", claSub.SCode);
            return View(claSub);
        }

        // POST: ClaSubs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(short id, [Bind("Id,CStage,SCode")] ClaSub claSub)
        {
            if (id != claSub.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(claSub);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClaSubExists(claSub.Id))
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
            ViewData["CStage"] = new SelectList(_context.Class, "CStage", "CStage", claSub.CStage);
            ViewData["SCode"] = new SelectList(_context.Subject, "SCode", "SName", claSub.SCode);
            return View(claSub);
        }

        // GET: ClaSubs/Delete/5
        public async Task<IActionResult> Delete(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var claSub = await _context.ClaSub
                .Include(c => c.CStageNavigation)
                .Include(c => c.SCodeNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (claSub == null)
            {
                return NotFound();
            }

            return View(claSub);
        }

        // POST: ClaSubs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(short id)
        {
            var claSub = await _context.ClaSub.SingleOrDefaultAsync(m => m.Id == id);
            _context.ClaSub.Remove(claSub);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ClaSubExists(short id)
        {
            return _context.ClaSub.Any(e => e.Id == id);
        }
    }
}
