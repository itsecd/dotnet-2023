namespace StoreApp.Domain;

/// <summary>
/// Product - Class describing the product
/// </summary>
public class Product
{
    /// <summary>
    /// Product ID, corresponds to its barcode
    /// </summary>
    public int ProductId { get; set; }

    /// <summary>
    /// Product Group
    /// </summary>
    public int ProductGroup { get; set; }

    /// <summary>
    /// Product name
    /// </summary>
    public string ProductName { get; set; } = string.Empty;

    /// <summary>
    /// Product weight
    /// </summary>
    public double ProductWeight { get; set; } = 0.0;

    /// <summary>
    /// Product type (piece, weighted) piece -> true | weighted -> false
    /// </summary>
    public bool ProductType { get; set; } = false;

    /// <summary>
    /// Product price
    /// </summary>
    public double ProductPrice { get; set; } = -1.0;

    /// <summary>
    /// Product deadline date storage
    /// </summary>
    public DateTime DateStorage { get; set; } = new DateTime(1970, 1, 1);


    public Product(int productId, int productGroup, string productName, double productWeight, bool productType, double productPrice, string dateStorage)
    {
        ProductId = productId;
        ProductGroup = productGroup;
        ProductName = productName;
        ProductWeight = productWeight;
        ProductType = productType;
        ProductPrice = productPrice;
        DateStorage = DateTime.Parse(dateStorage);
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Product param)
            return false;

        return ProductId == param.ProductId &&
               ProductGroup == param.ProductGroup &&
               ProductName == param.ProductName &&
               ProductWeight == param.ProductWeight &&
               ProductType == param.ProductType &&
               ProductPrice == param.ProductPrice &&
               DateStorage == param.DateStorage;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(ProductId, ProductGroup, ProductName, ProductWeight, ProductType, ProductPrice, DateStorage);
    }
}

