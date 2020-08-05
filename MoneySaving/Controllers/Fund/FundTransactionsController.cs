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
    public class FundTransactionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FundTransactionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FundTransactions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.FundTransaction.Include(f => f.FundSummary).Include(f => f.MFund).Include(f => f.MFundFlowType);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: FundTransactions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fundTransaction = await _context.FundTransaction
                .Include(f => f.FundSummary)
                .Include(f => f.MFund)
                .Include(f => f.MFundFlowType)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (fundTransaction == null)
            {
                return NotFound();
            }

            return View(fundTransaction);
        }

        // GET: FundTransactions/Create
        public IActionResult Create()
        {
            ViewData["FundSummaryId"] = new SelectList(_context.FundSummary, "ID", "ID");
            ViewData["MFundId"] = new SelectList(_context.MFund, "ID", "Abbr");
            ViewData["MFundFlowTypeId"] = new SelectList(_context.MFundFlowType, "ID", "Name");
            return View();
        }

        // POST: FundTransactions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,TransactionDate,FundSummaryId,MFundFlowTypeId,MFundId,Cost,Nav,Units,NavConfirmed,LastUpdate")] FundTransaction fundTransaction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fundTransaction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FundSummaryId"] = new SelectList(_context.FundSummary, "ID", "ID", fundTransaction.FundSummaryId);
            ViewData["MFundId"] = new SelectList(_context.MFund, "ID", "Abbr", fundTransaction.MFundId);
            ViewData["MFundFlowTypeId"] = new SelectList(_context.MFundFlowType, "ID", "Name", fundTransaction.MFundFlowTypeId);
            return View(fundTransaction);
        }

        // GET: FundTransactions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fundTransaction = await _context.FundTransaction.FindAsync(id);
            if (fundTransaction == null)
            {
                return NotFound();
            }
            ViewData["FundSummaryId"] = new SelectList(_context.FundSummary, "ID", "ID", fundTransaction.FundSummaryId);
            ViewData["MFundId"] = new SelectList(_context.MFund, "ID", "Abbr", fundTransaction.MFundId);
            ViewData["MFundFlowTypeId"] = new SelectList(_context.MFundFlowType, "ID", "Name", fundTransaction.MFundFlowTypeId);
            return View(fundTransaction);
        }

        // POST: FundTransactions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,TransactionDate,FundSummaryId,MFundFlowTypeId,MFundId,Cost,Nav,Units,NavConfirmed,LastUpdate")] FundTransaction fundTransaction)
        {
            if (id != fundTransaction.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fundTransaction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FundTransactionExists(fundTransaction.ID))
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
            ViewData["FundSummaryId"] = new SelectList(_context.FundSummary, "ID", "ID", fundTransaction.FundSummaryId);
            ViewData["MFundId"] = new SelectList(_context.MFund, "ID", "Abbr", fundTransaction.MFundId);
            ViewData["MFundFlowTypeId"] = new SelectList(_context.MFundFlowType, "ID", "Name", fundTransaction.MFundFlowTypeId);
            return View(fundTransaction);
        }

        // GET: FundTransactions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fundTransaction = await _context.FundTransaction
                .Include(f => f.FundSummary)
                .Include(f => f.MFund)
                .Include(f => f.MFundFlowType)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (fundTransaction == null)
            {
                return NotFound();
            }

            return View(fundTransaction);
        }

        // POST: FundTransactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fundTransaction = await _context.FundTransaction.FindAsync(id);
            _context.FundTransaction.Remove(fundTransaction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FundTransactionExists(int id)
        {
            return _context.FundTransaction.Any(e => e.ID == id);
        }
    }
}
