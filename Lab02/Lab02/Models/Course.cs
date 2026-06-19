namespace Lab02.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Credits { get; set; } = 1;
        public int TheoryHours { get; set; }
        public int PracticeHours => (Credits * 15 - TheoryHours) * 2;
        public int TotalHours => TheoryHours + PracticeHours;
    }
}
