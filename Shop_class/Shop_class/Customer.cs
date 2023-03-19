namespace Shop_class;
public class Customer
{
    public Customer(int id, string first_name, string last_name, string middle_name, string card_count)
    {
        Id = id;
        First_name = first_name;
        Last_name = last_name;
        Middle_name = middle_name;
        Card_count = card_count;
    }

    public int Id { get; set; }
    public string First_name { get; set; }
    public string Last_name { get; set;}
    public string Middle_name { get; set; }
    public string Card_count { get; set; }

}
