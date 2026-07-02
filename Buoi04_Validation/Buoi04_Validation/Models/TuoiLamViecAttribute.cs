using System.ComponentModel.DataAnnotations;

namespace Buoi04_Validation.Models
{
    public class TuoiLamViecAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            // 1. Ngày sinh bắt buộc
            if (value == null)
            {
                return new ValidationResult("Ngày sinh là bắt buộc");
            }

            // 2. Tuổi >= 18 (DateTime.Now.Year - BirthDate.Year >= 18)
            var birthDate = (DateTime)value;
            int tuoi = DateTime.Now.Year - birthDate.Year;
            if (tuoi > 17 && tuoi < 63)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Tuổi phải từ 18 đến 62");
            }
        }
    }
}