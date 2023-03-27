namespace Fabric.Test;

using Fabric.Domain;
using System.Collections.Generic;
public class FabricFixture
{
    public List<Fabric> FixtureFabrics
    {
        get
        {
            var shipments = FixtureShipments;
            var fabrics = new List<Fabric>();
            var firstFabric = new Fabric(1, "Сельское хозяйство", "Спелые фрукты", "г. Нефтегорск, Ул. Пушкина, д.34", "89378533145", "ТОО", 15, 75, new List<Shipment>() { shipments[0], shipments[4] });
            fabrics.Add(firstFabric);
            var secondFabric = new Fabric(2, "Транспорт", "Веселый таксист", "г. Самара, Ул. Дыбенко, д.30", "89371532175", "Муниципально-городская", 30, 50, new List<Shipment>() { shipments[1] });
            fabrics.Add(secondFabric);
            var thirdFabric = new Fabric(3, "Легкая и тяжелая промышленность", "Тяжелая легкость", "г. Самара, Ул. Понтия Пилата, д.1", "89278632157", "Частная", 70, 400, new List<Shipment>() { shipments[2] });
            fabrics.Add(thirdFabric);
            var fourthFabric = new Fabric(4, "Строительство", "Гвозди и молотки", "г. Нефтегорск, Ул. Тургенева, д.13", "89378123455", "Акционерная", 60, 150, new List<Shipment>() { shipments[3], shipments[5] });
            fabrics.Add(fourthFabric);
            return fabrics;
        }
    }
    public List<Provider> FixtureProviders
    {
        get
        {
            var shipments = FixtureShipments;
            var providers = new List<Provider>();
            var firstProvider = new Provider(1, "Детали для станков", "Детали для всех", "г. Самара, ул. Антова-Овсеенко, д. 4", new List<Shipment>() { shipments[0] });
            providers.Add(firstProvider);
            var secondProvider = new Provider(2, "Овощи и фрукты", "Дары природы", "г. Нефтегорск, ул. Авроры, д. 7", new List<Shipment>() { shipments[1], shipments[5] });
            providers.Add(secondProvider);
            var thirdProvider = new Provider(3, "Запчасти для машин", "Грузовичок", "г. Чапаевск, ул. Колмогорова, д. 5", new List<Shipment>() { shipments[2] });
            providers.Add(thirdProvider);
            var fourthProvider = new Provider(4, "Еда", "Крошка картошка", "г. Самара, ул. Авроры, д. 113", new List<Shipment>() { shipments[3], shipments[4] });
            providers.Add(fourthProvider);
            return providers;
        }
    }
    public List<Shipment> FixtureShipments
    {
        get
        {
            var shipments = new List<Shipment>();
            var firstDate = new DateTime(2022, 6, 11);
            var firstShipment = new Shipment(1, 1, 1, firstDate, 15);
            shipments.Add(firstShipment);
            var secondDate = new DateTime(2022, 7, 13);
            var secondShipment = new Shipment(2, 2, 2, secondDate, 15);
            shipments.Add(secondShipment);
            var thirdDate = new DateTime(2022, 8, 13);
            var thirdShipment = new Shipment(3, 3, 3, thirdDate, 11);
            shipments.Add(thirdShipment);
            var fourthDate = new DateTime(2022, 11, 11);
            var fourthShipment = new Shipment(4, 4, 4, fourthDate, 5);
            shipments.Add(fourthShipment);
            var fifthDate = new DateTime(2022, 3, 3);
            var fifthShipment = new Shipment(5, 1, 4, fifthDate, 4);
            shipments.Add(fifthShipment);
            var sixthDate = new DateTime(2022, 12, 13);
            var sixthShipment = new Shipment(6, 4, 2, sixthDate, 7);
            shipments.Add(sixthShipment);
            return shipments;
        }
    }
}
