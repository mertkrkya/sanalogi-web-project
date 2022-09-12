using Microsoft.EntityFrameworkCore;
using Sanalogi.Data.Models;

namespace Sanalogi.Data.Context
{
    public class AppDbContext : DbContext
    {
        private static string _connectionstring;

        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Siparis> Siparis { get; set; }
        public static void SetContextConnectionString(string connectionstring)
        {
            _connectionstring = connectionstring;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) optionsBuilder.UseSqlServer(_connectionstring);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Siparis>(entity =>
            {
                entity.HasKey(r => r.Id).HasName("PK_SiparisId");
                entity.Property(r => r.Id).UseIdentityColumn().ValueGeneratedOnAdd();
                entity.Property(r => r.UrunAdi).IsRequired().HasMaxLength(128);
                entity.Property(r => r.SiparisVerenFirma).IsRequired().HasMaxLength(128);
                entity.Property(r => r.Tutar).IsRequired().HasColumnType("decimal(18,2)");
                entity.Property(r => r.Adet).IsRequired();
                entity.Property(r => r.SiparisTarihi).IsRequired();
                entity.Property(r => r.CreatedBy).IsRequired();
                entity.Property(r => r.CreatedDate).IsRequired();
                entity.ToTable("siparis");
            });
        }
    }
}