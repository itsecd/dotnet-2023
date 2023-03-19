

namespace Shop_class;
public class Purchase_record
{
    public Purchase_record(Customer customer, List<Product> products, 
        Shop shop, double sum, DateTime dateSale)
    {
        Customer = customer;
        Products = products;
        Shop = shop;
        Sum = sum;
        DateSale = dateSale;
    }

    public Customer Customer { get; set; }
    public List<Product> Products { get; set; }
    public Shop Shop { get; set; }
    public double Sum { get; set; }
    public DateTime DateSale { get; set; }
}
