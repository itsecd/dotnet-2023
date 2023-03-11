namespace Realtors;
public class Client
{
    public Guid ID{get; set;}=Guid.Empty;
    public string Passport{get;set;} = string.Empty;
    public string Number{get;set;}=string.Empty;
    public string Registration{get;set;}=string.Empty;
    public string FirstName{get;set;}=string.Empty;
    public string SecondName{get;set;}=string.Empty;
    public string Surname{get;set;}=string.Empty;
    public Client(){}
    public Client(Guid id, string passport, string number, string registration, string firstname, string secondname, string surname)
    {
        ID=id;
        Passport=passport;
        Registration=registration;
        FirstName=firstname;
        SecondName=secondname;
        Surname=surname;
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Passport, Number, Registration, FirstName, SecondName, Surname);
    }
}