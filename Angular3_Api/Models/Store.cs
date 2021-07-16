using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Angular3_Api.Models
{
    public class Store
    {

        public long Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string OpeningHours { get; set; }
    }
}
