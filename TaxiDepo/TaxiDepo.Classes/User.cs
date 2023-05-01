namespace TaxiDepo.Domain;

/// <summary>
/// User class
/// </summary>
public class User
{
    /// <summary>
    /// User id
    /// </summary>
    public int Id { get; set; } = 0;
    /// <summary>
    /// User surname
    /// </summary>
    public string UserSurname { get; set; } = string.Empty;
    /// <summary>
    /// User name
    /// </summary>
    public string UserName { get; set; } = string.Empty;
    /// <summary>
    /// User patronymic
    /// </summary>
    public string UserPatronymic { get; set; } = string.Empty;
    /// <summary>
    /// User phone number
    /// </summary>
    public string UserPhoneNumber { get; set; } = string.Empty;
    /// <summary>
    /// Amount user rides
    /// </summary>
    public int AmountRides { get; set; }
    /// <summary>
    /// User ride collection
    /// </summary>
    public Ride? UserRide { get; set; }
    /// <summary>
    /// Constructor without parameters to instantiate the class User
    /// </summary>
    public User() {}
    /// <summary>
    /// Constructor with parameters to instantiate the class User
    /// </summary>
    /// <param name="id">User id</param>
    /// <param name="surname">User surname</param>
    /// <param name="name">User name</param>
    /// <param name="patronymic">User patronymic</param>
    /// <param name="phoneNumber">User phone number</param>
    public User(int id, string surname, string name, string patronymic, string phoneNumber)
    {
        Id = id;
        UserSurname = surname;
        UserName = name;
        UserPatronymic = patronymic;
        UserPhoneNumber = phoneNumber;
    }
    /// <summary>
    /// Overload Equals
    /// </summary>
    /// <param name="userObj">User class object</param>
    /// <returns>True - equal or false - not equal</returns>
    public override bool Equals(object? userObj)
    {
        if (userObj is not User param || GetType() != userObj.GetType())
            return false;
        
        return UserSurname == param.UserSurname &&
               UserName == param.UserName &&
               UserPatronymic == param.UserPatronymic &&
               UserPhoneNumber == param.UserPhoneNumber;
    }
    /// <summary>
    /// Overload == through Equals
    /// </summary>
    /// <param name="userObj1">User class object</param>
    /// <param name="userObj2">User class object</param>
    /// <returns>True - equal or false - not equal</returns>
    public static bool operator ==(User userObj1, User userObj2)        
    {            
        return Object.Equals(userObj1, userObj2);        
    }
    /// <summary>
    /// Overload != through Equals
    /// </summary>
    /// <param name="userObj1">User class object</param>
    /// <param name="userObj2">User class object</param>
    /// <returns>True - not equal or false - equal</returns>
    public static bool operator !=(User userObj1, User userObj2)        
    {            
        return !Object.Equals(userObj1, userObj2);        
    }
    /// <summary>
    /// Print function
    /// </summary>
    /// <param name="obj">User class object</param>
    public void PrintCarData(User obj)
    {
        Console.WriteLine(
            $"User: {obj.UserSurname} {obj.UserName} {obj.UserPatronymic}, phone number - {obj.UserPhoneNumber}");
    }
    /// <summary>
    /// Get hash code func
    /// </summary>
    /// <returns>Integer hash code</returns>
    public override int GetHashCode()
    {
        return UserSurname.GetHashCode();
    }
}