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
    
    public List<Application> Applications{get;set;}=new();

    public Client(){}
    public Client(Guid id, Application application, string passport, string number, string registration, string firstname, string secondname, string surname)
    {
        ID=id;
        Passport=passport;
        Registration=registration;
        FirstName=firstname;
        SecondName=secondname;
        Surname=surname;
        Applications=application;
    }
     public override bool Equals(object? obj)
    {
        if (obj is not Client param)
            return false;

        return Applications.Equals(param.Applications) && Id == param.Id &&
               Passport == param.Passport &&
               Number == param.Number &&
               Registration == param.Registration &&
               FirstName == param.FirstName &&
               SecondName == param.SecondName &&
               Surname == param.Surname;             
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(Id,Applications, Passport, Number, Registration, FirstName, SecondName, Surname);
    }
}