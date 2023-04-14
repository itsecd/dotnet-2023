using System.Security.Cryptography.X509Certificates;

namespace PharmacyCityNetwork.Tests;

public class PharmacyCityNetworkFixture
{
    private readonly List<Group> _groups;
    private readonly List<Manufacturer> _manufacturers;
    private readonly List<Pharmacy> _pharmacys;
    private readonly List<PharmaGroup> _pharmaGroups;
    private readonly List<Product> _products;
    private readonly List<ProductPharmacy> _productPharmacys;
    private readonly List<ProductPharmaGroup> _productPharmaGroups;
    private readonly List<Sale> _sales;
    public PharmacyCityNetworkFixture()
    {
        
            var firstGroup = new Group("Syrup", 1);
            var secondGroup = new Group("Pill", 2);
            var thridGroup = new Group("Injection", 3);

            var firstManufacturer = new Manufacturer("Novartis", 1);
            var secondManufacturer = new Manufacturer("Merck", 2);

            var firstPharmaGroup = new PharmaGroup("Adrenolytic", 1);
            var secondPharmaGroup = new PharmaGroup("Hematotropic", 2);
            var thridPharmaGroup = new PharmaGroup("Homeopathic", 3);
            var fourthPharmaGroup = new PharmaGroup("Interviewers", 4);


            var firstPharmacy = new Pharmacy("Vita", "8899606", "Pushkina, 7", "Yablokov");
            var secondPharmacy = new Pharmacy("Plus", "8844606", "Turgeneva, 8", "Pomelov");
            var thridPharmacy = new Pharmacy("Alia", "4499606", "Tolstogo, 8", "Slivin");
            var fourthPharmacy = new Pharmacy("Apteka63", "4558602", "Polevay, 23", "Chikarev");
            var fifthPharmacy = new Pharmacy("Vita", "9229303", "Gagarina, 67", "Parshin");

        ///1 продукт 
            var firstProduct = new Product("Paracetamol", 1, firstGroup, firstManufacturer);
            var firstProductPharmacy = new ProductPharmacy(1, 300, firstProduct, firstPharmacy);
            firstProduct.ProductPharmacy.Add(firstProductPharmacy);
            firstPharmacy.ProductPharmacy.Add(firstProductPharmacy);

            var firstProductPharmaGroup = new ProductPharmaGroup(1, firstPharmaGroup, firstProduct);
            firstProduct.ProductPharmaGroup.Add(firstProductPharmaGroup);
            firstPharmaGroup.ProductPharmaGroup.Add(firstProductPharmaGroup);

           
            firstGroup.Product.Add(firstProduct);

            firstManufacturer.Product.Add(firstProduct);


            var firstSale = new Sale("Online", new DateTime(2023, 1, 28), firstProduct);
            firstProduct.Sales.Add(firstSale);


            ///2 продукт
            var secondProduct = new Product("Espumizan", 2, secondGroup, secondManufacturer);
            var secondProductPharmacy = new ProductPharmacy(2, 250, secondProduct, firstPharmacy);
            secondProduct.ProductPharmacy.Add(secondProductPharmacy);
            firstPharmacy.ProductPharmacy.Add(secondProductPharmacy);

            var secondProductPharmaGroup = new ProductPharmaGroup(1, secondPharmaGroup, secondProduct);
            secondProduct.ProductPharmaGroup.Add(secondProductPharmaGroup);
            firstPharmaGroup.ProductPharmaGroup.Add(secondProductPharmaGroup);

            secondGroup.Product.Add(secondProduct);

            secondManufacturer.Product.Add(secondProduct);

            var secondSale = new Sale("Cash", new DateTime(2023, 4, 14), secondProduct);
            secondProduct.Sales.Add(secondSale);


            /////3 продукт
            var thridProduct = new Product("Noshpa", 3, thridGroup, secondManufacturer);
            var thridProductPharmacy = new ProductPharmacy(3, 200, thridProduct, thridPharmacy);
            thridProduct.ProductPharmacy.Add(thridProductPharmacy);
            thridPharmacy.ProductPharmacy.Add(thridProductPharmacy);

        var sixthProductPharmacy = new ProductPharmacy(4, 180, thridProduct, secondPharmacy);
        thridProduct.ProductPharmacy.Add(sixthProductPharmacy);
        secondPharmacy.ProductPharmacy.Add(sixthProductPharmacy);

            var thridProductPharmaGroup = new ProductPharmaGroup(1, thridPharmaGroup, thridProduct);
            thridProduct.ProductPharmaGroup.Add(thridProductPharmaGroup);
            thridPharmaGroup.ProductPharmaGroup.Add(thridProductPharmaGroup);

            thridGroup.Product.Add(thridProduct);

            secondManufacturer.Product.Add(thridProduct);

            var thridSale = new Sale("Online", new DateTime(2023, 3, 20), thridProduct);
            thridProduct.Sales.Add(thridSale);

        var sixthSale = new Sale("Online", new DateTime(2023, 3, 20), thridProduct);
        thridProduct.Sales.Add(sixthSale);

        /////4 продукт
        var fourthProduct = new Product("Analgin", 3, thridGroup, firstManufacturer);
            var fourthProductPharmacy = new ProductPharmacy(4, 135, fourthProduct, secondPharmacy);
            fourthProduct.ProductPharmacy.Add(fourthProductPharmacy);
            fourthProduct.ProductPharmacy.Add(fourthProductPharmacy);

            var fourthProductPharmaGroup = new ProductPharmaGroup(1, fourthPharmaGroup, fourthProduct);
            fourthProduct.ProductPharmaGroup.Add(fourthProductPharmaGroup);
            fourthPharmaGroup.ProductPharmaGroup.Add(fourthProductPharmaGroup);

            thridGroup.Product.Add(fourthProduct);

            firstManufacturer.Product.Add(fourthProduct);

            var fourthSale = new Sale("Online", new DateTime(2022, 11, 18), fourthProduct);
            fourthProduct.Sales.Add(fourthSale);

        ///5 продукт
            var fifthProduct = new Product("Nekst", 1, firstGroup, firstManufacturer);
            var fifthProductPharmacy = new ProductPharmacy(10, 350, fifthProduct, fourthPharmacy);
            fifthProduct.ProductPharmacy.Add(fifthProductPharmacy);
            fifthPharmacy.ProductPharmacy.Add(fifthProductPharmacy);

            var fifthProductPharmaGroup = new ProductPharmaGroup(1, firstPharmaGroup, fifthProduct);
            fifthProduct.ProductPharmaGroup.Add(fifthProductPharmaGroup);
            firstPharmaGroup.ProductPharmaGroup.Add(fifthProductPharmaGroup);


            firstGroup.Product.Add(fifthProduct);

            firstManufacturer.Product.Add(fifthProduct);


            var fifthSale = new Sale("Online", new DateTime(2022, 5, 23), fifthProduct);
            fifthProduct.Sales.Add(fifthSale);

        var groups = new List<Group> { firstGroup };
        var manufacturers = new List<Manufacturer> { firstManufacturer };
        var pharmacys = new List<Pharmacy> { firstPharmacy };
        var pharmaGroups = new List<PharmaGroup> { firstPharmaGroup };
        var products = new List<Product> { firstProduct };
        var productPharmacys = new List<ProductPharmacy> { firstProductPharmacy };
        var productPharmaGroups = new List<ProductPharmaGroup> { firstProductPharmaGroup };
        var sales = new List <Sale> { firstSale };

        _groups = groups;
        _manufacturers = manufacturers;
        _pharmacys = pharmacys;
        _pharmaGroups = pharmaGroups;
        _products = products;
        _productPharmacys = productPharmacys;
        _productPharmaGroups = productPharmaGroups;
        _sales = sales;

    }
    public List<Group> Groups => _groups;
    public List<Manufacturer> Manufacturers => _manufacturers;
    public List<Pharmacy> Pharmacys => _pharmacys;
    public List<PharmaGroup> PharmaGroups => _pharmaGroups;
    public List<Product> Products => _products;
    public List<ProductPharmacy> ProductPharmacys => _productPharmacys;
    public List<ProductPharmaGroup> ProductPharmaGroups => _productPharmaGroups;
    public List <Sale> Sale => _sales;
}
