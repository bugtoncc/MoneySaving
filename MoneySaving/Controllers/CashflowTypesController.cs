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
    public class CashflowTypesController : Controller
    {
        private readonly MoneyContext _context;

        public CashflowTypesController(MoneyContext context)
        {
            _context = context;
        }

        // GET: CashflowTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.CashflowType.ToListAsync());
        }

        // GET: CashflowTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cashflowType = await _context.CashflowType
                .FirstOrDefaultAsync(m => m.ID == id);
            if (cashflowType == null)
            {
                return NotFound();
            }

            return View(cashflowType);
        }

        // GET: CashflowTypes/Create
        public IActionResult Create()
        {
            //return View();
            var _cashflowType = new CashflowType();
            return View(_cashflowType);
        }

        // POST: CashflowTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,StatusFlag,LastUpdate,UpdateBy")] CashflowType cashflowType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cashflowType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cashflowType);
        }

        // GET: CashflowTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cashflowType = await _context.CashflowType.FindAsync(id);
            if (cashflowType == null)
            {
                return NotFound();
            }
            cashflowType.LastUpdate = DateTime.Now;
            return View(cashflowType);
        }

        // POST: CashflowTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,StatusFlag,LastUpdate,UpdateBy")] CashflowType cashflowType)
        {
            if (id != cashflowType.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cashflowType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CashflowTypeExists(cashflowType.ID))
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
            return View(cashflowType);
        }

        // GET: CashflowTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cashflowType = await _context.CashflowType
                .FirstOrDefaultAsync(m => m.ID == id);
            if (cashflowType == null)
            {
                return NotFound();
            }

            return View(cashflowType);
        }

        // POST: CashflowTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cashflowType = await _context.CashflowType.FindAsync(id);
            _context.CashflowType.Remove(cashflowType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CashflowTypeExists(int id)
        {
            return _context.CashflowType.Any(e => e.ID == id);
        }
    }
}
