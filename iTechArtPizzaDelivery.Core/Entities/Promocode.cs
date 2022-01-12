using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaDelivery.Core.Entities
{
    public enum MeasureType : short
    {
        Percent,
        Money
    }

    public class Promocode
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public double Discount { get; set; }
        public short Measure { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
