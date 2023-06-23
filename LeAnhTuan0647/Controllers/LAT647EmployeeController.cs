using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LeAnhTuan0647.Models;

namespace LeAnhTuan0647.Controllers
{
    public class LAT647EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LAT647EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LAT647Employee
        public async Task<IActionResult> Index()
        {
              return _context.LAT647Employee != null ? 
                          View(await _context.LAT647Employee.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.LAT647Employee'  is null.");
        }

        // GET: LAT647Employee/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LAT647Employee == null)
            {
                return NotFound();
            }

            var lAT647Employee = await _context.LAT647Employee
                .FirstOrDefaultAsync(m => m.EmployeeID == id);
            if (lAT647Employee == null)
            {
                return NotFound();
            }

            return View(lAT647Employee);
        }

        // GET: LAT647Employee/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LAT647Employee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeID,EmployeeName,Age")] LAT647Employee lAT647Employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lAT647Employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lAT647Employee);
        }

        // GET: LAT647Employee/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LAT647Employee == null)
            {
                return NotFound();
            }

            var lAT647Employee = await _context.LAT647Employee.FindAsync(id);
            if (lAT647Employee == null)
            {
                return NotFound();
            }
            return View(lAT647Employee);
        }

        // POST: LAT647Employee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeID,EmployeeName,Age")] LAT647Employee lAT647Employee)
        {
            if (id != lAT647Employee.EmployeeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lAT647Employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LAT647EmployeeExists(lAT647Employee.EmployeeID))
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
            return View(lAT647Employee);
        }

        // GET: LAT647Employee/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LAT647Employee == null)
            {
                return NotFound();
            }

            var lAT647Employee = await _context.LAT647Employee
                .FirstOrDefaultAsync(m => m.EmployeeID == id);
            if (lAT647Employee == null)
            {
                return NotFound();
            }

            return View(lAT647Employee);
        }

        // POST: LAT647Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LAT647Employee == null)
            {
                return Problem("Entity set 'ApplicationDbContext.LAT647Employee'  is null.");
            }
            var lAT647Employee = await _context.LAT647Employee.FindAsync(id);
            if (lAT647Employee != null)
            {
                _context.LAT647Employee.Remove(lAT647Employee);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LAT647EmployeeExists(int id)
        {
          return (_context.LAT647Employee?.Any(e => e.EmployeeID == id)).GetValueOrDefault();
        }
    }
}
