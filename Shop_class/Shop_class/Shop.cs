
namespace Shop_class;
public class Shop
{
   
    public int Id { get; set; }
    public List<Product> Products { get; set; } = new List<Product>();

    public Shop(int id, List<Product> products)
    {
        Id = id;
        Products = products;
    }

}
