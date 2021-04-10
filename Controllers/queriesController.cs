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
    public class queriesController : Controller
    {
        private readonly HRMVCContext _context;

        public queriesController(HRMVCContext context)
        {
            _context = context;
        }

        // GET: queries
        public async Task<IActionResult> Index()
        {
            return View(await _context.query.ToListAsync());
        }

        // GET: queries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var query = await _context.query
                .FirstOrDefaultAsync(m => m.Queryid == id);
            if (query == null)
            {
                return NotFound();
            }

            return View(query);
        }

        // GET: queries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: queries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Queryid,Name,Email,Contact,Message")] query query)
        {
            if (ModelState.IsValid)
            {
                _context.Add(query);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(query);
        }

        // GET: queries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var query = await _context.query.FindAsync(id);
            if (query == null)
            {
                return NotFound();
            }
            return View(query);
        }

        // POST: queries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Queryid,Name,Email,Contact,Message")] query query)
        {
            if (id != query.Queryid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(query);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!queryExists(query.Queryid))
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
            return View(query);
        }

        // GET: queries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var query = await _context.query
                .FirstOrDefaultAsync(m => m.Queryid == id);
            if (query == null)
            {
                return NotFound();
            }

            return View(query);
        }

        // POST: queries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var query = await _context.query.FindAsync(id);
            _context.query.Remove(query);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool queryExists(int id)
        {
            return _context.query.Any(e => e.Queryid == id);
        }
    }
}
