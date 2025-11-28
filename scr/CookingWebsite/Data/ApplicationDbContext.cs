using Microsoft.EntityFrameworkCore;
using CookingWebsite.Models;

namespace CookingWebsite.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<CongThuc> CongThucs { get; set; }
        public DbSet<CacBuocNau> CacBuocNaus { get; set; }
        public DbSet<NguyenLieu> NguyenLieus { get; set; }
        public DbSet<LoaiNguyenLieu> LoaiNguyenLieus { get; set; }
        public DbSet<LoaiMonAn> LoaiMonAns { get; set; }
        public DbSet<CongThucLoaiMonAn> CongThucLoaiMonAns { get; set; }
        public DbSet<CongThucNguyenLieu> CongThucNguyenLieus { get; set; }
        public DbSet<TaiKhoan> TaiKhoans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure CongThucLoaiMonAn (many-to-many without explicit key)
            modelBuilder.Entity<CongThucLoaiMonAn>()
                .HasKey(c => new { c.MaCongThuc, c.MaLoaiMonAn });

            // Configure relationships
            modelBuilder.Entity<CacBuocNau>()
                .HasOne(c => c.CongThuc)
                .WithMany(ct => ct.CacBuocNaus)
                .HasForeignKey(c => c.MaCongThuc)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CongThucNguyenLieu>()
                .HasOne(c => c.CongThuc)
                .WithMany(ct => ct.CongThucNguyenLieus)
                .HasForeignKey(c => c.MaCongThuc)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CongThucNguyenLieu>()
                .HasOne(c => c.NguyenLieu)
                .WithMany(n => n.CongThucNguyenLieus)
                .HasForeignKey(c => c.MaNguyenLieu)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<NguyenLieu>()
                .HasOne(n => n.LoaiNguyenLieu)
                .WithMany(l => l.NguyenLieus)
                .HasForeignKey(n => n.MaLoaiNguyenLieu)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CongThucLoaiMonAn>()
                .HasOne(c => c.CongThuc)
                .WithMany(ct => ct.CongThucLoaiMonAns)
                .HasForeignKey(c => c.MaCongThuc)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CongThucLoaiMonAn>()
                .HasOne(c => c.LoaiMonAn)
                .WithMany(l => l.CongThucLoaiMonAns)
                .HasForeignKey(c => c.MaLoaiMonAn)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}



