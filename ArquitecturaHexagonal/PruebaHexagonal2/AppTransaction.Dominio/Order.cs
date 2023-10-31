using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AppTransaction.Dominio
{
    public class Order
    {
        
        public long OrderId { get; set; }
        //[ForeignKey("ClientId")]
        public int ClientId { get; set; }
        //[ForeignKey("ProductoId")]
        public int ProductId { get; set; }
        public int Units { get; set; }
        public Double ProductValue { get; set; }
        public Double Total { get; set; }
        public Boolean Canceled { get; set; }     
        [JsonIgnore]
        public ICollection<Product> Product { get; set; }
    }
}
