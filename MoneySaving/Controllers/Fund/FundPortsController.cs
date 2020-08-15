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
using MoneySaving.Models;

namespace MoneySaving.Controllers
{
    [Authorize]
    public class FundPortsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public FundPortsController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: FundPorts
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            return View(await _context.FundPort.Where(x => x.User == user).ToListAsync());
        }

        // GET: FundPorts/Create
        public IActionResult Create()
        {
            var fundport = new FundPort();
            return View(fundport);
        }

        // POST: FundPorts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,LastUpdate")] FundPort fundPort)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                fundPort.User = user;
                _context.Add(fundPort);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fundPort);
        }

        // GET: FundPorts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(User);

            var fundPort = await _context.FundPort.FirstOrDefaultAsync(x => x.ID == id && x.User == user);
            if (fundPort == null)
            {
                return NotFound();
            }
            fundPort.LastUpdate = DateTime.Now;
            return View(fundPort);
        }

        // POST: FundPorts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,LastUpdate")] FundPort fundPort)
        {
            if (id != fundPort.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fundPort);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FundPortExists(fundPort.ID))
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
            return View(fundPort);
        }

        // GET: FundPorts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = await _userManager.GetUserAsync(User);
            var fundPort = await _context.FundPort
                .FirstOrDefaultAsync(m => m.ID == id && m.User == user);
            if (fundPort == null)
            {
                return NotFound();
            }

            return View(fundPort);
        }

        // POST: FundPorts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fundPort = await _context.FundPort.FindAsync(id);
            _context.FundPort.Remove(fundPort);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FundPortExists(int id)
        {
            return _context.FundPort.Any(e => e.ID == id);
        }
    }
}
