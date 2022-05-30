using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Server_v0._0.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        public string FullName { get; set; }
        public string Adress { get; set; }
        [Phone]
        public ulong Phone { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public int DiscountId {get;set;}
        public Discount Discount { get; set; }
        public List<Sale> Sales { get; set; }
    }
}
