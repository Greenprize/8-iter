using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Server_v0._0.Models
{
    public class Subject
    {
        [Key]
        public int Id_Subj { get; set; }
        public ICollection<Syllabus> Syllabuses { get; set; }
        public string Title { get; set; }
        public ICollection<Time_ss> Time_ss { get; set; }
    }
}
