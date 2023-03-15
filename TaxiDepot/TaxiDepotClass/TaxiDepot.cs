using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiDepotClass;

namespace TaxiDepotClass;

public class TaxiDepot
{
    /// <summary>
    /// Drivers who are registered in the taxi company
    /// </summary>
    public List<Driver> Drivers { get; set; } = new List<Driver>();

    /// <summary>
    /// Cars who are registered in the taxi company
    /// </summary>
    public List<Car> Cars { get; set; } = new List<Car>();

    /// <summary>
    /// Peoples who are used the taxi company
    /// </summary>
    public List<User> Users { get; set; } = new List<User>();

    /// <summary>
    /// Taxi company's trip info
    /// </summary>
    public List<Ride> Rides { get; set; } = new List<Ride>();

    /// <summary>
    /// Driver - Car: pair-container
    /// </summary>
    public readonly IDictionary<Driver, Car> CarAssignedToDriver = new Dictionary<Driver, Car>();

    /// <summary>
    /// Constructor without parameters to instantiate the class - TaxiDepot
    /// </summary>
    public TaxiDepot() {}

    /// <summary>
    /// Constructor with parameters to instantiate the class - TaxiDepot
    /// </summary>
    /// <param name="driverObj"></param>
    /// <param name="carObj"></param>
    /// <param name="userObj"></param>
    /// <param name="rideObj"></param>
    public TaxiDepot(List<Driver> driverObj, List<Car> carObj, List<User> userObj, List<Ride> rideObj)
    {
        Drivers = driverObj;
        Cars = carObj;
        Users = userObj;
        Rides = rideObj;
    }

    /// <summary>
    /// Try set pair of driver, car - func 
    /// </summary>
    /// <param name="driverInfo"></param>
    /// <param name="carInfo"></param>
    public void TrySetDriverCarPair(Driver driverInfo, Car carInfo)
    {
        if (driverInfo.DriverAssigned || carInfo.CarAssigned)
            return;
        try
        {
            CarAssignedToDriver.Add(driverInfo, carInfo);
        }
        catch (ArgumentException)
        {
            Console.WriteLine("An element with that Key already exists.");
        }
        carInfo.CarAssigned = true;
        driverInfo.DriverAssigned = true;
    }
    
    /// <summary>
    /// Try get pair of driver, car - func 
    /// </summary>
    /// <param name="driverInfo"></param>
    /// <returns></returns>
    public Car TryGetDriverCarInfo(Driver driverInfo)
    {
        try
        {
            return CarAssignedToDriver[driverInfo];
        }
        catch (KeyNotFoundException)
        {
            Console.WriteLine("Key is not found.");
            throw;
        }
    }
    
    /// <summary>
    /// Try add post to drivers list - func
    /// </summary>
    /// <param name="driverInfo"></param>
    public void TryAddPostToDrivers(Driver driverInfo)
    {
        try
        {
            Drivers.Add(driverInfo);
        }
        catch (KeyNotFoundException)
        {
            Console.WriteLine("Error");
        }
    }
    
    /// <summary>
    /// Try add post to cars list - func
    /// </summary>
    /// <param name="carInfo"></param>
    public void TryAddPostToCars(Car carInfo)
    {
        try
        {
            Cars.Add(carInfo);
        }
        catch (KeyNotFoundException)
        {
            Console.WriteLine("Error");
        }
    }
    
    /// <summary>
    /// Try add post to users list - func
    /// </summary>
    /// <param name="userInfo"></param>
    public void TryAddPostToUsers(User userInfo)
    {
        try
        {
            Users.Add(userInfo);
        }
        catch (KeyNotFoundException)
        {
            Console.WriteLine("Error");
        }
    }
    
    /// <summary>
    /// Try add post to rides list - func
    /// </summary>
    /// <param name="rideInfo"></param>
    public void TryAddPostToRides(Ride rideInfo)
    {
        try
        {
            Rides.Add(rideInfo);
        }
        catch (KeyNotFoundException)
        {
            Console.WriteLine("Error");
        }
    }
}