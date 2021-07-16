using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Angular3_Api.Models
{
    public class Order
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public bool Pickup { get; set; }

        public long? StoreId { get; set; }

        public string ShippingAddress { get; set; }
        public string City { get; set; }

        public decimal Total { get; set; }

        [JsonIgnore]
        public Store Store { get; set; }

    }
}
