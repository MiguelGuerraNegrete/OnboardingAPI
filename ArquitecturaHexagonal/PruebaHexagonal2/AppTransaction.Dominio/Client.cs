using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AppTransaction.Dominio
{
    public class Client
    {
        public int ClientId { get; set; }
        public string Identification { get; set; }
        public string Name { get; set; }
        public double AvailableBalance { get; set; }

        [JsonIgnore]
        public  ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
