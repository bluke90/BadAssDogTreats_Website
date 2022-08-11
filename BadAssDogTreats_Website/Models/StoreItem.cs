using System.ComponentModel.DataAnnotations;

namespace BadAssDogTreats_Website.Models
{
    public class StoreItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
        [DataType(dataType: DataType.MultilineText)]
        public string Description { get; set; }
#nullable enable
        public virtual Image? Image { get; set; }
#nullable disable
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public decimal DiscountPrice { get { return Price - (Price * Discount); } }
        public decimal Weight { get; set; }

    }
}
