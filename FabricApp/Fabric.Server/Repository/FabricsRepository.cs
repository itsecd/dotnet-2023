using Fabrics.Domain;

namespace Fabrics.Server.Repository;

public class FabricsRepository : IFabricsRepository
{
    private readonly List<Fabric> _fabrics;

    private readonly List<Provider> _providers;

    private readonly List<Shipment> _shipments;
    public FabricsRepository()
    {
        _shipments = new List<Shipment>
        {
            new Shipment{Id = 1,FabricId = 1, ProviderId = 1, Date =new DateTime(2022, 6, 11), NumberOfGoods = 15 },
            new Shipment{Id = 2,FabricId = 2, ProviderId = 2, Date =new DateTime(2022, 7, 13), NumberOfGoods = 15 },
            new Shipment{Id = 3,FabricId = 3, ProviderId = 3, Date =new DateTime(2022, 8, 13), NumberOfGoods = 11 },
            new Shipment{Id = 4,FabricId = 4, ProviderId = 4, Date =new DateTime(2022, 11, 11), NumberOfGoods = 5 },
            new Shipment{Id = 5,FabricId = 1, ProviderId = 4, Date =new DateTime(2022, 3, 3), NumberOfGoods = 4 },
            new Shipment{Id = 6,FabricId = 4, ProviderId = 2, Date =new DateTime(2022, 12, 13), NumberOfGoods = 7 }
        };

        _fabrics = new List<Fabric>
        {
            new Fabric{Id = 1, Type = "Сельское хозяйство", Name = "Спелые фрукты", Address = "г. Нефтегорск, Ул. Пушкина, д.34", PhoneNumber = "89378533145", FormOfOwnership = "ТОО", NumberOfWorkers = 15, TotalSquare =  75,Shipments = new List<Shipment> { _shipments[0], _shipments[4] } },
            new Fabric{Id = 2, Type = "Транспорт", Name = "Веселый таксист", Address = "г. Самара, Ул. Дыбенко, д.30", PhoneNumber = "89371532175", FormOfOwnership = "Муниципально-городская", NumberOfWorkers = 30, TotalSquare =  50,Shipments = new List<Shipment> { _shipments[1]} },
            new Fabric{Id = 3, Type = "Легкая и тяжелая промышленность", Name = "Тяжелая легкость", Address = "г. Самара, Ул. Понтия Пилата, д.1", PhoneNumber = "892786321", FormOfOwnership = "Частная", NumberOfWorkers = 70, TotalSquare =  400,Shipments = new List<Shipment> { _shipments[2]} },
            new Fabric{Id = 4, Type = "Строительство", Name =  "Гвозди и молотки", Address = "г. Нефтегорск, Ул. Тургенева, д.13", PhoneNumber = "89378123455", FormOfOwnership = "Акционерная", NumberOfWorkers = 60, TotalSquare =  150,Shipments = new List<Shipment> { _shipments[3], _shipments[5] } }
        };

        _providers = new List<Provider>
        {
             new Provider{Id = 1, TypeOfGoods = "Детали для станков", Name = "Детали для всех", Address = "г. Самара, ул. Антова-Овсеенко, д. 4", Shipments = new List<Shipment>() { _shipments[0] } },
             new Provider{Id = 2, TypeOfGoods = "Овощи и фрукты", Name = "Дары природы", Address = "г. Нефтегорск, ул. Авроры, д. 7", Shipments = new List<Shipment>() { _shipments[1], _shipments[5] } },
             new Provider{Id = 3, TypeOfGoods =  "Запчасти для машин", Name = "Грузовичок", Address = "г. Чапаевск, ул. Колмогорова, д. 5", Shipments = new List<Shipment>() { _shipments[2] } },
             new Provider{Id = 4, TypeOfGoods = "Еда", Name = "Крошка картошка", Address =  "г. Самара, ул. Авроры, д. 113", Shipments = new List<Shipment>() { _shipments[3], _shipments[4] } }
        };
    }

    public List<Fabric> Fabrics => _fabrics;

    public List<Provider> Providers => _providers;

    public List<Shipment> Shipments => _shipments;
}

