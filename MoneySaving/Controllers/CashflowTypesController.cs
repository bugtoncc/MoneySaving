using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using MoneySaving.Data;
using MoneySaving.Models;

namespace MoneySaving.Controllers
{
    [Authorize]
    public class CashflowTypesController : Controller

    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public CashflowTypesController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: CashflowTypes
        public async Task<IActionResult> Index()
        {
            //var _view = await _context.CashflowType.ToListAsync();
            var user = await _userManager.GetUserAsync(User);
            var cashflowType = from x in _context.CashflowType
                               where x.User == user
                               select x;

            return View(cashflowType);
        }

        // GET: CashflowTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var cashflowType = await _context.CashflowType
            //    .FirstOrDefaultAsync(m => m.ID == id);
            //if (cashflowType == null)
            //{
            //    return NotFound();
            //}

            var user = await _userManager.GetUserAsync(User);

            var cashflowType = await _context.CashflowType.FirstOrDefaultAsync(x => x.ID == id && x.User == user);
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
            var _view = new CashflowType();
            return View(_view);
        }

        // POST: CashflowTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,StatusFlag,LastUpdate")] CashflowType cashflowType)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);

                cashflowType.User = user;

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

            //var cashflowType = await _context.CashflowType.FindAsync(id);
            //if (cashflowType == null)
            //{
            //    return NotFound();
            //}

            var user = await _userManager.GetUserAsync(User);

            var cashflowType = await _context.CashflowType.FirstOrDefaultAsync(x => x.ID == id && x.User == user);
            if (cashflowType == null)
            {
                return NotFound();
            }

            return View(cashflowType);
        }

        // POST: CashflowTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,StatusFlag,LastUpdate")] CashflowType cashflowType)
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

            //var cashflowType = await _context.CashflowType
            //    .FirstOrDefaultAsync(m => m.ID == id);
            //if (cashflowType == null)
            //{
            //    return NotFound();
            //}

            var user = await _userManager.GetUserAsync(User);

            var cashflowType = await _context.CashflowType.FirstOrDefaultAsync(x => x.ID == id && x.User == user);
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
