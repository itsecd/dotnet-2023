namespace PharmacyCityNetwork.Server.Repository;

public class PharmacyCityNetworkRepository : IPharmacyCityNetworkRepository
{
    private readonly List<Group> _groups;
    private readonly List<Manufacturer> _manufacturers;
    private readonly List<Pharmacy> _pharmacys;
    private readonly List<PharmaGroup> _pharmaGroups;
    private readonly List<Product> _products;
    private readonly List<ProductPharmacy> _productPharmacys;
    private readonly List<ProductPharmaGroup> _productPharmaGroups;
    private readonly List<Sale> _sales;
    public PharmacyCityNetworkRepository()
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


        var firstPharmacy = new Pharmacy(1, "Vita", "8899606", "Pushkina, 7", "Yablokov");
        var secondPharmacy = new Pharmacy(2, "Plus", "8844606", "Turgeneva, 8", "Pomelov");
        var thridPharmacy = new Pharmacy(3, "Alia", "4499606", "Tolstogo, 8", "Slivin");
        var fourthPharmacy = new Pharmacy(4, "Apteka63", "4558602", "Polevay, 23", "Chikarev");
        var fifthPharmacy = new Pharmacy(5, "Tabls", "9229303", "Gagarina, 67", "Parshin");

        var firstProduct = new Product("Paracetamol", 1, firstGroup, firstManufacturer, 1, 1);
        var firstProductPharmacy = new ProductPharmacy(1, 300, firstProduct, firstPharmacy, 1, 1, 1);
        firstProduct.ProductPharmacys.Add(firstProductPharmacy);
        firstPharmacy.ProductPharmacys.Add(firstProductPharmacy);

        var firstProductPharmaGroup = new ProductPharmaGroup(1, firstPharmaGroup, firstProduct, 1, 1);
        firstProduct.ProductPharmaGroups.Add(firstProductPharmaGroup);
        firstPharmaGroup.ProductPharmaGroups.Add(firstProductPharmaGroup);

        firstGroup.Products.Add(firstProduct);

        firstManufacturer.Products.Add(firstProduct);

        var firstSale = new Sale("Online", new DateTime(2023, 1, 28), firstProduct, 1, 1);
        firstProduct.Sales.Add(firstSale);

        var secondProduct = new Product("Espumizan", 2, secondGroup, secondManufacturer, 2, 2);
        var secondProductPharmacy = new ProductPharmacy(2, 250, secondProduct, firstPharmacy, 2, 1, 2);
        secondProduct.ProductPharmacys.Add(secondProductPharmacy);
        firstPharmacy.ProductPharmacys.Add(secondProductPharmacy);

        var secondProductPharmaGroup = new ProductPharmaGroup(2, secondPharmaGroup, secondProduct, 2, 2);
        secondProduct.ProductPharmaGroups.Add(secondProductPharmaGroup);
        secondPharmaGroup.ProductPharmaGroups.Add(secondProductPharmaGroup);

        secondGroup.Products.Add(secondProduct);

        secondManufacturer.Products.Add(secondProduct);

        var secondSale = new Sale("Cash", new DateTime(2023, 4, 14), secondProduct, 2, 2);
        secondProduct.Sales.Add(secondSale);

        var thridProduct = new Product("Noshpa", 3, thridGroup, secondManufacturer, 3, 2);
        var thridProductPharmacy = new ProductPharmacy(3, 200, thridProduct, thridPharmacy, 3, 3, 3);
        thridProduct.ProductPharmacys.Add(thridProductPharmacy);
        thridPharmacy.ProductPharmacys.Add(thridProductPharmacy);

        var sixthProductPharmacy = new ProductPharmacy(4, 180, thridProduct, secondPharmacy, 3, 2, 3);
        thridProduct.ProductPharmacys.Add(sixthProductPharmacy);
        secondPharmacy.ProductPharmacys.Add(sixthProductPharmacy);

        var thridProductPharmaGroup = new ProductPharmaGroup(3, thridPharmaGroup, thridProduct, 3, 3);
        thridProduct.ProductPharmaGroups.Add(thridProductPharmaGroup);
        thridPharmaGroup.ProductPharmaGroups.Add(thridProductPharmaGroup);

        thridGroup.Products.Add(thridProduct);

        secondManufacturer.Products.Add(thridProduct);

        var thridSale = new Sale("Online", new DateTime(2023, 3, 20), thridProduct, 3, 3);
        thridProduct.Sales.Add(thridSale);

        var sixthSale = new Sale("Online", new DateTime(2023, 3, 20), thridProduct, 3, 6);
        thridProduct.Sales.Add(sixthSale);

        var fourthProduct = new Product("Analgin", 4, thridGroup, firstManufacturer, 3, 1);
        var fourthProductPharmacy = new ProductPharmacy(4, 135, fourthProduct, secondPharmacy, 4, 2, 4);
        fourthProduct.ProductPharmacys.Add(fourthProductPharmacy);
        fourthProduct.ProductPharmacys.Add(fourthProductPharmacy);

        var fourthProductPharmaGroup = new ProductPharmaGroup(4, fourthPharmaGroup, fourthProduct, 4, 4);
        fourthProduct.ProductPharmaGroups.Add(fourthProductPharmaGroup);
        fourthPharmaGroup.ProductPharmaGroups.Add(fourthProductPharmaGroup);

        thridGroup.Products.Add(fourthProduct);

        firstManufacturer.Products.Add(fourthProduct);

        var fourthSale = new Sale("Online", new DateTime(2022, 11, 18), fourthProduct, 4, 4);
        fourthProduct.Sales.Add(fourthSale);

        var fifthProduct = new Product("Nekst", 5, firstGroup, firstManufacturer, 1, 1);
        var fifthProductPharmacy = new ProductPharmacy(10, 350, fifthProduct, fifthPharmacy, 5, 5, 5);
        fifthProduct.ProductPharmacys.Add(fifthProductPharmacy);
        fifthPharmacy.ProductPharmacys.Add(fifthProductPharmacy);

        var fifthProductPharmaGroup = new ProductPharmaGroup(5, firstPharmaGroup, fifthProduct, 1, 5);
        fifthProduct.ProductPharmaGroups.Add(fifthProductPharmaGroup);
        firstPharmaGroup.ProductPharmaGroups.Add(fifthProductPharmaGroup);

        firstGroup.Products.Add(fifthProduct);

        firstManufacturer.Products.Add(fifthProduct);

        var fifthSale = new Sale("Online", new DateTime(2022, 5, 23), fifthProduct, 5, 5);
        fifthProduct.Sales.Add(fifthSale);

        var groups = new List<Group> { firstGroup, secondGroup, thridGroup };
        var manufacturers = new List<Manufacturer> { firstManufacturer, secondManufacturer };
        var pharmacys = new List<Pharmacy> { firstPharmacy, secondPharmacy, thridPharmacy, fourthPharmacy, fifthPharmacy };
        var pharmaGroups = new List<PharmaGroup> { firstPharmaGroup, secondPharmaGroup, thridPharmaGroup, fourthPharmaGroup };
        var products = new List<Product> { firstProduct, secondProduct, thridProduct, fourthProduct, fifthProduct };
        var productPharmacys = new List<ProductPharmacy> { firstProductPharmacy, secondProductPharmacy, thridProductPharmacy, fourthProductPharmacy, fifthProductPharmacy, sixthProductPharmacy };
        var productPharmaGroups = new List<ProductPharmaGroup> { firstProductPharmaGroup, secondProductPharmaGroup, thridProductPharmaGroup, fourthProductPharmaGroup, fifthProductPharmaGroup };
        var sales = new List<Sale> { firstSale, secondSale, thridSale, fourthSale, fifthSale, sixthSale };

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
    public List<Sale> Sale => _sales;
}
