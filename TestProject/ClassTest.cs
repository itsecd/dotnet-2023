using realtor;
namespace UnitTest;
public class FixtureRealt
{
    public List<Application> FixtureApplication
    {
        get
        {
            var Firsthouse = new House(Guid.NewGuid(), "Uninhabited", "Prosp. Fatiha Amirkhana, 1b", 594, 100);
            var Secondhouse = new House(Guid.NewGuid(), "Residential", "Profsoyuznaya, 22", 48, 3);
            var Thirdhouse = new House(Guid.NewGuid(), "Uninhabited", "Cathedral, 7", 12, 1);
            var Fourthhouse = new House(Guid.NewGuid(), "Residential", "Volzhsky prospect, 4", 2000, 74);
            var Fifthhouse = new House(Guid.NewGuid(), "Uninhabited", "Lesnaya, 23", 45, 2);

            var Firstclient = new Client(Guid.NewGuid(), "32218", "336-64-36", "Krasnoarmeyskaya, 1a", "Sergey", "Shnirov");
            var Secondclient = new Client(Guid.NewGuid(), "21415", "341-21-09", "Galaktionovskaya, 40", "Ilya", "Paramonov");
            var Thirdclient = new Client(Guid.NewGuid(), "59143", "265-89-77", "Communist, 90", "Ivan", "Terrible");
            var Fourthclient = new Client(Guid.NewGuid(), "91245", "880-05-55", "Aerodromnaya, 47a", "Michael", "Gorshnev");
            var Fifthclient = new Client(Guid.NewGuid(), "57504", "964-98-70", "Lesnaya, 23", "Stiven", "King");

            var Firstapplication = new Application(Guid.NewGuid(), "Purchase", 2, DateTime.Parse("1973-04-13"));
            var Secondapplication = new Application(Guid.NewGuid(), "Sale", 48000000, DateTime.Parse("1111-07-26"));
            var Thirdapplication = new Application(Guid.NewGuid(), "Purchase", 48000000, DateTime.Parse("1530-08-25"));
            var Fourthapplication = new Application(Guid.NewGuid(), "Purchase", 48000000, DateTime.Parse("1530-08-25"));
            var Fifthapplication = new Application(Guid.NewGuid(), "Purchase", 2000, DateTime.Parse("1973-08-07"));
            var Sixthapplication = new Application(Guid.NewGuid(), "Sale", 1, DateTime.Parse("1947-09-21"));
            var Seventhapplication = new Application(Guid.NewGuid(), "Purchase", 5, DateTime.Parse("1973-05-13"));

            Firstapplication.House.Add(Fifthhouse);
            Firstapplication.House.Add(Firsthouse);
            Firstapplication.Clients.Add(Fourthclient);

            Secondapplication.House.Add(Secondhouse);
            Secondapplication.Clients.Add(Fifthclient);

            Thirdapplication.House.Add(Thirdhouse);
            Thirdapplication.Clients.Add(Firstclient);

            Fourthapplication.House.Add(Fourthhouse);
            Fourthapplication.Clients.Add(Thirdclient);

            Fifthapplication.House.Add(Thirdhouse);
            Firstapplication.Clients.Add(Secondclient);

            Sixthapplication.House.Add(Fifthhouse);
            Sixthapplication.Clients.Add(Fifthclient);
            Seventhapplication.Clients.Add(Firstclient);
            Seventhapplication.House.Add(Firsthouse);

            Firstclient.Applications.Add(Firstapplication);
            Firstclient.Applications.Add(Secondapplication);
            Secondclient.Applications.Add(Thirdapplication);
            Thirdclient.Applications.Add(Fourthapplication);
            Fourthclient.Applications.Add(Fifthapplication);
            Fifthclient.Applications.Add(Sixthapplication);
            Firstclient.Applications.Add(Seventhapplication);

            Firsthouse.Applications.Add(Secondapplication);
            Secondhouse.Applications.Add(Secondapplication);
            Thirdhouse.Applications.Add(Thirdapplication);
            Thirdhouse.Applications.Add(Fifthapplication);
            Fourthhouse.Applications.Add(Fifthapplication);
            Fifthhouse.Applications.Add(Firstapplication);
            Fifthhouse.Applications.Add(Sixthapplication);

            var applications = new List<Application>
            {
                Firstapplication, Secondapplication, Thirdapplication, Fourthapplication, Fifthapplication, Sixthapplication
            };
            return applications;
        }
    }
}