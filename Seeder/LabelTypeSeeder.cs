using Database;
using Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seeder
{
    public static class LabelTypeSeeder
    {
        private static List<LabelType> labelTypes = new List<LabelType>
        {
            new LabelType{Symbol = "R2024", Description = "Naklejka roczna na rok 2024", Count = 0},
            new LabelType{Symbol = "R2025", Description = "Naklejka roczna na rok 2025", Count = 0},
            new LabelType{Symbol = "R2026", Description = "Naklejka roczna na rok 2026", Count = 0},
            new LabelType{Symbol = "R2027", Description = "Naklejka roczna na rok 2027", Count = 0},

            new LabelType{Symbol = "M01", Description = "Naklejka miesięczna na styczeń", Count = 0},
            new LabelType{Symbol = "M02", Description = "Naklejka miesięczna na luty", Count = 0},
            new LabelType{Symbol = "M03", Description = "Naklejka miesięczna na marzec", Count = 0},
            new LabelType{Symbol = "M04", Description = "Naklejka miesięczna na kwiecień", Count = 0},
            new LabelType{Symbol = "M05", Description = "Naklejka miesięczna na maj", Count = 0},
            new LabelType{Symbol = "M06", Description = "Naklejka miesięczna na czerwiec", Count = 0},
            new LabelType{Symbol = "M07", Description = "Naklejka miesięczna na lipiec", Count = 0},
            new LabelType{Symbol = "M08", Description = "Naklejka miesięczna na sierpień", Count = 0},
            new LabelType{Symbol = "M09", Description = "Naklejka miesięczna na wrzesień", Count = 0},
            new LabelType{Symbol = "M10", Description = "Naklejka miesięczna na październik", Count = 0},
            new LabelType{Symbol = "M11", Description = "Naklejka miesięczna na listopad", Count = 0},
            new LabelType{Symbol = "M12", Description = "Naklejka miesięczna na grudzień", Count = 0},

            new LabelType{Symbol = "UM", Description = "Naklejka urzędowa mała", Count = 0},
            new LabelType{Symbol = "UD", Description = "Naklejka urzędowa duża", Count = 0},
        };

        public static void SeedLabelTypes(LabelDbContext dbContext)
        {
            dbContext.AddRange(labelTypes);
            dbContext.SaveChanges();
        }
    }
}
