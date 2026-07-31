using Buoi07_EStoreDbFirst.Entities;
using Buoi07_EStoreDbFirst.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Buoi07_EStoreDbFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhachHangController : ControllerBase
    {
        private readonly MyeStoreContext _context;
        public KhachHangController(MyeStoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllKhachHang()
        {
            var khachHangs = _context.KhachHangs
                .Where(kh => kh.HieuLuc)
                .Select(kh => new KhachHangVM
                {
                    MaKh = kh.MaKh,
                    HoTen = kh.HoTen,
                    DiaChi = kh.DiaChi ?? string.Empty,
                    DienThoai = kh.DienThoai ?? string.Empty,
                    Email = kh.Email,
                    Hinh = kh.Hinh ?? string.Empty,
                    NgaySinh = kh.NgaySinh,
                    GioiTinh = kh.GioiTinh
                })
                .ToList();
            return Ok(khachHangs);
        }

        [HttpPost]
        public IActionResult CreateNewCustomer(KhachHangVMWithPassword khachHangVM)
        {
            if (khachHangVM == null)
            {
                return BadRequest("KhachHangVM is null.");
            }
            try
            {
                var khachHang = new KhachHang
                {
                    MaKh = khachHangVM.MaKh,
                    HoTen = khachHangVM.HoTen,
                    DiaChi = khachHangVM.DiaChi,
                    DienThoai = khachHangVM.DienThoai,
                    Email = khachHangVM.Email,
                    Hinh = khachHangVM.Hinh,
                    NgaySinh = khachHangVM.NgaySinh,
                    GioiTinh = khachHangVM.GioiTinh,
                    RandomKey = "ABC123", // tinh sau
                    MatKhau = khachHangVM.MatKhau + "ABC123", // tinh sau
                    HieuLuc = true // Set default value for HieuLuc
                };
                _context.KhachHangs.Add(khachHang);
                _context.SaveChanges();
                return CreatedAtAction(nameof(GetAllKhachHang), new { id = khachHang.MaKh }, khachHang);
            }catch
            {
                return BadRequest("Error creating new customer.");
            }
        }
    }
}
