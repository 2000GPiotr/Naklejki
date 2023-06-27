using Database;
using Database.Entities;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seeder
{
    public static class UserSeeder
    {
        private static List<User> users = new List<User>
        {
            new User{Name = "Admin", Surname = "Admin", Login = "admin"},
            new User{Name = "User", Surname = "User", Login = "user"},
            new User{Name = "Magasinier", Surname = "Magasinier", Login = "magasinier"},
            new User{Name = "SuperUser", Surname = "SuperUser", Login = "superuser"}
        };

        public static void SeedUsersBase(LabelDbContext dbContext)
        {
            dbContext.Users.AddRange(users);
            dbContext.SaveChanges();
        }

        public static void SeedUsers(LabelDbContext dbContext)
        {
            var roles = dbContext.Roles.ToList();
            var admin = roles.SingleOrDefault(r => r.Name == "Administrator");
            var user = roles.SingleOrDefault(r => r.Name == "Uzytkownik");
            var magasinier = roles.SingleOrDefault(r => r.Name == "Magazynier");

            users[0].Roles.Add(admin);
            users[1].Roles.Add(user);
            users[2].Roles.Add(magasinier);
            users[3].Roles.AddRange(roles);

            users[0].Password = PasswordHelper.CreatePassword("admin");
            users[1].Password = PasswordHelper.CreatePassword("user");
            users[2].Password = PasswordHelper.CreatePassword("magasinier");
            users[3].Password = PasswordHelper.CreatePassword("superuser");

            dbContext.Users.AddRange(users);
            dbContext.SaveChanges();
        }
    }
}
