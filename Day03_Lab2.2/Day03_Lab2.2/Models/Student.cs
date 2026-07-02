using System.ComponentModel.DataAnnotations;

namespace Day03_Lab2._2.Models
{
    public class Student
    {
        [RegularExpression(@"\d{8}")]
        public string Id { get; set; }

        [MinLength(5, ErrorMessage = "Tối thiểu 5 kí tự")]
        public string Name { get; set; }

        public string? Image { get; set; }


        [Range(0, 10, ErrorMessage = "Điểm từ 0 .. 10")]
        public double Score { get; set; }
    }
}
