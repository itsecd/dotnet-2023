namespace WarehouseTest;

using Warehouse;

public class WarehouseFixture
{
    public List<Goods> GoodsFixture
    {
        get
        {
            return new List<Goods> {
                new Goods (103722, "Контейнер 640мл с крышкой", 100, 1),
                new Goods (164302, "Картонная коробка 60*40*50", 50, 2),
                new Goods (106932, "Пищевая плёнка для упаковки 5м", 5, 3),
                new Goods (218302, "Гипсовая штукатурка 5кг", 10, 4),
                new Goods (319510, "Столовая ложка из нерж. стали", 35, 10),
                new Goods (312510, "Чайная ложка из нерж. стали", 50, 10),
                new Goods (320513, "Вилка из нерж. стали", 25, 10),
                new Goods (161708, "Ваза из стекла 4л", 10, 15),
                new Goods (103410, "Ваза из стекла 3л", 15, 15)
            };
        }
    }

    public List<CompanyWarehouse> WarehouseCellsFixture
    {
        get
        {
            return new List<CompanyWarehouse>
            {
                new CompanyWarehouse (1, 103722),
                new CompanyWarehouse (2, 164302),
                new CompanyWarehouse (3, 106932),
                new CompanyWarehouse (4, 218302),
                new CompanyWarehouse (10, 319510),
                new CompanyWarehouse (10, 312510),
                new CompanyWarehouse (10, 312510),
                new CompanyWarehouse (15, 161708),
                new CompanyWarehouse (15, 103410)

            };
        }
    }

    public List<Supply> SupplyFixture
    {
        get
        {
            return new List<Supply>
            {
                new Supply (103722, "СамараПласт", "г. Самара, ул. Луцкая, 16.", new DateOnly(2023, 02, 20), 10),
                new Supply (218302, "Самара Строй Комплект", "г. Самара, ул. Олимпийская, 73а.", new DateOnly(2023, 03, 01), 5),
                new Supply (312510, "Fix Price", "г. Самара, ул. Спортивная, 20.", new DateOnly(2023, 02, 11), 10),
                new Supply (106932, "Fix Price", "г. Самара, ул. Спортивная, 20.", new DateOnly(2023, 01, 23), 10)
            };
        }
    }
}