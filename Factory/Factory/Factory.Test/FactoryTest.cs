using Factory.Domain;
using System.Drawing;

namespace Factory.Test;

public class FactoryTest
{
    private List<Enterprise> CreateFactory()
    {
        return new List<Enterprise>()
        {
            new Enterprise("1036300446093", "Материально-техническое снабжение", "СТАН", "ул.22 партъезда д.7а", "88469926984", "ЗАО", 100, 1000),
            new Enterprise("1156313028981", "Материально-техническое снабжение", "ЗГМ", "ул.22 партъезда д.10а", "88462295931", "ООО", 150, 1500),
            new Enterprise("1116318009510", "Тяжелая промышленность", "ВЗМК", "ул.Балаковская д.6а", "884692007711", "ООО", 200, 2000),
            new Enterprise("1026300767899", "Транспорт", "АВИАКОР", "ул.Земеца д.32", "88463720888", "АО", 250, 2500),
            new Enterprise("1026301697487", "Материально-техническое снабжение", "ЭКРАН", "ул.Кирова д.24", "88469983785", "ОАО", 130, 1300),
        };
    }

    private List<Supplier> CreateSupplier()
    {
        return new List<Supplier>()
        {
            new Supplier("Артур Пирожков", "ул. Зацепильная д.42", "89375550203"),
            new Supplier("Чендлер Бинг", "ул. Центральная д.1", "89370101010"),
            new Supplier("Барни Стинсон", "ул. Приоденься д.50", "89376431289"),
            new Supplier("Джон Сноу", "ул. Таргариенская д.35", "89372229978"),
            new Supplier("Райан Гослинг", "ул. Лалаленд д.14", "89371234567")
        };
    }
    private List<Supply> CreateSupply()
    {
        return new List<Supply>()
        {
            new Supply("20.01.2023", 3, "89375550203"),
            new Supply("31.10.2022", 5, "89370101010"),
            new Supply("14.08.2022", 1, "89376431289"),
            new Supply("05.02.2023", 10, "89372229978"),
            new Supply("27.02.2023", 6, "89371234567"),
            new Supply("13.01.2023", 2, "89371234567"),
            new Supply("04.01.2023", 12, "89376431289"),
            new Supply("09.12.2022", 4, "89370101010")
        };
    }
    private List<Management> CreateManagement() 
    {
        var factory = CreateFactory();
        var suppliers = CreateSupplier();
        var supplies = CreateSupply();
        return new List<Management>()
        {
            new Management(factory[0], new List<Supplier>(){suppliers[0], suppliers[1] }, new List<Supply>(){supplies[0], supplies[1] }),
            new Management(factory[1], new List<Supplier>(){suppliers[1], suppliers[4] }, new List<Supply>(){supplies[7], supplies[4] }),
            new Management(factory[2], new List<Supplier>(){suppliers[2] }, new List<Supply>(){supplies[2] }),
            new Management(factory[3], new List<Supplier>(){suppliers[3], suppliers[2] }, new List<Supply>(){supplies[3], supplies[6] }),
            new Management(factory[4], new List<Supplier>(){suppliers[4] }, new List<Supply>(){supplies[5] }),
        };
    }
        [Fact]
    public void RequestTest1()
    {   
        var factories = CreateFactory();
        var result = from e in factories
                     where e.RegistrationNumber == "1116318009510"
                     select e;

        Assert.NotNull(result);
        Assert.Equal(1, result.Count());
        Assert.Contains(result, x => x.Address == "ул.Балаковская д.6а" && x.OwnershipForm == "ООО"); 
    }

    [Fact]
    public void RequestTest2()
    {
        var suppliers = CreateSupplier();
        var supplies = CreateSupply();
        var result = from sr in suppliers
                     join s in supplies on sr.Phone equals s.SuplierNumber
                     where s.Date > new DateTime(2023, 1, 1) && s.Date < new DateTime(2023, 1, 30)
                     orderby sr.Name 
                     select sr;

        Assert.Equal(3, result.Count());
        Assert.Contains(result, x => x.Name == "Артур Пирожков");
        Assert.Contains(result, x => x.Name == "Барни Стинсон");
        Assert.Contains(result, x => x.Name == "Райан Гослинг");
        Assert.DoesNotContain(result, x => x.Name == "Джон Сноу");
        Assert.DoesNotContain(result, x => x.Name == "Чендлер Бинг");
    }
/*
    [Fact] 
    public void RequestTest3() 
    {
        var managment = CreateManagement();
        var suppliers = CreateSupplier();
        var supplies = CreateSupply();

    }
*/
}