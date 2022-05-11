using Server_v0._0.Models;
using System.ComponentModel.DataAnnotations;

namespace Server_v0._0
{
    public class Syllabus
    {
        [Key]
        public int Syllabus_Id { get; set; }
        public int Grade { get;set; }

        public int Id_Subj { get; set; }
        public Subject Subject { get; set; }

        public int Id_Stud { get; set; }
        public Student Student { get; set; }
    }
}
