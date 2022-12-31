using Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    public class LabelDbContext : DbContext
    {
        public LabelDbContext(DbContextOptions<LabelDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Password> Passwords { get; set; }
        public DbSet<Registry> Registry { get; set; }
        public DbSet<LabelType> LabelTypes { get; set; }
        public DbSet<Items> Items { get; set; }
        public DbSet<DocumentHeader> DocumentHeaders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Registry>(eb =>
                {
                    eb.HasKey(x => new { x.LabelTypeId, x.LabelNumber });

                    eb.HasMany(r => r.Items)
                    .WithOne(i => i.Registry)
                    .HasForeignKey(i => new { i.LabelTypeId, i.LabelNumber });
                });

            modelBuilder.Entity<User>(eb =>
            {
                eb.HasOne(u => u.Password)
                .WithOne(p => p.User)
                .HasForeignKey<Password>(p => p.UserId);

                eb.HasMany(u => u.DocumentHeaders)
                .WithOne(h => h.User)
                .HasForeignKey(h => h.UserId);

                eb.HasMany(u => u.Registries)
                .WithOne(r => r.User)
                .HasForeignKey(r => r.UserId);
            });

            modelBuilder.Entity<DocumentHeader>(eb =>
            {
                eb.HasMany(h => h.Items)
                .WithOne(i => i.DocumentHeader)
                .HasForeignKey(i => i.DocumentHeaderId);

                eb.HasMany(h => h.Items)
                .WithOne(i => i.DocumentHeader)
                .HasForeignKey(i => i.DocumentHeaderId);
            });

            modelBuilder.Entity<LabelType>(eb =>
            {
                eb.HasMany(t => t.Items)
                .WithOne(i => i.LabelType)
                .HasForeignKey(i => i.LabelTypeId);

                eb.HasMany(t => t.Registries)
                .WithOne(r => r.LabelType)
                .HasForeignKey(r => r.LabelTypeId);
            });
        }
    }
}
