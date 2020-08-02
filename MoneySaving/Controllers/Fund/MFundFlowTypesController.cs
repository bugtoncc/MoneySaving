using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MoneySaving.Data;
using MoneySaving.Models;

namespace MoneySaving.Controllers
{
    [Authorize]
    public class MFundFlowTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MFundFlowTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MFundFlowTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.MFundFlowType.ToListAsync());
        }

        // GET: MFundFlowTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mFundFlowType = await _context.MFundFlowType
                .FirstOrDefaultAsync(m => m.ID == id);
            if (mFundFlowType == null)
            {
                return NotFound();
            }

            return View(mFundFlowType);
        }

        // GET: MFundFlowTypes/Create
        public IActionResult Create()
        {
            var _mFundFlowTYpe = new MFundFlowType();
            return View(_mFundFlowTYpe);
        }

        // POST: MFundFlowTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,StatusFlag,LastUpdate")] MFundFlowType mFundFlowType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mFundFlowType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mFundFlowType);
        }

        // GET: MFundFlowTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mFundFlowType = await _context.MFundFlowType.FindAsync(id);
            if (mFundFlowType == null)
            {
                return NotFound();
            }
            mFundFlowType.LastUpdate = DateTime.Now;
            return View(mFundFlowType);
        }

        // POST: MFundFlowTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,StatusFlag,LastUpdate")] MFundFlowType mFundFlowType)
        {
            if (id != mFundFlowType.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mFundFlowType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MFundFlowTypeExists(mFundFlowType.ID))
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
            return View(mFundFlowType);
        }

        // GET: MFundFlowTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mFundFlowType = await _context.MFundFlowType
                .FirstOrDefaultAsync(m => m.ID == id);
            if (mFundFlowType == null)
            {
                return NotFound();
            }

            return View(mFundFlowType);
        }

        // POST: MFundFlowTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mFundFlowType = await _context.MFundFlowType.FindAsync(id);
            _context.MFundFlowType.Remove(mFundFlowType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MFundFlowTypeExists(int id)
        {
            return _context.MFundFlowType.Any(e => e.ID == id);
        }
    }
}
