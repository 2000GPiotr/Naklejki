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
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<Roles> Roles { get; set; }
        
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
                eb.HasIndex(u => u.Login)
                .IsUnique();

                eb.HasOne(u => u.Password)
                .WithOne(p => p.User)
                .HasForeignKey<User>(p => p.PasswordId);

                eb.HasMany(u => u.DocumentHeaders)
                .WithOne(h => h.User)
                .HasForeignKey(h => h.UserId);

                eb.HasMany(u => u.Registries)
                .WithOne(r => r.User)
                .HasForeignKey(r => r.UserId);

                eb.HasMany(u => u.Roles)
                .WithMany(r => r.Users);
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

            modelBuilder.Entity<DocumentType>(eb =>
            {
                eb.HasMany(t => t.DocumentHeaders)
                .WithOne(h => h.DocumentType)
                .HasForeignKey(h => h.DocumentTypeId);
            });

            modelBuilder.Entity<LabelStatus>(eb =>
            {
                eb.HasMany(s => s.Registries)
                .WithOne(r => r.LabelStatus)
                .HasForeignKey(r => r.LabelStatusId);
            });

            modelBuilder.Entity<Password>(eb =>
            {
                eb.Property(u => u.Salt)
                .HasColumnType("bytea");
            });

            modelBuilder.Entity<Password>(eb =>
            {
                eb.Property(u => u.Hash)
                .HasColumnType("bytea");
            });
        }
    }
}
