namespace PharmacyCityNetwork;

    /// <summary>
    /// Сlass describing an pharma group
    /// </summary>
    public class ProductPharmaGroup
    {
    /// <summary>
    /// Unique Id of Product Pharma Group
    /// </summary>
    public int ProductPharmaGroupId { get; set; } = 0;
    public PharmaGroup PharmaGroup { get; set; } 
    /// <summary>
    /// List Products
    /// </summary>
    public Product Product { get; set; }

    public ProductPharmaGroup() { }
        public ProductPharmaGroup(int productPharmaGroupId, PharmaGroup pharmaGroup, Product product)
        {
            ProductPharmaGroupId = productPharmaGroupId;
            PharmaGroup = pharmaGroup;
            Product = product;
        }
    }
