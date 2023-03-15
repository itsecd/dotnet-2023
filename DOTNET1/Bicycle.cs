using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET_1
{
    public class Bicycle
    {
        public Bicycle()
        {
            Type = new Type();
        }
        public int SerialNumber { get; set; }
        public Type Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
    }
}
