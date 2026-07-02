using System.ComponentModel.DataAnnotations;

namespace Buoi04_Validation.Models
{
    public class NhanVien
    {
        [Required(ErrorMessage = "Họ tên không được để trống")]
        [MinLength(5, ErrorMessage = "Họ tên phải có ít nhất 5 ký tự")]
        public string HoTen { get; set; }

        [Range(18, 60, ErrorMessage = "Tuổi phải từ 18 đến 60")]
        public int Tuoi { get; set; }
    }
}
