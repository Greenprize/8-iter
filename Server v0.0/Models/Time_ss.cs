using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Server_v0._0.Models
{
    public class Time_ss
    {
        [Key]
        public int ID_Time { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string Time_Lecture { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string Time_Work { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string Time_Labor { get; set; }

        public ICollection<Grads_Of_Semestr> Grads_Of_Semestrs { get; set; }

        public int Id_Sem { get; set; }
        public Semestr Semestr { get; set; }
        public int Id_Subj { get; set; }
        public Subject Subject { get; set; }
    }
}
