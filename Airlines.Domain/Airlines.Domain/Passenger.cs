using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airlines.Domain;
public class PassengerClass
{
    public int PassportNumber { get; set; }
    public string Name { get; set; }
    public List<TicketClass> Tickets { get; set; }
    public PassengerClass(int passportnumber,string name) { 
        PassportNumber = passportnumber;
        Name = name;
        Tickets = new List<TicketClass>();
    }
}
