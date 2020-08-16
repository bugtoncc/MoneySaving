using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
    public class FundSummaryController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private IConfiguration _configuration { get; }

        public FundSummaryController(ApplicationDbContext context, UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            _context = context;
            _userManager = userManager;
            _configuration = configuration;
        }

        // GET: FundSummary
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);

            IQueryable<FundSummary> fundSummary = from x in _context.FundSummary.Include(f => f.MFund).Include(f => f.FundPort).Include(f => f.MFundFlowType)
                                                  where x.UserId == user.Id
                                                  orderby x.FundPortId, x.MFundId
                                                  select x;

            ViewData["PortList"] = await _context.FundPort.Where(x => x.User == user).ToListAsync();
            return View(fundSummary);
        }

        // GET : UpdateNav
        public IActionResult UpdateNav()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateNav(int? id)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);

                var transactions = await _context.FundTransaction.Include(m => m.MFund).Where(x => x.User == user).ToListAsync();

                var fundList = transactions.GroupBy(x => x.MFundId)
                    .Select(g => g.First())
                    .ToList();

                foreach (var item in fundList)
                {
                    var projectId = item.MFund.ProjectId;
                    var mfundId = item.MFund.ID;
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
                        var uri = "https://api.sec.or.th/FundDailyInfo/" + projectId + "/dailynav/" + navDate;
                        var response = await client.GetAsync(uri);
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            var jsonString = await client.GetStringAsync(uri);
                            DailyNavModel jsonObj = JsonConvert.DeserializeObject<DailyNavModel>(jsonString);

                            var dailyNav = await _context.DailyNav.FirstOrDefaultAsync(m => m.MFundId == mfundId && m.nav_date == day);

                            // delete
                            if (dailyNav != null)
                            {
                                _context.DailyNav.Remove(dailyNav);
                            }

                            // insert
                            dailyNav = new DailyNav()
                            {
                                MFundId = mfundId,
                                nav_date = day,
                                net_asset = jsonObj.net_asset,
                                last_val = jsonObj.last_val,
                                previous_val = jsonObj.previous_val,
                                LastUpdate = DateTime.Parse(jsonObj.last_upd_date)
                            };
                            _context.Add(dailyNav);

                            await _context.SaveChangesAsync();
                            break;
                        }
                    }
                }
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
