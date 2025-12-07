using DataAccessLayer.EntityClass;
using System.Data.Entity;

namespace DataAccessLayer
{
    public class CosmeticsContext : DbContext
    {
        public CosmeticsContext() : base("CosmeticsDbConnection")
        {
        }

        public DbSet<SanPham> SanPhams { get; set; }
        public DbSet<LoaiSP> LoaiSPs { get; set; }
        public DbSet<ThuongHieu> ThuongHieus { get; set; }
        public DbSet<NhaCungCap> NhaCungCaps { get; set; }
        public DbSet<PhieuNhap> PhieuNhaps { get; set; }
        public DbSet<CT_PhieuNhap> CT_PhieuNhaps { get; set; }
        public DbSet<HoaDon> HoaDons { get; set; }
        public DbSet<CT_HoaDon> CT_HoaDons { get; set; }
        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<NhanVien> NhanViens { get; set; }
        public DbSet<TaiKhoan> TaiKhoans { get; set; }

        public DbSet<AuditLog> AuditLogs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SanPham>()
                .HasRequired(sp => sp.LoaiSP)
                .WithMany(loai => loai.SanPhams)
                .HasForeignKey(sp => sp.MaLoai)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SanPham>()
                .HasRequired(sp => sp.ThuongHieu)
                .WithMany(th => th.SanPhams)
                .HasForeignKey(sp => sp.MaThuongHieu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhieuNhap>()
                .HasRequired(pn => pn.NhaCungCap)
                .WithMany(ncc => ncc.PhieuNhaps)
                .HasForeignKey(pn => pn.MaNCC)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HoaDon>()
                .HasRequired(hd => hd.KhachHang)
                .WithMany(kh => kh.HoaDons)
                .HasForeignKey(hd => hd.MaKH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HoaDon>()
                .HasRequired(hd => hd.NhanVien)
                .WithMany(nv => nv.HoaDons)
                .HasForeignKey(hd => hd.MaNV)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CT_PhieuNhap>()
                .HasRequired(ct => ct.PhieuNhap)
                .WithMany(pn => pn.CT_PhieuNhaps)
                .HasForeignKey(ct => ct.MaPN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CT_PhieuNhap>()
                .HasRequired(ct => ct.SanPham)
                .WithMany(sp => sp.CT_PhieuNhaps)
                .HasForeignKey(ct => ct.MaSP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CT_HoaDon>()
                .HasRequired(ct => ct.HoaDon)
                .WithMany(hd => hd.CT_HoaDons)
                .HasForeignKey(ct => ct.MaHD)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CT_HoaDon>()
                .HasRequired(ct => ct.SanPham)
                .WithMany(sp => sp.CT_HoaDons)
                .HasForeignKey(ct => ct.MaSP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhanVien>()
                .HasOptional(nv => nv.TaiKhoan)
                .WithRequired(tk => tk.NhanVien);

            modelBuilder.Entity<AuditLog>()
                .HasOptional(a => a.NhanVien)
                .WithMany()
                .HasForeignKey(a => a.MaNV)
                .WillCascadeOnDelete(false);


            base.OnModelCreating(modelBuilder);
        }
    }
}
