using System.Collections.Generic;

namespace Server_v0._0.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public uint Price { get; set; }
        public uint Remainder { get; set; }
        public int UnitId { get; set; }
        public Unit Unit { get; set; }
        public ICollection<OrderComponent> OrderComponents { get; set; }
    }
}
