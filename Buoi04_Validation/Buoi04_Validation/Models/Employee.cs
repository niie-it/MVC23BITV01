using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Buoi04_Validation.Models
{
    public enum Gender
    {
        Nam, Nữ, Khác
    }
    public class Employee
    {
        public int? ID { get; set; }

        [Length(5, 20, ErrorMessage = "Mã nhân viên phải có độ dài từ 5 đến 20 ký tự")]
        public string EmployeeNo { get; set; }

        [MaxLength(100, ErrorMessage = "Họ tên không được vượt quá 100 ký tự")]
        public string FullName { get; set; }

        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; }

        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Mật khẩu xác nhận không khớp")]
        public string ConfirmPassword { get; set; }


        [Url(ErrorMessage = "Website không hợp lệ")]
        public string? Website { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        public Gender Gender { get; set; } = Gender.Nam;

        [Range(0, double.MaxValue, ErrorMessage = "Lương phải từ 0 trở lên")]
        public double Salary { get; set; } = 0;

        public bool IsPartTime { get; set; } = false;

        public string Address { get; set; }

        [RegularExpression(@"^0[9875]\d{8}$", ErrorMessage = "Số điện thoại phải có 10 chữ số")]
        public string Phone { get; set; }

        [CreditCard(ErrorMessage = "Số thẻ tín dụng không hợp lệ")]
        public string? CreditCard { get; set; }

        [DataType(DataType.MultilineText)]
        [MaxLength(255, ErrorMessage = "Mô tả không được vượt quá 255 ký tự")]
        public string? Description { get; set; }

    }
}
