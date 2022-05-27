using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Server_v0._0.Models
{
    public class Sale
    {
        public int SaleId { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string DeliveryDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string SaleDate { get; set; }
        public ICollection<OrderComponent> OrderComponents { get; set; }
    }
}
