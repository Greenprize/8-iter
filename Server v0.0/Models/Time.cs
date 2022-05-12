using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Server_v0._0.Models
{
    public class Time
    {
        public int TimeId { get; set; }
        public uint LectureTime { get; set; }
        public uint WorkTime { get; set; }
        public uint LaborTime { get; set; }
        public int SemestrId { get; set; }
        public Semestr Semestr { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public ICollection<GradsOfSemestr> GradsOfSemestrs { get; set; }
    }
}
