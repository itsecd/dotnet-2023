namespace PharmacyCityNetwork.Tests
{
    public class PharmacyCityNetworkFixture
    {
        public List<Sale> FixtureClient
        {
            get
            {
                var firstPharmacy = new Pharmacy("Vita", "8899606", "Pushkina, 7", "Yablokov");
                var secondPharmacy = new Pharmacy("Plus", "8844606", "Turgeneva, 8", "Pomelov");
                var thridPharmacy = new Pharmacy("Alia", "4499606", "Tolstogo, 8", "Slivin");

                var firstPharmacyGroup = new PharmaGroup("Adrenolytic");
                var secondPharmacyGroup = new PharmaGroup("Hematotropic");
                var thridPharmacyGroup = new PharmaGroup("Homeopathic");
                var fourthPharmacyGroup = new PharmaGroup("Interviewers");

                var firstGroup = new Group("Syrup");
                var secondGroup = new Group("Pill");
                var thridGroup = new Group("Injection");

                var firstManufacturer = new Manufacturer("Novartis");
                var secondManufacturer = new Manufacturer("Merck");

                var firstProduct = new Product("Paracetamol");
                firstProduct.Group = firstGroup;
                firstProduct.Manufacturer = firstManufacturer;
                firstProduct.PharmaGroups.Add(firstPharmacyGroup);
                firstProduct.PharmaGroups.Add(secondPharmacyGroup);

                var secondProduct = new Product("Espumizan");
                secondProduct.Group = secondGroup;
                secondProduct.Manufacturer = firstManufacturer;
                secondProduct.PharmaGroups.Add(thridPharmacyGroup);
                secondProduct.PharmaGroups.Add(secondPharmacyGroup);

                var thridProduct = new Product("Noshpa");
                thridProduct.Group = secondGroup;
                thridProduct.Manufacturer = secondManufacturer;
                thridProduct.PharmaGroups.Add(thridPharmacyGroup);
                thridProduct.PharmaGroups.Add(fourthPharmacyGroup);

                var fourthProduct = new Product("Sputnik");
                fourthProduct.Group = secondGroup;
                fourthProduct.Manufacturer = secondManufacturer;
                fourthProduct.PharmaGroups.Add(fourthPharmacyGroup);
                fourthProduct.PharmaGroups.Add(firstPharmacyGroup);

                var firstSale = new Sale("Online", new DateTime(2023, 8, 28));
                firstSale.Pharmacy = firstPharmacy;
                firstSale.Product = firstProduct;

                var secondSale = new Sale("Online", new DateTime(2023, 10, 17));
                secondSale.Product = secondProduct;
                secondSale.Pharmacy = secondPharmacy;

                var thirdSale = new Sale("Cash", new DateTime(2023, 8, 28));
                thirdSale.Product = thridProduct;
                thirdSale.Pharmacy = secondPharmacy;

                var fourthSale = new Sale("Card", new DateTime(2023, 10, 2));
                fourthSale.Product = fourthProduct;
                fourthSale.Pharmacy = thridPharmacy;

                var fifthSale = new Sale("Card", new DateTime(2023, 6, 6));
                fifthSale.Product = firstProduct;
                fifthSale.Pharmacy = thridPharmacy;

                var sales = new List<Sale>
                {
                    firstSale,
                    secondSale,
                    thirdSale,
                    fourthSale,
                    fifthSale
                };
                return sales;
            }
        }
    }
}
