using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using MoneySaving.Models;

namespace MoneySaving.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
    }

    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        //--- Saving ---//
        public DbSet<CashflowType> CashflowType { get; set; }
        public DbSet<MPocket> MPocket { get; set; }
        public DbSet<MCategory> MCategory { get; set; }
        public DbSet<MainTransaction> MainTransaction { get; set; }

        //--- Fund ---//
        public DbSet<FundPort> FundPort { get; set; }
        public DbSet<FundSummary> FundSummary { get; set; }
        public DbSet<FundTransaction> FundTransaction { get; set; }
        public DbSet<MAmc> MAmc { get; set; }
        public DbSet<MFund> MFund { get; set; }
        public DbSet<MFundFlowType> MFundFlowType { get; set; }

    }
}
