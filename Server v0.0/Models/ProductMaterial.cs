using Server_v0._0.Models;

namespace Server_v0._0
{
    public class ProductMaterial
    {
        public int ProductMaterialId { get; set; }
        public int Weight { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int MaterialId { get; set; }
        public Material Material { get; set; }
    }
}
