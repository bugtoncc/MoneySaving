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
        public async Task<IActionResult> Index(string QueryAmc)
        {
            //var applicationDbContext = _context.MFund.Include(m => m.MAmc);
            //return View(await applicationDbContext.ToListAsync());

            var mamc = from m in _context.MAmc
                       orderby m.UniqueId
                       select m;

            var fundM = new MainFundModel
            {
                MFunds = await _context.MFund.ToListAsync(),
                AmcSelectList = new SelectList(await mamc.ToListAsync(), "UniqueId", "NameEn")
            };

            return View(fundM);
        }

        // GET: MFunds/Details/5
        public async Task<IActionResult> Details(int? id)
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


        [HttpPost]
        public async Task<IActionResult> UpdateApi([Bind("QueryAmc")] string queryAmc)
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
                            //RegisDate = DateTime.TryParseExact(element.regis_date) ? 1 : 2,
                            //CancelDate = element.cancel_date,
                            NameTh = element.proj_name_th,
                            NameEn = element.proj_name_en,
                            Abbr = element.proj_abbr_name,
                            FundStatus = element.fund_status,
                            PermitUs = element.permit_us_investment
                        };
                        //_context.Add(fund);
                    }
                    else
                    {
                        //mAmc.NameTh = element.name_th;
                        //mAmc.NameEn = element.name_en;
                        //mAmc.UniqueId = element.unique_id;
                        //mAmc.LastUpdate = DateTime.Now;
                        //_context.Update(mAmc);
                    }
                    //await _context.SaveChangesAsync();

                    var a = 0;
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
