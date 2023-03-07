namespace Non_residentialFundDomain;
public class Buyer
{
    public int BuyerId { get; set; } = 0;
    public string LastName { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string MiddleName { get; set; } = string.Empty;
    public string PassportSeries { get; set; } = string.Empty;
    public string PassportNumber { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public Buyer(int buyerId, string lastName, string firstName, string middleName, string passportSeries, string passportNumber, string address)
    {
        BuyerId = buyerId;
        LastName = lastName;
        FirstName = firstName;
        MiddleName = middleName;
        PassportSeries = passportSeries;
        PassportNumber = passportNumber;
        Address = address;
    }
}
