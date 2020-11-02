namespace Model.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CapThoatNuoc : DbContext
    {
        public CapThoatNuoc()
            : base("name=CapThoatNuoc")
        {
        }

        public virtual DbSet<chiso> chisoes { get; set; }
        public virtual DbSet<chucvu> chucvus { get; set; }
        public virtual DbSet<dongho> donghoes { get; set; }
        public virtual DbSet<hoadon> hoadons { get; set; }
        public virtual DbSet<khachhang> khachhangs { get; set; }
        public virtual DbSet<khuvuc> khuvucs { get; set; }
        public virtual DbSet<kyghi> kyghis { get; set; }
        public virtual DbSet<kythu> kythus { get; set; }
        public virtual DbSet<loaikhachhang> loaikhachhangs { get; set; }
        public virtual DbSet<lotrinh> lotrinhs { get; set; }
        public virtual DbSet<nganhang> nganhangs { get; set; }
        public virtual DbSet<nhanvien> nhanviens { get; set; }
        public virtual DbSet<phuong> phuongs { get; set; }
        public virtual DbSet<quan> quans { get; set; }
        public virtual DbSet<tinh> tinhs { get; set; }
        public virtual DbSet<vaitro> vaitroes { get; set; }
        public virtual DbSet<vt_cv> vt_cv { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<chiso>()
                .HasMany(e => e.hoadons)
                .WithRequired(e => e.chiso)
                .HasForeignKey(e => new { e.kh_id, e.k_id })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<chucvu>()
                .HasMany(e => e.nhanviens)
                .WithRequired(e => e.chucvu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<chucvu>()
                .HasMany(e => e.vt_cv)
                .WithRequired(e => e.chucvu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<khachhang>()
                .HasMany(e => e.chisoes)
                .WithRequired(e => e.khachhang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<khachhang>()
                .HasMany(e => e.donghoes)
                .WithRequired(e => e.khachhang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<khuvuc>()
                .HasMany(e => e.lotrinhs)
                .WithRequired(e => e.khuvuc)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<kyghi>()
                .HasMany(e => e.chisoes)
                .WithRequired(e => e.kyghi)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<kyghi>()
                .HasMany(e => e.kythus)
                .WithRequired(e => e.kyghi)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<loaikhachhang>()
                .HasMany(e => e.khachhangs)
                .WithRequired(e => e.loaikhachhang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<lotrinh>()
                .HasMany(e => e.khachhangs)
                .WithRequired(e => e.lotrinh)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<nhanvien>()
                .HasMany(e => e.hoadons)
                .WithRequired(e => e.nhanvien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<nhanvien>()
                .HasMany(e => e.kyghis)
                .WithRequired(e => e.nhanvien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<phuong>()
                .HasMany(e => e.khuvucs)
                .WithRequired(e => e.phuong)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<quan>()
                .HasMany(e => e.phuongs)
                .WithRequired(e => e.quan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tinh>()
                .HasMany(e => e.quans)
                .WithRequired(e => e.tinh)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<vaitro>()
                .HasMany(e => e.vt_cv)
                .WithRequired(e => e.vaitro)
                .WillCascadeOnDelete(false);
        }
    }
}
