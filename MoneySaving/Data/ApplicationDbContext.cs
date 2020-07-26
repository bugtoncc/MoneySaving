using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
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

        public DbSet<CashflowType> CashflowType { get; set; }
        public DbSet<MPocket> MPocket { get; set; }
        public DbSet<MCategory> MCategory { get; set; }
        //public DbSet<CategoryMap> CategoryMap { get; set; }
        public DbSet<MainTransaction> MainTransaction { get; set; }
    }
}
