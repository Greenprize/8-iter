namespace Server_v0._0.Models
{
    public class GradsOfSemestr
    {
        public int GradsOfSemestrId { get; set; }
        public int Grade { get; set; }
        public int StudId { get; set; }
        public Student Student { get; set; }
        public int TimeId { get; set; }
        public Time Time { get; set; }
    }
}
