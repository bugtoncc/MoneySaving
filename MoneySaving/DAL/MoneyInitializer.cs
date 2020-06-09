using MoneySaving.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneySaving.DAL
{
    public class MoneyInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<MoneyContext>
    {
        protected override void Seed(MoneyContext context)
        {
            var pockets = new List<Pocket>
            {
                new Pocket{PocketID=1001, Name="Cash", LastUpdate=DateTime.Now},
                new Pocket{PocketID=1002, Name="Bank account #1", LastUpdate=DateTime.Now}
            };

            pockets.ForEach(p => context.Pocket.Add(p));
            context.SaveChanges();

            var categories = new List<Category>
            {
                new Category{Name="Food", Type=Models.Type.Outcome, PocketId=1001, LastUpdate=DateTime.Now},
                new Category{Name="Shoping", Type=Models.Type.Outcome, PocketId=1001, LastUpdate=DateTime.Now},
                new Category{Name="Salary", Type=Models.Type.Income, PocketId=1001, LastUpdate=DateTime.Now},
                new Category{Name="Dept", Type=Models.Type.Outcome, PocketId=1001, LastUpdate=DateTime.Now},
                new Category{Name="Food", Type=Models.Type.Outcome, PocketId=1002, LastUpdate=DateTime.Now},
                new Category{Name="Shoping", Type=Models.Type.Outcome, PocketId=1002, LastUpdate=DateTime.Now},
                new Category{Name="Salary", Type=Models.Type.Income, PocketId=1002, LastUpdate=DateTime.Now},
                new Category{Name="Dept", Type=Models.Type.Outcome, PocketId=1002, LastUpdate=DateTime.Now}
            };

            categories.ForEach(c => context.Categories.Add(c));
            context.SaveChanges();
        }
    }
}
