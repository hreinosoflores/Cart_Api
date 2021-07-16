using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Angular3_Api.Models
{
    public class DetailOrder
    {

        public long Id { get; set; }
        public long OrderId { get; set; }
        public long ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Subtotal { get; set; }
        [JsonIgnore]
        public Order Order { get; set; }
        [JsonIgnore]
        public Product Product { get; set; }

    }
}
