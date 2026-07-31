namespace Buoi07_EStoreDbFirst.Models
{
    public class KhachHangVM
    {
        public string MaKh { get; set; }
        public string HoTen { get; set; }
        public string DiaChi { get; set; } = string.Empty;
        public string DienThoai { get; set; } = string.Empty;
        public string Email { get; set; }
        public string Hinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public bool GioiTinh { get; set; }
    }

    public class KhachHangVMWithPassword : KhachHangVM
    {
        public string MatKhau { get; set; }
    }
}
