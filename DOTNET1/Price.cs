using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET_1
{
    public class Price
    {
        public Price()
        {
            Type = new Type();
        }
        public Type Type { get; set; }
        public decimal RentalPricePerHour { get; set; }
    }
}
