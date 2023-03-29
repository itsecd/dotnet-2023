using Realtor;
namespace UnitTest;
public class FixtureRealt
{
    public List<Application> FixtureApplication
    {
        get
        {
            var firstHouse = new House(Guid.NewGuid(), "Uninhabited", "Prosp. Fatiha Amirkhana, 1b", 594, 100);
            var secondHouse = new House(Guid.NewGuid(), "Residential", "Profsoyuznaya, 22", 48, 3);
            var thirdHouse = new House(Guid.NewGuid(), "Uninhabited", "Cathedral, 7", 12, 1);
            var fourthHouse = new House(Guid.NewGuid(), "Residential", "Volzhsky prospect, 4", 2000, 74);
            var fifthHouse = new House(Guid.NewGuid(), "Uninhabited", "Lesnaya, 23", 45, 2);

            var firstClient = new Client(Guid.NewGuid(), "32218", "336-64-36", "Krasnoarmeyskaya, 1a", "Sergey", "Shnirov");
            var secondClient = new Client(Guid.NewGuid(), "21415", "341-21-09", "Galaktionovskaya, 40", "Ilya", "Paramonov");
            var thirdClient = new Client(Guid.NewGuid(), "59143", "265-89-77", "Communist, 90", "Ivan", "Terrible");
            var fourthClient = new Client(Guid.NewGuid(), "91245", "880-05-55", "Aerodromnaya, 47a", "Michael", "Gorshnev");
            var fifthClient = new Client(Guid.NewGuid(), "57504", "964-98-70", "Lesnaya, 23", "Stiven", "King");

            var firstApplication = new Application(Guid.NewGuid(), "Purchase", 2, DateTime.Parse("1973-04-13"));
            var secondApplication = new Application(Guid.NewGuid(), "Sale", 48000000, DateTime.Parse("1111-07-26"));
            var thirdApplication = new Application(Guid.NewGuid(), "Purchase", 48000000, DateTime.Parse("1530-08-25"));
            var fourthApplication = new Application(Guid.NewGuid(), "Purchase", 48000000, DateTime.Parse("1530-08-25"));
            var fifthApplication = new Application(Guid.NewGuid(), "Purchase", 2000, DateTime.Parse("1973-08-07"));
            var sixthApplication = new Application(Guid.NewGuid(), "Sale", 1, DateTime.Parse("1947-09-21"));
            var seventhApplication = new Application(Guid.NewGuid(), "Purchase", 5, DateTime.Parse("1973-05-13"));

            firstApplication.House.Add(fifthHouse);
            firstApplication.House.Add(firstHouse);
            firstApplication.Clients.Add(fourthClient);

            secondApplication.House.Add(secondHouse);
            secondApplication.Clients.Add(fifthClient);

            thirdApplication.House.Add(thirdHouse);
            thirdApplication.Clients.Add(firstClient);

            fourthApplication.House.Add(fourthHouse);
            fourthApplication.Clients.Add(thirdClient);

            fifthApplication.House.Add(thirdHouse);
            firstApplication.Clients.Add(secondClient);

            sixthApplication.House.Add(fifthHouse);
            sixthApplication.Clients.Add(fifthClient);
            seventhApplication.Clients.Add(firstClient);
            seventhApplication.House.Add(firstHouse);

            firstClient.Applications.Add(firstApplication);
            firstClient.Applications.Add(secondApplication);
            secondClient.Applications.Add(thirdApplication);
            thirdClient.Applications.Add(fourthApplication);
            fourthClient.Applications.Add(fifthApplication);
            fifthClient.Applications.Add(sixthApplication);
            firstClient.Applications.Add(seventhApplication);

            firstHouse.Applications.Add(secondApplication);
            secondHouse.Applications.Add(secondApplication);
            thirdHouse.Applications.Add(thirdApplication);
            thirdHouse.Applications.Add(fifthApplication);
            fourthHouse.Applications.Add(fifthApplication);
            fifthHouse.Applications.Add(firstApplication);
            fifthHouse.Applications.Add(sixthApplication);

            var applications = new List<Application>
            {
                firstApplication, secondApplication, thirdApplication, fourthApplication, fifthApplication, sixthApplication
            };
            return applications;
        }
    }
}