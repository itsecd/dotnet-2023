using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airlines.Domain;

/// <summary>
/// Сlass describing the passenger
/// </summary>
public class PassengerClass
{
    /// <summary>
    /// Represent a unique ID of passanger
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Represent a passport number 
    /// </summary>
    public int PassportNumber { get; set; }
    /// <summary>
    /// Represent a passenger name
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Represent a tickets 
    /// </summary>
    public List<TicketClass> Tickets { get; set; }
    public PassengerClass(){}
    public PassengerClass(int passportnumber,string name) { 
        PassportNumber = passportnumber;
        Name = name;
        Tickets = new List<TicketClass>();
    }
}
