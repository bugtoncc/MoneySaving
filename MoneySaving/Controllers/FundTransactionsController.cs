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
    public class FundTransactionsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public FundTransactionsController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: FundTransactions
        public async Task<IActionResult> Index(string QueryFundKeyword)
        {
            //var applicationDbContext = _context.FundTransaction.Include(f => f.FundPort).Include(f => f.MFund).Include(f => f.MFundFlowType);
            //return View(await applicationDbContext.ToListAsync());


            var fundTransactions = from f in _context.FundTransaction.Include(f => f.FundPort).Include(f => f.MFund).Include(f => f.MFundFlowType)
                                   select f;

            var funds = from m in _context.MFund.Include(m => m.MAmc)
                        select m;

            if (string.IsNullOrEmpty(QueryFundKeyword))
            {
                funds = funds.Where(x => 1 == 1);
            }
            else
            {
                funds = funds.Where(x => x.NameTh.ToUpper().Contains(QueryFundKeyword)
                    || x.NameEn.ToUpper().Contains(QueryFundKeyword)
                    || x.Abbr.ToUpper().Contains(QueryFundKeyword));
            }

            funds = funds.OrderBy(x => x.NameEn);


            var mainFundTransaction = new MainFundTransaction()
            {
                FundTransactions = await fundTransactions.ToListAsync(),
                FundSelectListFilter = new SelectList(await funds.ToListAsync(), "ID", "NameEn"),
                FundFlowTypeSelectListFilter = new SelectList(await _context.MFundFlowType.ToListAsync(), "ID", "Name"),
            };
            return View(mainFundTransaction);

        }

        // GET: FundTransactions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fundTransaction = await _context.FundTransaction
                .Include(f => f.FundPort)
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
        public IActionResult Create(int? QueryFundSelected, int? QueryFundFlowSelected)
        {
            if (QueryFundSelected == null || QueryFundFlowSelected == null)
            {
                return NotFound();
            }

            var userId = _userManager.GetUserId(User);
            ViewData["FundPortId"] = new SelectList(_context.FundPort.Where(x => x.User.Id == userId), "ID", "Name");
            ViewData["MFundId"] = new SelectList(_context.MFund, "ID", "Abbr");
            ViewData["MFundFlowTypeId"] = new SelectList(_context.MFundFlowType, "ID", "Name");

            var fundTransaction = new FundTransaction();
            return View(fundTransaction);
        }

        // POST: FundTransactions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,TransactionDate,FundPortId,MFundFlowTypeId,MFundId,Cost,Nav,Units,NavConfirmed,LastUpdate")] FundTransaction fundTransaction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fundTransaction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FundPortId"] = new SelectList(_context.FundPort, "ID", "Name", fundTransaction.FundPortId);
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
            ViewData["FundPortId"] = new SelectList(_context.FundPort, "ID", "Name", fundTransaction.FundPortId);
            ViewData["MFundId"] = new SelectList(_context.MFund, "ID", "Abbr", fundTransaction.MFundId);
            ViewData["MFundFlowTypeId"] = new SelectList(_context.MFundFlowType, "ID", "Name", fundTransaction.MFundFlowTypeId);
            return View(fundTransaction);
        }

        // POST: FundTransactions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,TransactionDate,FundPortId,MFundFlowTypeId,MFundId,Cost,Nav,Units,NavConfirmed,LastUpdate")] FundTransaction fundTransaction)
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
            ViewData["FundPortId"] = new SelectList(_context.FundPort, "ID", "Name", fundTransaction.FundPortId);
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
                .Include(f => f.FundPort)
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
