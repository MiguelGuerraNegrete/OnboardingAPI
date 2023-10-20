using System.Text.Json.Serialization;

namespace Actividad_semana4_VS.Model
{
    public class Client
    {
        public int ClientId { get; set; }
        public string Identification { get; set; }
        public string Name { get; set; }
        public double AvailableBalance { get; set; }

        [JsonIgnore]
        public virtual ICollection<Order>? Orders { get; set; }
    }
}
