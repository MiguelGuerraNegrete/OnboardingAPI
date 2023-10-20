using System.Text.Json.Serialization;

namespace Actividad_semana4_VS.Model
{
    public class Product
    {
        //[Key]
        public int ProductId { get; set; }
        public int ProductCode { get; set; }
        public string ProductName { get; set; }
        public double ProductValue { get; set; }

        [JsonIgnore]
        public virtual ICollection<Order>? Orders { get; set; }
    }
}
