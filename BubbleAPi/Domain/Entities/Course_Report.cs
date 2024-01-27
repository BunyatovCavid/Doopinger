namespace BubbleAPi.Domain.Entities
{
    public class Course_Report
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int Student_Number { get; set; }
        public double Amount { get; set; }
        public string State { get; set; }
        public DateTime Date { get; set; }

        public Course Course { get; set; }
    }
}
