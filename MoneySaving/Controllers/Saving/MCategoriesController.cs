using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MoneySaving.Data;
using MoneySaving.Models;

namespace MoneySaving.Controllers
{
    [Authorize]
    public class MCategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public MCategoriesController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: MCategories
        public async Task<IActionResult> Index()
        {
            //var applicationDbContext = _context.MCategory.Include(m => m.CashflowType);
            //return View(await applicationDbContext.ToListAsync());

            var user = await _userManager.GetUserAsync(User);
            var mCategory = from x in _context.MCategory.Include(m => m.CashflowType)
                            where x.User == user
                            select x;

            return View(mCategory);

        }

        // GET: MCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(User);

            var mCategory = await _context.MCategory
                .Include(m => m.CashflowType)
                .FirstOrDefaultAsync(m => m.ID == id && m.User == user);
            if (mCategory == null)
            {
                return NotFound();
            }

            return View(mCategory);
        }

        // GET: MCategories/Create
        public IActionResult Create()
        {
            var userId = _userManager.GetUserId(User);

            ViewData["CashflowTypeId"] = new SelectList(_context.CashflowType.Where(x => x.User.Id == userId || x.User == null), "ID", "Name");

            var _view = new MCategory();
            return View(_view);
        }

        // POST: MCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,CashflowTypeId,StatusFlag,LastUpdate")] MCategory mCategory)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);

                mCategory.User = user;

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

            //var mCategory = await _context.MCategory.FindAsync(id);
            //if (mCategory == null)
            //{
            //    return NotFound();
            //}

            var user = await _userManager.GetUserAsync(User);
            var mCategory = await _context.MCategory.FirstOrDefaultAsync(m => m.ID == id && m.User == user);
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
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,CashflowTypeId,StatusFlag,LastUpdate")] MCategory mCategory)
        {
            if (id != mCategory.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    mCategory.LastUpdate = DateTime.Now;

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

            //var user = await _userManager.GetUserAsync(User);

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

            var user = await _userManager.GetUserAsync(User);

            var mCategory = await _context.MCategory
                .Include(m => m.CashflowType)
                .FirstOrDefaultAsync(m => m.ID == id && m.User == user);
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
