using System.Linq;
using Realtors;
namespace UnitTest;
public class RealtFixture
{
    /// <summary>
    /// list of houses to test queries
    /// </summary>
    public List<House> HouseFixture
    {
        get
        {
            var houses = new List<House>()
                {
                    new House(Guid.NewGuid(),"Uninhabited", "Prosp. Fatiha Amirkhana, 1b" , 594 , 100),
                    new House(Guid.NewGuid(), "Residential", "Profsoyuznaya, 22",48, 3),
                    new House(Guid.NewGuid(), "Uninhabited", "Cathedral, 7",12,1),
                    new House(Guid.NewGuid(), "Residential", "Volzhsky prospect, 4",2000,74),
                    new House(Guid.NewGuid(), "Uninhabited", "Lesnaya, 23",45, 2)
                };
            return houses;
        }
    }
    /// <summary>
    /// list of applications to test queries
    /// </summary>
    public List<Application> ApplicationFixture
    {
        get
        {
            var applications = new List<Application>()
                {
                    new Application(Guid.NewGuid(),"Purchase", 1 ,DateTime.Parse("1973-04-13"), houses[4]),
                    new Application(Guid.NewGuid(), "Sale", 48000000, DateTime.Parse("1111-07-26"), houses[1]),
                    new Application(Guid.NewGuid(), "Purchase", 48000000,DateTime.Parse("1530-08-25"), houses[2]),
                    new Application(Guid.NewGuid(), "Purchase", 48000000,DateTime.Parse("1530-08-25"), houses[0]),
                    new Application(Guid.NewGuid(), "Purchase",2000,DateTime.Parse("1973-08-07"),  houses[3]),
                    new Application(Guid.NewGuid(), "Sale", 45, DateTime.Parse("1947-09-21"), houses[4])
                };
            return applications;
        }
    }
    /// <summary>
    /// list of clients to test queries
    /// </summary>
    public List<Client> ClientFixture
    {
        get
        {
            var clients = new List<Client>()
                {
                    new Client(Guid.NewGuid(), "32218","336-64-36" ,"Krasnoarmeyskaya, 1a" ,"Shnirov", "Sergey",applications[2]),
                    new Client(Guid.NewGuid(), "21415", "341-21-09" ,"Galaktionovskaya, 40","Paramonov", "Ilya",applications[4]),
                    new Client(Guid.NewGuid(), "59143", "265-89-77" ,"Communist, 90","Terrible", "Ivan",applications[3]),
                    new Client(Guid.NewGuid(), "91245", "880-05-55" ,"Aerodromnaya, 47a","Gorshnev", "Michael",applications[0]),
                    new Client(Guid.NewGuid(), "57504", "964-98-70" ,"Lesnaya, 23","King", "Stiven",applications[5])
                    new Client(Guid.NewGuid(), "57504", "964-98-70" ,"Lesnaya, 23","King", "Stiven",applications[1])
                };
            return clients;
        }
    }


}