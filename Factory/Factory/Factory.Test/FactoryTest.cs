using Factory.Domain;
using System.Drawing;
using System.Globalization;

namespace Factory.Test;

public class FactoryTest
{
    /// <summary>
    /// Creating a list of factories
    /// </summary>
    /// <returns></returns>
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

    /// <summary>
    /// Creating a list of suppliers
    /// </summary>
    /// <returns></returns>
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

    /// <summary>
    /// Creating a list of supplies
    /// </summary>
    /// <returns></returns>
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

    /// <summary>
    /// Creating a list of managements
    /// </summary>
    /// <returns></returns>
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

    /// <summary>
    /// Selecting information about some factory
    /// </summary>
    [Fact]
    public void RequestTest1()
    {
        var factories = CreateFactory();
        var result = from e in factories
                     where e.RegistrationNumber == "1116318009510"
                     select e;

        Assert.NotNull(result);
        Assert.Single(result);
        Assert.Contains(result, x => x.Address == "ул.Балаковская д.6а" && x.OwnershipForm == "ООО");
    }

    /// <summary>
    /// Selecting all suppliers who made supplies from 01.01.2023 to 30.01.2023
    /// </summary>
    [Fact]
    public void RequestTest2()
    {
        var suppliers = CreateSupplier();
        var supplies = CreateSupply();
        var result = from sr in suppliers
                     join s in supplies on sr.Phone equals s.SupplierNumber
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

    /// <summary>
    /// Selecting count of factories working with supplier
    /// </summary>
    [Fact]
    public void RequestTest3()
    {
        var management = CreateManagement();
        var result = from m in management
                     from s in m.Suppliers
                     group m by s.Name into supplierGroup
                     select new { SupplierName = supplierGroup.Key, FactoryCount = supplierGroup.Select(m => m.Factory).Distinct().Count() };

        // Assert
        var supplier1 = result.FirstOrDefault(s => s.SupplierName == "Артур Пирожков");
        Assert.NotNull(supplier1);
        Assert.Equal(1, supplier1.FactoryCount);

        var supplier2 = result.FirstOrDefault(s => s.SupplierName == "Чендлер Бинг");
        Assert.NotNull(supplier2);
        Assert.Equal(2, supplier2.FactoryCount);

        var supplier3 = result.FirstOrDefault(s => s.SupplierName == "Барни Стинсон");
        Assert.NotNull(supplier3);
        Assert.Equal(2, supplier3.FactoryCount);

        var supplier4 = result.FirstOrDefault(s => s.SupplierName == "Джон Сноу");
        Assert.NotNull(supplier4);
        Assert.Equal(1, supplier4.FactoryCount);

        var supplier5 = result.FirstOrDefault(s => s.SupplierName == "Райан Гослинг");
        Assert.NotNull(supplier5);
        Assert.Equal(2, supplier5.FactoryCount);
    }

    /// <summary>
    /// Selecting count od suppliers for every type and ownership
    /// </summary>
    [Fact]
    public void RequestTest4()
    {
        var management = CreateManagement();

        var expected = new List<object>()
    {
        new { IndustryType = "Материально-техническое снабжение", SupplierCount = 5 },
        new { IndustryType = "Тяжелая промышленность", SupplierCount = 1 },
        new { IndustryType = "Транспорт", SupplierCount = 2 },
    };

        var result = from m in management
                     group m by m.Factory.Type into g
                     select new
                     {
                         IndustryType = g.Key,
                         SupplierCount = g.Sum(m => m.Suppliers.Count)
                     };

        Assert.Equal(result, expected);

        var expected2 = new List<object>()
    {
        new { IndustryForm = "ЗАО", SupplierCount = 2 },
        new { IndustryForm = "ООО", SupplierCount = 3 },
        new { IndustryForm = "АО", SupplierCount = 2 },
        new { IndustryForm = "ОАО", SupplierCount = 1 }
    };

        var result2 = from m in management
                      group m by m.Factory.OwnershipForm into g
                      select new
                      {
                          IndustryForm = g.Key,
                          SupplierCount = g.Sum(m => m.Suppliers.Count)
                      };

        Assert.Equal(result2, expected2);
    }

    /// <summary>
    /// Selecting top-5 factories by supply count 
    /// </summary>
    [Fact]
    public void RequestTest5()
    {
        var management = CreateManagement();
        
        var result = (from m in management
                            orderby m.Supplies.Count() descending
                            select m.Factory).Take(5).ToList();
        
        Assert.Equal("СТАН", result[0].Name);
        Assert.Equal("ЗГМ", result[1].Name);
        Assert.Equal("АВИАКОР", result[2].Name);
        Assert.Equal("ВЗМК", result[3].Name);
        Assert.Equal("ЭКРАН", result[4].Name);
    }

    /// <summary>
    /// Selecting supplier who delivered max quantity 
    /// of goods from 01.01.2023 to 01.03.2023
    /// </summary>
    [Fact]
    public void RequestTest6()
    { 
        var suppliers = CreateSupplier();
        var supplies = CreateSupply();

          var result = (from sr in suppliers
                       join s in supplies on sr.Phone equals s.SupplierNumber
                       where s.Date > new DateTime(2023, 1, 1) && s.Date < new DateTime(2023, 1, 30)
                       orderby s.Quantity descending
                       select new { sr.Name, sr.Address, sr.Phone }).ToList()[0];
 
        Assert.Equal("Барни Стинсон", result.Name);
        Assert.Equal("ул. Приоденься д.50", result.Address);
        Assert.Equal("89376431289", result.Phone);
    }

    /// <summary>
    /// Enterprise constructor with parameters test
    /// </summary>
    [Fact]
    public void EnterpriseConstructorTest() 
    {
        var enterprise = new Enterprise("1036300446093", "Материально-техническое снабжение", "СТАН", "ул.22 партъезда д.7а", "88469926984", "ЗАО", 100, 1000);
        Assert.Equal("1036300446093", enterprise.RegistrationNumber);
        Assert.Equal("Материально-техническое снабжение", enterprise.Type);
        Assert.Equal("СТАН", enterprise.Name);
        Assert.Equal("ул.22 партъезда д.7а", enterprise.Address);
        Assert.Equal("88469926984", enterprise.TelephoneNumber);
        Assert.Equal("ЗАО", enterprise.OwnershipForm);
        Assert.Equal(100, enterprise.EmployeesCount);
        Assert.Equal(1000, enterprise.TotalArea);
    }

    /// <summary>
    /// Supplier constructor with parameters test
    /// </summary>
    [Fact]
    public void SupplierConstructorTest()
    {
        var supplier = new Supplier("Джон Сноу", "ул. Таргариенская д.35", "89372229978");
        Assert.Equal("Джон Сноу", supplier.Name);
        Assert.Equal("ул. Таргариенская д.35", supplier.Address);
        Assert.Equal("89372229978", supplier.Phone);
    }

    /// <summary>
    /// Supply constructor with parameters test
    /// </summary>
    [Fact]
    public void SupplyConstructorTest()
    {
        var supply = new Supply("20.01.2023", 3, "89375550203");
        Assert.Equal(DateTime.Parse("20.01.2023"), supply.Date);
        Assert.Equal(3, supply.Quantity);
        Assert.Equal("89375550203", supply.SupplierNumber);
    }

    /// <summary>
    /// Management constructor with parameters test
    /// </summary>
    [Fact]
    public void ManagmentConstructorTest()
    {
        var enterprise = new Enterprise("1036300446093", "Материально-техническое снабжение", "СТАН", "ул.22 партъезда д.7а", "88469926984", "ЗАО", 100, 1000);
        var supplier = new Supplier("Джон Сноу", "ул. Таргариенская д.35", "89372229978");
        var supply = new Supply("20.01.2023", 3, "89375550203");

        var management = new Management(enterprise, new List<Supplier>() { supplier }, new List<Supply>() { supply });

        Assert.Equal(enterprise, management.Factory);
        Assert.Equal(new List<Supplier>(){supplier }, management.Suppliers);
        Assert.Equal(new List<Supply>() { supply }, management.Supplies);

    }

    /// <summary>
    /// Enterprise default constructor test
    /// </summary>
    [Fact]
    public void EDefaultConstructorTest()
    {
        var enterprise = new Enterprise(); 
        Assert.Equal(string.Empty, enterprise.RegistrationNumber);
        Assert.Equal(string.Empty, enterprise.Type);
        Assert.Equal(string.Empty, enterprise.Name);
        Assert.Equal(string.Empty, enterprise.Address);
        Assert.Equal(string.Empty, enterprise.TelephoneNumber);
        Assert.Equal(string.Empty, enterprise.OwnershipForm);
        Assert.Equal(0, enterprise.EmployeesCount);
        Assert.Equal(0, enterprise.TotalArea);
    }

    /// <summary>
    /// Supplier default constructor test
    /// </summary>
    [Fact]
    public void SRDefaultConstructorTest()
    {
        var supplier = new Supplier();
        Assert.Equal(string.Empty, supplier.Name);
        Assert.Equal(string.Empty, supplier.Address);
        Assert.Equal(string.Empty, supplier.Phone);
    }

    /// <summary>
    /// Supply default constructor test
    /// </summary>
    [Fact]
    public void SDefaultConstructorTest()
    {
        var supply = new Supply();
        Assert.Equal(new DateTime(1970, 1, 1), supply.Date);
        Assert.Equal(string.Empty, supply.SupplierNumber);
        Assert.Equal(0, supply.Quantity);
    }

}
