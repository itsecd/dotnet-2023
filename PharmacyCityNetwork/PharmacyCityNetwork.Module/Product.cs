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
        public Group Group { get; set; } = new();
        /// <summary>
        /// Product Manufacturer
        /// </summary>
        public Manufacturer Manufacturer { get; set; } = new();
        /// <summary>
        /// Pharma Group
        /// </summary>
        public List<PharmaGroup> PharmaGroups { get; set; } = new();   
        public Product() { }
        public Product(string ProductName)
        {
            this.ProductName = ProductName;
        }
    }