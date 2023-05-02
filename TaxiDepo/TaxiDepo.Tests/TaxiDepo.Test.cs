namespace TaxiDepo.Model.Tests;

public class TaxiDepotTest
{
    /// <summary>
    /// Class Driver initialization
    /// </summary>
    /// <returns>Driver's list</returns>
    private List<Driver> DriversList()
    {
        return new List<Driver>()
        {
            new Driver(0, "Antonov", "Viktor", "Pavlovich", 14557586, "Samara Lenina 25, 4", "89791113223"),
            new Driver(1, "Antipov", "Anton", "Viktorovich", 21534496, "Samara Stalina 115, 43", "89343322223"),
            new Driver(2, "Pavlov", "Sergey", "Sergeevich", 37927348, "Samara Nikonova 205, 49", "87983839938"),
            new Driver(3, "Tolov", "Dmitriy", "Stanislavovich", 93894829, "Samara Pavlova 99, 99", "89111199993"),
            new Driver(4, "Sipov", "Pavel", "Antonovich", 34943834, "Samara Vokzalnaya 32, 533", "89787293792"),
            new Driver(5, "Markin", "Anatoliy", "Nikitovich", 34892743, "Samara Chainaya 23, 122", "82932992019"),
            new Driver(6, "Vitin", "Vladimir", "Pavlovich", 00293944, "Samara Lisova 323, 11", "83747378283"),
            new Driver(7, "Votin", "Vladimir", "Sergeevich", 00244944, "Samara Losova 123, 11", "89997378283")
        };
    }

    /// <summary>
    /// Class Car initialization
    /// </summary>
    /// <returns></returns>
    private List<Car> CarsList()
    {
        return new List<Car>()
        {
            new Car(0, "A279TT163", "BMW E34", "Purple"),
            new Car(1, "M777MM763", "Mercedes E63", "Black"),
            new Car(2, "B281BB777", "Toyota corolla", "White"),
            new Car(3, "A909BA102", "Toyota LC200", "Yellow"),
            new Car(4, "M763MM763", "Lada Vesta", "White"),
            new Car(5, "E700EA77", "Lada Priora", "Orange"),
            new Car(6, "M808AM63", "Geely Emgrand", "Blue"),
        };
    }

    /// <summary>
    /// Class User initialization
    /// </summary>
    /// <returns></returns>
    private List<User> UsersList()
    {
        return new List<User>()
        {
            new User(0, "Vitov", "Viktor", "Vladimirovich", "89193829222"),
            new User(1, "Kotov", "Stanislav", "Pavlovich", "89290334434"),
            new User(2, "Topov", "Andrey", "Dmitrievich", "89889230233"),
            new User(3, "Losev", "Pavel", "Yanovich", "89230039402"),
            new User(4, "Lisov", "Vladimir", "Artmovich", "89177373403")
        };
    }

    /// <summary>
    /// Class Ride initialization
    /// </summary>
    /// <returns></returns>
    private List<Ride> RidesList()
    {
        return new List<Ride>()
        {
            new Ride(0, "Samara Lisova 15", "Samara Lisova 113", new DateTime(2020, 05, 14, 22, 43, 42),
                new TimeSpan(2, 3, 4), 341.23, new Car(0, "A279TT163", "BMW E34", "Purple"),
                new User(4, "Lisov", "Vladimir", "Artmovich", "89177373403")),
            new Ride(1, "Samara Antonova 25", "Samara Vitova 122", new DateTime(2020, 06, 22, 15, 53, 54),
                new TimeSpan(1, 32, 4), 129.22, new Car(0, "A279TT163", "BMW E34", "Purple"),
                new User(4, "Lisov", "Vladimir", "Artmovich", "89177373403")),
            new Ride(2, "Samara Vlasova 77", "Samara Motova 222", new DateTime(2021, 11, 29, 19, 20, 22),
                new TimeSpan(1, 19, 4), 472.41, new Car(0, "A279TT163", "BMW E34", "Purple"),
                new User(1, "Kotov", "Stanislav", "Pavlovich", "89290334434")),
            new Ride(3, "Samara Tolova 9", "Samara Stakova 91", new DateTime(2022, 01, 19, 18, 30, 20),
                new TimeSpan(1, 13, 42), 99.11, new Car(1, "M777MM763", "Mercedes E63", "Black"),
                new User(1, "Kotov", "Stanislav", "Pavlovich", "89290334434")),
            new Ride(4, "Samara Olova 9", "Samara Stakova 91", new DateTime(2022, 01, 19, 18, 30, 20),
                new TimeSpan(1, 13, 42), 99.11, new Car(1, "M777MM763", "Mercedes E63", "Black"),
                new User(1, "Kotov", "Stanislav", "Pavlovich", "89290334434")),
            new Ride(5, "Samara Rolova 9", "Samara Stakova 91", new DateTime(2022, 01, 19, 18, 30, 20),
                new TimeSpan(1, 13, 42), 99.11, new Car(1, "M777MM763", "Mercedes E63", "Black"),
                new User(4, "Losev", "Pavel", "Yanovich", "89230039402"))
        };
    }

    /// <summary>
    /// Driver car connection - Assigned car to driver
    /// </summary>
    public TaxiDepot CreatDriverCarConnect()
    {
        var company = new TaxiDepot(DriversList(), CarsList(), UsersList(), RidesList());
        for (var i = 0; i < 7; i++)
        {
            if (company.Cars != null)
            {
                company.Cars[i].AssignedDriver = company.Drivers?[i];
            }
        }

        return company;
    }

    /// <summary>
    /// Drivers amount test
    /// </summary>
    [Fact]
    public void DriversAmountTest()
    {
        var company = new TaxiDepot(DriversList(), CarsList(), UsersList(), RidesList());
        List<Driver>? drivers = company.Drivers;
        if (drivers != null)
        {
            Assert.Equal(8, drivers.Count);
        }
    }

    /// <summary>
    /// Cars amount test
    /// </summary>
    [Fact]
    public void CarsAmountTest()
    {
        var company = new TaxiDepot(DriversList(), CarsList(), UsersList(), RidesList());
        List<Car>? cars = company.Cars;
        if (cars != null)
        {
            Assert.Equal(7, cars.Count);
        }
    }

    /// <summary>
    /// Users amount test
    /// </summary>
    [Fact]
    public void UsersAmountTest()
    {
        var company = new TaxiDepot(DriversList(), CarsList(), UsersList(), RidesList());
        List<User>? users = company.Users;
        if (users != null)
        {
            Assert.Equal(5, users.Count);
        }
    }

    /// <summary>
    /// Rides amount test
    /// </summary>
    [Fact]
    public void RidesAmountTest()
    {
        var company = new TaxiDepot(DriversList(), CarsList(), UsersList(), RidesList());
        List<Ride>? rides = company.Rides;
        if (rides != null)
        {
            Assert.Equal(6, rides.Count);
        }
    }

    /// <summary>
    /// Right data constructor test - class Driver
    /// </summary>
    [Fact]
    public void DriverConstructorTest()
    {
        var driver = new Driver(0, "Antonov", "Viktor", "Pavlovich", 14557586, "Samara Lenina 25, 4", "89791113223");
        Assert.Equal("Antonov", driver.DriverSurname);
        Assert.Equal("Viktor", driver.DriverName);
        Assert.Equal("Pavlovich", driver.DriverPatronymic);
        Assert.Equal("Samara Lenina 25, 4", driver.DriverAddress);
        Assert.Equal("89791113223", driver.DriverPhoneNumber);
        Assert.Equal(14557586, driver.DriverPassportId);
    }

    /// <summary>
    /// Right data constructor test - class Car
    /// </summary>
    [Fact]
    public void CarConstructorTest()
    {
        var car = new Car(0, "A279TT163", "BMW E34", "Purple");
        Assert.Equal("A279TT163", car.CarNumber);
        Assert.Equal("BMW E34", car.CarModel);
        Assert.Equal("Purple", car.CarColor);
    }

    /// <summary>
    /// Right data constructor test - class User
    /// </summary>
    [Fact]
    public void UserConstructorTest()
    {
        var user = new User(6, "Antonov", "Viktor", "Pavlovich", "89228881212");
        Assert.Equal("Antonov", user.UserSurname);
        Assert.Equal("Viktor", user.UserName);
        Assert.Equal("Pavlovich", user.UserPatronymic);
        Assert.Equal("89228881212", user.UserPhoneNumber);
    }

    /// <summary>
    /// Right data constructor test - class Ride
    /// </summary>
    [Fact]
    public void RideConstructorTest()
    {
        var ride = new Ride(0, "Samara Antonova 25", "Samara Vitova 122", new DateTime(2020, 06, 22, 15, 53, 54),
            new TimeSpan(1, 9, 23), 129.22, new Car(0, "A279TT163", "BMW E34", "Purple"),
            new User(6, "Antonov", "Viktor", "Pavlovich", "89228881212"));
        Assert.Equal("Samara Antonova 25", ride.TripDeparturePlace);
        Assert.Equal("Samara Vitova 122", ride.TripDestinationPlace);
        Assert.Equal(new DateTime(2020, 06, 22, 15, 53, 54), ride.TripDate);
        Assert.Equal(new TimeSpan(1, 9, 23), ride.TripTime);
        Assert.Equal(129.22, ride.TripPrice);
        Assert.Equal(new Car(0, "A279TT163", "BMW E34", "Purple"), ride.TripCar);
        Assert.Equal(new User(6, "Antonov", "Viktor", "Pavlovich", "89228881212"), ride.UserInfo);
    }

    /// <summary>
    /// Test with place condition to search amount of posts - class Ride
    /// </summary>
    [Fact]
    public void AmountPostsPlaceConditionRide()
    {
        TaxiDepot company = new TaxiDepot(DriversList(), CarsList(), UsersList(), RidesList());
        var countRide = (from obj in company.Rides
            where (obj.TripDeparturePlace == "Samara Lisova 15") && (obj.TripDestinationPlace == "Samara Lisova 113")
            select obj).Count();
        Assert.Equal(1, countRide);
    }

    /// <summary>
    /// Test with price condition to search amount of posts - class Ride
    /// </summary>
    [Fact]
    public void AmountPostsPriceConditionRide()
    {
        TaxiDepot company = new TaxiDepot(DriversList(), CarsList(), UsersList(), RidesList());
        var countRide = (from obj in company.Rides where (obj.TripPrice < 400.0) select obj).Count();
        Assert.Equal(5, countRide);
    }

    /// <summary>
    /// Test with date condition to search amount of posts - class Ride
    /// </summary>
    [Fact]
    public void AmountPostsDateConditionRide()
    {
        TaxiDepot company = new TaxiDepot(DriversList(), CarsList(), UsersList(), RidesList());
        var countRide = (from obj in company.Rides
            where (obj.TripDate < new DateTime(2021, 12, 12, 12, 12, 12))
            select obj).Count();
        Assert.Equal(3, countRide);
    }

    /// <summary>
    /// Test with time condition to search amount of posts - class Ride
    /// </summary>
    [Fact]
    public void AmountPostsTimeConditionRide()
    {
        TaxiDepot company = new TaxiDepot(DriversList(), CarsList(), UsersList(), RidesList());
        var countRide = (from obj in company.Rides where (obj.TripTime < new TimeSpan(1, 59, 23)) select obj).Count();
        Assert.Equal(5, countRide);
    }

    /// <summary>
    /// Test with car condition to search amount of posts - class Ride
    /// </summary>
    [Fact]
    public void AmountPostsCarConditionRide()
    {
        TaxiDepot company = new TaxiDepot(DriversList(), CarsList(), UsersList(), RidesList());
        var countRide = (from obj in company.Rides
            where (obj.TripCar == new Car(0, "A279TT163", "BMW E34", "Purple"))
            select obj).Count();
        Assert.Equal(3, countRide);
    }

    /// <summary>
    /// Task 1 - Print info about driver, his car
    /// </summary>
    [Fact]
    public void TestDriverCarPair()
    {
        var company = CreatDriverCarConnect();
        var driver = (from obj in company.Drivers where (obj.DriverSurname == "Antonov") select obj).ToList();
        //Assert.Equal(new Car(0, "A279TT163", "BMW E34", "Purple", new Driver(7, "Votin", "Vladimir", "Sergeevich", 
        //  00244944, "Samara Losova 123, 11", "89997378283")), driver[0].AssignedCar);
        Assert.Single(driver);
    }

    /// <summary>
    /// Task 2 - Print info about user who driven in date range sort by surname
    /// </summary>
    [Fact]
    public void TestUserDate()
    {
        var company = new TaxiDepot(DriversList(), CarsList(), UsersList(), RidesList());

        var user = (from obj in company.Rides
            where (obj.TripDate > new DateTime(2020, 12, 12, 12, 12, 12) &&
                   obj.TripDate < new DateTime(2022, 12, 12, 12, 12, 12))
            orderby obj.UserInfo.UserSurname descending
            select obj.UserInfo);
        Assert.Equal(4, user.Count());
    }

    /// <summary>
    /// Task 3 - Print user rides amount
    /// </summary>
    [Fact]
    public void TestUserRides()
    {
        var company = new TaxiDepot(DriversList(), CarsList(), UsersList(), RidesList());

        var user = (from obj in company.Rides
            where (obj.UserInfo == new User(1, "Kotov", "Stanislav", "Pavlovich", "89290334434"))
            select obj.UserInfo).Count();
        Assert.Equal(3, user);
    }

    /// <summary>
    /// Task 4 - Print top five drivers with max amount rides
    /// </summary>
    [Fact]
    public void TestDriversRidesAmount()
    {
        var company = CreatDriverCarConnect();

        var driver = (from obj in company.Rides where (obj.TripCar != null) select obj.TripCar.AssignedDriver).Take(5)
            .Count();
        Assert.Equal(5, driver);
    }

    /// <summary>
    /// Task 5 - Print info about amount driver rides, min trip time
    /// </summary>
    [Fact]
    public void TestDriverTripTime()
    {
        var company = new TaxiDepot(DriversList(), CarsList(), UsersList(), RidesList());

        var time = (from obj in company.Rides
            where (obj.TripCar == new Car(0, "A279TT163", "BMW E34", "Purple"))
            select obj.TripTime).ToList();
        var minTime = time.Min();
        Assert.Equal(new TimeSpan(1, 19, 4), minTime);
    }

    /// <summary>
    /// Task 6 - Print info about users, who made max amount of rides
    /// </summary>
    [Fact]
    public void TestUserTripAmount()
    {
        var company = new TaxiDepot(DriversList(), CarsList(), UsersList(), RidesList());
        var user = (from obj in company.Rides
            where (obj.TripDate < new DateTime(2022, 12, 12, 12, 12, 12) &&
                   obj.UserInfo == new User(1, "Kotov", "Stanislav", "Pavlovich", "89290334434"))
            select obj.UserInfo).Count();
        Assert.Equal(3, user);
    }
}