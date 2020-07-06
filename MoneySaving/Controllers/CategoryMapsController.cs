using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MoneySaving.DAL;
using MoneySaving.Models;

namespace MoneySaving.Controllers
{
    public class CategoryMapsController : Controller
    {
        private readonly MoneyContext _context;

        public CategoryMapsController(MoneyContext context)
        {
            _context = context;
        }

        // GET: CategoryMaps
        public async Task<IActionResult> Index()
        {
            var moneyContext = _context.CategoryMap.Include(c => c.MCategory).Include(c => c.MPocket);
            return View(await moneyContext.ToListAsync());
        }

        // GET: CategoryMaps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryMap = await _context.CategoryMap
                .Include(c => c.MCategory)
                .Include(c => c.MPocket)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (categoryMap == null)
            {
                return NotFound();
            }

            return View(categoryMap);
        }

        // GET: CategoryMaps/Create
        public IActionResult Create()
        {
            ViewData["MCategoryId"] = new SelectList(_context.MCategory, "ID", "Name");
            ViewData["MPocketId"] = new SelectList(_context.MPocket, "ID", "Name");

            //return View();
            var _categoryMaps = new CategoryMap();
            return View(_categoryMaps);
        }

        // POST: CategoryMaps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,StatusFlag,LastUpdate,UpdateBy,MCategoryId,MPocketId")] CategoryMap categoryMap)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoryMap);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MCategoryId"] = new SelectList(_context.MCategory, "ID", "Name", categoryMap.MCategoryId);
            ViewData["MPocketId"] = new SelectList(_context.MPocket, "ID", "Name", categoryMap.MPocketId);
            return View(categoryMap);
        }

        // GET: CategoryMaps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryMap = await _context.CategoryMap.FindAsync(id);
            if (categoryMap == null)
            {
                return NotFound();
            }
            ViewData["MCategoryId"] = new SelectList(_context.MCategory, "ID", "Name", categoryMap.MCategoryId);
            ViewData["MPocketId"] = new SelectList(_context.MPocket, "ID", "Name", categoryMap.MPocketId);
            return View(categoryMap);
        }

        // POST: CategoryMaps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,StatusFlag,LastUpdate,UpdateBy,MCategoryId,MPocketId")] CategoryMap categoryMap)
        {
            if (id != categoryMap.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoryMap);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryMapExists(categoryMap.ID))
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
            ViewData["MCategoryId"] = new SelectList(_context.MCategory, "ID", "Name", categoryMap.MCategoryId);
            ViewData["MPocketId"] = new SelectList(_context.MPocket, "ID", "Name", categoryMap.MPocketId);
            return View(categoryMap);
        }

        // GET: CategoryMaps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryMap = await _context.CategoryMap
                .Include(c => c.MCategory)
                .Include(c => c.MPocket)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (categoryMap == null)
            {
                return NotFound();
            }

            return View(categoryMap);
        }

        // POST: CategoryMaps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoryMap = await _context.CategoryMap.FindAsync(id);
            _context.CategoryMap.Remove(categoryMap);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryMapExists(int id)
        {
            return _context.CategoryMap.Any(e => e.ID == id);
        }
    }
}
