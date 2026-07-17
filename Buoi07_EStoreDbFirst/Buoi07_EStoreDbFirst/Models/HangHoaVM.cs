using System.ComponentModel.DataAnnotations;

namespace Buoi07_EStoreDbFirst.Models
{
    public class HangHoaVM
    {
        [Key]
        public int MaHh { get; set; }
        public string TenHh { get; set; }
        public string Hinh { get; set; }
        public double DonGia { get; set; }
        public string TenLoai { get; set; }
        public string TenNhaCungCap { get; set; }
    }
}
