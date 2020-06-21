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
    public class PocketsController : Controller
    {
        private readonly MoneyContext _context;

        public PocketsController(MoneyContext context)
        {
            _context = context;
        }

        // GET: Pockets
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pocket.ToListAsync());
        }

        // GET: Pockets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pocket = await _context.Pocket
                .FirstOrDefaultAsync(m => m.PocketID == id);
            if (pocket == null)
            {
                return NotFound();
            }

            return View(pocket);
        }

        // GET: Pockets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pockets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PocketID,Name,LastUpdate")] Pocket pocket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pocket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pocket);
        }

        // GET: Pockets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pocket = await _context.Pocket.FindAsync(id);
            if (pocket == null)
            {
                return NotFound();
            }
            return View(pocket);
        }

        // POST: Pockets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PocketID,Name,LastUpdate")] Pocket pocket)
        {
            if (id != pocket.PocketID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pocket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PocketExists(pocket.PocketID))
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
            return View(pocket);
        }

        // GET: Pockets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pocket = await _context.Pocket
                .FirstOrDefaultAsync(m => m.PocketID == id);
            if (pocket == null)
            {
                return NotFound();
            }

            return View(pocket);
        }

        // POST: Pockets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pocket = await _context.Pocket.FindAsync(id);
            _context.Pocket.Remove(pocket);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PocketExists(int id)
        {
            return _context.Pocket.Any(e => e.PocketID == id);
        }
    }
}
