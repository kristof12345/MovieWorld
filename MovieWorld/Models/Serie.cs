using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieWorld.Models
{
    public class Serie
    {
        public long OrderId { get; set; }

        public DateTime OrderDate { get; set; }

        public string Company { get; set; }

        public string ShipTo { get; set; }

        public double OrderTotal { get; set; }

        public string Status { get; set; }

        public char Symbol { get; set; }

        public override string ToString()
        {
            return $"{Company} {Status}";
        }
    }
}
