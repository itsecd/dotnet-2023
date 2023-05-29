using Realtor;

namespace RealtorServer.Repository;

public class RealtorRepository : IRealtorRepository
{
    private readonly List<House> _houses;
    private readonly List<Client> _clients;
    private readonly List<Application> _applications;
    public RealtorRepository()

    {
        var firstHouse = new House(1, "Uninhabited", "Prosp. Fatiha Amirkhana, 1b", 594, 100);
        var secondHouse = new House(2, "Residential", "Profsoyuznaya, 22", 48, 3);
        var thirdHouse = new House(3, "Uninhabited", "Cathedral, 7", 12, 1);
        var fourthHouse = new House(4, "Residential", "Volzhsky prospect, 4", 2000, 74);
        var fifthHouse = new House(5, "Uninhabited", "Lesnaya, 23", 45, 2);

        var firstClient = new Client(1, "32218", "336-64-36", "Krasnoarmeyskaya, 1a", "Sergey", "Shnirov");
        var secondClient = new Client(2, "21415", "341-21-09", "Galaktionovskaya, 40", "Ilya", "Paramonov");
        var thirdClient = new Client(3, "59143", "265-89-77", "Communist, 90", "Ivan", "Terrible");
        var fourthClient = new Client(4, "91245", "880-05-55", "Aerodromnaya, 47a", "Michael", "Gorshnev");
        var fifthClient = new Client(5, "57504", "964-98-70", "Lesnaya, 23", "Stiven", "King");

        var firstApplication = new Application(1, "Purchase", 2, DateTime.Parse("1973-04-13"));
        var secondApplication = new Application(2, "Sale", 48000000, DateTime.Parse("1111-07-26"));
        var thirdApplication = new Application(3, "Purchase", 48000000, DateTime.Parse("1530-08-25"));
        var fourthApplication = new Application(4, "Purchase", 48000000, DateTime.Parse("1530-08-25"));
        var fifthApplication = new Application(5, "Purchase", 2000, DateTime.Parse("1973-08-07"));
        var sixthApplication = new Application(6, "Sale", 1, DateTime.Parse("1947-09-21"));
        var seventhApplication = new Application(7, "Purchase", 5, DateTime.Parse("1973-05-13"));

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

        _clients = new List<Client>
            {
                firstClient, secondClient,thirdClient,fourthClient,fifthClient
            };

        _houses = new List<House> { firstHouse, secondHouse, thirdHouse, fourthHouse, fifthHouse };

        _applications = new List<Application>
            {
                firstApplication, secondApplication, thirdApplication, fourthApplication, fifthApplication, sixthApplication
            };
    }
    public List<Client> Clients => _clients;
    public List<House> Houses => _houses;
    public List<Application> Applications => _applications;
}

