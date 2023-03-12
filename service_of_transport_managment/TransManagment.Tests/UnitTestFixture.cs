using TransManagment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace TransManagment.Tests;
public class UnitTestFixture
{
    public List<Transport> FixturTrans()
    {
        return new List<Transport>()
        {
            new Transport(1, "bus", "Mercedes", new DateOnly(1990, 10, 23)),
            new Transport(2, "bus", "Audi", new DateOnly(1992, 04, 18)),
            new Transport(3, "trolleybus", "VAZ", new DateOnly(1985, 10, 23)),
            new Transport(4, "trolleybus", "VAZ", new DateOnly(2010, 11, 01)),
            new Transport(5, "tram", "Sam_tram", new DateOnly(1990, 10, 13)),
            new Transport(6, "tram", "Mos_tram", new DateOnly(1989, 08, 02)),
        };
    }
    public List<Drivers> FixtureDriv
{
    get
    {
        return new List<Drivers>
            {
                 new Drivers (11, "Igor", "Mercedes", new DateOnly(1990, 10, 23)),
            };
    }
}
}
