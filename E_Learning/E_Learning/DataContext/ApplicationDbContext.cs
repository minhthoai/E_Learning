using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using E_Learning.Model;
namespace E_Learning.DataContext
{
    public class ApplicationDbContext: IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        //public DbSet<Admin> Admin { get; set; } = null!;
        public DbSet<BanGiamHieu> BanGiamHieu { get; set; } = null!;
        public DbSet<BaiKiemTra> BaiKiemTra { get; set; } = null!;
        public DbSet<BangDiem> BangDiem { get; set; } = null!;
        public DbSet<Class> Class { get; set; } = null!;
        public DbSet<Detail_Class> Detail_Class { get; set; } = null!;
        public DbSet<ManageStudent> ManageStudent { get; set; } = null!;
        public DbSet<ManageTeacher> ManageTeacher { get; set; } = null!;
        public DbSet<HoiDap> HoiDap { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
