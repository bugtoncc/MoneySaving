using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MoneySaving.Data;
using MoneySaving.Models;
using Newtonsoft.Json;

namespace MoneySaving.Controllers
{
    [Authorize]
    public class DailyNavsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private IConfiguration _configuration { get; }

        public DailyNavsController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // GET: DailyNavs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DailyNav.Include(d => d.MFund).OrderByDescending(x => x.nav_date).ThenBy(x => x.MFund.Abbr);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DailyNavs/Create
        public IActionResult Create()
        {
            ViewData["MFundId"] = new SelectList(_context.MFund, "ID", "Abbr");
            return View();
        }

        // POST: DailyNavs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,MFundId,nav_date,net_asset,last_val,previous_val,LastUpdate")] DailyNav dailyNav)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dailyNav);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MFundId"] = new SelectList(_context.MFund, "ID", "Abbr", dailyNav.MFundId);
            return View(dailyNav);
        }

        // GET: DailyNavs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dailyNav = await _context.DailyNav.FindAsync(id);
            if (dailyNav == null)
            {
                return NotFound();
            }
            ViewData["MFundId"] = new SelectList(_context.MFund, "ID", "Abbr", dailyNav.MFundId);
            return View(dailyNav);
        }

        // POST: DailyNavs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,MFundId,nav_date,net_asset,last_val,previous_val,LastUpdate")] DailyNav dailyNav)
        {
            if (id != dailyNav.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dailyNav);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DailyNavExists(dailyNav.ID))
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
            ViewData["MFundId"] = new SelectList(_context.MFund, "ID", "Abbr", dailyNav.MFundId);
            return View(dailyNav);
        }

        // GET: DailyNavs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dailyNav = await _context.DailyNav
                .Include(d => d.MFund)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (dailyNav == null)
            {
                return NotFound();
            }

            return View(dailyNav);
        }

        // POST: DailyNavs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dailyNav = await _context.DailyNav.FindAsync(id);
            _context.DailyNav.Remove(dailyNav);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DailyNavExists(int id)
        {
            return _context.DailyNav.Any(e => e.ID == id);
        }

        // GET: UpdateNav
        public async Task<IActionResult> UpdateNav(string QueryFundKeyword)
        {
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

            var updateNav = new UpdateNavModel()
            {
                FundSelectListFilter = new SelectList(await funds.ToListAsync(), "ID", "Abbr")
            };

            return View(updateNav);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateNav(int MFundId)
        {
            if (ModelState.IsValid)
            {
                var mfund = await _context.MFund.FirstOrDefaultAsync(x => x.ID == MFundId);
                var client = new HttpClient();
                var key = _configuration.GetSection("SecSubscriptionKey").GetSection("FundDailyInfo").Value.ToString();

                // Request headers
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", key);

                var fDate = DateTime.Now;
                var tDate = DateTime.Now.AddDays(-7);
                var curDate = fDate;

                for (var day = fDate.Date; day.Date >= tDate.Date; day = day.AddDays(-1))
                {
                    var navDate = day.ToString("yyyy-MM-dd");
                    var uri = "https://api.sec.or.th/FundDailyInfo/" + mfund.ProjectId + "/dailynav/" + navDate;
                    var response = await client.GetAsync(uri);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var jsonString = await client.GetStringAsync(uri);
                        DailyNavModel jsonObj = JsonConvert.DeserializeObject<DailyNavModel>(jsonString);

                        var dailyNav = await _context.DailyNav.FirstOrDefaultAsync(m => m.MFundId == MFundId && m.nav_date == day);

                        // delete
                        if (dailyNav != null)
                        {
                            _context.DailyNav.Remove(dailyNav);
                        }

                        // insert
                        dailyNav = new DailyNav()
                        {
                            MFundId = MFundId,
                            nav_date = day,
                            net_asset = jsonObj.net_asset,
                            last_val = jsonObj.last_val,
                            previous_val = jsonObj.previous_val,
                            LastUpdate = DateTime.Parse(jsonObj.last_upd_date)
                        };
                        _context.Add(dailyNav);

                        await _context.SaveChangesAsync();

                        //return RedirectToAction(nameof(Index));
                    }
                }
            }
            return RedirectToAction(nameof(Index));
        }
    }

    public class DailyNavModel
    {
        public string last_upd_date { get; set; }
        public string nav_date { get; set; }
        public double net_asset { get; set; }
        public double last_val { get; set; }
        public double previous_val { get; set; }
    }
}
