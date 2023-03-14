namespace CarSharingTests;
public class CarSharingQueries:IClassFixture<CarSharingFixture>
{
    private readonly CarSharingFixture _fixture;
    public CarSharingQueries(CarSharingFixture fixture)
    {
        _fixture = fixture;
    }
    /// <summary>
    /// first request - info about all cars
    /// </summary>
    [Fact]
    public void AllCars()
    {
        var carList = _fixture.CarFixture.ToList();
        var carRequest = (for car in carList select car).Count();
        Assert.Equal(4, carRequest);
    }
    /// <summary>
    /// second request - all clients who rented requested car - Rolls-Royce
    /// </summary>
    [Fact]
    public void AllClientsRented()
    {
        var rentedCarList = _fixture.RentedCarFixture.ToList();
        var whorentedrolls = (from car in rentedCarList where car.Car.Model == "Rolls-Royce Boat Tail" select car.Client.FirstName).ToList();
        Assert.Equal(whorentedrolls[0], rentedCarList[1].Client.FirstName);
    }
    ///<summary>
    ///third request - info about cars which are in rent now
    ///</summary>
    [Fact]
    public void AllRented()
    {
        var carsinrent = _fixture.RentedCarFixture.ToList();
        var rentedcar = (from car in carsinrent where car.TimeOfReturn > DateTime.Now select car.Car.Model).ToList();
        Assert.Equal(carsinrent[0].Car.Model, rentedcar[0]);
    }
    ///<summary>
    ///fourth request - top five most rented cars 
    ///</summary>
    [Fact]
    public void TopFiveRents()
    {
        var rentedCars = _fixture.RentedCarFixture.ToList();
        DateTime nowadays = DateTime.Parse("2023-03-13");
        var counter = (from cartop in rentedCars
                       where cartop.TimeOfReturn < nowadays
                       group cartop by cartop.Car.CarId into g
                       select new
                       {
                           carmodel = g.Key,
                           count = g.Count()
                       }).ToList();
        var top = (from carcounter in counter orderby carcounter.count descending select carcounter).Take(5).ToList();
        Assert.Equal(5, top.Count());
    }
    ///<summary>
    ///fifth request - number of rents for each car
    ///</summary>
    [Fact]
    public void NumberOfRents()
    {
        var rentInfo = _fixture.RentedCarFixture.ToList();
        var numOfRents = (from rent in rentInfo
                          group rent by rent.Car.Model into g
                          select new
                          {
                              model = g.Key,
                              cntr = g.Distinct().Count()
                          }).ToList();
        Assert.Equal(4, numOfRents[0].cntr);
    }
    ///<summary>
    ///sixth request - rental point where the most cars were rented
    ///</summary>
    [Fact]
    public void RentalPointInfo()
    {
        var rentalPoint = _fixture.RentedCarFixture.ToList();
        var rentNumber = (from rp in rentalPoint
                          orderby rp.Point.PointName
                          group rp by rp.Point.PointName into g
                          select new
                          {
                              name = g.Key,
                              counter = g.Distinct().Count()
                          }).ToList();
        var maxRent = (from rn in rentNumber where (rn.counter == rentNumber.Max(x => x.counter)) select rn.name).ToList();
        Assert.Equal("Kchau", maxRent[0]);
    }
}
