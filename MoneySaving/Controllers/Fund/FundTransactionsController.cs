using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic;
using MoneySaving.Data;
using MoneySaving.Models;
using Newtonsoft.Json;

namespace MoneySaving.Controllers
{
    [Authorize]
    public class FundTransactionsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private IConfiguration _configuration { get; }

        public FundTransactionsController(ApplicationDbContext context, UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            _context = context;
            _userManager = userManager;
            _configuration = configuration;
        }

        // GET: FundTransactions
        public async Task<IActionResult> Index(string QueryFundPortId, string QueryFundKeyword)
        {
            var userId = _userManager.GetUserId(User);

            var fundTransactions = from f in _context.FundTransaction.Include(f => f.FundPort).Include(f => f.MFund).Include(f => f.MFundFlowType)
                                   where f.User.Id == userId
                                   select f;

            var ports = from m in _context.FundPort
                        where m.User.Id == userId
                        select m;
            ports = ports.OrderBy(x => x.Name);

            //var fundList = fundTransactions.GroupBy(x => x.MFundId)
            //        .Select(g => g.First())
            //        .ToList();            

            if (!string.IsNullOrEmpty(QueryFundPortId))
            {
                fundTransactions = fundTransactions.Where(x => x.FundPortId.ToString() == QueryFundPortId);
            }
            fundTransactions = fundTransactions.OrderBy(x => x.FundPort.Name)
                            .ThenByDescending(x => x.TransactionDate)
                            .ThenBy(x => x.MFund.Abbr);

            //if (!string.IsNullOrEmpty(QueryFundKeyword))
            //{
            //    funds = funds.Where(x => x.NameTh.ToUpper().Contains(QueryFundKeyword)
            //          || x.NameEn.ToUpper().Contains(QueryFundKeyword)
            //          || x.Abbr.ToUpper().Contains(QueryFundKeyword));
            //}
            //funds = funds.OrderBy(x => x.Abbr);

            var mainFundTransaction = new MainFundTransaction()
            {
                FundTransactions = await fundTransactions.ToListAsync(),
                //FundSelectListFilter = new SelectList(fundList, "ID", "Abbr"),
                PortSelectListFilter = new SelectList(await ports.ToListAsync(), "ID", "Name")
            };

            return View(mainFundTransaction);
        }

        // GET: FundTransactions/Create
        public async Task<IActionResult> Create(string QueryFundKeyword)
        {
            var userId = _userManager.GetUserId(User);
            var funds = from m in _context.MFund.Include(m => m.MAmc)
                        select m;

            if (string.IsNullOrEmpty(QueryFundKeyword))
            {
                funds = funds.Where(x => 1 == 0);
            }
            else
            {
                funds = funds.Where(x => x.NameTh.ToUpper().Contains(QueryFundKeyword)
                    || x.NameEn.ToUpper().Contains(QueryFundKeyword)
                    || x.Abbr.ToUpper().Contains(QueryFundKeyword));
            }
            funds = funds.OrderBy(x => x.Abbr);

            var mainFundTransaction = new MainFundTransaction()
            {
                FundSelectListFilter = new SelectList(await funds.ToListAsync(), "ID", "Abbr"),
                FundFlowTypeSelectListFilter = new SelectList(await _context.MFundFlowType.ToListAsync(), "ID", "Name"),
                TransactionDate = DateTime.Now
            };

            ViewData["FundPortId"] = new SelectList(_context.FundPort.Where(x => x.User.Id == userId), "ID", "Name");
            return View(mainFundTransaction);
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
                var user = await _userManager.GetUserAsync(User);

                //var client = new HttpClient();
                //var queryString = HttpUtility.ParseQueryString(string.Empty);
                //var key = _configuration.GetSection("SecSubscriptionKey").GetSection("FundDailyInfo").Value.ToString();
                //var navDate = fundTransaction.TransactionDate.ToString("yyyy-MM-dd");
                //var projectId = await _context.MFund.FirstOrDefaultAsync(x => x.ID == fundTransaction.MFundId);

                //// Request headers
                //client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", key);

                //var uri = "https://api.sec.or.th/FundDailyInfo/" + projectId.ProjectId + "/dailynav/" + navDate + "?" + queryString;
                //var response = await client.GetAsync(uri);

                //if (response.StatusCode == System.Net.HttpStatusCode.OK)
                //{
                //    var jsonString = await client.GetStringAsync(uri);
                //    DailyNavModel obj = JsonConvert.DeserializeObject<DailyNavModel>(jsonString);

                //    fundTransaction.Nav = obj.last_val;
                //    fundTransaction.Units = Math.Round(fundTransaction.Cost / fundTransaction.Nav, 4);
                //    fundTransaction.NavConfirmed = true;
                //}

                fundTransaction.User = user;
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

            var user = await _userManager.GetUserAsync(User);
            var fundTransaction = await _context.FundTransaction.FirstOrDefaultAsync(m => m.ID == id && m.User == user);
            if (fundTransaction == null)
            {
                return NotFound();
            }
            fundTransaction.LastUpdate = DateTime.Now;
            ViewData["FundPortId"] = new SelectList(_context.FundPort, "ID", "Name", fundTransaction.FundPortId);
            ViewData["MFundId"] = new SelectList(_context.MFund.OrderBy(x => x.Abbr), "ID", "Abbr", fundTransaction.MFundId);
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

            var user = await _userManager.GetUserAsync(User);
            var fundTransaction = await _context.FundTransaction
                .Include(f => f.FundPort)
                .Include(f => f.MFund)
                .Include(f => f.MFundFlowType)
                .FirstOrDefaultAsync(m => m.ID == id && m.User == user);
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
