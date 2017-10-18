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
    public class RegistriesController : Controller
    {
        private readonly routine_managementContext _context;

        public RegistriesController(routine_managementContext context)
        {
            _context = context;    
        }

        // GET: Registries
        public async Task<IActionResult> Index()
        {
            return View(await _context.Registry.ToListAsync());
        }

        // GET: Registries/Details/5
        public async Task<IActionResult> Details(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registry = await _context.Registry
                .SingleOrDefaultAsync(m => m.Id == id);
            if (registry == null)
            {
                return NotFound();
            }

            return View(registry);
        }

        // GET: Registries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Registries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Password,Email")] Registry registry)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registry);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(registry);
        }

        // GET: Registries/Edit/5
        public async Task<IActionResult> Edit(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registry = await _context.Registry.SingleOrDefaultAsync(m => m.Id == id);
            if (registry == null)
            {
                return NotFound();
            }
            return View(registry);
        }

        // POST: Registries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(short id, [Bind("Id,Name,Password,Email")] Registry registry)
        {
            if (id != registry.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistryExists(registry.Id))
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
            return View(registry);
        }

        // GET: Registries/Delete/5
        public async Task<IActionResult> Delete(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registry = await _context.Registry
                .SingleOrDefaultAsync(m => m.Id == id);
            if (registry == null)
            {
                return NotFound();
            }

            return View(registry);
        }

        // POST: Registries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(short id)
        {
            var registry = await _context.Registry.SingleOrDefaultAsync(m => m.Id == id);
            _context.Registry.Remove(registry);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool RegistryExists(short id)
        {
            return _context.Registry.Any(e => e.Id == id);
        }
    }
}
