using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EventSender
{
    public class Order
    {
        public string OrderId { get; set; }

        public string OrderName { get; set; }

        public double Price { get; set; }


        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
