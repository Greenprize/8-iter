using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Server_v0._0.Models
{
    public class Unit
    {
        public int UnitId { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
