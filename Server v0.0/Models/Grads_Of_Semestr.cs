using Server_v0._0.Models;
using System.ComponentModel.DataAnnotations;

namespace Server_v0._0
{
    public class Grads_Of_Semestr
    {
        [Key]
        public int Grads_Of_Semestr_Id { get; set; }
        public int Grade { get;set; }

        public int Id_Time { get; set; }
        public Time_ss Time_ss { get; set; }

        public int Id_Stud { get; set; }
        public Student Student { get; set; }
    }
}
