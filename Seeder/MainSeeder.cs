using Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seeder
{
    public static class MainSeeder
    {
        public static void clearDatabase(LabelDbContext dbContext)
        {
            var tables = dbContext.Model.GetEntityTypes().Select(t => t.ClrType).ToList();

            dbContext.Roles.RemoveRange(dbContext.Roles);
            dbContext.Passwords.RemoveRange(dbContext.Passwords);
            dbContext.Users.RemoveRange(dbContext.Users);
            dbContext.LabelStatus.RemoveRange(dbContext.LabelStatus);
            dbContext.LabelTypes.RemoveRange(dbContext.LabelTypes);
            dbContext.DocumentTypes.RemoveRange(dbContext.DocumentTypes);

            dbContext.SaveChanges();
        }

        public static void seedAll(LabelDbContext dbContext)
        {
            clearDatabase(dbContext);

            RoleSeeder.SeedRoles(dbContext);
            UserSeeder.SeedUsers(dbContext);
            LabelStatusSeeder.SeedLabelStatuses(dbContext);
            LabelTypeSeeder.SeedLabelTypes(dbContext);
            DocumentTypeSeeder.SeedDocumentTypes(dbContext);

        }
    }
}
