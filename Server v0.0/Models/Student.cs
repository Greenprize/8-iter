using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Server_v0._0.Models
{
    public class Student
    {
        [Key]
        public int Id_Stud { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronomic { get; set; }
        [Phone]
        public string Phone { get; set; }
        public string Addres { get; set; }
        public ICollection<Grads_Of_Semestr> Grads_Of_Semestrs { get; set; }
        public ICollection<Syllabus> Syllabuses { get; set; }
    }
}
