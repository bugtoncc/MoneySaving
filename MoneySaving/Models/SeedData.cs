using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MoneySaving.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneySaving.Models
{
    public class SeedData
    {
        protected static int CashflowTypeId_Income = 7;
        protected static int CashflowTypeId_Outcome = 8;

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MoneyContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MoneyContext>>()))
            {
                if (context.MCategory.Any())
                {
                    return;
                }

                var listIncome = new List<string>
                {
                    "เงินเดือน",
                    "ดอกเบี้ย",
                    "ของขวัญ",
                    "เงินรางวัล",
                    "อื่นๆ"
                };

                var listOutcome = new List<string>
                {
                    "การลงทุน",
                    "การศึกษา",
                    "ที่จอดรถ",
                    "บำรุงรักษารถ",
                    "บริจาค",
                    "ครอบครัว",
                    "ปรับปรุงบ้าน",
                    "ค่าธรรมเนียม",
                    "ช้อปปิ้ง",
                    "บันเทิง",
                    "บิล & สาธารณูปโภค",
                    "ประกันภัย",
                    "สุขภาพ & กีฬา",
                    "อาหาร",
                    "เพื่อน",
                    "อื่นๆ",
                };

                foreach (string strIncomeName in listIncome)
                {
                    context.MCategory.Add(new MCategory
                    {
                        Name = strIncomeName,
                        CashflowTypeId = CashflowTypeId_Income
                    });
                }

                foreach (string strOutcomeName in listOutcome)
                {
                    context.MCategory.Add(new MCategory
                    {
                        Name = strOutcomeName,
                        CashflowTypeId = CashflowTypeId_Outcome
                    });
                }
                context.SaveChanges();
            }
        }
    }
}
