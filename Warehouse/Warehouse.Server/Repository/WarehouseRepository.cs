using Warehouse.Domain;

namespace Warehouse.Server.Repository;

public class WarehouseRepository : IWarehouseRepository
{
    private readonly List<Products> _goods;
    private readonly List<Supplies> _supply;
    private readonly List<WarehouseCells> _cells;

    public WarehouseRepository()
    {
        var firstRoute = new Supplies(1, "СамараПласт", "г. Самара, ул. Луцкая, 16.", new DateTime(2023, 02, 20), 10);
        var secondRoute = new Supplies(2, "Самара Строй Комплект", "г. Самара, ул. Олимпийская, 73а.", new DateTime(2023, 03, 01), 5);
        var thirdRoute = new Supplies(3, "Fix Price", "г. Самара, ул. Спортивная, 20.", new DateTime(2023, 02, 11), 10);
        var fourthRoute = new Supplies(4, "Fix Price", "г. Самара, ул. Спортивная, 20.", new DateTime(2023, 02, 11), 10);

        var firstProduction = new Products(103722, "Контейнер 640мл с крышкой", 100);
        var secondProduction = new Products(164302, "Картонная коробка 60*40*50", 50);
        var thirdProduction = new Products(106932, "Пищевая плёнка для упаковки 5м", 5);
        var fourthProduction = new Products(218302, "Гипсовая штукатурка 5кг", 10);
        var fifthProduction = new Products(319510, "Столовая ложка из нерж. стали", 35);
        var sixthProduction = new Products(320513, "Вилка из нерж. стали", 25);
        var seventhProduction = new Products(161708, "Ваза из стекла 4л", 10);
        var eighthProduction = new Products(103410, "Ваза из стекла 3л", 15);

        var firstCell = new WarehouseCells(1, firstProduction);
        var secondCell = new WarehouseCells(2, secondProduction);
        var thirdCell = new WarehouseCells(3, thirdProduction);
        var fourthCell = new WarehouseCells(4, fourthProduction);
        var fifthCell = new WarehouseCells(5, fifthProduction);
        var sixthCell = new WarehouseCells(6, sixthProduction);
        var seventhCell = new WarehouseCells(7, seventhProduction);
        var eighthCell = new WarehouseCells(8, eighthProduction);
        var ninthCell = new WarehouseCells(9, eighthProduction);
        var tenthCell = new WarehouseCells(10, fourthProduction);
        var eleventhCell = new WarehouseCells(11, fourthProduction);

        firstProduction.WarehouseCell.Add(firstCell);
        secondProduction.WarehouseCell.Add(secondCell);
        thirdProduction.WarehouseCell.Add(thirdCell);
        fourthProduction.WarehouseCell.Add(fourthCell);
        fourthProduction.WarehouseCell.Add(tenthCell);
        fourthProduction.WarehouseCell.Add(eleventhCell);
        fifthProduction.WarehouseCell.Add(fifthCell);
        sixthProduction.WarehouseCell.Add(sixthCell);
        seventhProduction.WarehouseCell.Add(seventhCell);
        eighthProduction.WarehouseCell.Add(eighthCell);
        eighthProduction.WarehouseCell.Add(ninthCell);

        firstProduction.Supply.Add(firstRoute);
        thirdProduction.Supply.Add(fourthRoute);
        fourthProduction.Supply.Add(secondRoute);
        fifthProduction.Supply.Add(thirdRoute);

        firstRoute.Products.Add(firstProduction);
        secondRoute.Products.Add(fourthProduction);
        thirdRoute.Products.Add(fifthProduction);
        fourthRoute.Products.Add(thirdProduction);

        _goods = new List<Products>
            {
                firstProduction,
                secondProduction,
                thirdProduction,
                fourthProduction,
                fifthProduction,
                sixthProduction,
                seventhProduction,
                eighthProduction
            };

        _supply = new List<Supplies>
            {
                firstRoute,
                secondRoute,
                thirdRoute,
                fourthRoute
            };

        _cells = new List<WarehouseCells>
            {
                firstCell,
                secondCell,
                thirdCell,
                fourthCell,
                fifthCell,
                sixthCell,
                seventhCell,
                eighthCell,
                ninthCell,
                tenthCell,
                eleventhCell
        };
    }

    public List<Products> Products => _goods;
    public List<WarehouseCells> Cells => _cells;
    public List<Supplies> Supplies => _supply;
}
