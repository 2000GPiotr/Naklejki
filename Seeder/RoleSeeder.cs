using Database;
using Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seeder
{
    public static class RoleSeeder
    {
        public static void SeedRoles(LabelDbContext dbContext)
        {
            var roles = new List<Roles>
            {
                new Roles{ Name = "Administrator", Description = "Zarządza użytkownikami"},
                new Roles{ Name = "Magazynier", Description = "Zarządza wydawaniem i zwrotami naklejek"},
                new Roles{ Name = "Uzytkownik", Description = "Przyjmuje i zużywa naklejki"}
            };

            dbContext.Roles.AddRange(roles);
            dbContext.SaveChanges();
        }
    }
}
