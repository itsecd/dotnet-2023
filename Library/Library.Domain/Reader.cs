namespace Library.Domain;
public class Reader
{
    public int Id { set; get; }

    public string FullName { set; get; } = string.Empty;

    public string Address { set; get; } = string.Empty;

    public string Phone { set; get; } = string.Empty;

    public DateTime RegistrationDate { set; get; }
}
