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
        
            var firstGroup = new Group("Syrup", 1); //
            var secondGroup = new Group("Pill", 2);
            var thridGroup = new Group("Injection", 3);

            var firstManufacturer = new Manufacturer("Novartis", 1);//
            var secondManufacturer = new Manufacturer("Merck", 2);

            var firstPharmaGroup = new PharmaGroup("Adrenolytic", 1);
            var secondPharmaGroup = new PharmaGroup("Hematotropic", 2);
            var thridPharmaGroup = new PharmaGroup("Homeopathic", 3);
            var fourthPharmaGroup = new PharmaGroup("Interviewers", 4);


            var firstPharmacy = new Pharmacy("Vita", "8899606", "Pushkina, 7", "Yablokov");
            var secondPharmacy = new Pharmacy("Plus", "8844606", "Turgeneva, 8", "Pomelov");
            var thridPharmacy = new Pharmacy("Alia", "4499606", "Tolstogo, 8", "Slivin");
        ///1 продукт 
            var firstProduct = new Product("Paracetamol", 1, firstGroup, firstManufacturer);
            var firstProductPharmacy = new ProductPharmacy(1, 300, firstProduct, firstPharmacy);
            firstProduct.ProductPharmacy.Add(firstProductPharmacy);
            firstPharmacy.ProductPharmacy.Add(firstProductPharmacy);

            var firstProductPharmaGroup = new ProductPharmaGroup(1, firstPharmaGroup, firstProduct);//
            firstProduct.ProductPharmaGroup.Add(firstProductPharmaGroup);
            firstPharmaGroup.ProductPharmaGroup.Add(firstProductPharmaGroup);

           
            firstGroup.Product.Add(firstProduct);//

            firstManufacturer.Product.Add(firstProduct);//


            var firstSale = new Sale("Online", new DateTime(2023, 8, 28), firstProduct);//
            firstProduct.Sales.Add(firstSale);//
        ///2 продукт
        var secondProduct = new Product("Aka", 2, secondGroup, secondManufacturer);
        var secondProductPharmacy = new ProductPharmacy(2, 300, secondProduct, firstPharmacy);
        secondProduct.ProductPharmacy.Add(secondProductPharmacy);
        firstPharmacy.ProductPharmacy.Add(secondProductPharmacy);

        var secondProductPharmaGroup = new ProductPharmaGroup(1, secondPharmaGroup, secondProduct);//
        firstProduct.ProductPharmaGroup.Add(secondProductPharmaGroup);
        firstPharmaGroup.ProductPharmaGroup.Add(secondProductPharmaGroup);


        secondGroup.Product.Add(secondProduct);//

        secondManufacturer.Product.Add(secondProduct);//


        var secondSale = new Sale("Online", new DateTime(2023, 8, 28), secondProduct);//
        secondProduct.Sales.Add(secondSale);//
        /////3 продукт
        var thridProduct = new Product("ere", 3, thridGroup, secondManufacturer);
        var thridProductPharmacy = new ProductPharmacy(2, 300, thridProduct, thridPharmacy);
        thridProduct.ProductPharmacy.Add(thridProductPharmacy);
        thridPharmacy.ProductPharmacy.Add(thridProductPharmacy);

        var thridProductPharmaGroup = new ProductPharmaGroup(1, thridPharmaGroup, thridProduct);//
        thridProduct.ProductPharmaGroup.Add(thridProductPharmaGroup);
        thridPharmaGroup.ProductPharmaGroup.Add(thridProductPharmaGroup);


        thridGroup.Product.Add(thridProduct);//

        secondManufacturer.Product.Add(thridProduct);//


        var thridSale = new Sale("Online", new DateTime(2023, 8, 28), thridProduct);//
        thridProduct.Sales.Add(thridSale);//

















        //var secondProduct = new Product("Espumizan");
        //secondProduct.Group = secondGroup;
        //secondProduct.Manufacturer = firstManufacturer;
        //secondProduct.PharmaGroups.Add(thridPharmacyGroup);
        //secondProduct.PharmaGroups.Add(secondPharmacyGroup);

        //var thridProduct = new Product("Noshpa");
        //thridProduct.Group = thridGroup;
        //thridProduct.Manufacturer = secondManufacturer;
        //thridProduct.PharmaGroups.Add(thridPharmacyGroup);
        //thridProduct.PharmaGroups.Add(fourthPharmacyGroup);

        //var fourthProduct = new Product("Sputnik");
        //fourthProduct.Group = secondGroup;
        //fourthProduct.Manufacturer = secondManufacturer;
        //fourthProduct.PharmaGroups.Add(fourthPharmacyGroup);
        //fourthProduct.PharmaGroups.Add(firstPharmacyGroup);




        //var secondSale = new Sale("Online", new DateTime(2023, 10, 17));
        //secondSale.Product = secondProduct;
        ////secondSale.Pharmacy = secondPharmacy;

        //var thirdSale = new Sale("Cash", new DateTime(2023, 8, 28));
        //thirdSale.Product = thridProduct;
        ////thirdSale.Pharmacy = secondPharmacy;

        //var fourthSale = new Sale("Card", new DateTime(2023, 10, 2));
        //fourthSale.Product = fourthProduct;
        ////fourthSale.Pharmacy = thridPharmacy;

        //var fifthSale = new Sale("Card", new DateTime(2023, 6, 6));
        //fifthSale.Product = firstProduct;
        ////fifthSale.Pharmacy = thridPharmacy;

        //var sales = new List<Sale>
        //{
        //    firstSale
        //    //secondSale,
        //    //thirdSale,
        //    //fourthSale,
        //    //fifthSale
        //};
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
