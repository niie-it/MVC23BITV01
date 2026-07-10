using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Buoi06_EFCore_CodeFirst.Models
{
    [Table("Product")]
    public class HangHoa
    {
        [Key]
        public int MaHh { get; set; }
        [MaxLength(50)]
        public string TenHh { get; set; }
        public double DonGia { get; set; }
        public int SoLuong { get; set; }
        [MaxLength(150)]
        public string? Hinh { get; set; }
        public int? MaLoai { get; set; }

        [ForeignKey("MaLoai")]
        public Loai? Loai { get; set; }
    }
}
