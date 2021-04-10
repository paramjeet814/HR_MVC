using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HRMVC.Data;
using HRMVC.Models;

namespace HRMVC.Controllers
{
    public class EmployeersController : Controller
    {
        private readonly HRMVCContext _context;

        public EmployeersController(HRMVCContext context)
        {
            _context = context;
        }

        // GET: Employeers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Employeer.ToListAsync());
        }

        // GET: Employeers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeer = await _context.Employeer
                .FirstOrDefaultAsync(m => m.Employeerid == id);
            if (employeer == null)
            {
                return NotFound();
            }

            return View(employeer);
        }

        // GET: Employeers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employeers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Employeerid,Name,Email,Contact,recuritment,No_ofPost")] Employeer employeer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employeer);
        }

        // GET: Employeers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeer = await _context.Employeer.FindAsync(id);
            if (employeer == null)
            {
                return NotFound();
            }
            return View(employeer);
        }

        // POST: Employeers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Employeerid,Name,Email,Contact,recuritment,No_ofPost")] Employeer employeer)
        {
            if (id != employeer.Employeerid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeerExists(employeer.Employeerid))
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
            return View(employeer);
        }

        // GET: Employeers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeer = await _context.Employeer
                .FirstOrDefaultAsync(m => m.Employeerid == id);
            if (employeer == null)
            {
                return NotFound();
            }

            return View(employeer);
        }

        // POST: Employeers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeer = await _context.Employeer.FindAsync(id);
            _context.Employeer.Remove(employeer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeerExists(int id)
        {
            return _context.Employeer.Any(e => e.Employeerid == id);
        }
    }
}
