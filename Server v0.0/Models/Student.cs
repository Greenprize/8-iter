using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Server_v0._0.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronomic { get; set; }
        [Phone]
        public string Phone { get; set; }
        public string Addres { get; set; }
        public ICollection<GradsOfSemestr> GradsOfSemestrs { get; set; }
        public ICollection<Syllabus> Syllabuses { get; set; }
    }
}
