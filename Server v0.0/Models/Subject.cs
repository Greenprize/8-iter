using System.Collections.Generic;

namespace Server_v0._0.Models
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string Title { get; set; }
        public List<Time> Times { get; set; }
        public ICollection<Syllabus> Syllabuses { get; set; }
    }
}
