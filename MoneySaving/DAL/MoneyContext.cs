using Microsoft.EntityFrameworkCore;
using MoneySaving.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MoneySaving.DAL
{
    public class MoneyContext : DbContext
    {
        public MoneyContext(DbContextOptions<MoneyContext> options) : base(options)
        {
        }

        public DbSet<Pocket> Pocket { get; set; }
        public DbSet<Category> Categories { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
        //}
    }
}
