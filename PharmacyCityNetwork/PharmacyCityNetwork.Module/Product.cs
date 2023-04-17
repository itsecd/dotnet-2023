namespace PharmacyCityNetwork;
   
    /// <summary>
     /// Сlass describing an Product
     /// </summary>
    public class Product
    {
        /// <summary>
        /// Unique Id of Product
        /// </summary>
        public int ProductId { get; set; } = 0;
        /// <summary>
        /// Product Name
        /// </summary>
        public string ProductName { get; set; } = string.Empty;
        /// <summary>
        /// Product Group
        /// </summary>
        public Group Group { get; set; }
        /// <summary>
        /// Product Manufacturer
        /// </summary>
        public Manufacturer Manufacturer { get; set; }
        /// <summary>
        /// Pharma Group
        /// </summary>
        public List<ProductPharmacy> ProductPharmacy { get; set; } = new List<ProductPharmacy>();
        public List<ProductPharmaGroup> ProductPharmaGroup { get; set; } = new List<ProductPharmaGroup>();
        public List<Sale> Sales { get; set; } = new List<Sale>();
        public Product() { }
        public Product(string productName, int productId, Group group, Manufacturer manufacturer)
        {
            ProductName = productName;
            ProductId = productId;
            Group = group;
            Manufacturer = manufacturer;
        }
    }