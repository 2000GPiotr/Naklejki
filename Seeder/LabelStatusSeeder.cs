using Database;
using Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seeder
{
    public static class LabelStatusSeeder
    {
        private static List<LabelStatus> statuses = new List<LabelStatus>
        {
            new LabelStatus{Symbol = "Dostepna", Description = "Naklejka jest dostępna na stanie"},
            new LabelStatus{Symbol = "Wydana", Description = "Naklejka jest wydana pracownikowi, może zostać zużyta lub zniszczona"},
            new LabelStatus{Symbol = "Zuzyta", Description = "Naklejka została zużyta, nie jeest już dostępna i nie będzie w przyszłości"},
            new LabelStatus{Symbol = "Zniszczona", Description = "Naklejka jest zniszczona, nie została zużyta i nie będzie dostępna"},
            new LabelStatus{Symbol = "Zwrocona", Description = "Naklejka jest zwrócona na stałe, nie jest już dostępna"}
        };

        public static void SeedLabelStatuses(LabelDbContext dbContext)
        {
            dbContext.LabelStatus.AddRange(statuses);
            dbContext.SaveChanges();
        }
    }
}
