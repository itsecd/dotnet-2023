using System.Linq;

namespace CarSharingTests
{
    public class CarSharingQueries
    {
        /// <summary>
        /// first request - info about all cars
        /// </summary>
        [Fact]
        public void AllCars()
        {
            var carList = CarFixture.ToList();
            var carRequest = (for car in carList select car).Count();
            Assert.Equal(4, carRequest);
        }
        /// <summary>
        /// second request - all clients who rented requested car - Rolls-Royce
        /// </summary>
        [Fact]
        public void AllClientsRented()
        {
            var rentedCarList = RentedCarFixture.ToList();
            var whorentedrolls = (from car in rentedCarList where car.Car.Model == "Rolls-Royce Boat Tail" select car.Client.FirstName).ToList();
            Assert.Equal(whorentedrolls[0], rentedCarList[1].Client.FirstName);
        }

        ///<summary>
        ///third request - info about cars which are in rent now
        ///</summary>
        [Fact]
        public void AllRented()
        {
            var carsinrent = RentedCarFixture.ToList();
            var rentedcar = (from car in carsinrent where car.TimeOfReturn > DateTime.Now select car.Car.Model).ToList();
            Assert.Equal(carsinrent[0].Car.Model, rentedcar[0]);
        }
    }
}
