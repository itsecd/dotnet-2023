using Factory.Domain;
using System.Data.Common;

namespace Factory.Server;

public class FactoryRepository
{
    private readonly List<TypeIndustry> _industryTypes;

    private readonly List<OwnershipForm> _ownershipForms;

    private readonly List<Supply> _supplies;

    private readonly List<Enterprise> _enterprises;

    private readonly List<Supplier> _suppliers;

    public FactoryRepository()
    {
        _industryTypes = new List<TypeIndustry>
        {
            new TypeIndustry(1, "Cельское хозяйство"),
            new TypeIndustry(2, "Транспорт"),
            new TypeIndustry(3, "Легкая промышленность"),
            new TypeIndustry(4, "Тяжелая промышленность"),
            new TypeIndustry(5, "Строительство"),
            new TypeIndustry(6, "Материально - техническое снабжение")
        };

       _ownershipForms =  new List<OwnershipForm>
        {
            new OwnershipForm(1, "ЗАО"),
            new OwnershipForm(2, "ООО"),
            new OwnershipForm(3, "АО"),
            new OwnershipForm(4, "ОАО")
        };

       _supplies = new List<Supply>
        {
            new Supply(1, 1, 1, "20.01.2023", 3), // СТАН - Артур
            new Supply(2, 1, 2, "31.10.2022", 5), // СТАН - Чендлер
            new Supply(3, 3, 3, "14.08.2022", 1), // ВЗМК -Барни
            new Supply(4, 4, 4, "05.02.2023", 10), // АВИАКОР - Джон
            new Supply(5, 2, 5, "27.02.2023", 6), // ЗГМ - Райан
            new Supply(6, 5, 5, "13.01.2023", 2), // ЭКРАН - Райан
            new Supply(7, 4, 3, "04.01.2023", 12), // АВИАКОР - Барни
            new Supply(8, 2, 2, "09.12.2022", 4) // ЗГМ - Чендлер
        };

        _enterprises = new List<Enterprise>
        { 
            new Enterprise(1, "1036300446093", 6, "СТАН", "ул.22 партъезда д.7а", "88469926984", 1, 100, 1000, new List<Supply>(){_supplies[0], _supplies[1] }),
            new Enterprise(2, "1156313028981", 6, "ЗГМ", "ул.22 партъезда д.10а", "88462295931", 2, 150, 1500, new List<Supply>(){ _supplies[4], _supplies[7] }),
            new Enterprise(3, "1116318009510", 4, "ВЗМК", "ул.Балаковская д.6а", "884692007711", 2, 200, 2000, new List<Supply>(){ _supplies[2] }),
            new Enterprise(4, "1026300767899", 2, "АВИАКОР", "ул.Земеца д.32", "88463720888", 3, 250, 2500, new List < Supply >() { _supplies[3], _supplies[6] }),
            new Enterprise(5, "1026301697487", 6, "ЭКРАН", "ул.Кирова д.24", "88469983785", 4, 130, 1300, new List < Supply >() { _supplies[5]}),
        };
        
        _suppliers = new List<Supplier>
        {
            new Supplier(1, "Артур Пирожков", "ул. Зацепильная д.42", "89375550203", new List<Supply>(){ _supplies[0]}),
            new Supplier(2, "Чендлер Бинг", "ул. Центральная д.1", "89370101010", new List<Supply>(){ _supplies[1], _supplies[7] }),
            new Supplier(3, "Барни Стинсон", "ул. Приоденься д.50", "89376431289", new List<Supply>(){ _supplies[2], _supplies[6] }),
            new Supplier(4, "Джон Сноу", "ул. Таргариенская д.35", "89372229978", new List<Supply>(){ _supplies[3] }),
            new Supplier(5, "Райан Гослинг", "ул. Лалаленд д.14", "89371234567", new List<Supply>(){ _supplies[4], _supplies[5] })
        };

    }
    public List<TypeIndustry> IndustryTypes => _industryTypes;
    public List<OwnershipForm> OwnershipForms => _ownershipForms;   
    public List<Supply> Supplies => _supplies;
    public List<Enterprise> Enterprises => _enterprises;    
    public List<Supplier> Suppliers => _suppliers;

}
