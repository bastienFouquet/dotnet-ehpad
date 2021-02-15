using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ehpad.ORM;

namespace Ehpad.WEB.Controllers
{
    public class VaccineTypeController : Controller
    {
        private readonly Context _context;

        public VaccineTypeController(Context context)
        {
            _context = context;
        }

        // GET: VaccineType
        public async Task<IActionResult> Index()
        {
            return View(await _context.VaccineTypes.ToListAsync());
        }

        // GET: VaccineType/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaccineType = await _context.VaccineTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vaccineType == null)
            {
                return NotFound();
            }

            return View(vaccineType);
        }

        // GET: VaccineType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VaccineType/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Label")] VaccineType vaccineType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vaccineType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vaccineType);
        }

        // GET: VaccineType/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaccineType = await _context.VaccineTypes.FindAsync(id);
            if (vaccineType == null)
            {
                return NotFound();
            }
            return View(vaccineType);
        }

        // POST: VaccineType/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Label")] VaccineType vaccineType)
        {
            if (id != vaccineType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vaccineType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VaccineTypeExists(vaccineType.Id))
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
            return View(vaccineType);
        }

        // GET: VaccineType/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaccineType = await _context.VaccineTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vaccineType == null)
            {
                return NotFound();
            }

            return View(vaccineType);
        }

        // POST: VaccineType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vaccineType = await _context.VaccineTypes.FindAsync(id);
            _context.VaccineTypes.Remove(vaccineType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VaccineTypeExists(int id)
        {
            return _context.VaccineTypes.Any(e => e.Id == id);
        }
    }
}
