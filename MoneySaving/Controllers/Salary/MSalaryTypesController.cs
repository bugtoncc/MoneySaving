using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MoneySaving.Data;
using MoneySaving.Models;

namespace MoneySaving.Controllers
{
    public class MSalaryTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MSalaryTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MSalaryTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.MSalaryType.ToListAsync());
        }

        // GET: MSalaryTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mSalaryType = await _context.MSalaryType
                .FirstOrDefaultAsync(m => m.ID == id);
            if (mSalaryType == null)
            {
                return NotFound();
            }

            return View(mSalaryType);
        }

        // GET: MSalaryTypes/Create
        public IActionResult Create()
        {
            var mSalaryType = new MSalaryType();
            return View(mSalaryType);
        }

        // POST: MSalaryTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,StatusFlag,LastUpdate")] MSalaryType mSalaryType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mSalaryType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mSalaryType);
        }

        // GET: MSalaryTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mSalaryType = await _context.MSalaryType.FindAsync(id);
            if (mSalaryType == null)
            {
                return NotFound();
            }
            mSalaryType.LastUpdate = DateTime.Now;
            return View(mSalaryType);
        }

        // POST: MSalaryTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,StatusFlag,LastUpdate")] MSalaryType mSalaryType)
        {
            if (id != mSalaryType.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mSalaryType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MSalaryTypeExists(mSalaryType.ID))
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
            return View(mSalaryType);
        }

        // GET: MSalaryTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mSalaryType = await _context.MSalaryType
                .FirstOrDefaultAsync(m => m.ID == id);
            if (mSalaryType == null)
            {
                return NotFound();
            }

            return View(mSalaryType);
        }

        // POST: MSalaryTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mSalaryType = await _context.MSalaryType.FindAsync(id);
            _context.MSalaryType.Remove(mSalaryType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MSalaryTypeExists(int id)
        {
            return _context.MSalaryType.Any(e => e.ID == id);
        }
    }
}
