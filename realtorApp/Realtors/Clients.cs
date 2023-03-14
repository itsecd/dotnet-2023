namespace Realtors;
/// <summary>
/// ClientType sellers and buyers of the real estate agency
/// </summary>
public class Client
{
    /// <summary>
    /// Id - guid typed value for storing Id of the client
    /// </summary>
    public Guid Id{get; set;}=Guid.Empty;
    /// <summary>
    /// Passport - a string representing passport number
    /// </summary>
    public string Passport{get;set;} = string.Empty;
    /// <summary>
    /// Number - a string for contact number
    /// </summary> 
    public string Number{get;set;}=string.Empty;
    /// <summary>
    /// Registration- a string for customer registration address
    /// </summary> 
    public string Registration{get;set;}=string.Empty;
    /// <summary>
    /// FirstName, SecondName - a string for name and second_name optionally
    /// </summary> 
    public string FirstName{get;set;}=string.Empty;
    public string SecondName{get;set;}=string.Empty;
    public List<Application> Applications{get;set;}=new();
    public Client(){}
    public Client(Guid id, string passport, string number, string registration, string firstname, string secondname, string surname, Application application)
    {
        Id=id;
        Passport=passport;
        Number=number;
        Registration=registration;
        FirstName=firstname;
        SecondName=secondname;
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
               SecondName == param.SecondName;            
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Passport, Number, Registration, FirstName, SecondName, Applications);
    }
}