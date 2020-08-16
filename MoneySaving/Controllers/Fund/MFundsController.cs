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
    public class MFundsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private IConfiguration _configuration { get; }

        public MFundsController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // GET: MFunds
        public async Task<IActionResult> Index(string QueryAmc, string QueryFundKeyword)
        {
            //var applicationDbContext = _context.MFund.Include(m => m.MAmc);
            //return View(await applicationDbContext.ToListAsync());

            var mamc = from m in _context.MAmc
                       orderby m.UniqueId
                       select m;

            var funds = from m in _context.MFund.Include(m => m.MAmc)
                        select m;



            if (string.IsNullOrEmpty(QueryFundKeyword))
            {
                if (string.IsNullOrEmpty(QueryAmc))
                {
                    QueryAmc = "0";
                }
                funds = funds.Where(x => x.MAmcId == int.Parse(QueryAmc));
            }
            else
            {
                if (!string.IsNullOrEmpty(QueryAmc))
                {
                    funds = funds.Where(x => x.MAmcId == int.Parse(QueryAmc));
                }

                funds = funds.Where(x => x.NameTh.ToUpper().Contains(QueryFundKeyword)
                   || x.NameEn.ToUpper().Contains(QueryFundKeyword)
                   || x.Abbr.ToUpper().Contains(QueryFundKeyword));
            }


            funds = funds.OrderBy(x => x.MAmc.ID).ThenBy(x => x.Abbr);

            var fundM = new MainFundModel
            {
                MFunds = await funds.ToListAsync(),
                AmcSelectListFilter = new SelectList(await mamc.ToListAsync(), "ID", "NameTh"),
            };

            return View(fundM);
        }

        // GET: MFunds/Create
        public IActionResult Create()
        {
            ViewData["MAmcId"] = new SelectList(_context.MAmc, "ID", "NameEn");
            return View();
        }

        // POST: MFunds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,NameTh,NameEn,Abbr,ProjectId,RegisId,RegisDate,CancelDate,FundStatus,MAmcId,PermitUs,CountryFlag,StatusFlag,LastUpdate")] MFund mFund)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mFund);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MAmcId"] = new SelectList(_context.MAmc, "ID", "NameEn", mFund.MAmcId);
            return View(mFund);
        }

        // GET: MFunds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mFund = await _context.MFund.FindAsync(id);
            if (mFund == null)
            {
                return NotFound();
            }
            ViewData["MAmcId"] = new SelectList(_context.MAmc, "ID", "NameEn", mFund.MAmcId);
            mFund.LastUpdate = DateTime.Now;
            return View(mFund);
        }

        // POST: MFunds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,NameTh,NameEn,Abbr,ProjectId,RegisId,RegisDate,CancelDate,FundStatus,MAmcId,PermitUs,CountryFlag,StatusFlag,LastUpdate")] MFund mFund)
        {
            if (id != mFund.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mFund);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MFundExists(mFund.ID))
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
            ViewData["MAmcId"] = new SelectList(_context.MAmc, "ID", "NameEn", mFund.MAmcId);
            return View(mFund);
        }

        // GET: MFunds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mFund = await _context.MFund
                .Include(m => m.MAmc)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (mFund == null)
            {
                return NotFound();
            }

            return View(mFund);
        }

        // POST: MFunds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mFund = await _context.MFund.FindAsync(id);
            _context.MFund.Remove(mFund);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MFundExists(int id)
        {
            return _context.MFund.Any(e => e.ID == id);
        }

        public async Task<IActionResult> UpdateFromApi()
        {
            var mamc = from m in _context.MAmc
                       orderby m.UniqueId
                       select m;

            var fundM = new MainFundModel
            {
                AmcSelectList = new SelectList(await mamc.ToListAsync(), "UniqueId", "NameTh"),
            };

            return View(fundM);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFromApi([Bind("QueryAmc")] string queryAmc)
        {
            if (string.IsNullOrEmpty(queryAmc))
            {
                queryAmc = "0";
            }

            var mamcId = await _context.MAmc.FirstOrDefaultAsync(x => x.UniqueId == queryAmc);
            if (mamcId != null)
            {
                var client = new HttpClient();
                var queryString = HttpUtility.ParseQueryString(string.Empty);
                var key = _configuration.GetSection("SecSubscriptionKey").GetSection("FundFactSheet").Value.ToString();
                var uri = "https://api.sec.or.th/FundFactsheet/fund/amc/" + queryAmc + "?" + queryString;

                // Request headers
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", key);

                var response = await client.GetAsync(uri);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var jsonString = await client.GetStringAsync(uri);
                    List<FundsModel> listJsonObject = JsonConvert.DeserializeObject<List<FundsModel>>(jsonString);


                    foreach (FundsModel element in listJsonObject)
                    {
                        var fund = await _context.MFund.FirstOrDefaultAsync(m => m.ProjectId == element.proj_id);

                        if (fund == null)
                        {
                            fund = new MFund()
                            {
                                ProjectId = element.proj_id,
                                RegisId = element.regis_id,
                                NameTh = element.proj_name_th,
                                NameEn = element.proj_name_en,
                                Abbr = element.proj_abbr_name,
                                FundStatus = element.fund_status,
                                PermitUs = element.permit_us_investment,
                                MAmcId = mamcId.ID
                            };

                            if (DateTime.TryParse(element.regis_date, out DateTime tempDT)) { fund.RegisDate = tempDT; }
                            if (DateTime.TryParse(element.cancel_date, out tempDT)) { fund.CancelDate = tempDT; }
                            if (int.TryParse(element.invest_country_flage, out int tempCF)) { fund.CountryFlag = tempCF; }

                            _context.Add(fund);
                        }
                        else
                        {
                            fund.ProjectId = element.proj_id;
                            fund.RegisId = element.regis_id;
                            fund.NameTh = element.proj_name_th;
                            fund.NameEn = element.proj_name_en;
                            fund.Abbr = element.proj_abbr_name;
                            fund.FundStatus = element.fund_status;
                            fund.PermitUs = element.permit_us_investment;
                            fund.MAmcId = mamcId.ID;
                            fund.LastUpdate = DateTime.Now;

                            if (DateTime.TryParse(element.regis_date, out DateTime tempDT)) { fund.RegisDate = tempDT; }
                            if (DateTime.TryParse(element.cancel_date, out tempDT)) { fund.CancelDate = tempDT; }
                            if (int.TryParse(element.invest_country_flage, out int tempCF)) { fund.CountryFlag = tempCF; }

                            _context.Update(fund);
                        }
                        await _context.SaveChangesAsync();
                    }
                }
            }
            return RedirectToAction(nameof(Index));
        }

        public class FundsModel
        {
            public string last_upd_date { get; set; }
            public string proj_id { get; set; }
            public string regis_id { get; set; }
            public string regis_date { get; set; }
            public string cancel_date { get; set; }
            public string proj_name_th { get; set; }
            public string proj_name_en { get; set; }
            public string proj_abbr_name { get; set; }
            public string fund_status { get; set; }
            public string unique_id { get; set; }
            public string permit_us_investment { get; set; }
            public string invest_country_flage { get; set; }
        }
    }
}
