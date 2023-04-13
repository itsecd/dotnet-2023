namespace PharmacyCityNetwork;

    /// <summary>
    /// Сlass describing an Product Pharmacy
    /// </summary>
    public class ProductPharmacy
    {
        /// <summary>
        /// Product Count
        /// </summary>
        public int ProductCount { get; set; } = 0;
        /// <summary>
        /// Product Cost
        /// </summary>
        public int ProductCost { get; set; } = 0;
        /// <summary>
        /// Product
        /// </summary>
        public Product Product { get; set; } 
        /// <summary>
        /// Pharmacy
        /// </summary>
        public Pharmacy Pharmacy { get; set; }
        public ProductPharmacy() { }
        public ProductPharmacy(int productCount, int productCost, Product product, Pharmacy pharmacy)
        {
            ProductCount = productCount;
            ProductCost = productCost;
            Product = product;
            Pharmacy = pharmacy;
    }
    }
