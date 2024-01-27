namespace BubbleAPi.Domain.Entities
{
    public class Course
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public List<Course_Report> Course_Reports { get; set; }
    }
}
