using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Buoi06_EFCore_CodeFirst.Models
{
    [Table("KhachHang")]
    public class KhachHang
    {
        [Key]
        [MaxLength(8)]
        public string MaKh { get; set; }
        [MaxLength(100)]
        public string TenKh { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        [MaxLength(10)]
        public string Phone { get; set; }
        public ICollection<HoaDon>? HoaDons { get; set; } = new List<HoaDon>();
    }

    [Table("HoaDon")]
    public class HoaDon
    {
        [Key]
        public int MaHd { get; set; }
        public DateTime NgayLap { get; set; }
        [MaxLength(8)]
        public string? MaKh { get; set; }
        [ForeignKey("MaKh")]
        public KhachHang? KhachHang { get; set; }
    }

    [Table("ChiTietHoaDon")]
    public class ChiTietHoaDon
    {
        [Key]
        public int MaCthd { get; set; }
        public int MaHd { get; set; }
        [ForeignKey("MaHd")]
        public HoaDon? HoaDon { get; set; }
        public int MaHh { get; set; }
        [ForeignKey("MaHh")]
        public HangHoa? HangHoa { get; set; }
        public int SoLuong { get; set; }
    }
}
