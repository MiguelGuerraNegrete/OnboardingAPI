using System.Text.Json.Serialization;

namespace Actividad_semana4_VS.Model
{
    public class Order
    {
        //[Key]
        public long OrderId { get; set; }
        //[ForeignKey("ClientId")]
        public int ClientId { get; set; }
        //[ForeignKey("ProductoId")]
        public int ProductId { get; set; }
        public int Units { get; set; }
        public Double ProductValue { get; set; }
        public Double Total { get; set; }

        [JsonIgnore]
        public virtual Client Client { get; set; }
        [JsonIgnore]
        public virtual Product Product { get; set; }
    }
}
