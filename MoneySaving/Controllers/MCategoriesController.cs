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
    public class MCategoriesController : Controller
    {
        private readonly MoneyContext _context;

        public MCategoriesController(MoneyContext context)
        {
            _context = context;
        }

        // GET: MCategories
        public async Task<IActionResult> Index()
        {
            var moneyContext = _context.MCategory.Include(m => m.CashflowType);
            return View(await moneyContext.ToListAsync());
        }

        // GET: MCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mCategory = await _context.MCategory
                .Include(m => m.CashflowType)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (mCategory == null)
            {
                return NotFound();
            }

            return View(mCategory);
        }

        // GET: MCategories/Create
        public IActionResult Create()
        {
            ViewData["CashflowTypeId"] = new SelectList(_context.CashflowType, "ID", "Name");
            //return View();
            var _mCategories = new MCategory();
            return View(_mCategories);
        }

        // POST: MCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,StatusFlag,LastUpdate,UpdateBy,CashflowTypeId")] MCategory mCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CashflowTypeId"] = new SelectList(_context.CashflowType, "ID", "Name", mCategory.CashflowTypeId);
            return View(mCategory);
        }

        // GET: MCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mCategory = await _context.MCategory.FindAsync(id);
            if (mCategory == null)
            {
                return NotFound();
            }
            ViewData["CashflowTypeId"] = new SelectList(_context.CashflowType, "ID", "Name", mCategory.CashflowTypeId);
            return View(mCategory);
        }

        // POST: MCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,StatusFlag,LastUpdate,UpdateBy,CashflowTypeId")] MCategory mCategory)
        {
            if (id != mCategory.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MCategoryExists(mCategory.ID))
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
            ViewData["CashflowTypeId"] = new SelectList(_context.CashflowType, "ID", "Name", mCategory.CashflowTypeId);
            return View(mCategory);
        }

        // GET: MCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mCategory = await _context.MCategory
                .Include(m => m.CashflowType)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (mCategory == null)
            {
                return NotFound();
            }

            return View(mCategory);
        }

        // POST: MCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mCategory = await _context.MCategory.FindAsync(id);
            _context.MCategory.Remove(mCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MCategoryExists(int id)
        {
            return _context.MCategory.Any(e => e.ID == id);
        }
    }
}
