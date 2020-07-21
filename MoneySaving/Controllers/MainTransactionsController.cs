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
    public class MainTransactionsController : Controller
    {
        private readonly MoneyContext _context;

        public MainTransactionsController(MoneyContext context)
        {
            _context = context;
        }

        // GET: MainTransactions
        public async Task<IActionResult> Index(string QueryPocket)
        {
            //var moneyContext = _context.MainTransaction.Include(m => m.MCategory).Include(m => m.MPocket);
            //return View(await moneyContext.ToListAsync());

            IQueryable<string> pocketQuery = from m in _context.MPocket
                                             orderby m.Name
                                             select m.Name;

            var transactions = from m in _context.MainTransaction.Include(m => m.MCategory).Include(m => m.MPocket)
                               select m;

            var pockets = from p in _context.MPocket
                          select p;

            if (!string.IsNullOrEmpty(QueryPocket))
            {
                transactions = transactions.Where(x => x.MPocket.Name == QueryPocket);
            }

            var mainVM = new MainViewModel
            {
                PocketsSelectList = new SelectList(await pocketQuery.Distinct().ToListAsync()),
                Pockets = await pockets.ToListAsync(),
                MainTransactions = await transactions.ToListAsync()
            };

            return View(mainVM);
        }

        // GET: MainTransactions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mainTransaction = await _context.MainTransaction
                .Include(m => m.MCategory)
                .Include(m => m.MPocket)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (mainTransaction == null)
            {
                return NotFound();
            }

            return View(mainTransaction);
        }

        // GET: MainTransactions/Create
        public IActionResult Create(int CashflowTypeId)
        {
            ViewData["MCategoryId"] = new SelectList(_context.MCategory.Where(x => x.CashflowTypeId == CashflowTypeId), "ID", "Name");
            ViewData["MpocketId"] = new SelectList(_context.MPocket, "ID", "Name");

            var cashflowType = _context.CashflowType.Where(x => x.ID == CashflowTypeId);
            ViewData["Title_1"] = "Add " + cashflowType.ToList()[0].Name;

            var mainTransaction = new MainTransaction();
            return View(mainTransaction);

            //return View();
        }

        // POST: MainTransactions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,TransactionDate,MpocketId,MCategoryId,Detail,Amount,StatusFlag,LastUpdate,UpdateBy")] MainTransaction mainTransaction)
        {
            if (ModelState.IsValid)
            {
                //--- Update balance ---//
                var mCategory = await _context.MCategory.FindAsync(mainTransaction.MCategoryId);
                var mCashFlowType = await _context.CashflowType.FindAsync(mCategory.CashflowTypeId);
                var mPocket = await _context.MPocket.FindAsync(mainTransaction.MpocketId);

                if (mCashFlowType.Name == "Income")
                {
                    mPocket.Balance += mainTransaction.Amount;
                }
                else
                {
                    mPocket.Balance -= mainTransaction.Amount;
                }
                //--- Update balance ---//

                _context.Update(mPocket);
                _context.Add(mainTransaction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MCategoryId"] = new SelectList(_context.MCategory, "ID", "Name", mainTransaction.MCategoryId);
            ViewData["MpocketId"] = new SelectList(_context.MPocket, "ID", "Name", mainTransaction.MpocketId);
            return View(mainTransaction);
        }

        // GET: MainTransactions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mainTransaction = await _context.MainTransaction.FindAsync(id);
            if (mainTransaction == null)
            {
                return NotFound();
            }
            ViewData["MCategoryId"] = new SelectList(_context.MCategory, "ID", "Name", mainTransaction.MCategoryId);
            ViewData["MpocketId"] = new SelectList(_context.MPocket, "ID", "Name", mainTransaction.MpocketId);
            return View(mainTransaction);
        }

        // POST: MainTransactions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,TransactionDate,MpocketId,MCategoryId,Detail,Amount,StatusFlag,LastUpdate,UpdateBy")] MainTransaction mainTransaction)
        {
            if (id != mainTransaction.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //--- Update balance ---//
                    var mCategory = await _context.MCategory.FindAsync(mainTransaction.MCategoryId);
                    var mCashFlowType = await _context.CashflowType.FindAsync(mCategory.CashflowTypeId);
                    var mPocket = await _context.MPocket.FindAsync(mainTransaction.MpocketId);

                    if (mCashFlowType.Name == "Income")
                    {
                        mPocket.Balance += mainTransaction.Amount;
                    }
                    else
                    {
                        mPocket.Balance -= mainTransaction.Amount;
                    }
                    //--- Update balance ---//

                    _context.Update(mainTransaction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MainTransactionExists(mainTransaction.ID))
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
            ViewData["MCategoryId"] = new SelectList(_context.MCategory, "ID", "Name", mainTransaction.MCategoryId);
            ViewData["MpocketId"] = new SelectList(_context.MPocket, "ID", "Name", mainTransaction.MpocketId);
            return View(mainTransaction);
        }

        // GET: MainTransactions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mainTransaction = await _context.MainTransaction
                .Include(m => m.MCategory)
                .Include(m => m.MPocket)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (mainTransaction == null)
            {
                return NotFound();
            }

            return View(mainTransaction);
        }

        // POST: MainTransactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mainTransaction = await _context.MainTransaction.FindAsync(id);

            //--- Update balance ---//
            var mCategory = await _context.MCategory.FindAsync(mainTransaction.MCategoryId);
            var mCashFlowType = await _context.CashflowType.FindAsync(mCategory.CashflowTypeId);
            var mPocket = await _context.MPocket.FindAsync(mainTransaction.MpocketId);

            if (mCashFlowType.Name == "Income")
            {
                mPocket.Balance -= mainTransaction.Amount;
            }
            else
            {
                mPocket.Balance += mainTransaction.Amount;
            }
            //--- Update balance ---//

            _context.MainTransaction.Remove(mainTransaction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MainTransactionExists(int id)
        {
            return _context.MainTransaction.Any(e => e.ID == id);
        }

        private async void UpdatePocket(MainTransaction mainTransaction)
        {
            //--- Update balance ---//
            var mCategory = await _context.MCategory.FindAsync(mainTransaction.MCategoryId);
            var mCashFlowType = await _context.CashflowType.FindAsync(mCategory.CashflowTypeId);
            var mPocket = await _context.MPocket.FindAsync(mainTransaction.MpocketId);

            if (mCashFlowType.Name == "Income")
            {
                mPocket.Balance += mainTransaction.Amount;
            }
            else
            {
                mPocket.Balance -= mainTransaction.Amount;
            }

            _context.Update(mPocket);
        }
    }
}
