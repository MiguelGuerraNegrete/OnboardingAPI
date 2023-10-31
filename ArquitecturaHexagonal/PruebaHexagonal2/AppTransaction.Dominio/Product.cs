using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AppTransaction.Dominio
{
    public class Product
    {
        public int ProductId { get; set; }
        public int ProductCode { get; set; }
        public string ProductName { get; set; }
        public double ProductValue { get; set; }

    }
}
