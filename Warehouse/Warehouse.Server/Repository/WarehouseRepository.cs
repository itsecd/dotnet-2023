using System.Net.Sockets;
using Warehouse.Domain;
namespace Warehouse.Server.Repository;

public class WarehouseRepository : IWarehouseRepository
{
    private readonly List<Goods> _goods;
    private readonly List<Supply> _supply;
    private readonly List<WarehouseCells> _cells;
    public WarehouseRepository()
    {
        var firstRoute = new Supply(1, "СамараПласт", "г. Самара, ул. Луцкая, 16.", new DateTime(2023, 02, 20), 10);
        var secondRoute = new Supply(2, "Самара Строй Комплект", "г. Самара, ул. Олимпийская, 73а.", new DateTime(2023, 03, 01), 5);
        var thirdRoute = new Supply(3, "Fix Price", "г. Самара, ул. Спортивная, 20.", new DateTime(2023, 02, 11), 10);
        var fourthRoute = new Supply(4, "Fix Price", "г. Самара, ул. Спортивная, 20.", new DateTime(2023, 02, 11), 10);

        var firstProduction = new Goods(103722, "Контейнер 640мл с крышкой", 100);
        var secondProduction = new Goods(164302, "Картонная коробка 60*40*50", 50);
        var thirdProduction = new Goods(106932, "Пищевая плёнка для упаковки 5м", 5);
        var fourthProduction = new Goods(218302, "Гипсовая штукатурка 5кг", 10);
        var fifthProduction = new Goods(319510, "Столовая ложка из нерж. стали", 35);
        var sixthProduction = new Goods(320513, "Вилка из нерж. стали", 25);
        var seventhProduction = new Goods(161708, "Ваза из стекла 4л", 10);
        var eighthProduction = new Goods(103410, "Ваза из стекла 3л", 15);

        firstProduction.WarehouseCell.Add(new WarehouseCells(1, firstProduction));
        secondProduction.WarehouseCell.Add(new WarehouseCells(2, secondProduction));
        thirdProduction.WarehouseCell.Add(new WarehouseCells(3, thirdProduction));
        fourthProduction.WarehouseCell.Add(new WarehouseCells(4, fourthProduction));
        fourthProduction.WarehouseCell.Add(new WarehouseCells(10, fourthProduction));
        fourthProduction.WarehouseCell.Add(new WarehouseCells(11, fourthProduction));
        fifthProduction.WarehouseCell.Add(new WarehouseCells(5, fifthProduction));
        sixthProduction.WarehouseCell.Add(new WarehouseCells(6, sixthProduction));
        seventhProduction.WarehouseCell.Add(new WarehouseCells(7, seventhProduction));
        eighthProduction.WarehouseCell.Add(new WarehouseCells(8, eighthProduction));
        eighthProduction.WarehouseCell.Add(new WarehouseCells(9, eighthProduction));

        firstProduction.Supply.Add(firstRoute);
        thirdProduction.Supply.Add(fourthRoute);
        fourthProduction.Supply.Add(secondRoute);
        fifthProduction.Supply.Add(thirdRoute);

        firstRoute.Goods.Add(firstProduction);
        secondRoute.Goods.Add(fourthProduction);
        thirdRoute.Goods.Add(fifthProduction);
        fourthRoute.Goods.Add(thirdProduction);

        var goods = new List<Goods>
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
    }
    public List<Goods> Goods => _goods;
    public List<WarehouseCells> WarehouseCells => _cells;
    public List<Supply> Supply => _supply;
}
