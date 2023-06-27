using Database;
using Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seeder
{
    public static class DocumentTypeSeeder
    {
        private static List<DocumentType> types = new List<DocumentType>
        {
            new DocumentType{Symbol = "Przyjecie", Description = "Przyjęcie na stan"},
            new DocumentType{Symbol = "Wydanie", Description = "Wydanie naklejek pracownikowi"},
            new DocumentType{Symbol = "Zuzycie", Description = "Przyjęcie zużycia deklarowanego przez uzytkownika"},
            new DocumentType{Symbol = "Likwidacja", Description = "Likwidacja naklejek na stałe, zwrot do organu nadrzędnego"}
        };

        public static void SeedDocumentTypes(LabelDbContext dbContext)
        {
            dbContext.DocumentTypes.AddRange(types);
            dbContext.SaveChanges();
        }
    }
}
