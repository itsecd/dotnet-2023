using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiDepo.Domain;

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
    public Dictionary<Driver, Car> CarAssignedToDriver;
    /// <summary>
    /// User - Ride: pair-container
    /// </summary>
    public Dictionary<User, Ride> UserAssignedToRide;
    /// <summary>
    /// Constructor without parameters to instantiate the class TaxiDepot
    /// </summary>
    public TaxiDepot() {}
    /// <summary>
    /// Constructor with parameters to instantiate the class TaxiDepot
    /// </summary>
    /// <param name="driverObj">List of drivers(Driver class object)</param>
    /// <param name="carObj">List of cars(Car class object)</param>
    /// <param name="userObj">List of users(User class object)</param>
    /// <param name="rideObj">List of rides(Ride class object)</param>
    public TaxiDepot(List<Driver> driverObj, List<Car> carObj, List<User> userObj, List<Ride> rideObj)
    {
        Drivers = driverObj;
        Cars = carObj;
        Users = userObj;
        Rides = rideObj;
        CarAssignedToDriver = new Dictionary<Driver, Car>();
        UserAssignedToRide = new Dictionary<User, Ride>();
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
            throw;
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
    /// Try set pair of user, ride - func 
    /// </summary>
    /// <param name="userInfo"></param>
    /// <param name="rideInfo"></param>
    public void TrySetUserRidePair(User userInfo, Ride rideInfo)
    {
        try
        {
            UserAssignedToRide.Add(userInfo, rideInfo);
        }
        catch (ArgumentException)
        {
            Console.WriteLine("An element with that Key already exists.");
            throw;
        }
    }
    /// <summary>
    /// Try get pair of user, ride - func 
    /// </summary>
    /// <param name="userInfo"></param>
    /// <returns></returns>
    public Ride TryGetUserRideInfo(User userInfo)
    {
        try
        {
            return UserAssignedToRide[userInfo];
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
            throw;
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
            throw;
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
            throw;
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
            throw;
        }
    }
}