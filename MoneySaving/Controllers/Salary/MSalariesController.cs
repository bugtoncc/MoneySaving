using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MoneySaving.Data;
using MoneySaving.Models.Salary;

namespace MoneySaving.Controllers
{
    [Authorize]
    public class MSalariesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;


        public MSalariesController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: MSalaries
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);

            var applicationDbContext = _context.MSalary.Include(m => m.MSalaryType).Where(x => x.User == user).OrderByDescending(x => x.Date);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: MSalaries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mSalary = await _context.MSalary
                .Include(m => m.MSalaryType)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (mSalary == null)
            {
                return NotFound();
            }

            return View(mSalary);
        }

        // GET: MSalaries/Create
        public IActionResult Create()
        {
            ViewData["MSalaryTypeId"] = new SelectList(_context.MSalaryType, "ID", "Name");

            var mSalary = new MSalary();
            return View(mSalary);
        }

        // POST: MSalaries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Date,MSalaryTypeId,Salary,Overtime,Incentive,Bonus,Position,Diligence,Food,Vehicle,Leave,Award,Tax,SS,PVD,Loan,LastUpdate")] MSalary mSalary)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                mSalary.User = user;
                _context.Add(mSalary);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MSalaryTypeId"] = new SelectList(_context.MSalaryType, "ID", "Name", mSalary.MSalaryTypeId);
            return View(mSalary);
        }

        // GET: MSalaries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(User);
            //var mSalary = await _context.MSalary.FindAsync(id);
            var mSalary = await _context.MSalary.Where(x => x.User == user && x.ID == id).FirstOrDefaultAsync();

            if (mSalary == null)
            {
                return NotFound();
            }
            ViewData["MSalaryTypeId"] = new SelectList(_context.MSalaryType, "ID", "Name", mSalary.MSalaryTypeId);
            return View(mSalary);
        }

        // POST: MSalaries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Date,MSalaryTypeId,Salary,Overtime,Incentive,Bonus,Position,Diligence,Food,Vehicle,Leave,Award,Tax,SS,PVD,Loan,LastUpdate")] MSalary mSalary)
        {
            if (id != mSalary.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mSalary);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MSalaryExists(mSalary.ID))
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
            ViewData["MSalaryTypeId"] = new SelectList(_context.MSalaryType, "ID", "Name", mSalary.MSalaryTypeId);
            return View(mSalary);
        }

        // GET: MSalaries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(User);

            var mSalary = await _context.MSalary
                .Include(m => m.MSalaryType)
                .Where(x => x.User == user)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (mSalary == null)
            {
                return NotFound();
            }

            return View(mSalary);
        }

        // POST: MSalaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mSalary = await _context.MSalary.FindAsync(id);
            _context.MSalary.Remove(mSalary);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MSalaryExists(int id)
        {
            return _context.MSalary.Any(e => e.ID == id);
        }
    }
}
