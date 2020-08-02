using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoneySaving.Data;
using MoneySaving.Models;

namespace MoneySaving.Controllers
{
    [Authorize]
    public class MPocketsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public MPocketsController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: MPockets
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var mPocket = from x in _context.MPocket
                          where x.User == user
                          select x;

            //return View(await _context.MPocket.ToListAsync());
            return View(mPocket);
        }

        // GET: MPockets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(User);
            var mPocket = await _context.MPocket.FirstOrDefaultAsync(m => m.ID == id && m.User == user);
            if (mPocket == null)
            {
                return NotFound();
            }

            return View(mPocket);
        }

        // GET: MPockets/Create
        public IActionResult Create()
        {
            //return View();
            var _view = new MPocket();
            return View(_view);
        }

        // POST: MPockets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Balance,StatusFlag,LastUpdate")] MPocket mPocket)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);

                mPocket.User = user;

                _context.Add(mPocket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mPocket);
        }

        // GET: MPockets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var mPocket = await _context.MPocket.FindAsync(id);
            //if (mPocket == null)
            //{
            //    return NotFound();
            //}

            var user = await _userManager.GetUserAsync(User);
            var mPocket = await _context.MPocket.FirstOrDefaultAsync(m => m.ID == id && m.User == user);
            if (mPocket == null)
            {
                return NotFound();
            }
            return View(mPocket);
        }

        // POST: MPockets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Balance,StatusFlag,LastUpdate")] MPocket mPocket)
        {
            if (id != mPocket.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    mPocket.LastUpdate = DateTime.Now;
                    _context.Update(mPocket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MPocketExists(mPocket.ID))
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
            return View(mPocket);
        }

        // GET: MPockets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(User);
            var mPocket = await _context.MPocket.FirstOrDefaultAsync(m => m.ID == id && m.User == user);
            if (mPocket == null)
            {
                return NotFound();
            }

            return View(mPocket);
        }

        // POST: MPockets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mPocket = await _context.MPocket.FindAsync(id);
            _context.MPocket.Remove(mPocket);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MPocketExists(int id)
        {
            return _context.MPocket.Any(e => e.ID == id);
        }
    }
}
