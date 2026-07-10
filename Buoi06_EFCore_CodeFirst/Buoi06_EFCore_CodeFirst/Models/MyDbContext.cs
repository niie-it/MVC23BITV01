using Microsoft.EntityFrameworkCore;

namespace Buoi06_EFCore_CodeFirst.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        //Định nghĩa bảng
        public DbSet<HangHoa> HangHoas { get; set; }
        public DbSet<Loai> Loais { get; set; }
        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<HoaDon> HoaDons { get; set; }
        public DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }
    }
}
