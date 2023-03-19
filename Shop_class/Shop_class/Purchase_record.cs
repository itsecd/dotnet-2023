

namespace Shop_class;
public class Purchase_record
{
    public Purchase_record(Customer customer, Product product, double quantity)
    {
        Customer = customer;
        Product = product;
        Quantity = quantity;
    }

    public Customer Customer { get; set; }
    public Product Product { get; set; }
    public double Quantity { get; set; }
    public DateTime Date { get; set; }
}
