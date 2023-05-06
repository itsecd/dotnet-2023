using Warehouse.Domain;

namespace Warehouse.Test;

public class WarehouseFixture
{
    public List<Products> ProductsFixture
    {
        get
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

            firstRoute.Products.Add(firstProduction);
            secondRoute.Products.Add(fourthProduction);
            thirdRoute.Products.Add(fifthProduction);
            fourthRoute.Products.Add(thirdProduction);

            var products = new List<Products>
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

            return products;
        }
    }
}