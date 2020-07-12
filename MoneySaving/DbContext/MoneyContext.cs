using Microsoft.EntityFrameworkCore;
using MoneySaving.Models;

namespace MoneySaving.DAL
{
    public class MoneyContext : DbContext
    {
        public MoneyContext(DbContextOptions<MoneyContext> options)
            : base(options)
        {
        }

        public DbSet<MPocket> MPocket { get; set; }
        public DbSet<MCategory> MCategory { get; set; }
        public DbSet<CashflowType> CashflowType { get; set; }
        //public DbSet<CategoryMap> CategoryMap { get; set; }
        public DbSet<MainTransaction> MainTransaction { get; set; }
    }
}
