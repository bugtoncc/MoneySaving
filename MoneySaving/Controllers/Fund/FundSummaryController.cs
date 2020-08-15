using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MoneySaving.Data;
using MoneySaving.Models;

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
    }
}
