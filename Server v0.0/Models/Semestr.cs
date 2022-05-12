using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Server_v0._0.Models
{
    public class Semestr
    {
        public int SemestrId { get; set; }
        public List<Time> Times { get; set; }
    }
}
