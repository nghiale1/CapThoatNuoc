namespace Model.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CapThoatNuocDbContext : DbContext
    {
        public CapThoatNuocDbContext()
            : base("name=CapThoatNuoc")
        {
        }

        public virtual DbSet<ChiSo> ChiSoes { get; set; }
        public virtual DbSet<ChucVu> ChucVus { get; set; }
        public virtual DbSet<DongHo> DongHoes { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<KhuVuc> KhuVucs { get; set; }
        public virtual DbSet<KyGhi> KyGhis { get; set; }
        public virtual DbSet<KyThu> KyThus { get; set; }
        public virtual DbSet<LoaiKhachHang> LoaiKhachHangs { get; set; }
        public virtual DbSet<LoTrinh> LoTrinhs { get; set; }
        public virtual DbSet<NganHang> NganHangs { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<Phuong> Phuongs { get; set; }
        public virtual DbSet<Quan> Quans { get; set; }
        public virtual DbSet<Tinh> Tinhs { get; set; }
        public virtual DbSet<VaiTro> VaiTroes { get; set; }
        public virtual DbSet<VT_CV> VT_CV { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChucVu>()
                .HasMany(e => e.NhanViens)
                .WithRequired(e => e.ChucVu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ChucVu>()
                .HasMany(e => e.VT_CV)
                .WithRequired(e => e.ChucVu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhachHang>()
                .HasMany(e => e.ChiSoes)
                .WithRequired(e => e.KhachHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhachHang>()
                .HasMany(e => e.DongHoes)
                .WithRequired(e => e.KhachHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhachHang>()
                .HasMany(e => e.HoaDons)
                .WithRequired(e => e.KhachHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KyGhi>()
                .HasMany(e => e.ChiSoes)
                .WithRequired(e => e.KyGhi)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KyGhi>()
                .HasMany(e => e.HoaDons)
                .WithRequired(e => e.KyGhi)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KyGhi>()
                .HasMany(e => e.KyThus)
                .WithRequired(e => e.KyGhi)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KyThu>()
                .HasMany(e => e.HoaDons)
                .WithRequired(e => e.KyThu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LoaiKhachHang>()
                .HasMany(e => e.KhachHangs)
                .WithRequired(e => e.LoaiKhachHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LoTrinh>()
                .HasMany(e => e.KhachHangs)
                .WithRequired(e => e.LoTrinh)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.HoaDons)
                .WithRequired(e => e.NhanVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.KyGhis)
                .WithRequired(e => e.NhanVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VaiTro>()
                .HasMany(e => e.VT_CV)
                .WithRequired(e => e.VaiTro)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VT_CV>()
                .Property(e => e.vtcv_ghichu)
                .IsUnicode(false);
        }
    }
}
