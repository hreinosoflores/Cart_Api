using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace Angular3_Api.Models
{
    public class Product
    {
        public long Id { get; set; }
        public string Name{ get; set; }
        public decimal Price{ get; set; }
        public string Description{ get; set; }
        public int Stock{ get; set; }

    }
}
