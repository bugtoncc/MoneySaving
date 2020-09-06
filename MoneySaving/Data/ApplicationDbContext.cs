using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using MoneySaving.Models;
using MoneySaving.Models.Salary;

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

            //modelBuilder.Query<PortSummary>().ToView("PortSummary");

            modelBuilder.Entity<FundSummary>(eb =>
            {
                eb.HasNoKey();
                eb.ToView("FundSummary");
            });
        }


        //--- Saving ---//
        public DbSet<CashflowType> CashflowType { get; set; }
        public DbSet<MPocket> MPocket { get; set; }
        public DbSet<MCategory> MCategory { get; set; }
        public DbSet<MainTransaction> MainTransaction { get; set; }


        //--- Fund ---//
        public DbSet<FundPort> FundPort { get; set; }
        //public DbSet<FundSummary> FundSummary { get; set; }
        public DbSet<FundTransaction> FundTransaction { get; set; }
        public DbSet<MAmc> MAmc { get; set; }
        public DbSet<MFund> MFund { get; set; }
        public DbSet<MFundFlowType> MFundFlowType { get; set; }
        public DbSet<FundSummary> FundSummary { get; set; }
        public DbSet<DailyNav> DailyNav { get; set; }


        //--- Salary ---//
        public DbSet<MSalaryType> MSalaryType { get; set; }
        public DbSet<MSalary> MSalary { get; set; }
    }
}
