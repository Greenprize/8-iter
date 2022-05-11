using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Server_v0._0.Models
{
    public class Semestr
    {
        [Key]
        public int Id_Sem { get; set; }
        public List<Time_ss> Time_sss { get; set; }
    }
}
