using System.Collections.Generic;

namespace Server_v0._0.Models
{
    public class Discount
    {
        public int DiscountId { get; set; }
        public string Type { get; set; }
        public int Amount { get; set; }
        public List<Client> Clients { get; set; }
    }
}
