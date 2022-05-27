using System.Collections.Generic;

namespace Server_v0._0.Models
{
    public class OrderComponent
    {
        public int OrderComponentId { get; set; }
        public uint Quanity { get; set; }
        public int SaleId { get; set; }
        public Sale Sale { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
