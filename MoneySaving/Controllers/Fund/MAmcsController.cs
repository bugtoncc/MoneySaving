using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MoneySaving.Data;
using MoneySaving.Models;
using Newtonsoft.Json;

namespace MoneySaving.Controllers
{
    [Authorize]
    public class MAmcsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private IConfiguration _configuration { get; }

        public MAmcsController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // GET: MAmcs
        public async Task<IActionResult> Index()
        {
            return View(await _context.MAmc.OrderBy(x => x.UniqueId).ToListAsync());
        }

        // GET: MAmcs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mAmc = await _context.MAmc
                .FirstOrDefaultAsync(m => m.ID == id);
            if (mAmc == null)
            {
                return NotFound();
            }

            return View(mAmc);
        }

        // GET: MAmcs/Create
        public IActionResult Create()
        {
            var mAmc = new MAmc();
            return View(mAmc);
        }

        // POST: MAmcs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,NameTh,NameEn,StatusFlag,LastUpdate")] MAmc mAmc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mAmc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mAmc);
        }

        // GET: MAmcs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mAmc = await _context.MAmc.FindAsync(id);
            if (mAmc == null)
            {
                return NotFound();
            }
            mAmc.LastUpdate = DateTime.Now;
            return View(mAmc);
        }

        // POST: MAmcs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,NameTh,NameEn,StatusFlag,LastUpdate")] MAmc mAmc)
        {
            if (id != mAmc.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mAmc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MAmcExists(mAmc.ID))
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
            return View(mAmc);
        }

        // GET: MAmcs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mAmc = await _context.MAmc
                .FirstOrDefaultAsync(m => m.ID == id);
            if (mAmc == null)
            {
                return NotFound();
            }

            return View(mAmc);
        }

        // POST: MAmcs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mAmc = await _context.MAmc.FindAsync(id);
            _context.MAmc.Remove(mAmc);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MAmcExists(int id)
        {
            return _context.MAmc.Any(e => e.ID == id);
        }


        [HttpPost]
        public async Task<IActionResult> UpdateApi()
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);
            var key = _configuration.GetSection("SecSubscriptionKey").GetSection("FundFactSheet").Value.ToString();
            var uri = "https://api.sec.or.th/FundFactsheet/fund/amc?" + queryString;

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", key);

            var response = await client.GetAsync(uri);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonString = await client.GetStringAsync(uri);
                List<AssetManagementModel> listJsonObject = JsonConvert.DeserializeObject<List<AssetManagementModel>>(jsonString);

                foreach (AssetManagementModel element in listJsonObject)
                {
                    var mAmc = await _context.MAmc.FirstOrDefaultAsync(m => m.UniqueId == element.unique_id);

                    if (mAmc == null)
                    {
                        mAmc = new MAmc()
                        {
                            NameTh = element.name_th,
                            NameEn = element.name_en,
                            UniqueId = element.unique_id,
                        };
                        _context.Add(mAmc);
                    }
                    else
                    {
                        mAmc.NameTh = element.name_th;
                        mAmc.NameEn = element.name_en;
                        mAmc.UniqueId = element.unique_id;
                        mAmc.LastUpdate = DateTime.Now;
                        _context.Update(mAmc);
                    }
                    await _context.SaveChangesAsync();
                }
            }

            return RedirectToAction(nameof(Index));
        }


        public class AssetManagementModel
        {
            public string last_upd_date { get; set; }
            public string unique_id { get; set; }
            public string name_th { get; set; }
            public string name_en { get; set; }
        }
    }
}
